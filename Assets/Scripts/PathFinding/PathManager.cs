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
    public WayPoint FindClosestWaypoint(Transform obj, AI character)
    {
        WayPoint curClosests = null;
        float distance = Mathf.Infinity;
        Vector3 Pos = obj.position;

        foreach(WayPoint wp in Waypoints)
        {
            Vector3 difference = wp.transform.position - Pos;
            float magitude = difference.sqrMagnitude;
            if (magitude < distance && magitude > 0.2f) 
            {
                if(wp!=character.LastWayPoint)
                {
                    curClosests = wp;
                    distance = magitude;
                }
            }
        }
        return curClosests;
    }
    public WayPoint FindClosestWaypointAsWaypoint(Transform obj, WayPoint way)
    {
        WayPoint curClosests = null;
        float distance = Mathf.Infinity;
        Vector3 Pos = obj.position;

        foreach (WayPoint wp in Waypoints)
        {
            Vector3 difference = wp.transform.position - Pos;
            float magitude = difference.sqrMagnitude;
            if (magitude < distance && magitude > 0.2f)
            {
                if (wp != way)
                {
                    curClosests = wp;
                    distance = magitude;
                }
            }
        }
        return curClosests;
    }
    public WayPoint FindClosestWaypointInPath(Transform obj, AI character, List<WayPoint> wps)
    {
        WayPoint curClosests = null;
        float distance = Mathf.Infinity;
        Vector3 Pos = obj.position;

        foreach (WayPoint wp in wps)
        {
            Vector3 difference = wp.transform.position - Pos;
            float magitude = difference.sqrMagnitude;
            if (magitude < distance && magitude > 0.2f)
            {
                if (wp != character.LastWayPoint)
                {
                    curClosests = wp;
                    distance = magitude;
                }
            }
        }
        return curClosests;
    }
    public List<WayPoint> FindPathToLocation(Transform start, Location end)
    {
        List<WayPoint> wp = new List<WayPoint>();
        WayPoint w = FindClosestWaypoint(start, start.GetComponent<AI>());
        if(!w.GetComponent<Location>())
        {
            wp.Add(w);
        }

        for(int i = 1; i < Waypoints.Count - 1; i++)
        {
            WayPoint wwp = FindClosestWaypointAsWaypoint(Waypoints[i - 1].transform, Waypoints[i]);
            if (!wwp.GetComponent<Location>())
            {
                wp.Add(wwp);
            }
;        }

        return wp;
    }
}
