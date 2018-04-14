using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordPositions : MonoBehaviour {

    private bool record = false;

    Vector3 pos;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        if (record == true) {
            pos = GameObject.Find("Sphere").transform.position;

            Debug.Log(pos);
        }

    }

    public  bool GetRecord()
    {
        return this.record;
    }

    public void SetRecord() {

        if (this.record == true) {

            this.record = false;
        }
        else {

            this.record = true;

        }

    }

}
