using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class LobbyManager : MonoBehaviourPunCallbacks
{   
    public static LobbyManager Instance;
    public InputField CreateLob, JoinLob;
    public GameObject InputFieldObj, PlayerField,p1,p2;
    public int Player = 0;
    private void Awake()
    {
        Instance = this;
    }
    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(JoinLob.text);
    }
    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(CreateLob.text);
    }
    public override void OnJoinedRoom()
    {
        InputFieldObj.SetActive(false);
        PlayerField.SetActive(true);

    }
    public void  Player1()
    {
        p1.gameObject.SetActive(false);
        Player = 1;
        PhotonNetwork.LoadLevel("Game_Scene");
    }
    public void Player2()
    {
        p2.gameObject.SetActive(false);
        Player = 2;
        PhotonNetwork.LoadLevel("Game_Scene");
    }
    
}
