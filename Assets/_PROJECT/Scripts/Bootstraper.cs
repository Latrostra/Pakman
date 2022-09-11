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
        #if UNITY_EDITOR
        EditorApplication.playModeStateChanged += OnPlayModeExit;
        #endif
        
        Cursor.visible = sceneSO.CursorVisible;
        Cursor.lockState = sceneSO.CursorLockState ? CursorLockMode.Locked : CursorLockMode.None;
    }

    public void WinScene(int id) {
        levelSetup.MenuType = MenuType.Win;
        levelSetup.ActualLevel += 1;
        if (levelSetup.ActualLevel < levelSettingSO.Count) {
            levelSetup.LevelSettingSO = levelSettingSO[levelSetup.ActualLevel];
        }
        else {
            levelSetup.MenuType = MenuType.End;
            levelSetup.LevelSettingSO = levelSettingSO[0];
        }
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
        #if UNITY_EDITOR
            EditorApplication.playModeStateChanged -= OnPlayModeExit;
        #endif
        
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
    #if UNITY_EDITOR
        public void OnPlayModeExit(PlayModeStateChange playModeStateChange) {
            if (PlayModeStateChange.ExitingEditMode == playModeStateChange) {
                levelSetup.MenuType = MenuType.Start;
                levelSetup.LevelSettingSO = levelSettingSO[0];
                levelSetup.ActualLevel = 0;
            }
        }
    #endif
    
    void OnApplicationQuit() {
        levelSetup.MenuType = MenuType.Start;
        levelSetup.LevelSettingSO = levelSettingSO[0];
        levelSetup.ActualLevel = 0;
    }
}
