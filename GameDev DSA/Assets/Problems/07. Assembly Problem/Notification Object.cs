using TMPro;
using UnityEngine;

public class NotificationObject : MonoBehaviour
{
    public TMP_Text notificationName;
    public TMP_Text dateTimeTxt;

    public void Init(string _notificationName, string dateTime)
    {
        notificationName.text = _notificationName;
        dateTimeTxt.text = dateTime;
    }
}