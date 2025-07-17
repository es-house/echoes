using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class DeathZone : MonoBehaviour
{
    [SerializeField]
    private AudioClip youLoseAudioClip;
    [SerializeField]
    private AudioSource audioSource;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("it's the player");
            StartCoroutine(ResetAndReload());
        }
    }

    IEnumerator ResetAndReload() {
        PlayYouLoseAudio();
        yield return new WaitForSeconds(youLoseAudioClip.length / 2);
        GameManager.Instance.ReloadScene();
    }

    private void PlayYouLoseAudio() {
        if (audioSource != null) {
            audioSource.PlayOneShot(youLoseAudioClip);
        }
    }
}
