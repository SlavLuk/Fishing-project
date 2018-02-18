using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Devices.Sensors;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FishPi
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            Start();
        }

        static void Start()
        {

            Accelerometer _accerometer = Accelerometer.GetDefault();

            UdpClient udpClient = new UdpClient(5000);

            string ip = "192.168.0.5";
            int port = 5000;

            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ip), port);

            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            while (true)
            {

                AccelerometerReading reading = _accerometer.GetCurrentReading();

                string data = "x: " +reading.AccelerationX +"/n"
                             +"Y: " +reading.AccelerationY +"/n"
                             +"Z: " +reading.AccelerationZ;

                byte[] sendBytes = Encoding.ASCII.GetBytes(data);
                client.SendTo(sendBytes, ep);

            }

        }
    }
}
