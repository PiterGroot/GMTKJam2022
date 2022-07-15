using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Transform> wayPoints = new List<Transform>();

    private void Start()
    {
        GetAllWayPoints();
    }
    private void GetAllWayPoints()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            wayPoints.Add(transform.GetChild(i));
        }
    }
    public Transform GetWayPoint(int index)
    {
        return wayPoints[index];
    }
}