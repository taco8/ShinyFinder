using System.Diagnostics;
using System.Threading;
using OpenCvSharp;

namespace ShinyFinder
{
    internal class ShinyDetector
    {
        private readonly VideoCapture capture;
        private bool running;
        private bool shiny;
        private IPokeProfile profile;
        private string profileName;
        private string portName;
        private  Mat frame;
        private Stopwatch sw;
        private GameController gc;



        //MainWindow mw;

        public ShinyDetector()
        {
            running = false;
            shiny = false;
           

            frame = new Mat();
            capture = new VideoCapture();
            
            sw = new Stopwatch();
        }

        public bool Initialize()
        {
            bool result = true;
            
            capture.Open(1, VideoCaptureAPIs.ANY);
            if (capture.IsOpened())
            {
                capture.Set(3, 1280);
                capture.Set(4, 720);
            }
            else
            {
                result = false;
            }
            return result;


        }
       public bool getRunning()
        {
            return running;
        }
        public void setRunning(bool a)
        {
            running = a;
        }
        public void setProfileName(string profileName)
        {
            this.profileName = profileName;
        }

        public void setPortName(string portName)
        {
            this.portName = portName;
        }
        public void updateFrame()
        {
            Mat frameMat = capture.RetrieveMat();
            if (frameMat.Empty())
            {
                frameMat = Cv2.ImRead(@"Images\NoSignal.jpg");
            }
            //OpenCvSharp.Rect area = new OpenCvSharp.Rect(80, 583, 1130, 118);
            //Cv2.Rectangle(frameMat, area, Scalar.Blue, 3);
            frame = frameMat;
        }

        public Mat getFrame()
        {

            return frame;
        }
       
        private bool DetectShiny()
        {
            bool result;
            result = profile.detect(frame.Clone()); 
            return result;
        }

        public bool run()
        {
            gc = new GameController(portName);
            gc.BeginSerial();
            Stopwatch sw2 = new Stopwatch();
            switch (profileName)
            {
                case "BDSPシェイミ":
                    profile = new ShaminProfile(gc);
                    break;
                case "SSHレジ系":
                    profile = new RegiProfile(gc);
                    break;
            }
            Thread.Sleep(10000);
            while (running && !shiny)
            {
                Debug.Print("start");
                profile.start();
                
                sw2.Restart();
                while (sw2.ElapsedMilliseconds < profile.getBattleTime() && !shiny)
                {
                    
                    shiny = DetectShiny();
                    Thread.Sleep(250);
                }

                if (!shiny)
                {
                    Debug.Print("reset");
                    profile.reset();
                }
            }
            return shiny;
        }

        public void release()
        {
            gc.release();
            
        }
    }
}
