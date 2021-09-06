using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody rig;
    public float jumpForce;
    private bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        // get x and z inputs
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;

        //setting velocity based on inputs
        rig.velocity = new Vector3(x, rig.velocity.y, z);

        //create velocity variable and setting y to 0
        Vector3 vel = rig.velocity;
        vel.y = 0;

        //if we're moving, rotate to face out moving direction
        if(vel.x != 0 || vel.z != 0)
        {
            transform.forward = vel;
        }

        //Jump function
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded==true)
            {
            isGrounded = false;
                rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }

        //check if falling into void
        if(transform.position.y < -10)
        {
            GameOver();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.contacts[0].normal==Vector3.up)
        {
            isGrounded = true;
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
