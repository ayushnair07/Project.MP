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
    public GameObject Switch;
    public bool action = false;

    Vector3 right = new Vector2(1, 0);
    Vector3 left = new Vector2(-1, 0);
    private void Start()
    {
        Switch.SetActive(false);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Ground")
        {
            isGrounded = true;
            

        }
        if (collision.gameObject.tag == "Platforn")
        {
            isGrounded = true;
            

        }
        if(collision.gameObject.tag=="Kanta")
        {
            Destroy(rb);
        }
        

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Finish")
        {
            Switch.SetActive(true);
            action = true;
        }
    }


    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (action == true)
            {
                Switch.SetActive(false);
                //TerrainChangedFlags lvel script here
            }
        }
        if (rb.transform.position.x <= 8 && rb.transform.position.x >= -8)
        {

            if (Input.GetKey("d"))
            {
                rb.MovePosition(car.position + right * speed * Time.deltaTime);
            }
            if (Input.GetKey("a"))
            {
                rb.MovePosition(car.position + left * speed * Time.deltaTime);
            }
            if (Input.GetKey("w"))
            {
                if (isGrounded == true)
                {
                    GetComponent<Rigidbody>().AddForce(new Vector3(0, 2, 0), ForceMode.Impulse);
                    isGrounded = false;
                }

            }
        }

        if (rb.transform.position.x < -8)
        {
            if (Input.GetKey("d"))
            {
                rb.MovePosition(car.position + right * speed * Time.deltaTime);
            }
            if (Input.GetKey("w"))
            {
                if (isGrounded == true)
                {
                    GetComponent<Rigidbody>().AddForce(new Vector3(0, 2, 0), ForceMode.Impulse);
                    isGrounded = false;
                }

            }

        }
        if (rb.transform.position.x > 8)
        {
            if (Input.GetKey("a"))
            {
                rb.MovePosition(car.position + left * speed * Time.deltaTime);
            }
            if (Input.GetKey("w"))
            {
                if (isGrounded == true)
                {
                    GetComponent<Rigidbody>().AddForce(new Vector3(0, 2, 0), ForceMode.Impulse);
                    isGrounded = false;
                }

            }

        }

    }

    
}
