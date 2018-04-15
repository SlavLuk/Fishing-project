using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordPositions : MonoBehaviour {

    Vector3 pos;
    private bool recordStatus = false;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {


        RecordState();

    }

    public void RecordState() {


        if (this.recordStatus == true)
        {

            Debug.Log(pos);

        }
        else {

            Debug.ClearDeveloperConsole();

        }

    }

    public bool GetRecordStatus() {

        return this.recordStatus;
    }

    public void SetRecordStatus()
    {

        if (this.recordStatus == false)
        {
            this.recordStatus = true;
        }
        else {
            this.recordStatus = false;
        }

    }

}
