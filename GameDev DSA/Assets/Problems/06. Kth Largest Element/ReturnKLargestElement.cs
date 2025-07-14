using UnityEngine;

public class ReturnKLargestElement : MonoBehaviour
{

    private void Start()
    {
        ReturnLargestElement(4, new int[]{ 2, 3, 6, 11, 19, 4, 7, 10, 5, 3 });
    }
    public void ReturnLargestElement(int element, int[] numArray)
    {
        int maxNo = 0;
        foreach(var num in  numArray)
        {
            if (num > maxNo)
            {
                maxNo = num;
            }
        }

        int[] maxNoArry = new int[maxNo + 1];

        for(int i = 0; i  < numArray.Length; i++)
        {
            maxNoArry[numArray[i]]++;
        }

        int index = 0;
        for(int i = maxNo; i >= 0; i--)
        {
            if (maxNoArry[i] > 0)
            {
                numArray[index] = i;
                index++;
            }
        }

        Debug.Log($"{element} largest element in the array {string.Join(",", numArray)} is {numArray[element - 1]}"); // 0-indexing
    }
}