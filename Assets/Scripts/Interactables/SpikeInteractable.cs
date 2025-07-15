using UnityEngine;

public class SpikeInteractable : MonoBehaviour
{
    [SerializeField]
    private Animator spikeAnimator;
    
    public void DeactivateSpike()
    {
        print("Deactivate Spike");
        spikeAnimator.SetBool("isActive", false);
    }

    public void ActivateSpike()
    {
        print("Activate Spike");
        spikeAnimator.SetBool("isActive", true);
    }
}
