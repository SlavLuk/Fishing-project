using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSphere2 : MonoBehaviour {

    private static IList<Coordinates> points = new List<Coordinates>();

    private void Start()
    {
        //Get the line renderer for our Manager Object - disable it
        GetComponent<LineRenderer>().enabled = false;
    }

    // Use this for initialization
    public void Move() {
        //Get the line renderer for our Manager Object
        LineRenderer lineRenderer = GetComponent<LineRenderer>();

        //Get the line renderer for our Manager Object - enable it
        GetComponent<LineRenderer>().enabled = true;

        //Iterator
        int count = 0;

        //Return the points from file so we can map them
        points = History.GetPoints();

        //The number of points
        lineRenderer.positionCount = points.Count;


        //Iterate through the points
        foreach (Coordinates point in points) {

            //Set a new position
            lineRenderer.SetPosition(count, new Vector3((float)point.XPos, (float)point.YPos, (float)point.ZPos) );
            count++;
        }

        count = 0;

        //empty the list
        points.Clear();

    }

    public void Destroy(){

        //Disable the renderer
        GetComponent<LineRenderer>().enabled = false;

    }

}
