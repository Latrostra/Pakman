using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="SO/LevelSetup")]
public class LevelSetupSO : ScriptableObject
{
    public MenuType MenuType;
    public int ActualLevel;
    public LevelSettingSO LevelSettingSO;
}
