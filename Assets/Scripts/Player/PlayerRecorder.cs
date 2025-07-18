using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRecorder : MonoBehaviour
{
    [SerializeField]
    private float recordingInterval = 0.1f;
    [SerializeField]
    private float maxRecordingDuration = 15f;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip startRecording;
    [SerializeField]
    private AudioClip stopRecording;
    [SerializeField]
    private ParticleSystem recordingParticleSystem;

    private bool isRecording = false;
    private List<PlayerRecordData> playerRecordDatas = new List<PlayerRecordData>();
    private Coroutine currentRecordingCoroutine;

    void Start()
    {
        recordingParticleSystem.Stop();
        recordingParticleSystem.Clear();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.R)) {
            HandleRecording();
        }
    }

    private void HandleRecording() {
        if (!isRecording) {
            StartRecording();
        } else {
            StopRecording();
        }
    }

    public List<PlayerRecordData> GetPlayerRecordedData () {
        return playerRecordDatas;
    }

    public void StartRecording() {
        if (isRecording) {
            return;
        }

        recordingParticleSystem.Play();
        audioSource.PlayOneShot(startRecording);

        isRecording = true;
        playerRecordDatas.Clear();
        currentRecordingCoroutine = StartCoroutine(RecordPlayer());
    }

    public void StopRecording() {
        if (!isRecording) {
            return;
        }

        recordingParticleSystem.Stop();
        recordingParticleSystem.Clear();
        audioSource.PlayOneShot(stopRecording);

        isRecording = false;
        if (currentRecordingCoroutine != null) {
            StopCoroutine(currentRecordingCoroutine);
        }
    }

    private IEnumerator RecordPlayer()
    {
        float timer = 0f;

        while (isRecording && timer < maxRecordingDuration)
        {
            RecordCurrentData(timer);
            timer += recordingInterval;
            yield return new WaitForSeconds(recordingInterval);
        }

        StopRecording();
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
