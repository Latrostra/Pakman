using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class Bootstraper : MonoBehaviour
{
    public static Bootstraper Instance {get; private set;}
    [SerializeField]
    private SceneSO sceneSO;
    [SerializeField]
    private LevelSetupSO levelSetup;
    [SerializeField]
    private List<LevelSettingSO> levelSettingSO;

    private void Awake() {
        Instance = this;
        EditorApplication.playModeStateChanged += OnPlayModeExit;
        Cursor.visible = sceneSO.CursorVisible;
        Cursor.lockState = sceneSO.CursorLockState ? CursorLockMode.Locked : CursorLockMode.None;
    }

    public void WinScene(int id) {
        levelSetup.MenuType = MenuType.Win;
        LoadScene(id);
    }

    public void LostScene(int id) {
        levelSetup.MenuType = MenuType.Lose;
        LoadScene(id);
    }

    public void LoadScene(int id) {
        var func = LoadSceneAsync(id);
        StartCoroutine(func);
    }

    private void OnDestroy() {
        EditorApplication.playModeStateChanged -= OnPlayModeExit;
    }

    public void ExitGame() {
        Application.Quit();
    }
    
    private IEnumerator LoadSceneAsync(int id) {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(id);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    public void OnPlayModeExit(PlayModeStateChange playModeStateChange) {
        if (PlayModeStateChange.ExitingEditMode == playModeStateChange) {
            levelSetup.MenuType = MenuType.Start;
        }
    }

    void OnApplicationQuit() {
        levelSetup.MenuType = MenuType.Start;
    }
}
