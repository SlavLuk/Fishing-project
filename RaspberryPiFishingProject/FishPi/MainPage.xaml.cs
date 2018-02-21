using System.Net;
using System.Net.Sockets;
using System.Text;
using Windows.Devices.Sensors;
using Windows.UI.Xaml.Controls;
using Emmellsoft.IoT.Rpi.SenseHat;
using Windows.UI.Xaml;
using System;
using System.Threading.Tasks;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FishPi
{

    public sealed partial class MainPage : Page
    {

        private ISenseHat _senseHat { get; set; }

        public MainPage()
        {
            this.InitializeComponent();
            Loaded += Start;
        }

        private async void Start(object sender, RoutedEventArgs e)
        {
            //get our sense hat
            _senseHat = await GetSenseHatAsync();

            //udp client on port 5000
            UdpClient udpClient = new UdpClient(5000);

            //Ip address and port number of our unity build
            string ip = "192.168.137.89";
            int port = 5000;

            //our endpoint
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ip), port);

            //UDP socket
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            while (true)
            {
                //Update the data from the IMU sensor
                _senseHat.Sensors.ImuSensor.Update();

                //If there is an acceleration value
                if (_senseHat.Sensors.Acceleration.HasValue)
                {
                    //The data we will send over the network
                    string data = "Accelerometer\nX: "
                        +(_senseHat.Sensors.Acceleration.Value.X * 10).ToString()
                        +"\nY: "
                        + (_senseHat.Sensors.Acceleration.Value.Y * 10).ToString()
                        +"\nZ: "
                        +(_senseHat.Sensors.Acceleration.Value.Z * 10).ToString()
                        +" \n\nGyroscope"
                        +"\nX: "
                        +(_senseHat.Sensors.Gyro.Value.X).ToString()
                        + "\nY: "
                        + (_senseHat.Sensors.Gyro.Value.Y).ToString()
                        + "\nZ: "
                        + (_senseHat.Sensors.Gyro.Value.Z).ToString()
                        ;

                    //Byte array to package our data
                    byte[] sendBytes = Encoding.ASCII.GetBytes(data);
                    //Send the data using a udpclient with our endpoint
                    client.SendTo(sendBytes, ep);

                    Task.Delay(20).Wait();

                }
                //if there is no acceleration value
                else
                {
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
