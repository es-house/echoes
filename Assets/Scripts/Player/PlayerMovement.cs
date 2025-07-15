using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody), typeof(PlayerRecorder))]
public class PlayerMovement : MonoBehaviour
{

    # region PlayerMovement
    [SerializeField]
    private float playerSpeed = 8f;
    [SerializeField]
    private float jumpForce = 5f;
    [SerializeField]
    private float maxSpeed = 10f;
    # endregion

    // # region Ghost
    // [SerializeField]
    // private GameObject ghostPrefab;
    // private GameObject ghostInstance;
    // private GhostReplay ghostReplay;
    // # endregion


    private Rigidbody playerRigidbody;
    private Vector3 playerInput;

    private bool isRecording = false;

    private bool isGrounded = true;
    private float groundDistanceCheck = 1f;

    

    void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        playerInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));

        isGrounded = CheckGround();

        if (isGrounded && Input.GetKeyDown(KeyCode.Space)) {
            Jump();
        }
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer() {
        // if (!isGrounded) {
        //     return;
        // }
        Vector3 movement = playerInput * playerSpeed;

        playerRigidbody.AddForce(movement);
    }

    private void Jump() {
        Vector3 linearVelocity = playerRigidbody.linearVelocity;
        linearVelocity.y = 0f;

        playerRigidbody.linearVelocity = linearVelocity;

        playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); 
    }

    private bool CheckGround() {
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, groundDistanceCheck)) {
            if (hit.collider.CompareTag("Ground"))
            {
                return true;
            }
        }
        return false;
    }
}
