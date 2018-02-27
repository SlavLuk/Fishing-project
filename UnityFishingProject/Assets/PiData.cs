using UnityEngine;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine.UI;

public class PiData : MonoBehaviour {


    //Read from any IP Address
	IPAddress ip = IPAddress.Any;

    //Use port 5000 - Same on our Pi
    const int port = 5000;

    //Using UDP Client, We dont need a socket Just collect the data if its offered
    UdpClient client = new UdpClient(port);

	//Use the Ip and port as End Point
	IPEndPoint ep;

    //For testing purposes
    public Text name_text;

	public static int changeInX = 0;
	public static int changeInY = 0;
	public static int changeInZ = 0;

	public static int[] previousReading = {0,0,0};
	public static string[] currentReading;

    void Start()
    {

        // Open our client
        client = new UdpClient(port);

		ep = new IPEndPoint(ip, port);

		var receivedData = client.Receive(ref ep);

		if(receivedData != null)
		{
			currentReading = Encoding.ASCII.GetString(receivedData).Split(' ', '\t');

			previousReading[0] = (int)Double.Parse(currentReading[0]);
			previousReading[1] = (int)Double.Parse(currentReading[1]);
			previousReading[2] = (int)Double.Parse(currentReading[2]);

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
				currentReading = Encoding.ASCII.GetString(receivedData).Split(' ', '\t');

				changeInX = (int)Double.Parse(currentReading[0]) - previousReading[0];
				changeInY = (int)Double.Parse(currentReading[1]) - previousReading[1];
				changeInZ = (int)Double.Parse(currentReading[2]) - previousReading[2];

	            //For Testing purpose - Sets a Text object to a string of the incoming Data
				this.name_text.text = changeInX +"\n" +changeInY +"\n" +changeInZ;

			}
		
        }
        catch (Exception)
        {
            //For testing purpose - sets the text object to error if we collect no data 
            this.name_text.text = "Error";
        }

    }

}