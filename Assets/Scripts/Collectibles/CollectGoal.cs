using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class CollectGoal : MonoBehaviour
{
    [SerializeField]
    private AudioClip audioClip;
    void OnTriggerEnter(Collider other)
    {
        print("triggering goal");
        if (other.CompareTag("Player"))
        {
            print("is player");
            Play2DAudio(audioClip);
            Destroy(gameObject, .2f);
            GameManager.Instance.PauseAndShowVictoryUI();
        }
    }

    private void Play2DAudio(AudioClip audioClipToPlay) {
        GameObject audio = new GameObject("Audio");
        AudioSource audioSource = audio.AddComponent<AudioSource>();
        audioSource.clip = audioClipToPlay;
        audioSource.spatialBlend = 0f;
        audioSource.volume = .6f;
        audioSource.Play();

        Destroy(audio, audioClipToPlay.length);
    }

}
