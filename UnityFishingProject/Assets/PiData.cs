using UnityEngine;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine.UI;

public class PiData : MonoBehaviour {

	  //Use port 5000 - Same on our Pi
	private const int port = 5000;
	
	
	  //Using UDP Client, We dont need a socket Just collect the data if its offered
    private UdpClient client;

		//Use the Ip and port as End Point
	private IPEndPoint ep;


    //For testing purposes
    public Text name_text;

	//variables for storing and passing acceleration to our object
	public static int accelerationOfX = 0;
	public static int accelerationOfY = 0;
	public static int accelerationOfZ = 0;

	//variables to store our readings
	public static int[] previousReading = {0,0,0};
	public static string[] currentReading;

	//Variables used to calculate time
	public TimeSpan initalTime;
	public static TimeSpan difference;


    void Start()
    {

        // Open our client
        client = new UdpClient(port);

		//end point
		ep = new IPEndPoint(IPAddress.Any, port);

		//Incoming data variable
		var receivedData = client.Receive(ref ep);

		if(receivedData != null)
		{
			//Seperate the Incomming byte(converted to string), into seperate values
			currentReading = Encoding.ASCII.GetString(receivedData).Split(' ', '\t');

			//Initial readings from the incoming data
			previousReading[0] = (int)Double.Parse(currentReading[0]);
			previousReading[1] = (int)Double.Parse(currentReading[1]);
			previousReading[2] = (int)Double.Parse(currentReading[2]);

			//initial time taken from the incoming data
			initalTime = TimeSpan.Parse(currentReading[3]);

		}

    }

    void Update()
    {

        try
        {

            //Collect Data from Our UDP stream
            var receivedData = client.Receive(ref ep);

			if(receivedData != null)
			{
				//Difference in time from the latest reading and the new reading.
				difference = DateTime.Now.TimeOfDay - initalTime;

				//Seperate the Incomming byte(converted to string), into seperate values
				currentReading = Encoding.ASCII.GetString(receivedData).Split(' ', '\t');

				//3 Axis for X,Y and Z
				accelerationOfX = (int)Double.Parse(currentReading[0]) - previousReading[0];
				accelerationOfY = (int)Double.Parse(currentReading[1]) - previousReading[1];
				accelerationOfZ = (int)Double.Parse(currentReading[2]) - previousReading[2];

	            //For Testing purpose - Sets a Text object to a string of the incoming Data
				this.name_text.text = accelerationOfX +"\n" +accelerationOfY +"\n" +accelerationOfZ +"\n"+"\n"+difference;

				//Make the new initial time = the time the reading that was taken
				initalTime = TimeSpan.Parse(currentReading[3]);

			}
		
        }
        catch (Exception)
        {
            //For testing purpose - sets the text object to error if we collect no data 
            this.name_text.text = "Error";
        }

    }

}