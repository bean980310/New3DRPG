using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AI : MonoBehaviour {
    public PlayerController Controller;
    public bool DoneHome;
    public Vector3 MoveVector = Vector3.zero;
    public bool GeneratedVector;
    public WayPoint CurWayPoint;
    public WayPoint LastWayPoint;
    public Location CurrentLocation;
    public LocationType CurrentActivity;
    public List<WayPoint> CurrentPath;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (!Controller.CanPlay) 
        {
            if(Vector3.Distance(transform.position, Controller.LocalCharacter.HomeSpawn.position) > 1)
            {
                transform.LookAt(Controller.LocalCharacter.HomeSpawn);
                Controller.v = 2;
            }
            else
            {
                DoneHome = true;
                //GeneratedVector = false;
                //MoveVector = Vector3.zero;
                Controller.v = 0;
            }
            if (DoneHome)
            {
                transform.LookAt(MoveVector);
                Controller.v = 2;

                //if (Vector3.Distance(transform.position, MoveVector) < 0.2f)
                //{
                //GeneratedVector = false;
                //}
                //if (!GeneratedVector)
                //{
                if (CurrentLocation == null)
                {
                    CurrentActivity = (LocationType)Random.Range(0, 2);
                    CurrentLocation = GameManager.Instance.FindLocationOfType(CurrentActivity);
                    PathManager.Instance.FindPathToLocation(transform, CurrentLocation);
                }
                else
                {
                    WayPoint wp = PathManager.Instance.FindClosestWaypointInPath(transform, this, CurrentPath);
                    if (CurWayPoint != wp)
                    {
                        LastWayPoint = CurWayPoint;
                        CurWayPoint = wp;
                    }
                    float x = wp.transform.position.x;
                    float z = wp.transform.position.z;
                    MoveVector = new Vector3(x, 0, z);
                }
                GeneratedVector = true;
                //}
            }
        }
	}
}
