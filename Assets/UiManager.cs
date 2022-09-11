using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager
{
    [SerializeField]
    public IDataUi dataUi;
    [SerializeField]
    private GameObject[] healthImage;
    [SerializeField]
    private IntSO currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        dataUi.OnChangeValue += OnChangeValueHandler;
    }

    public virtual void OnChangeValueHandler()
    {
        
    }

    void OnDestroy() {
        dataUi.OnChangeValue -= OnChangeValueHandler;
    }
}
