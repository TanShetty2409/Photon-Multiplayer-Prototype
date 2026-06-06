using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [Header("UI Screens")]
    [SerializeField] private GameObject mainMenuScreen;
    [SerializeField] private GameObject createRoomScreen;
    [SerializeField] private GameObject joinRoomScreen;

    [Header("Room Inputs")]
    [SerializeField] private TMP_InputField createRoomNameInput;
    [SerializeField] private TMP_InputField joinRoomNameInput;


    [SerializeField] private TMP_Text statusText;

    void Awake()
    {
        Instance = this;
    }

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

    public void OnCreateRoomButtonPressed()
    {
        RoomManager.Instance.CreateRoom(createRoomNameInput.text);
    }
    public void OnJoinRoomButtonPressed()
    {
        RoomManager.Instance.JoinRoom(joinRoomNameInput.text);
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
