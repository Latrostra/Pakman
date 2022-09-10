using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bootstraper : MonoBehaviour
{
    public static Bootstraper Instance {get; private set;}

    private void Awake() {
        if (FindObjectsOfType<Bootstraper>().Length > 1) {
            Destroy(this.gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(this);
    }

    public void LoadScene(int id) {
        SceneManager.LoadScene(id);
    }
}
