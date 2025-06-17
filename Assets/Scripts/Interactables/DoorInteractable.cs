using UnityEngine;

public class DoorInteractable : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    public void OpenDoor()
    {
        print("opening door");
        animator.SetBool("isOpen", true);
    }

    public void CloseDoor()
    {
        print("closing door");
        animator.SetBool("isOpen", false);
    }
}
