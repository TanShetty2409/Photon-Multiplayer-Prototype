using UnityEngine;
using Photon.Pun;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private UIManager uiManager;
    void Start()
    {
        Debug.Log("Connecting to Photon...");
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master");
        uiManager.SetStatus("Joining lobby...");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Joined Lobby");
        uiManager.SetStatus("Joined lobby.");
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("Room created: " + PhotonNetwork.CurrentRoom.Name);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined room: " + PhotonNetwork.CurrentRoom.Name);
        uiManager.SetStatus("Joined room: " + PhotonNetwork.CurrentRoom.Name);
        uiManager.ShowInRoomScreen(PhotonNetwork.CurrentRoom.Name);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.LogWarning("Join failed: " + message);
    }

    public override void OnLeftRoom()
    {
        Debug.Log("Left room");
        uiManager.SetStatus("Joined lobby.");
        uiManager.ShowMainMenu();
    }

    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        Debug.Log(newPlayer.NickName + " joined. Players: "
            + PhotonNetwork.CurrentRoom.PlayerCount + "/2");
        uiManager.UpdatePlayerCount();
    }

    public override void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)
    {
        Debug.Log(otherPlayer.NickName + " left. Players: "
            + PhotonNetwork.CurrentRoom.PlayerCount + "/2");
        uiManager.UpdatePlayerCount();
    }
}
