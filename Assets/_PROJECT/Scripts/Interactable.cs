using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Interactable : MonoBehaviour
{
    public void OnTriggerEnter(Collider collision) {
        if (collision != null) {
            if (collision.gameObject.tag == "Player") {
                FindObjectOfType<InteractableManager>().Remove(this.gameObject);
            }
        }
    }
}
