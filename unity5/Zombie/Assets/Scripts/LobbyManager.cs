using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    private string gameVersion = "1";

    public TextMeshProUGUI message;
    public Button joinButton;

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.GameVersion = gameVersion;
        PhotonNetwork.ConnectUsingSettings();

        joinButton.interactable = false;
        message.text = "Connecting...";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnConnectedToMaster()
    {
        joinButton.interactable = true;
        message.text = "Online: Connected To Master";
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        joinButton.interactable = false;
        message.text = "Offline: Disconnected To Master";

        PhotonNetwork.ConnectUsingSettings();
    }

    public void Connect()
    {
        joinButton.interactable = false;

        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.JoinRandomRoom();
            message.text = "Join Random Room";
        }
        else
        {
            PhotonNetwork.ConnectUsingSettings();
            message.text = "Offline: Disconnected To Master";
        }

        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        PhotonNetwork.CreateRoom(string.Empty, new RoomOptions { MaxPlayers = 4 });
        this.message.text = message + "\nCreate Room";
    }

    public override void OnJoinedRoom()
    {
        this.message.text = "Joined Room";
        PhotonNetwork.LoadLevel("Main");
    }

    
}
