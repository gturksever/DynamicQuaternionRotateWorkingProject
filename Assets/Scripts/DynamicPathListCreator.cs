using System.Collections.Generic;
using UnityEngine;

public class DynamicPathListCreator : MonoBehaviour
{
    public static List <Transform> pathPoints;

    private void Awake()
    {
        AddArrayPathPoints();
    }

    private void AddArrayPathPoints()
    {
        GameObject pathObject = GameObject.FindGameObjectWithTag("Paths");

        pathPoints = new List<Transform> (pathObject.GetComponentsInChildren<Transform>(false));
        DeleteParentObjectToList();
    }

    private void DeleteParentObjectToList()
    {
        pathPoints.RemoveAt(0);
    }
}
