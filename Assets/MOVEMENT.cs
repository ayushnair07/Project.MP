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
    public GameObject light1, light0, light3, light4, light5;

    Vector3 right = new Vector2(1, 0);
    Vector3 left = new Vector2(-1, 0);
    private void Start()
    {
        Switch.SetActive(false);
        light0.SetActive(false);    
        light1.SetActive(false);
        light3.SetActive(false);    
        light4.SetActive(false);
        light5.SetActive(false);
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
            Destroy(this.gameObject);
        }
        

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Finish")
        {
            Switch.SetActive(true);
            action = true;
        }
       if(other.transform.tag =="Switch1")
        {                   
                light0.SetActive(true);
                light1.SetActive(true);
        }
        if (other.transform.tag == "Switch3")
        {
            light3.SetActive(true);
            light4.SetActive(true);
        }
        if (other.transform.tag == "Switch4")
        {
            light5.SetActive(true);
            
        }

    }
    IEnumerator Wait1()
    {
        yield return new WaitForSeconds(1.99999f);
        light0.SetActive(false);
        light1.SetActive(false);
    }
    IEnumerator Wait3()
    {
        yield return new WaitForSeconds(1.99999f);
        light3.SetActive(false);
        light4.SetActive(false);
        
    }
    IEnumerator Wait4()
    {
        yield return new WaitForSeconds(1.99999f);
        light5.SetActive(false);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Switch1")
        {

            StartCoroutine(Wait1());

            

        }
        if (other.transform.tag == "Switch3")
        {

            StartCoroutine(Wait3());



        }
        if (other.transform.tag == "Switch4")
        {

            StartCoroutine(Wait4());



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
                    GetComponent<Rigidbody>().AddForce(new Vector3(0, 3, 0), ForceMode.Impulse);
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
