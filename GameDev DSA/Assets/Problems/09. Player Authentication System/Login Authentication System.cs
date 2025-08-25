using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
public class LoginAuthenticationSystem : MonoBehaviour
{
    public TMP_InputField emailText;
    public TMP_InputField passwordText;

    public string signUpURL;

    #region Web Request Functions
    private const string POST = "POST";
    #endregion

    public void SignIn()
    {
        string emailVal = emailText.text.Trim();
        string passwordVal = passwordText.text.Trim();

        LoginRequest loginAuthenticationSystem = new LoginRequest { email = emailVal, password = passwordVal };
        string json = JsonUtility.ToJson(loginAuthenticationSystem);
        StartCoroutine(PostSignupRequest(json));
    }
    public IEnumerator PostSignupRequest(string jsonVal)
    {
        UnityWebRequest webRequest = new UnityWebRequest(signUpURL, POST);
        byte[] bufferRaw = System.Text.Encoding.UTF8.GetBytes(jsonVal);
        webRequest.uploadHandler = new UploadHandlerRaw(bufferRaw);
        webRequest.downloadHandler = new DownloadHandlerBuffer();
        webRequest.SetRequestHeader("Content-Type", "application/json");
        yield return webRequest.SendWebRequest();

        if (webRequest.result == UnityWebRequest.Result.Success)
        {
            Debug.Log($"STATUS CODE {webRequest.responseCode} | {webRequest.result}");
        }

        else
        {
            Debug.Log($"STATUS CODE {webRequest.responseCode} | {webRequest.result}");
        }
    }
}

[System.Serializable]
public class LoginRequest
{
    public string email;
    public string password;
}