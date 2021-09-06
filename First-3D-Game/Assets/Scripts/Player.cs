using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody rig;

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        rig.velocity = new Vector3(x, rig.velocity.y, 0);
    }
}
