using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiPelletsManager : UiManager
{
    [SerializeField]
    private TextMeshProUGUI text;
    [SerializeField]
    private IntSO currentPellets;
    public void Start() {
        base.dataUi = FindObjectOfType<InteractableManager>();
        base.Start();
        text.text = currentPellets.Value.ToString();
    }

    public override void OnChangeValueHandler()
    {
        text.text = currentPellets.Value.ToString();
    }
}
