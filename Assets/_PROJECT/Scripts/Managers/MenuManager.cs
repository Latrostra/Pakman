using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    public LevelSetupSO levelSetupSO;
    [SerializeField]
    GameObject header;
    [SerializeField]
    GameObject play;
    [SerializeField]
    GameObject restart;

    private void Start() {
        switch (levelSetupSO.MenuType)
        {
        case MenuType.Win:
            header.GetComponent<TextMeshProUGUI>().text = "WYGRANKO";
            play.SetActive(true);
            restart.SetActive(false);
            break;

        case MenuType.Lose:
            header.GetComponent<TextMeshProUGUI>().text = ":(";
            play.SetActive(false);
            restart.SetActive(true);
            break;
        case MenuType.End:
            header.GetComponent<TextMeshProUGUI>().text = "KONIEC :)";
            play.SetActive(false);
            restart.SetActive(true);
            break;
        case MenuType.Start:
            header.GetComponent<TextMeshProUGUI>().text = "ZACZYNAMY????";
            play.SetActive(true);
            restart.SetActive(false);
            break;
        }
    }
}
