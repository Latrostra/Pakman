using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField]
    public IDataUi dataUi;

    public void Start()
    {
        dataUi.OnChangeValue += OnChangeValueHandler;
    }

    public virtual void OnChangeValueHandler()
    {
        
    }

    private void OnDestroy() {
        dataUi.OnChangeValue -= OnChangeValueHandler;
    }
}
