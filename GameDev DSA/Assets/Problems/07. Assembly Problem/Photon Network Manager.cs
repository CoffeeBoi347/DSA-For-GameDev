using Photon.Pun;
using Photon.Realtime;

public class PhotonNetworkManager : MonoBehaviourPunCallbacks
{
    public static PhotonNetworkManager instance;
    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void Init()
    {
        PhotonNetwork.ConnectUsingSettings();
        GameManager.instance.OpenMenu(ItemsMenu.CreateNickName);
    }

    public void SetPlayerName(string playerName)
    {
        PhotonNetwork.NickName = playerName;
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        base.OnDisconnected(cause);
        GameManager.instance.OpenMenu(ItemsMenu.Error);
    }
}