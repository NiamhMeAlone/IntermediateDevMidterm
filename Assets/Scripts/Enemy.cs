using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float iniTimer;
    public GameObject bullet;
    public Transform player;
    public bool alive;

    private RaycastHit hit;
    private float timer;
    
	void Start () {
        timer = iniTimer;
        alive = true;
	}
    
    void Update()
    {
        if (alive) {
            Vector3 dir2Player = player.position - transform.position;
            transform.forward = dir2Player.normalized;
            Ray playRay = new Ray(transform.position, player.position - transform.position);
            if (Physics.Raycast(playRay, out hit, 1000))
            {
                if (hit.transform.CompareTag("Player") && timer <= 0)
                {
                    print("bang");
                    GameObject b = Instantiate(bullet, transform.position, transform.rotation);
                    b.transform.Rotate(-5, 0, 0);
                    b.GetComponent<Rigidbody>().AddForce(b.transform.forward * .25f, ForceMode.Impulse);
                    timer = iniTimer;
                }
            }
            timer -= Time.deltaTime;
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            alive = false;
        }
    }
}
