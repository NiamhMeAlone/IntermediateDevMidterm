using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    Rigidbody rigidBody;
    Vector3 inputVector;

    public float moveSpeed;
    public GameObject bullet;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        transform.Rotate(0, mouseX*4, 0);
        Camera.main.transform.Rotate(-mouseY*4, 0, 0);

        inputVector = transform.forward * Input.GetAxis("Vertical");
        inputVector += transform.right * Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.E))
        {
            GameObject b = Instantiate(bullet, Camera.main.transform.position + (transform.forward*2), Camera.main.transform.rotation);
            b.transform.Rotate(-10, 0, 0);
            b.GetComponent<Rigidbody>().AddForce(b.transform.forward*10, ForceMode.Impulse);
        }
	}

    private void FixedUpdate()
    {
        rigidBody.velocity = inputVector * moveSpeed + Physics.gravity * .5f;
    }
}
