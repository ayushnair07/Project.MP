using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MOVEMENT : MonoBehaviourPunCallbacks
{
    Transform InstP1, InstP2;
    GameObject p1, p2;
    public GameObject Player1PRE, Player2PRE;
    GameObject P1, P2;
    public Rigidbody rb;
    public Transform car;
    public float speed = 17;
    public bool isGrounded;
    public float height = 5;
    public GameObject Switch;
    public bool action = false;
    public GameObject light1, light0, light3,light4,light5;
    public float LeftCorner, RightCorner;
    public AudioSource levelMusic;
    public AudioSource JumpMusic;
    public AudioSource DeathMusic;
    public AudioSource VictoryMusic;
    public bool levelmusic=true;
    public bool jumpMusic=false;
    public bool deathMusic=false;
    public bool Victory = false;

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
        levelMusic.Play();
        levelmusic = true;
        if(LobbyManager.Instance.Player == 1)
        {
            p1 =PhotonNetwork.Instantiate(Player1PRE.name, InstP1.transform.position, Quaternion.identity);
            P1 = GameObject.Find("Player1");
            
        }
        else
        {
            p2 = PhotonNetwork.Instantiate(Player2PRE.name, InstP2.transform.position, Quaternion.identity);
            P2 = GameObject.Find("Player2");
        }

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
            levelmusic = false;
            levelMusic.Stop();
            DeathMusic.Play();
            deathMusic = true;
            
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
            light3.SetActive(true);
            light4.SetActive(true);
        }
        if (other.transform.tag == "Switch3")
        {
            light1.SetActive(true);
        }
        if (other.transform.tag == "Switch4")
        {
            light0.SetActive(true);
            light5.SetActive(true);
            
        }

    }
    IEnumerator Wait1()
    {
      
        yield return new WaitForSeconds(1.99999f);
        light0.SetActive(false);
        light5.SetActive(false);
        
    }
    IEnumerator Wait3()
    {
        yield return new WaitForSeconds(1.99999f);
        light1.SetActive(false);

    }
    IEnumerator Wait4()
    {
        yield return new WaitForSeconds(1.99999f);
        light3.SetActive(false);
        light4.SetActive(false);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Switch1")
        {


            StartCoroutine(Wait4());


        }
        if (other.transform.tag == "Switch3")
        {

            StartCoroutine(Wait3());



        }
        if (other.transform.tag == "Switch4")
        {

            StartCoroutine(Wait1());



        }

    }

    


    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (action == true)
            {
                Switch.SetActive(false);
                VictoryMusic.Play();
                Victory = true;
                levelMusic.Stop();
                levelmusic = false;
                //TerrainChangedFlags lvel script here
            }
        }
       

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
                    jumpMusic = true;
                    JumpMusic.Play();

                }

            }
        


    }

    
}
