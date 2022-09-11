using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField]
    private GameObject teleportOut;
    [SerializeField]
    private CharacterController characterController;
    public void OnTriggerEnter(Collider collision) {
        if (collision != null) {
            if (collision.gameObject.tag == "Player") {
                characterController.enabled = false;
                collision.gameObject.transform.position = teleportOut.transform.position;
                characterController.enabled = true;
            }
        }
    }
}