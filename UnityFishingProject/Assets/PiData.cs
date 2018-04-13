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
	public static double gyroX = 0;
    public static double gyroY = 0;
    public static double gyroZ = 0;

    //variables to store our readings
    public static string[] currentReading;


    void Start()
    {

        // Open our client
        client = new UdpClient(port);

		//end point
		ep = new IPEndPoint(IPAddress.Any, port);

		//Incoming data variable
		var receivedData = client.Receive(ref ep);


    }

    void Update()
    {

        try
        {

            //Collect Data from Our UDP stream
            var receivedData = client.Receive(ref ep);

			if(receivedData != null)
			{

				//Seperate the Incomming byte(converted to string), into seperate values
				currentReading = Encoding.ASCII.GetString(receivedData).Split(' ', '\t');
                if (accelerationOfX <= 0 || accelerationOfX >= 0)
                {
                    //3 Axis for X,Y and Z
                    accelerationOfX = (int)Double.Parse(currentReading[0]);
                    accelerationOfY = (int)Double.Parse(currentReading[1]);
                    accelerationOfZ = (int)Double.Parse(currentReading[2]);

                    gyroX = Double.Parse(currentReading[3]);
                    gyroY = Double.Parse(currentReading[4]);
                    gyroZ = Double.Parse(currentReading[5]);


                    //For Testing purpose - Sets a Text object to a string of the incoming Data
                    this.name_text.text = accelerationOfX + "\n" + accelerationOfY + "\n" + accelerationOfZ + "\n"
                        + gyroX + "\n" + gyroY + "\n" + gyroZ;

                }
                else {

                    //For Testing purpose - Sets a Text object to a string of the incoming Data
                    this.name_text.text = "Error, No Reading";

                    //3 Axis for X,Y and Z
                    accelerationOfX = 0;
                    accelerationOfY = 0;
                    accelerationOfZ = 0;

                    gyroX = 0;
                    gyroY = 0;
                    gyroZ = 0;
                }

			}
		
        }
        catch (Exception e)
        {
            //For testing purpose - sets the text object to error if we collect no data 
            this.name_text.text = "Error " +e;

        }

    }

}