using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSphere2 : MonoBehaviour {

    private static IList<Coordinates> points = new List<Coordinates>();

    private void Start()
    {
        GetComponent<LineRenderer>().enabled = false;
    }

    // Use this for initialization
    public void Move() {

        LineRenderer lineRenderer = GetComponent<LineRenderer>();

        GetComponent<LineRenderer>().enabled = true;

        int count = 0;

        points = History.GetPoints();

        Vector3[] tests = new Vector3[3];

        lineRenderer.positionCount = points.Count;

        foreach (Coordinates point in points) {

            lineRenderer.SetPosition(count, new Vector3((float)point.XPos, (float)point.YPos, (float)point.ZPos) );
            count++;
        }

        count = 0;

        points.Clear();

    }

    public void Destroy(){

        GetComponent<LineRenderer>().enabled = false;

    }

}
