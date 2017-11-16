
public class ClockTime
{
    public ClockTime(int h,int m,int s)
    {
        hour = h;
        min = m;
        sec = s;
    }

    public ClockTime(int s){
        hour = s / 3600;
        min = (s % 3600) / 60;
        sec = s % 60;
    }

    private int hour;
    private int min;
    private int sec;

    public string GetClockTime(){
        string s;
        s = hour > 10 ? hour.ToString() : "0" + hour;
        s += ":";
        s += min > 10 ? min.ToString() : "0" + min;
        s+=":";
        s += sec > 10 ? sec.ToString() : "0" + sec;
        return s;
    }

}


