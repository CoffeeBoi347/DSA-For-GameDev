using UnityEngine;

[CreateAssetMenu(fileName = "AWS Config", menuName = "Backend/URL", order = 1)]
public class AWSConfig : ScriptableObject
{
    public string url;

    public string usernamePlayer;
    public string passwordPlayer;
}