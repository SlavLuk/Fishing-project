using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class History : MonoBehaviour {


    public static int counter = 0;
    private int noOfFiles = 0;

    //Objects
    public GameObject nextButton;
    public GameObject previousButton;
    private bool clickCondition = false;

    //List of coordinates from list
    private static List<Coordinates> points = new List<Coordinates>();
    private DirectoryInfo di = new DirectoryInfo("./");


    //Get the number of files available
    public void CountFiles()
    {

        //number of files
        FileInfo[] TXTFile = di.GetFiles("*.txt");
        noOfFiles = TXTFile.Length;

        //if there are no files
        if (noOfFiles == 0 ) {

            counter = 0;
        }
        //if there are files
        else {

            counter = noOfFiles - 1;

        }

    }

    //if previous button clicked
    public void PressPrevious()
    {
        counter++;

        points.Clear();

        ButtonState();
    }

    //if next button clicked
    public void PressNext()
    {
        counter--;

        points.Clear();

        ButtonState();
    }

    //Review the state of the button to determine if the next and previous buttons should be enabled or not
    public void ButtonState()
    {

            //if more files than 1
            if (noOfFiles > 1)
            {

                //if we are on the last file
                if (counter == noOfFiles - 1)
                {

                    previousButton.SetActive(false);

                }
                //any time not on the last file
                else
                {

                    previousButton.SetActive(true);

                }

                //if we are not on the first file
                if (counter != 0)
                {

                    nextButton.SetActive(true);

                }
                //if we are on the first file
                else
                {

                    nextButton.SetActive(false);

                }

            }
            //if we have only 1 file or no files
            else
            {
                nextButton.SetActive(false);
                previousButton.SetActive(false);
            }


            //Read the current file
            ReadFromFile();

    }

    public void ReadFromFile() {

        if (noOfFiles > 0)
        {

            //initialise our file
            string[] split = { "0","0","0"};

            //read all the lines from the current file
            string[] lines = System.IO.File.ReadAllLines(@"./Coordinates"+counter+".txt");

            //iterate through the file
            for (int i = 0; i < lines.Length-1; i++)
            {
                //split the lines by empty spaces
                split = lines[i].Split(' ');

                //add the coordinates to a list
                points.Add(new Coordinates(float.Parse(split[0]), float.Parse(split[1]), float.Parse(split[2])));

            }

        }

    }

    public static  List<Coordinates> GetPoints() {

        return points;

    }

    public void Active() {

        //if we are active after clicking the history button and intend to view history
        if (clickCondition == false)
        {

            counter = 0;

            ButtonState();

            clickCondition = true;
        }
        //if we want to view live casts
        else {

            clickCondition = false;

        }

    }


}
