using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class AWSPostTest : MonoBehaviour
{
    public AWSConfig configAsset;

    [System.Serializable]
    public class LoginData
    {
        public string username;
        public string password;
    }

    private void Start()
    {
        StartCoroutine(LoginToAWS(configAsset.usernamePlayer, configAsset.passwordPlayer));
    }

    public IEnumerator LoginToAWS(string _usrname, string _password)
    {
        string url = configAsset.url;
        var request = new UnityWebRequest(url, "POST");
        var json = JsonUtility.ToJson(new LoginData { username = _usrname, password = _password });
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(json);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.SetRequestHeader("Content-Type", "application/json");

        Debug.Log("Posting to URL: " + url);
        Debug.Log("Request JSON: " + json);

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            string responseText = request.downloadHandler.text;
            Debug.Log($"Successfully connected: {responseText}");
        }

        else
        {
            string responseCode = request.responseCode.ToString();
            string errorText = request.error;
            string responseBody = request.downloadHandler.text;

            Debug.Log($"Error {responseCode}: {errorText}");
            Debug.Log($"Server Response: {responseBody}");
        }

    }
}