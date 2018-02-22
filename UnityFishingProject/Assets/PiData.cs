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

    //For testing purposes
    public Text name_text;

    void Start()
    {

        // Open our client
        client = new UdpClient(5000);

    }


    void Update()
    {

        try
        {
			//Use the Ip and port as End Point
			IPEndPoint ep = new IPEndPoint(ip, 5000);

            //Collect Data from Our UDP stream
            var receivedData = client.Receive(ref ep);

			if(receivedData != null)
			{
            //For Testing purpose - Sets a Text object to a string of the incoming Data
            this.name_text.text = Encoding.ASCII.GetString(receivedData);
			}

        }
        catch (Exception)
        {
            //For testing purpose - sets the text object to error if we collect no data 
            this.name_text.text = "Error";
        }

    }

}