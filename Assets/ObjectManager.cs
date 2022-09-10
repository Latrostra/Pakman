using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ObjectManager : MonoBehaviour
{

    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private GameObject planeGround;
    [SerializeField]
    private int objectCount;
    private List<GameObject> objects = new List<GameObject>();
    private RandomPosition randomPosition;

    private void Start() {
        randomPosition = new RandomPosition(new List<Vector3>(planeGround.GetComponent<MeshFilter>().sharedMesh.vertices), planeGround);
    }
    public void Update() {
        if (objects.Count > objectCount) {
            return;
        }
        var pos = randomPosition.CalculateRandomPoint();
        NavMesh.SamplePosition(pos, out var hit, Mathf.Infinity, 1);
        var positionInsideNavMesh = hit.position;
        objects.Add(Instantiate(prefab, positionInsideNavMesh, Quaternion.identity));
    }
}
