using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<InspectorMenu> menuHolder = new List<InspectorMenu>();
    public Transform menuHolderParent;
    public static GameManager instance;

    public TMP_InputField playerName;
    public Button setPlayerName;
    public Button connectToServer;
    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);

        SetMenuHolder();
    }

    public void SetMenuHolder()
    {
        foreach(Transform menu in menuHolderParent)
        {
            var menuComp = menu.GetComponent<InspectorMenu>();
            if(menuComp != null)
            {
                menuHolder.Add(menuComp);
            }
        }
    }

    public void OpenMenu(ItemsMenu menuToAdd)
    {
        foreach(var item in menuHolder)
        {
            if (item.menuItem != menuToAdd)
            {
                var canvasGroup = item.GetComponent<CanvasGroup>();
                if (canvasGroup == null) AddCanvasGroup(item);
                canvasGroup.alpha = 0;
                canvasGroup.interactable = false;
                canvasGroup.blocksRaycasts = false;
            }

            else
            {
                var itemToDisplay = item.GetComponent<CanvasGroup>();
                if (itemToDisplay == null) AddCanvasGroup(item);
                itemToDisplay.alpha = 1;
                itemToDisplay.interactable = true;
                itemToDisplay.blocksRaycasts = true;
            }
        }
    }

    private void AddCanvasGroup(InspectorMenu addCanvas)
    {
        addCanvas.AddComponent<CanvasGroup>();
    }

    public void OnConnectToServer()
    {
        PhotonNetworkManager.instance.Init();
    }

    public void OnSetPlayerName()
    {
        if (!string.IsNullOrEmpty(playerName.text))
        {
            PhotonNetworkManager.instance.SetPlayerName(playerName.text);
            OpenMenu(ItemsMenu.Gameplay);
        }
    }
}