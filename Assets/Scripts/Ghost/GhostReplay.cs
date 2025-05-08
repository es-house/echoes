using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostReplay : MonoBehaviour
{
    [SerializeField]
    private float replaySpeed = 1f;

    private bool isReplaying = false;

    public void StartReplay(List<PlayerRecordData> data, Action onFinished) {
        StartCoroutine(ReplayData(data, onFinished));
    }

    private IEnumerator ReplayData(List<PlayerRecordData> data, Action onFinished) {
        isReplaying = true;

        for (int index = 0; index < data.Count - 1; index++) {
            PlayerRecordData currentData = data[index];
            PlayerRecordData nextData = data[index + 1];

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
        onFinished?.Invoke();
    }
}
