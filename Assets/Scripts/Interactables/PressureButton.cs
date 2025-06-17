using System.Collections.Generic;
using UnityEngine;

public class PressureButton : MonoBehaviour
{
    [SerializeField]
    private float pressDepth = 0.1f;
    [SerializeField]
    private float pressSpeed = 5f;

    private Vector3 _originalPosition;
    private Vector3 _pressedPosition;
    private bool _isPressed = false;

    // Used HashSet instead of List because it doesn't allows duplicates; adding, removing, checking functionality are faster
    private HashSet<Collider> objectsOnPlate = new HashSet<Collider>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _originalPosition = transform.position;
        _pressedPosition = _originalPosition - new Vector3(0f, pressDepth, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        ClearObjectsOnPlaneReferences();

        _isPressed = objectsOnPlate.Count > 0;
        Vector3 targetPosition = _isPressed ? _pressedPosition : _originalPosition;
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * pressSpeed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Ghost"))
        {
            objectsOnPlate.Add(other);
            Activate();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Ghost"))
        {
            objectsOnPlate.Remove(other);
            Deactivate();
        }
    }

    private void ClearObjectsOnPlaneReferences()
    {
        objectsOnPlate.RemoveWhere(obj => obj == null);
    }

    private void Activate()
    {
        print("activating");
    }

    private void Deactivate()
    {
        print("deactivating");
    }
}
