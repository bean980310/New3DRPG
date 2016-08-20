using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PathManager : MonoBehaviour {
    public List<WayPoint> Waypoints = new List<WayPoint>();

    public static PathManager Instance;

    void Awake()
    {
        Instance = this;
        //Waypoints = FindObjectOfType<WayPoint>();
    }

    //public WayPoint FindClosestWaypoint(Transform obj, float range)
    //{
    //    float closest = range;
    //    WayPoint closestw = null;

    //    foreach(WayPoint w in Waypoints){
    //        if (w.Distance(obj) < closest)
    //            closestw = w;
    //    }
    //    return closestw;
    //}
    public WayPoint FindClosestWaypoint(Transform obj)
    {
        WayPoint curClosests = null;
        float distance = Mathf.Infinity;
        Vector3 Pos = obj.position;

        foreach(WayPoint wp in Waypoints)
        {
            Vector3 difference = wp.transform.position - Pos;
            float magitude = difference.sqrMagnitude;
            if(magitude<distance)
            {
                curClosests = wp;
                distance = magitude;
            }
        }
        return curClosests;
    }
}
