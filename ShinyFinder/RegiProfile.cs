using System.Diagnostics;
using OpenCvSharp;

namespace ShinyFinder
{
    class RegiProfile:IPokeProfile
    {
        GameController gc = null;
        int battleTime;
        int messageBoxCount;
        Stopwatch sw;
        public RegiProfile(GameController gc)
        {
            this.gc = gc;
            sw = new Stopwatch();
            battleTime = 14000;
        }

        public int getBattleTime()
        {
            return battleTime;
        }
        public void start()
        {
            for (int i = 0; i < 3; i++) gc.pressAndRelease(ButtonType.A, 500);
           
        }

        public void reset()
        {
            
        }

        public bool detect(Mat frame)
        {
            bool shiny = false;
            /*
            OpenCvSharp.Rect windowRect = new OpenCvSharp.Rect(0, 575, 1280, 125);
            Mat dst = new Mat(frame, windowRect);
            Cv2.CvtColor(dst, dst, ColorConversionCodes.BGR2HSV, 3);
            dst = Cv2.Split(dst)[2];//明度
                                    //Cv2.InRange(dst, new Scalar(0), new Scalar(30), dst);

            Mat tmp = new Mat();
            Cv2.MeanStdDev(dst, tmp, dst);
            tmp.Dispose();
            double std = frame.At<double>(0, 0);
            if (std < 1) Debug.Print("std:" + std);
            //double dist = std - prevStd;

            if (std < 1)
            {
                if (messageBoxCount == 0)
                {
                    sw.Start();
                    messageBoxCount++;
                }
                else if(messageBoxCount == 1)
                {
                    sw.Stop();
                    if (sw.ElapsedMilliseconds > 4000) shiny = true;//色のときは約4500ms
                    Debug.Print("time:" + sw.ElapsedMilliseconds);
                    sw.Reset();
                    
                }
            }
            */
            return shiny;
        }
    }
}

/*   private void GetFrame()
          {

              bool firstWindow = false;
              Stopwatch sw = new Stopwatch();
              int brightnessMean = 0;
              int beforeMean = 0;
              Thread.CurrentThread.Name = "ImageThread";
              Debug.Print(Thread.CurrentThread.Name.ToString());

              Mat noSignal = new Mat(@"D:\Dev\ShinyFinder\ShinyFinder\ERzLaMAUwAAUnW4.jpg");


              //OpenCvSharp.Point p = new OpenCvSharp.Point(windowP.X, windowP.Y);
              OpenCvSharp.Rect windowRect = new OpenCvSharp.Rect(0, 575, 1280, 125);



              while (true)
              {
                  using (Mat frameMat = capture.RetrieveMat())
                  {

                      if (!frameMat.Empty())
                      {
                          Mat dst = frameMat;



                          Dispatcher.Invoke(() =>
                          {
                              FrameImage.Source = dst.ToWriteableBitmap();
                          });
                          dst = new Mat(dst, windowRect);
                          Cv2.CvtColor(dst, dst, ColorConversionCodes.BGR2HSV, 3);
                          dst = Cv2.Split(dst)[2];//明度
                          Cv2.InRange(dst, new Scalar(0), new Scalar(30), dst);
                          brightnessMean = (int)dst.Sum()[0] / (dst.Height * dst.Width);
                          int diff = brightnessMean - beforeMean;

                          isShiny = DetectShiny(diff, ref firstWindow, sw);

                          if (isShiny)
                          {
                              Debug.Print("SHINY!!!");
                              Dispatcher.Invoke(() => message.Items.Add("SHINY!!!!!!!!!!!!!!!!!!!!!!!!!"));
                              //コントローラーストップ
                              break;
                          }
                          //zikannkeisokusyorigahairu


                          //Cv2.Rectangle(dst, windowRect, Scalar.Red, 3, LineTypes.Link8);

                          beforeMean = brightnessMean;

                          Dispatcher.Invoke(() =>
                          {
                              ProcessedImage.Source = dst.ToWriteableBitmap();
                          });
                          dst.Dispose();
                      }
                      else
                      {
                          Dispatcher.Invoke(() =>
                          {
                              FrameImage.Source = noSignal.ToWriteableBitmap();
                              ProcessedImage.Source = noSignal.ToWriteableBitmap();
                          });
                      }
                  }
                  Thread.Sleep(30);
              }


          }*/






//private void StartRegi()
//{
//    //コントローラースタート＆色判定スタート

//    for (int i = 0; i < 3; i++) pressAndRelease(ButtonType.A, 500);
//    inGame = true;


//}
/*private void RestertRegi()
{
    if (!isShiny)
    {
        inGame = false;
        pressAndRelease(ButtonType.HOME, 1000);
        pressAndRelease(ButtonType.X, 500);
        pressAndRelease(ButtonType.A, 2500);
        pressAndRelease(ButtonType.A, 1000);
        pressAndRelease(ButtonType.A, 500);
        Thread.Sleep(13000);
        pressAndRelease(ButtonType.A, 500);
        Thread.Sleep(4000);

        for (int i = 0; i < 3; i++) pressAndRelease(ButtonType.A, 500);
        inGame = true;

    }
}*/