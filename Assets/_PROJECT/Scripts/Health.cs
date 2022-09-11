using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour, IDataUi
{
    private const float hitDelayTime = 3f;
    [SerializeField]
    private int maxHealth = 3;
    [SerializeField]
    private IntSO currentHealth;
    private float hitDelay;
    private CharacterController characterController;
    public Action OnChangeValue { get; set;}

    private void Update() {
        if (hitDelay < hitDelayTime) {
            hitDelay += Time.deltaTime;
        }
    }
    private void Awake() {
        currentHealth.Value = maxHealth;
        characterController = GetComponent<CharacterController>();
    }

    private void Hit() {
        if (hitDelay < hitDelayTime) {
            return;
        }
        hitDelay = 0f;
        currentHealth.Value -= 1;
        OnChangeValue?.Invoke();
        characterController.enabled = false;
        this.gameObject.transform.position = new Vector3(-1.5f, 0f, -2.6f);
        this.gameObject.transform.rotation = Quaternion.Euler(0, 90f, 0);
        characterController.enabled = true;
        if (currentHealth.Value <= 0) {
            Bootstraper.Instance.LostScene(0);
        }
    }

    public void OnTriggerEnter(Collider collision) {
        if (collision != null) {
            if (collision.gameObject.tag == "Enemy") {
                Hit();
            }
        }
    }
}
