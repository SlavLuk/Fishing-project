using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class History : MonoBehaviour {

    private int counter = 0;
    private int noOfFiles = 0;
    public GameObject nextButton;
    public GameObject previousButton;

    public Material material;



    void Start()
    {

        //number of files
        DirectoryInfo di = new DirectoryInfo("./");
        FileInfo[] TXTFile = di.GetFiles("*.txt");
        noOfFiles = TXTFile.Length;
        counter = noOfFiles - 1;

    }

    public void PressPrevious()
    {
        counter++;

        ButtonState();
    }

    public void PressNext()
    {
        counter--;

        ButtonState();
    }

    public void ButtonState()
    {
        ReadFromFile();

        nextButton.SetActive(true);
        previousButton.SetActive(false);

        if (noOfFiles <= 1) {
            nextButton.SetActive(false);
            previousButton.SetActive(false);
        }
        if (counter == 0){
            nextButton.SetActive(false);
        }
        else {
            nextButton.SetActive(true);
        }
        if (counter == noOfFiles - 1){
            previousButton.SetActive(false);
        }
        else {
            previousButton.SetActive(true);
        }

    }

    public void ReadFromFile() {

        if (noOfFiles > 0)
        {
            Vector3 pointA = new Vector3(0,0,0);

            string[] split;

            string[] lines = System.IO.File.ReadAllLines(@"./Coordinates"+counter+".txt");

            for (int i =0; i < lines.Length; i++)
            {
                split = lines[i].Split(' ');

                Vector3 pointB = new Vector3(
                    float.Parse(split[0]),
                    float.Parse(split[1]),
                    float.Parse(split[2])
                );

                //Need to print line here from PointA to PointB

                pointA = new Vector3(
                    float.Parse(split[0]),
                    float.Parse(split[1]),
                    float.Parse(split[2])
                );

            }

        }

    }


}
