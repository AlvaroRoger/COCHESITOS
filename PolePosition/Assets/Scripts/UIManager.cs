using Mirror;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public bool showGUI = true;

    private NetworkManager m_NetworkManager;
    public string playerName;

    [Header("Main Menu")] [SerializeField] private GameObject mainMenu;
    [SerializeField] private Button buttonHost;
    [SerializeField] private Button buttonClient;
    [SerializeField] private Button buttonServer;
    [SerializeField] private InputField inputFieldIP;

    [Header("In-Game HUD")]
    [SerializeField]
    private GameObject inGameHUD;

    [SerializeField] private Text textSpeed;
    [SerializeField] private Text textLaps;
    [SerializeField] private Text textPosition;

    [Header("Login Menu")]
    [SerializeField] GameObject loginMenu;
    [SerializeField] InputField nameInput;

    [Header("Chat Menu")]
    [SerializeField] GameObject chatMenu;
    public Mirror.Examples.Chat.Player player;

    private void Awake()
    {
        m_NetworkManager = FindObjectOfType<NetworkManager>();
    }

    private void Start()
    {
        buttonHost.onClick.AddListener(() => StartHost());
        buttonClient.onClick.AddListener(() => StartClient());
        buttonServer.onClick.AddListener(() => StartServer());
        buttonServer.onClick.AddListener(() => SetPlayer());
        ActivateLoginMenu();
    }

    public void UpdateSpeed(int speed)
    {
        textSpeed.text = "Speed " + speed + " Km/h";
    }

    private void ActivateLoginMenu()
    {
        loginMenu.SetActive(true);
        mainMenu.SetActive(false);
        inGameHUD.SetActive(false);
        chatMenu.SetActive(false);
    }

    private void StartHost()
    {
        m_NetworkManager.StartHost();
    }

    private void StartClient()
    {
        m_NetworkManager.StartClient();
        m_NetworkManager.networkAddress = inputFieldIP.text;
    }

    private void StartServer()
    {
        m_NetworkManager.StartServer();
    }

    public void SetPlayer()
    {
        player = NetworkClient.connection.identity.GetComponent<Mirror.Examples.Chat.Player>();
        player.playerName = playerName;
    }

    public void GetPlayerName()
    {
        playerName = nameInput.text;
    }
}
