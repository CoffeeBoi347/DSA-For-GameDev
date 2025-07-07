using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System.IO;
public class QuestObjectives : MonoBehaviour
{
    public List<QuestSO> questHolder = new List<QuestSO>();
    public int[] rewardPoints;
    private void Start()
    {
        SortQuests(questHolder);
        SaveRewards(rewardPoints);
        LoadRewards(rewardPoints);
    }

    public void SortQuests(List<QuestSO> holder)
    {
        var stopwatch = Stopwatch.StartNew();

        rewardPoints = new int[holder.Count];

        for(int i = 0; i < holder.Count; i++)
        {
            rewardPoints[i] = holder[i].rewardPoints;
        }

        int maxNo = 0;
        foreach(var item in rewardPoints)
        {
            if(item > maxNo)
            {
                maxNo = item;
            }
        }

        int[] maxArray = new int[maxNo + 1];

        for(int i = 0; i < rewardPoints.Length; i++)
        {
            maxArray[rewardPoints[i]]++;
        }

        int index = 0;
        for(int i = maxNo; i >= 0; i--)
        {
            if (maxArray[i] > 0)
            {
                rewardPoints[index] = i;
                index++;
            }
        }

        stopwatch.Stop();
        UnityEngine.Debug.Log($"TIME TAKEN: {stopwatch.Elapsed}");
        UnityEngine.Debug.Log($"{string.Join(",", rewardPoints)}");
    }

    public void SaveRewards(int[] arry)
    {
        string path = Application.persistentDataPath + "/rewardsHolder.json";

        using (StreamWriter writer = new StreamWriter(path))
        {
            foreach(int reward in arry)
            {
                writer.WriteLine(reward);
            }
        }
    }

    public void LoadRewards(int[] arry)
    {
        var stopwatch = Stopwatch.StartNew();
        string path = Application.persistentDataPath + "/rewardsHolder.json";
        if (File.Exists(path))
        {
            string[] lines = File.ReadAllLines(path);
            rewardPoints = System.Array.ConvertAll(lines, int.Parse);
            foreach (var i in rewardPoints)
            {
                UnityEngine.Debug.Log($"Loaded {i} from {string.Join(",", rewardPoints)}");
            }
        }
        
        else
        {
            UnityEngine.Debug.Log("No paths found! Invalid. Create one instead.");
        }

        stopwatch.Stop();

        UnityEngine.Debug.Log($"Time taken for loading: {stopwatch.Elapsed}");
    }
}