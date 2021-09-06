using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody rig;
    public float jumpForce;

    private bool isGrounded;

    // Update is called once per frame
    void Update()
    {

        // get horizontal and vertical inputes
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;

        // set velocity based on inputs
        rig.velocity = new Vector3(x, rig.velocity.y, z);

        // create copy of velocity and set Y axis to 0
        Vector3 vel = rig.velocity;
        vel.y = 0;

        // if moving, rotate to face direction
        if(vel.x != 0 || vel.z != 0)
        {
            transform.forward = vel;
        }


        if(Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            isGrounded = false;
            rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.contacts[0].normal == Vector3.up)
        {
            isGrounded = true;
        }
    }

}
