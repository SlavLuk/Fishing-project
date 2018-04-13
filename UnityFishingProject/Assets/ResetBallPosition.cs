using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBallPosition : MonoBehaviour {

    GameObject sphere;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ResetBall()
    {

        transform.SetPositionAndRotation(new Vector3(0, 0, 7.94f), Quaternion.Euler(0, 0, 0));

    }
}
