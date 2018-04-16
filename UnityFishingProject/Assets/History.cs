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
    private bool clickCondition = false;

    private static List<Coordinates> points = new List<Coordinates>();
    private DirectoryInfo di = new DirectoryInfo("./");



    void Start()
    {

        //number of files
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

        if (noOfFiles > 1)
        {

            if (counter == noOfFiles - 1)
            {

                previousButton.SetActive(false);

            }
            else
            {

                previousButton.SetActive(true);

            }

            if (counter != 0)
            {

                nextButton.SetActive(true);

            }
            else {

                nextButton.SetActive(false);

            }

        }
        else {
            nextButton.SetActive(false);
            previousButton.SetActive(false);
        }

        ReadFromFile();

    }

    public void ReadFromFile() {

        if (noOfFiles > 0)
        {

            string[] split = { "0","0","0"};

            string[] lines = System.IO.File.ReadAllLines(@"./Coordinates"+counter+".txt");

            for (int i = 0; i < lines.Length-1; i++)
            {
                split = lines[i].Split(' ');

                points.Add(new Coordinates(float.Parse(split[0]), float.Parse(split[1]), float.Parse(split[2])));

            }

        }

    }

    public static  List<Coordinates> GetPoints() {

        return points;

    }

    public void Active() {

        if (clickCondition == false)
        {

            counter = 0;

            ButtonState();

            clickCondition = true;
        }
        else {

            nextButton.SetActive(false);
            previousButton.SetActive(false);

            clickCondition = true;

        }

    }


}
