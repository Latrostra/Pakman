using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiHealthManager : UiManager
{
    [SerializeField]
    private GameObject[] objects;
    [SerializeField]
    private IntSO currentHealth;
    public void Start() {
        base.dataUi = FindObjectOfType<Health>();
        base.Start();
    }

    public override void OnChangeValueHandler()
    {
        objects[currentHealth.Value].SetActive(false);
    }
}
