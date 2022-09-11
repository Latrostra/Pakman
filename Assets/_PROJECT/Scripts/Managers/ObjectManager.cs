using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class ObjectManager : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private GameObject planeGround;
    [SerializeField]
    private int objectCount;
    [SerializeField]
    private bool isSeed;
    private RandomPosition randomPosition;
    public List<GameObject> objects = new List<GameObject>();
    public LevelSetupSO levelSetupSO;
    
    private void Awake() {
        objectCount = isSeed ? levelSetupSO.LevelSettingSO.PelletsCount : levelSetupSO.LevelSettingSO.MonstersCount; 
        randomPosition = new RandomPosition(new List<Vector3>(planeGround.GetComponent<MeshFilter>().sharedMesh.vertices), planeGround);
        StartCoroutine("Spawn");
    }
    private IEnumerator Spawn()
    {
        while (objects.Count < objectCount) {
            var pos = randomPosition.CalculateRandomPoint();
            NavMesh.SamplePosition(pos, out var hit, Mathf.Infinity, 1);
            var vec = new Vector3(hit.position.x, hit.position.y + prefab.transform.position.y, hit.position.z);
            var obj = Instantiate(prefab, vec, Quaternion.identity);
            obj.transform.parent = this.transform;
            objects.Add(obj);
        }
        yield return null;
    }
}
