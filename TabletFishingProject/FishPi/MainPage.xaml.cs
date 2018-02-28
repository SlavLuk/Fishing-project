using System.Net;
using System.Net.Sockets;
using System.Text;
using Windows.Devices.Sensors;
using Windows.UI.Xaml.Controls;
using Emmellsoft.IoT.Rpi.SenseHat;
using Windows.UI.Xaml;
using System;
using System.Threading.Tasks;
using Windows.Devices.Enumeration;
using Windows.Devices.I2c;
using System.Diagnostics;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FishPi
{

    public sealed partial class MainPage : Page
    {
        private Accelerometer _accelerometer;
        private Gyrometer _gyrometer;
        private Magnetometer _magnetometer;

        //UDP socket
        Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

        //Ip address and port number of our unity build
        string ip = "127.0.0.1";
        int port = 5000;
        EndPoint ep;

        public MainPage()
        {
            //Default accelerometer
            _accelerometer = Accelerometer.GetDefault();
            _gyrometer = Gyrometer.GetDefault();
            _magnetometer = Magnetometer.GetDefault();

            //our endpoint
            ep = new IPEndPoint(IPAddress.Parse(ip), port);

            Loaded += Start;

        }

        private void Start(object sender, RoutedEventArgs e)
        {

            while (true)
            {

                if (_accelerometer != null)
                {
                    try
                    {
                        //Read the accelerometer
                        AccelerometerReading readingAccel = _accelerometer.GetCurrentReading();

                        //The data we will send over the network
                        string data = (readingAccel.AccelerationX * 10).ToString() + "\n "
                                        + (readingAccel.AccelerationY * 10).ToString() + "\n "
                                        + (readingAccel.AccelerationZ * 10).ToString() + "\n "
                                        + DateTime.Now.TimeOfDay;

                        //Byte array to package our data
                        byte[] sendBytes = Encoding.ASCII.GetBytes(data);
                        //Send the data using a udpclient with our endpoint
                        client.SendTo(sendBytes, ep);

                        Task.Delay(200).Wait();
                    }
                    catch (Exception) {
                        Debug.WriteLine("Failed to send");
                    }
                }
                //if there is no acceleration value
                else
                {
                    //Wait and try again
                    Task.Delay(500).Wait();

                }

            }

        }
    }

}
