using UnityEngine;
using UnityEngine.UI;

public class GhostSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject ghostPrefab;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip spawnAudioClip;
    [SerializeField]
    private AudioClip despawnAudioClip;
    [SerializeField]
    private Image playGhostButtonBackgroundImage;
    [SerializeField]
    private Image playGhostButtonIconImage;

    private PlayerRecorder playerRecorder;

    private GameObject currentGhost;

    void Awake()
    {
        playerRecorder = GetComponent<PlayerRecorder>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) {
            SpawnGhost();
        }
    }

    private void SpawnGhost() {
        OnGhostReplayOver();
        // if (currentGhost != null) {
        //     Destroy(currentGhost);
        // }

        playGhostButtonBackgroundImage.color = new Color(playGhostButtonBackgroundImage.color.r, playGhostButtonBackgroundImage.color.g, playGhostButtonBackgroundImage.color.b, .6f);
        playGhostButtonIconImage.color = new Color(playGhostButtonIconImage.color.r, playGhostButtonIconImage.color.g, playGhostButtonIconImage.color.b, .6f);


        audioSource.PlayOneShot(spawnAudioClip);
        currentGhost = Instantiate(ghostPrefab);


        GhostReplay ghostReplay = currentGhost.GetComponent<GhostReplay>();
        ghostReplay.StartReplay(playerRecorder.GetPlayerRecordedData(), OnGhostReplayOver);
    }

    private void OnGhostReplayOver() {
        if (currentGhost != null)
        {
            Destroy(currentGhost, .4f);
            audioSource.PlayOneShot(despawnAudioClip);
            currentGhost = null;
            
            playGhostButtonBackgroundImage.color = new Color(playGhostButtonBackgroundImage.color.r, playGhostButtonBackgroundImage.color.g, playGhostButtonBackgroundImage.color.b, 1f);
            playGhostButtonIconImage.color = new Color(playGhostButtonIconImage.color.r, playGhostButtonIconImage.color.g, playGhostButtonIconImage.color.b, 1f);
        }
    }
}
