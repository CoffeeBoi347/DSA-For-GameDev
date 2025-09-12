using UnityEngine;
using UnityEngine.UIElements;

public class LabelStyler : MonoBehaviour
{
    public string classListName;
    public string buttonListName;
    private void OnEnable()
    {
        var root = this.GetComponent<UIDocument>().rootVisualElement; // returns the UI element holding the elements
        var label = root.Q<Label>("helloLabel"); // accessing the helloLabel object from unity UI toolkit
        var button = root.Q<Button>("myButton");

        if(label == null)
        {
            Debug.LogWarning($"Label not found! Please assign the label's name correctly.");
            return;
        }

        button.clicked += () =>
        {
            label.AddToClassList(classListName);
            button.AddToClassList(buttonListName);
        };
    }
}