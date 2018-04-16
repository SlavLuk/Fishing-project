using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSphereHistory : MonoBehaviour {

    //Start is called once 
    void Start()
    {


    }

    // Update is called once per frame
    public void MoveBall()
    {

        //s = ut + 1/2 at² - equation for distance
        List<Coordinates> listOfPoints = History.GetPoints();

        foreach (Coordinates point in listOfPoints) {

            //rotate our object
            transform.Rotate(0, 0, 0);

            //without Y axis
            transform.Translate((float)point.XPos, (float)point.YPos, (float)point.ZPos);

            Debug.Log((float)point.XPos);
     

        }

    }
}
