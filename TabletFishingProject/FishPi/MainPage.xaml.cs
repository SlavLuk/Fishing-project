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

        public MainPage()
        {
            this.InitializeComponent();

            Loaded += Start;
        }

        private void Start(object sender, RoutedEventArgs e)
        {
            //Ip address and port number of our unity build
            string ip = "192.168.43.169";
            int port = 5000;

            //our endpoint
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ip), port);

            //UDP socket
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            //udp client on port 5000
            UdpClient udpClient = new UdpClient(5000);

            while (true)
            {
                _accelerometer = Accelerometer.GetDefault();


                if (_accelerometer != null)
                {

                    AccelerometerReading reading = _accelerometer.GetCurrentReading();

                    //The data we will send over the network
                    string data =  reading.AccelerationX.ToString()+"\n "
                                    + reading.AccelerationY.ToString() + "\n "
                                    + reading.AccelerationZ.ToString() + "\n ";

                    //Byte array to package our data
                    byte[] sendBytes = Encoding.ASCII.GetBytes(data);
                    //Send the data using a udpclient with our endpoint
                    client.SendTo(sendBytes, ep);

                    Task.Delay(200).Wait();
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
