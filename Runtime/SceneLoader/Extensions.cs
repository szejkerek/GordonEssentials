using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    public static List<T> SelectRandomElements<T>(this List<T> list, int count)
    {
        List<T> copiedList = new List<T>(list);
        List<T> selectedElements = new List<T>();

        if (selectedElements.Count > count)
        {
            Debug.LogWarning("Number of selected elements is greater than given list!");
            return copiedList;
        }

        while (selectedElements.Count < count)
        {
            int randomIndex = Random.Range(0, copiedList.Count);
            selectedElements.Add(copiedList[randomIndex]);
            copiedList.RemoveAt(randomIndex);
        }

        return selectedElements;
    }

    public static T SelectRandomElement<T>(this List<T> list)
    {
        if (list == null || list.Count == 0)
        {
            Debug.LogWarning("The list is empty or null.");
        }

        int randomIndex = Random.Range(0, list.Count);
        return list[randomIndex];
    }
}
