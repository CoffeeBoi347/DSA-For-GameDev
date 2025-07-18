using UnityEngine;

public class InspectorMenu : MonoBehaviour
{
    public ItemsMenu menuItem;
}

public enum ItemsMenu
{
    ConnectToServer,
    CreateNickName,
    NotificationsManager,
    Gameplay,
    Error
}