using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    Rigidbody rigidBody;
    Vector3 inputVector;

    public float moveSpeed;
    public GameObject bullet;
    public GameObject gun;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");


        transform.Rotate(0, mouseX*4, 0);
        if (Mathf.Abs(-mouseY*4+Camera.main.transform.rotation.eulerAngles.x) < 60 || Mathf.Abs(-mouseY * 4 + Camera.main.transform.rotation.eulerAngles.x) > 300) {
            Camera.main.transform.Rotate(-mouseY * 4, 0, 0);
        }

        inputVector = transform.forward * Input.GetAxis("Vertical");
        inputVector += transform.right * Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.E))
        {
            GameObject b = Instantiate(bullet, gun.transform.position + (gun.transform.up*.25f), gun.transform.rotation);
            b.transform.Rotate(-5, 0, 0);
            b.GetComponent<Rigidbody>().AddForce(b.transform.forward * .25f, ForceMode.Impulse);
        }
	}

    private void FixedUpdate()
    {
        rigidBody.velocity = inputVector * moveSpeed + Physics.gravity * .5f;
    }
}
