using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSphere : MonoBehaviour {


	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {

		//s = ut + 1/2 at² - equation for distance

		//rotate our objsct
		transform.Rotate(0, 0, 0);
		//move our objext
		transform.Translate(0,0,0);


	}
}