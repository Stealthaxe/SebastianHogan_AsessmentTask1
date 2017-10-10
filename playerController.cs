using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

    public bool wPressed;
    public bool aPressed;
    public bool sPressed;
    public bool dPressed;
    public bool spacePressed;
    public bool canJump = true;

    public float moveSpeed;
    public float rotSpeed;
    public float jumpPower;
	
	// Update is called once per frame
	void Update () {
        wPressed = Input.GetKey("w");
        sPressed = Input.GetKey("s");
        aPressed = Input.GetKey("a");
        dPressed = Input.GetKey("d");
        spacePressed = Input.GetKey(KeyCode.Space);
    }

    private void FixedUpdate()
    {
        if (wPressed)
        {
            transform.position += transform.forward * moveSpeed;
        }

        if (sPressed)
        {
            transform.position -= transform.forward * moveSpeed;
        }

        if (aPressed)
        {
            transform.Rotate(-transform.up*rotSpeed);
        }

        if (dPressed)
        {
            transform.Rotate(transform.up*rotSpeed);
        }

        if (spacePressed && canJump)
        {
            gameObject.GetComponent<Rigidbody>().AddForce((transform.up * jumpPower), ForceMode.Impulse);
            canJump = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            canJump = true;
        }
    }
}
