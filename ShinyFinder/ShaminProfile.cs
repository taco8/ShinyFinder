using System.Diagnostics;
using System.Threading;
using OpenCvSharp;

namespace ShinyFinder
{
    internal class ShaminProfile: IPokeProfile
    {
        private GameController gc;
        private int battleTime;
        private Stopwatch sw;
        private int messageBoxCount;
        private OpenCvSharp.Rect area;
        private double preMean;
       
        public ShaminProfile(GameController gc)
        {
            this.gc = gc;
            sw = new Stopwatch();
            battleTime = 12000;
            preMean = 200;
            area = new OpenCvSharp.Rect(80, 583, 1130, 118);
        }
        
        public int getBattleTime()
        {
            return battleTime;
        }
        public void start()
        {
            messageBoxCount = 0;
            gc.pressAndRelease(ButtonType.A, 500);
            Thread.Sleep(6000);
            gc.pressAndRelease(ButtonType.A, 500);
            Thread.Sleep(7000);
            
        }
        public void reset()
        {
            //逃げる処理
            for(int i = 0; i < 3; i++)
            {
                gc.pressAndRelease(ButtonType.DOWN, 500);
            }
            gc.pressAndRelease(ButtonType.A, 500);
            Thread.Sleep(4500);
            gc.pressAndRelease(ButtonType.A, 500);
            //海割れの道まで往復
            gc.pressButton(ButtonType.B);
            Thread.Sleep(100);
            gc.pressButton(ButtonType.DOWN);
            Thread.Sleep(3500);
            gc.releaseButton(ButtonType.DOWN);
            Thread.Sleep(100);
            gc.pressButton(ButtonType.UP);
            Thread.Sleep(4500);
            gc.releaseButton(ButtonType.UP);
            Thread.Sleep(100);
            gc.releaseButton(ButtonType.B);
            Thread.Sleep(500);
        }

        public bool detect(Mat frame)
        {
            bool shiny = false;
            
            Mat dst = new Mat(frame, area);
            //Cv2.CvtColor(dst, dst, ColorConversionCodes.BGR2HSV, 3);
            //dst = Cv2.Split(dst)[2];//Redを抽出
            //Cv2.InRange(dst, new Scalar(0), new Scalar(30), dst);

            Mat meanMat = new Mat();
            Mat stdMat = new Mat();
            Cv2.MeanStdDev(dst, meanMat, stdMat);
            double mean = meanMat.At<double>(0,0);
            double std = stdMat.At<double>(0, 0);
            
            Debug.Print("mean" + mean);
            
            double meanDiff = mean - preMean;

            Debug.Print("dif" + meanDiff);
            if (mean > 225 && meanDiff > 30 )
            {
               
                if(messageBoxCount == 0)//野生のシェイミがあらわれた
                {
                    sw.Start();
                    messageBoxCount++;
                    Debug.Print("firstMB");
                }
                else if(messageBoxCount == 1)//いけhogehoge
                {
                    messageBoxCount++;
                    sw.Stop();
                    if (sw.ElapsedMilliseconds > 4000)
                    {
                        shiny = true; //通常2264ms 色のときは約4900ms
                        Debug.Print("shiny!!!!");
                    }
                    Debug.Print("time:" + sw.ElapsedMilliseconds);
                    sw.Reset();
                    Debug.Print("secondMB");
                }
            }
            preMean = mean;
          
            meanMat.Dispose();
            stdMat.Dispose();
            dst.Dispose();
            frame.Dispose();
            return shiny;
        }
    }
}
