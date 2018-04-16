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
    private static List<Coordinates> points = new List<Coordinates>();


    void Start()
    {

        //number of files
        DirectoryInfo di = new DirectoryInfo("./");
        FileInfo[] TXTFile = di.GetFiles("*.txt");
        noOfFiles = TXTFile.Length;
        if (noOfFiles == 0 ) {

            counter = 0;
        }
        else {

            counter = noOfFiles - 1;

        }

    }

    public void PressPrevious()
    {
        counter++;

        points.Clear();

        ButtonState();
    }

    public void PressNext()
    {
        counter--;

        points.Clear();

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

            string[] split = { "0","0","0"};

            string[] lines = System.IO.File.ReadAllLines(@"./Coordinates"+counter+".txt");

            for (int i = 0; i < lines.Length; i++)
            {
                split = lines[i].Split(' ');
                
                points.Add(new Coordinates(float.Parse(split[0]), float.Parse(split[1]), float.Parse(split[2])));


            }

            Debug.Log(points.Count);

        }

    }

    public static  List<Coordinates> GetPoints() {
        return points;
    }


}
