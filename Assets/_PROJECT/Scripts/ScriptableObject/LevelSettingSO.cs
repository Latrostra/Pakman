using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="SO/LevelSettings")]
public class LevelSettingSO : ScriptableObject
{
    public int MonstersCount;
    public int PelletsCount;
    public float MonstersSpeed;
}
