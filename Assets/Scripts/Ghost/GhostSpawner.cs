using UnityEngine;

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

        audioSource.PlayOneShot(spawnAudioClip);
        currentGhost = Instantiate(ghostPrefab);


        GhostReplay ghostReplay = currentGhost.GetComponent<GhostReplay>();
        ghostReplay.StartReplay(playerRecorder.GetPlayerRecordedData(), OnGhostReplayOver);
    }

    private void OnGhostReplayOver() {
        if (currentGhost != null) {
            Destroy(currentGhost, .7f);
            audioSource.PlayOneShot(despawnAudioClip);
            currentGhost = null;
        }
    }
}
