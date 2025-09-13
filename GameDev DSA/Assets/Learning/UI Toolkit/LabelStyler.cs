using UnityEngine;
using UnityEngine.UIElements;

public class LabelStyler : MonoBehaviour
{
    [SerializeField] private string visualContainerName;
    [SerializeField] private string buttonName;

    [SerializeField] private StyleSheet styleSheet;

    [SerializeField] private string panelClassName;
    [SerializeField] private string buttonClassName;
    private VisualElement element;
    private Button actionButton;
    private void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        element = root.Q<VisualElement>(visualContainerName);
        actionButton = root.Q<Button>(buttonName);

        if(element != null )
        {
            Debug.Log("Adding StyleSheet!");
            element.styleSheets.Add(styleSheet);
            if(!string.IsNullOrEmpty(panelClassName) && !string.IsNullOrEmpty(buttonClassName)) {
                Debug.Log("Adding Class To Class List Of Visual Element!");
                element.AddToClassList(panelClassName);
                actionButton.AddToClassList(buttonClassName);
            }
        }
    }
}