using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordPositions : MonoBehaviour {

    Vector3 pos;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        pos = GameObject.Find("Sphere").transform.position;

    }

}
