using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    Rigidbody rigidBody;
    Vector3 inputVector;

    public float moveSpeed;
    public float lookSpeed;
    public GameObject bullet;
    public GameObject gun;
    
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
	}
	
	void Update () {
        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * 1000f, Color.green);
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime;


        transform.Rotate(0, mouseX * lookSpeed, 0);
        if (Mathf.Abs(-mouseY*4+Camera.main.transform.rotation.eulerAngles.x) < 70 || Mathf.Abs(-mouseY * 4 + Camera.main.transform.rotation.eulerAngles.x) > 290) {
            Camera.main.transform.Rotate(-mouseY * lookSpeed, 0, 0);
        }

        inputVector = transform.forward * Input.GetAxis("Vertical");
        inputVector += transform.right * Input.GetAxis("Horizontal");

        Ray myRay = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit = new RaycastHit();
        Physics.Raycast(myRay, out hit, Mathf.Infinity);
        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * 1000f, Color.green);

        if (Input.GetKeyDown(KeyCode.E))
        {
            GameObject b = Instantiate(bullet, gun.transform.position + (gun.transform.up * .25f), Quaternion.identity);
            b.transform.forward = hit.point - b.transform.position;
            b.transform.Rotate(-5, 0, 0);
            b.GetComponent<Rigidbody>().AddForce(b.transform.forward * .25f, ForceMode.Impulse);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
	}

    private void FixedUpdate()
    {
        rigidBody.velocity = inputVector * moveSpeed + Physics.gravity * .5f * Time.deltaTime;
    }
}
