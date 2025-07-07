using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class NonRepeatingAlphabet : MonoBehaviour
{
    public Dictionary<char, int> charIndexPair = new Dictionary<char, int>();

    private void Start()
    {
        CheckForNonRepeatingAlphabets("lallu");
    }
    public void CheckForNonRepeatingAlphabets(string word)
    {
        charIndexPair.Clear();
        var stopwatch = Stopwatch.StartNew();
        for (int i = 0; i < word.Length; i++)
        {
            var currentElement = word[i];
            if(charIndexPair.ContainsKey(currentElement) )
            {
                charIndexPair[currentElement]++;
            }

            else
            {
                charIndexPair[currentElement] = 1;
            }
        }

        foreach(var item in charIndexPair)
        {
            if (charIndexPair[item.Key] == 1)
            {
                UnityEngine.Debug.Log($"First non repeating alphabet is {item.Key}");
                break;
            }
        }

        stopwatch.Stop();
        UnityEngine.Debug.Log($"Time Taken: {stopwatch.Elapsed}");
    }
}