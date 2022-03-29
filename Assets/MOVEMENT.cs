using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOVEMENT : MonoBehaviour
{
    public Rigidbody rb;
    public Transform car;
    public float speed = 17;
    public bool isGrounded;
    public float height = 5;

    Vector3 right = new Vector2(1, 0);
    Vector3 left = new Vector2(-1, 0);

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Ground")
        {
            isGrounded = true;
            this.transform.parent = collision.transform;

        }
        if (collision.gameObject.tag == "Platforn")
        {
            isGrounded = true;

            /*  private void OnCollisionExit(Collision collision)
    {
        collision.gameObject.transform.parent = null;
    }*/
        }

    }
  /*  private void OnCollisionExit(Collision collision)
    {
        collision.gameObject.transform.parent = null;
    }*/
    void FixedUpdate()
    {
        
        if (Input.GetKey("d"))
        {
            rb.MovePosition(car.position + right * speed * Time.deltaTime);
        }
        if (Input.GetKey("a"))
        {
            rb.MovePosition(car.position + left * speed * Time.deltaTime);
        }
        if(Input.GetKey("w"))
        {
            if(isGrounded==true)
            {
                GetComponent<Rigidbody>().AddForce(new Vector3(0, 2, 0),ForceMode.Impulse);
                isGrounded=false;
            }

        }

    }
}
