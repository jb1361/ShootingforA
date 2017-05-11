using System.Timers;
using System;
public class Timer {
    public bool done { get; set; }


    public Timer()  { timer(10.0f); }
    public Timer(double i) { timer(i); }

    private void timer(double i)
    {
        done = false;
        System.Timers.Timer clock = new System.Timers.Timer(i);
        clock.Elapsed += new ElapsedEventHandler(timerElapsed);
        clock.Interval = i;
        clock.Enabled = true;
    }

    private void timerElapsed(object sender, ElapsedEventArgs e)
    {
        done = true;
    }

 

}
