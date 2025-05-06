using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRecorder : MonoBehaviour
{
    [SerializeField]
    private float recordingInterval = 0.1f;

    private bool isRecording = false;
    private List<PlayerRecordData> playerRecordDatas = new List<PlayerRecordData>();
    private Coroutine currentRecordingCoroutine;

    public List<PlayerRecordData> GetPlayerRecordedData () {
        return playerRecordDatas;
    }

    public void StartRecording() {
        if (isRecording) {
            return;
        }

        isRecording = true;
        playerRecordDatas.Clear();
        currentRecordingCoroutine = StartCoroutine(RecordPlayer());
    }

    public void StopRecording() {
        if (!isRecording) {
            return;
        }

        isRecording = false;
        if (currentRecordingCoroutine != null) {
            StopCoroutine(currentRecordingCoroutine);
        }
    }

    private IEnumerator RecordPlayer() {
        float timer = 0f;

        while (isRecording) {
            RecordCurrentData(timer);
            timer += recordingInterval;
            yield return new WaitForSeconds(recordingInterval);
        }
    }

    private void RecordCurrentData(float time) {
        PlayerRecordData playerRecordData = new PlayerRecordData() {
            timestamp = time,
            position = transform.position,
            rotation = transform.rotation
        };
        playerRecordDatas.Add(playerRecordData);
    }
}
