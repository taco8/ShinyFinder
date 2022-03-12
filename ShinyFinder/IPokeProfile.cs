using OpenCvSharp;

namespace ShinyFinder
{
    interface IPokeProfile
    {
        public int getBattleTime();
        public abstract void start();
        public abstract void reset();
     public abstract bool detect(Mat frame);
    }
}
