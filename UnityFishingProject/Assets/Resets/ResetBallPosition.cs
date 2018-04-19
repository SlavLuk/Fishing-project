using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBallPosition : MonoBehaviour {

    public GameObject sphere;

    public void ResetBall()
    {


        //Rest the balls position - recenter
        sphere.transform.SetPositionAndRotation(new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));

		DisableTrail ();

    }

	public void DisableTrail(){
		sphere.GetComponent<TrailRenderer>().enabled=false;
	}

	public void EnableTrail(){
		sphere.GetComponent<TrailRenderer>().enabled=true;
	}
}
