using UnityEngine;

public class GhostSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject ghostPrefab;

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
        if (currentGhost != null) {
            Destroy(currentGhost);
        }

        currentGhost = Instantiate(ghostPrefab);

        GhostReplay ghostReplay = currentGhost.GetComponent<GhostReplay>();
        ghostReplay.StartReplay(playerRecorder.GetPlayerRecordedData(), OnGhostReplayOver);
    }

    private void OnGhostReplayOver() {
        if (currentGhost != null) {
            Destroy(currentGhost);
            currentGhost = null;
        }
    }
}
