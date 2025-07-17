using UnityEngine;

public class PressureButtonAudioTrigger : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip audioToPlay;

    private bool _hasAlreadyPlayed = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !_hasAlreadyPlayed)
        {
            _hasAlreadyPlayed = true;
            audioSource.PlayOneShot(audioToPlay);
        }
    }
}
