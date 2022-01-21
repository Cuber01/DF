namespace DF.Framework
{
    public class Timer
    {
        private int timer1;
        private int timer2;

        private readonly int maxTimer1;
        private readonly int maxTimer2;
        
        public bool oneIsRunning = true;

        public Timer(int maxTimer1, int maxTimer2)
        {
            this.maxTimer1 = maxTimer1;
            this.maxTimer2 = maxTimer2;

            timer1 = maxTimer1;
        }
        
        public void update()
        {
            if (oneIsRunning)
            {
                update1();
            }
            else
            {
                update2();
            }
        }

        private void update1()
        {
            if (timer1 > 0)
            {
                timer1--;
            }
            else
            {
                timer2 = maxTimer2;
                oneIsRunning = false;
            }
        }

        private void update2()
        {
            if (timer2 > 0)
            {
                timer2--;
            }
            else
            {
                timer1 = maxTimer1;
                oneIsRunning = true;
            }
        }
    }
}