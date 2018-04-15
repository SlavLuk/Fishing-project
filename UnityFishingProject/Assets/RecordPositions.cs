using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class RecordPositions : MonoBehaviour {

    Vector3 pos;
    private bool recordStatus = false;
    private List<Coordinates> list = new List<Coordinates>();

    // Update is called once per frame
    void Update () {

        //Each frame run this method
        //if the record status is false, it simply returns without recording any points
        RecordState();

    }

    public void RecordState() {


        if (this.recordStatus == true)
        {

            //Current Position of the Sphere
            pos = GameObject.Find("Sphere").transform.position;

            //Create a new set of Coordinates
            Coordinates coords = new Coordinates(pos.x, pos.y, pos.z);

            //Add the new Coordinates to the list
            this.list.Add(coords);

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
        else
        {
            //Wite the list to a file
            WriteToFile();

            //Clear the List, So it can be written to again
            list.Clear();

            //Stop the recording
            this.recordStatus = false;

        }

    }

    public void WriteToFile() {

        //number of files
        DirectoryInfo di = new DirectoryInfo("./");
        FileInfo[] TXTFile = di.GetFiles("*.txt");


        //Writer that creates a new file to print to
        TextWriter tw = new StreamWriter("Coordinates"+TXTFile.Length+".txt");//"+fileCount+"

        //loop through our point list
        foreach (Coordinates coord in this.list){

            //Write out
            tw.WriteLine(coord.XPos+" " +coord.YPos+" " +coord.ZPos);

        }

        //close the writer
        tw.Close();
    }

}
