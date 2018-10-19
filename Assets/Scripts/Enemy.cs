using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float iniTimer;
    public GameObject bullet;
    public Transform player;
    public Transform gun;
    public bool alive;

    protected RaycastHit hit;
    protected float timer;
    
	void Start () {
        timer = iniTimer;
        alive = false;
	}
    
    void Update()
    {
        if (alive) {
            Vector3 dir2Player = player.position - transform.position;
            dir2Player.y = 0;
            transform.forward = dir2Player.normalized;
            Ray playRay = new Ray(transform.position, player.position - transform.position);
            if (Physics.Raycast(playRay, out hit, 1000))
            {
                if (hit.transform.CompareTag("Player") && timer <= 0)
                {
                    Shoot();
                }
            }
            timer -= Time.deltaTime;
        }
	}

    protected void Shoot()
    {
        GameObject b = Instantiate(bullet, gun.position + (gun.transform.up * .25f), transform.rotation);
        b.transform.Rotate(-5, 0, 0);
        b.GetComponent<Rigidbody>().AddForce(b.transform.forward * .25f, ForceMode.Impulse);
        timer = iniTimer;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            alive = false;
        }
    }
}
