using UnityEngine;
using Photon.Pun;

public class RoomManager : MonoBehaviour
{
  public static RoomManager Instance;

  void Awake()
    {
        Instance = this;
    }

    public void CreateRoom(string roomName)
    {
        if(string.IsNullOrEmpty(roomName))
        {
            Debug.LogError("Room name cannot be empty.");
            return;
        }
        ExitGames.Client.Photon.Hashtable customProps = new ExitGames.Client.Photon.Hashtable();
        Photon.Realtime.RoomOptions roomOptions = new Photon.Realtime.RoomOptions
        {
            MaxPlayers = 2,
            CustomRoomProperties = customProps
        };
        PhotonNetwork.CreateRoom(roomName, roomOptions);
        Debug.Log("Attempting to create room: " + roomName);
    }

    public void JoinRoom(string roomName)
    {
        if(string.IsNullOrEmpty(roomName))
        {
            Debug.LogError("Room name cannot be empty.");
            return;
        }
        PhotonNetwork.JoinRoom(roomName);
        Debug.Log("Attempting to join room: " + roomName);
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        Debug.Log("Leaving room...");
    }
}
