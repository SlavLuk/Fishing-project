using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSphere2 : MonoBehaviour {

    private static List<Coordinates> points = new List<Coordinates>();

    public GameObject sphere2;

    int i = 0;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	public void Move() {

        sphere2.transform.SetPositionAndRotation(new Vector3(0, 0, 0), new Quaternion(0f, 0f, 0f, 0f));

        points = History.GetPoints();

        Debug.Log(points.Count);

        foreach (Coordinates point in points) {

            sphere2.transform.SetPositionAndRotation(new Vector3((float)point.XPos, (float)point.YPos, (float)point.ZPos), new Quaternion(0f, 0f, 0f, 0f));

        }

        points.Clear();
		
	}
}
