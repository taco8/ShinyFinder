using OpenCvSharp.WpfExtensions;
using System;
using System.ComponentModel;
using System.IO.Ports;
using System.Threading.Tasks;
using System.Windows;

namespace ShinyFinder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        ShinyDetector sd;
  
        public MainWindow()
        {
            InitializeComponent();
            sd = new ShinyDetector();
        }

  
        private void MainWindow_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            sd.Initialize();
            GetSerialPort();
            GetPokeProfiles();
            Task drawTask = Task.Run(() =>
            {
                while (true)
                {
                    Draw();
                }
            });
        }

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            sd.release();
        }
        private void Draw()
        {
            sd.updateFrame();
            
            Dispatcher.Invoke(() =>
            {
                FrameImage.Source = sd.getFrame().ToWriteableBitmap();
            });
            
        }
        private void GetSerialPort()
        {
            string[] portNames = SerialPort.GetPortNames();

            for (int i = 0; i < portNames.Length; i++)
            {
                portCmb.Items.Add(portNames[i]);
                
            }
            portCmb.SelectedIndex = 0;
        }
        private void GetPokeProfiles()
        {
            string[] profileNames = Enum.GetNames(typeof(PokeProfiles));
            
            for(int i = 0; i < profileNames.Length; i++)
            {
                profileCmb.Items.Add(profileNames[i]);
            }
            profileCmb.SelectedIndex = 0;
        }
        private void ButtonIsClicked(object sender, RoutedEventArgs e)
        {
            
            if (!sd.getRunning())
            {                
                sd.setRunning(true);
                sd.setProfileName(profileCmb.Text);
                sd.setPortName(portCmb.Text);              
                startButton.Content = "STOP";
                
                Task.Run(() => {
                    sd.run();
                    });
            }
            else
            {
                sd.setRunning(false);
                sd.release();
                startButton.Content = "START";
            }
           
        }
        private void AisPressed(object sender, RoutedEventArgs e)
        {
            
        }
        private void BisPressed(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
