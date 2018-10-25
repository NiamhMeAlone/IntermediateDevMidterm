using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && tag != "Inert")
        {
            collision.gameObject.GetComponent<Player>().health--;
        }
        tag = "Inert";
    }
}
