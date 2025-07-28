using System;
using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    [SerializeField]
    private GameObject victoryImageUI;
    public static GameManager Instance;

    void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(this);
        } else {
            Instance = this;
        }
    }

    public void ReloadScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void RestartGame() {
        Time.timeScale = 1;
        ReloadScene();
    }

    public void PauseAndShowVictoryUI() {
        StartCoroutine(PauseAndRestart());
    }
    
    IEnumerator PauseAndRestart() {
        yield return new WaitForSeconds(0.2f);
        Time.timeScale = 0;
        SetActiveVictoryImageUI(true);
    }

    public void SetActiveVictoryImageUI(bool isActive)
    {
        victoryImageUI.SetActive(isActive);
    }

    public void QuitApplication() {
        # if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        # else
            Application.Quit();
        # endif
    }

}
