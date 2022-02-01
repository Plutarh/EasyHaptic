using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlgoritmTest : MonoBehaviour
{
    public int listElementsCount;
    public List<int> randomValues = new List<int>();
    public int needToFind;
    public int iterationsCount;
    public int founededRes;

    void Start()
    {
        CreateRandomList();
        SortList();
        BinarySearch(randomValues,needToFind);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BinarySearch(List<int> list, int key)
    {
        int low = 0;
        int high = list.Count - 1;
        int mid;
        int guess;

        while(low <= high)
        {
            iterationsCount++;
            mid = (int)(low + high) / 2;
            guess = randomValues[mid];

            if (guess == key)
            {
                founededRes = guess;
                break;
            }


            if (guess > key)
                high = mid - 1;
            else
                low = mid + 1;
            
        }
    }

    void CreateRandomList()
    {
        randomValues.Clear();
        for (int i = 0; i < listElementsCount; i++)
        {
            randomValues.Add(i);
        }
    }

    void SortList()
    {
        randomValues.Sort();
    }
}
