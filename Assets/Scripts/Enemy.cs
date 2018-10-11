using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float iniTimer;
    public GameObject bullet;
    public Transform player;

    private RaycastHit hit;
    private float timer;

	// Use this for initialization
	void Start () {
        timer = iniTimer;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 dir2Player = player.position - transform.position;
        transform.forward = dir2Player.normalized;
        Ray playRay = new Ray(transform.position, player.position-transform.position);
        if (Physics.Raycast(playRay, out hit, 1000))
        {
            if (hit.transform.CompareTag("Player") && timer <= 0) {
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
