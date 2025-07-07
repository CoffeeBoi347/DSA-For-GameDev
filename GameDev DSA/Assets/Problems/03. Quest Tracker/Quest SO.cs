using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName = "Scriptables/Quest SO")]
public class QuestSO : ScriptableObject
{
    public int questID;
    public string questTitle;
    public int rewardPoints;
    public string[] steps;
}