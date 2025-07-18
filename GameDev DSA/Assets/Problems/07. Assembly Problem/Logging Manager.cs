using Photon.Pun;
using TMPro;

public class LoggingManager : MonoBehaviourPun
{
    public TMP_Text setPlayerNameTxt;
    public void Setup(string playerName)
    {
        setPlayerNameTxt.text = $"WELCOME {playerName}";
    }
}