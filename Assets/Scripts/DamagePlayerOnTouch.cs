using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayerOnTouch : MonoBehaviour
{
    [SerializeField]
    private int Damage = 1;

    Health ownHealth;

    private void Start() {
        ownHealth = GetComponent<Health>();
    }

    private void OnCollisionEnter(Collision other) {
        if (other.rigidbody.tag == "Player"){
            Health playerHealth = other.rigidbody.GetComponent<Health>();
            ownHealth.LoseHealth(other.rigidbody.transform.gameObject,0);
            playerHealth.LoseHealth(gameObject,Damage);
        }
    }
}
