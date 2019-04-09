using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NetworkManagerScript : MonoBehaviour
{
    public Text TextInfos;
    public Transform SpawnPoint1;
    public Transform SpawnPoint2;

    public Camera player1cam;
    public Camera player2cam;

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings("v0");
    }

    // Update is called once per frame
    void Update()
    {
        if (PhotonNetwork.connectionStateDetailed.ToString() != "Joined")
        {
            TextInfos.text = PhotonNetwork.connectionStateDetailed.ToString();
        }
        else
        {
            TextInfos.text = "Connected to " + PhotonNetwork.room.name + " Player(s) Online: " + PhotonNetwork.room.PlayerCount;
        }
    }

    private void OnConnectedToMaster()
    {
        Debug.Log("Connected with Master");
        PhotonNetwork.JoinLobby();
    }

    void OnJoinedLobby()
    {
        RoomOptions MyRoomOptions = new RoomOptions();
        MyRoomOptions.MaxPlayers = 2;
        PhotonNetwork.JoinOrCreateRoom("Room1", MyRoomOptions, TypedLobby.Default);
        Debug.Log("Connected with Lobby");
    }

    void OnJoinedRoom()
    {
        if (PhotonNetwork.playerList.Length > 1)
        {
            StartCoroutine(SpawnMyPlayer2());
        }
        else
        {
            StartCoroutine(SpawnMyPlayer());
        }
    }

    IEnumerator SpawnMyPlayer()
    {
        yield return new WaitForSeconds(1);
        player2cam.enabled = false;
        player1cam.enabled = true;
        GameObject MyPlayer = PhotonNetwork.Instantiate("Air Hockey Paddle", SpawnPoint1.position, SpawnPoint1.rotation, 0) as GameObject;
    }

    IEnumerator SpawnMyPlayer2()
    {
        yield return new WaitForSeconds(1);
        player1cam.enabled = false;
        player2cam.enabled = true;
        GameObject MyPlayer = PhotonNetwork.Instantiate("Air Hockey Paddle 2", SpawnPoint2.position, SpawnPoint1.rotation, 0) as GameObject;
    }
}