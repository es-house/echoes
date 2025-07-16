using UnityEngine;

public class PlatformInteractable : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    public void GrowPlatform()
    {
        print("growing platform");
        animator.SetBool("isActive", true);
    }

    public void ShrinkPlatform()
    {
        print("shrinking platform");
        animator.SetBool("isActive", false);
    }
}
