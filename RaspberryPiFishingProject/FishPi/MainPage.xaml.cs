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

        private ISenseHat _senseHat { get; set; }
        private string ip = "192.168.137.1";
		private  int port = 5000;

        public MainPage()
        {
            this.InitializeComponent();


            Loaded += Start;
        }

        private async void Start(object sender, RoutedEventArgs e)
        {

            //our endpoint
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ip), port);

            //UDP socket
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            //get our sense hat
            _senseHat = await GetSenseHatAsync();


            //udp client on port 5000
            UdpClient udpClient = new UdpClient(port);

            while (true)
            {
                Debug.WriteLine("TESTS");

                //Update the data from the IMU sensor
                _senseHat.Sensors.ImuSensor.Update();

                 
                //If there is an acceleration value
                if (_senseHat.Sensors.Acceleration.HasValue)
                {

                    //The data we will send over the network
                    string data =  (_senseHat.Sensors.Acceleration.Value.X * 10).ToString()
                        + "\n "
                        + (_senseHat.Sensors.Acceleration.Value.Y * 10).ToString()
                        + "\n "
                        + (_senseHat.Sensors.Acceleration.Value.Z * 10).ToString();

                    Debug.WriteLine(data);

                    //Byte array to package our data
                    byte[] sendBytes = Encoding.ASCII.GetBytes(data);
                    //Send the data using a udpclient with our endpoint
                    client.SendTo(sendBytes, ep);

                    Task.Delay(200).Wait();

                }
                //if there is no acceleration value
                else
                {
                    Debug.WriteLine("Error");

                    //Wait and try again
                    Task.Delay(500).Wait();

                }

            }

        }

        private async Task<ISenseHat> GetSenseHatAsync() {

            Task<ISenseHat> task = Task.Run(async() => 
            {

                return await SenseHatFactory.GetSenseHat();

            });

            task.Wait(); 

            return await task;

        }

    }
}