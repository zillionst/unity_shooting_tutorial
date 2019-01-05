using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GameObject shot;
    public Transform firePosition;
    float speed = 5;
    float tilt = 5;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") == true) {
            Instantiate(shot, firePosition.position, firePosition.rotation);
        }
    }

    void FixedUpdate()
    {
        float dirX = Input.GetAxis("Horizontal");
        float dirY = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(dirX, 0, dirY);
        Rigidbody rb = GetComponent<Rigidbody>();

        rb.velocity = movement * speed;
        rb.rotation = Quaternion.Euler(0, 0, rb.velocity.x * -tilt);
    }
}
