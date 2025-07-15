using UnityEngine;

public class SpikeInteractable : MonoBehaviour
{
    private int counter = 0;
    // [SerializeField]
    // private Animator spikeAnimator;

    public void SetSpikesActive(bool isActive)
    {
        counter = 0;
        foreach (Transform spikeRow in transform)
        {
            print("found some");
            foreach (Transform spikeParent in spikeRow)
            {
                foreach (Transform spike in spikeParent)
                {
                    counter++;
                    print("found spikes " + spike.name);
                    Animator spikeAnimator = spike.GetComponent<Animator>();
                    if (spikeAnimator != null)
                    {
                        print("found animator");
                        spikeAnimator.SetBool("isActive", isActive);
                    }
                }
            }
        }
        print("counter: " + counter);
    }
    
    // public void DeactivateSpike()
    // {
    //     print("Deactivate Spike");
    //     spikeAnimator.SetBool("isActive", false);
    // }

    // public void ActivateSpike()
    // {
    //     print("Activate Spike");
    //     spikeAnimator.SetBool("isActive", true);
    // }
}
