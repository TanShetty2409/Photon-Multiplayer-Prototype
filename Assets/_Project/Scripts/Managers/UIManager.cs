using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;

public class UIManager : MonoBehaviour
{
    [Header("UI Screens")]
    [SerializeField] private GameObject mainMenuScreen;
    [SerializeField] private GameObject createRoomScreen;
    [SerializeField] private GameObject joinRoomScreen;
    [SerializeField] private GameObject inRoomScreen;

    [Header("Room Inputs")]
    [SerializeField] private TMP_InputField createRoomNameInput;
    [SerializeField] private TMP_InputField joinRoomNameInput;

    [SerializeField] private TMP_Text roomNameDisplayText;
    [SerializeField] private TMP_Text playerCountText;


    [SerializeField] private TMP_Text statusText;

    void Start()
    {
        ShowMainMenu();
        SetStatus("Connecting to Photon...");
    }

    public void ShowMainMenu()
    {
        mainMenuScreen.SetActive(true);
        createRoomScreen.SetActive(false);
        joinRoomScreen.SetActive(false);
        inRoomScreen.SetActive(false);
    }

    public void ShowCreateRoomScreen()
    {
        mainMenuScreen.SetActive(false);
        createRoomScreen.SetActive(true);
    }
    public void ShowJoinRoomScreen()
    {
        mainMenuScreen.SetActive(false);
        joinRoomScreen.SetActive(true);
    }

    public void ShowInRoomScreen(string roomName)
    {
        mainMenuScreen.SetActive(false);
        createRoomScreen.SetActive(false);
        joinRoomScreen.SetActive(false);
        inRoomScreen.SetActive(true);
        roomNameDisplayText.text = "Room: " + roomName;
        UpdatePlayerCount();
    }

    public void UpdatePlayerCount()
    {
        if (Photon.Pun.PhotonNetwork.InRoom)
            playerCountText.text = "Players: " + PhotonNetwork.CurrentRoom.PlayerCount + "/2";
    }

    public void OnCreateRoomButtonPressed()
    {
        RoomManager.Instance.CreateRoom(createRoomNameInput.text);
    }
    public void OnJoinRoomButtonPressed()
    {
        RoomManager.Instance.JoinRoom(joinRoomNameInput.text);
    }
    public void OnLeaveRoomButtonPressed()
    {
        RoomManager.Instance.LeaveRoom();
    }

    public void OnQuitButtonPressed()
    {
        Application.Quit();
    }

    public void SetStatus(string message)
    {
        statusText.text = message;
    }
}
