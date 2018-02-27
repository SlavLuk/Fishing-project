using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSphere : MonoBehaviour {


	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {

		transform.Rotate(0, 0, 0);
		transform.Translate(PiData.changeInX,PiData.changeInY,PiData.changeInZ);

	}
}