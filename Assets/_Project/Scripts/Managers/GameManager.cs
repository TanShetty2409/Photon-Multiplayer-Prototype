using UnityEngine;
using Photon.Pun;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject inRoomScreen;
    [SerializeField] private TMP_Text roomNameDisplayText;
    [SerializeField] private TMP_Text playerCountText;

    IEnumerator Start()
    {
        yield return new WaitUntil(() => PhotonNetwork.InRoom);
        SpawnManager.Instance.SpawnPlayer();
        ShowInRoomScreen(PhotonNetwork.CurrentRoom.Name);
        UpdatePlayerCount();

    }

    public void ShowInRoomScreen(string roomName)
    {
        inRoomScreen.SetActive(true);
        roomNameDisplayText.text = "Room: " + roomName;
    }

    public void UpdatePlayerCount()
    {
        if (Photon.Pun.PhotonNetwork.InRoom)
            playerCountText.text = "Players: " + PhotonNetwork.CurrentRoom.PlayerCount + "/2";
    }
    public void OnLeaveRoomButtonPressed()
    {
        RoomManager.Instance.LeaveRoom();
    }

    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        Debug.Log(newPlayer.NickName + " joined. Players: "
            + PhotonNetwork.CurrentRoom.PlayerCount + "/2");
        UpdatePlayerCount();
    }

    public override void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)
    {
        Debug.Log(otherPlayer.NickName + " left. Players: "
            + PhotonNetwork.CurrentRoom.PlayerCount + "/2");
        UpdatePlayerCount();
    }
    public override void OnLeftRoom()
    {
        SceneManager.LoadScene("Lobby_Scene");
    }


}
