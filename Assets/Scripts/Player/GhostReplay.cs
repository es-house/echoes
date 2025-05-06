using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostReplay : MonoBehaviour
{
    public Action OnReplayOver;
    [SerializeField]
    private float replaySpeed = 1f;

    private bool isReplaying = false;
    private List<PlayerRecordData> recordedDatas;

    public void StartReplay() {
        recordedDatas = FindFirstObjectByType<PlayerRecorder>().GetPlayerRecordedData();
        if (recordedDatas == null || recordedDatas.Count < 2) {
            print("not enough data to replay");
            return;
        }

        StartCoroutine(ReplayData());
    }

    private IEnumerator ReplayData() {
        isReplaying = true;

        for (int index = 0; index < recordedDatas.Count - 1; index++) {
            PlayerRecordData currentData = recordedDatas[index];
            PlayerRecordData nextData = recordedDatas[index + 1];

            float duration = (nextData.timestamp - currentData.timestamp) / replaySpeed;

            float time = 0f;

            while (time < 1f) {
                time += Time.deltaTime / duration;
                transform.position = Vector3.Lerp(currentData.position, nextData.position, time);
                transform.rotation = Quaternion.Slerp(currentData.rotation, nextData.rotation, time);
                yield return null;
            }
        }

        isReplaying = false;
        OnReplayOver?.Invoke();
    }
}
