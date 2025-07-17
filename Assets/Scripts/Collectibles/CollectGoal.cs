using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(AudioSource))]
public class CollectGoal : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        print("triggering goal");
        if (other.CompareTag("Player"))
        {
            print("is player");
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.Play();

            Destroy(gameObject, .3f);
        }
    }

}
