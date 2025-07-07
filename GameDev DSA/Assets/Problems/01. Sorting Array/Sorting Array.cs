using UnityEngine;
using System.Diagnostics;

public class SortingArray : MonoBehaviour
{
    private void Start()
    {
        SortArrayUsingLinearTime(new int[] { 3,5,8,1,3,3 });
        SortArrayUsingLinearithmicTime(new int[] { 3, 5, 8, 1, 3, 3 });
        SortArrayUsingQuadraticTime(new int[] { 3, 5, 8, 1, 3, 3 });
    }
    public void SortArrayUsingLinearTime(int[] distances)
    {
        // using counting sort logic for it

        var stopwatch = Stopwatch.StartNew();

        int biggestNo = 0;
        foreach(var item in distances)
        {
            if(item > biggestNo)
            {
                biggestNo = item;
            }
        }

        int[] occurences = new int[biggestNo + 1];

        for(int i = 0; i < distances.Length; i++)
        {
            occurences[distances[i]]++;
        }

        int index = 0;
        for(int i = 0; i < occurences.Length; i++)
        {
            while (occurences[i] > 0)
            {
                distances[index] = i;
                index++;
                occurences[i]--;
            }
        }

        stopwatch.Stop();
        UnityEngine.Debug.Log($"Time Taken: {stopwatch.Elapsed} (LINEAR TIME)");
        UnityEngine.Debug.Log($"Sorted Array: {string.Join(",", distances)} (LINEAR TIME)");
    }

    public void SortArrayUsingLinearithmicTime(int[] distances)
    {
        var stopwatch = Stopwatch.StartNew();
        System.Array.Sort(distances);
        stopwatch.Stop();
        UnityEngine.Debug.Log($"Time taken: {stopwatch.Elapsed} (Linearithmic Time)");
        UnityEngine.Debug.Log($"Sorted Array: {string.Join(",", distances)}  (Linearithmic Time))");
    }

    public void SortArrayUsingQuadraticTime(int[] distances)
    {
        var stopwatch = Stopwatch.StartNew();
        for(int i = 0; i < distances.Length - 1; i++)
        {
            for(int j = i + 1; j < distances.Length; j++)
            {
                if (distances[i] > distances[j])
                {
                    var temp = distances[i];
                    distances[i] = distances[j];
                    distances[j] = temp;
                }
            }
        }

        stopwatch.Stop();
        UnityEngine.Debug.Log($"Time taken: {stopwatch.Elapsed} (QUADRATIC TIME)");
        UnityEngine.Debug.Log($"Sorted Array: {string.Join(",", distances)}  (QUADRATIC TIME))");
    }
} 