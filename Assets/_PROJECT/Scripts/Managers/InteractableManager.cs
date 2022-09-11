using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InteractableManager : MonoBehaviour, IDataUi
{
    public Action OnChangeValue { get; set;}
    private ObjectManager objectManager;
    public IntSO pellets;
    private void Awake() {
        objectManager = this.GetComponent<ObjectManager>();
        pellets.Value = objectManager.objects.Count;
    }

    public void Remove(GameObject obj) {
        objectManager.objects.Remove(obj);
        Destroy(obj);
        pellets.Value -= 1;
        OnChangeValue?.Invoke();
        if (pellets.Value <= 0) {
            Bootstraper.Instance.WinScene(0);
        }
    }
}
