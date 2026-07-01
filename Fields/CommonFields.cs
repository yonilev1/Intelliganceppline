
namespace IntelligencePipeline.Fields.Common;

class CommonFields
{
    //int reportId, DateTime timestamp, double latitude, double longitude, string description
    public DateTime _timestamp { get; private set; }
    public double _latitude { get; private set; }
    public double _longitude { get; private set; }
    public string _desc { get; private set; }


    public void setData()
    {
        setTime();
        setLatitude();
        setLongitude();
        setDesc();
    }

    protected void setTime()
    {
        Console.WriteLine("Enter the date and time (in format yyyy-MM-dd HH:mm:ss): ");
        string time = Console.ReadLine();
        DateTime dtTime;
        while (!DateTime.TryParse(time, out dtTime))
        {
            Console.WriteLine("Wrong Format, Try Again. Enter the date and time (in format yyyy-MM-dd HH:mm:ss): ");
            time = Console.ReadLine();
        }
        _timestamp = dtTime;
    }

    protected void setLongitude()
    {
        Console.WriteLine("Enter the longitude (34.0 - 36.0): ");
        string longitude = Console.ReadLine();
        double dblongitude;
        while (!double.TryParse(longitude, out dblongitude))
        {
            Console.WriteLine("Wrong Format, Try Again. Enter the longitude (34.0 - 36.0): ");
            longitude = Console.ReadLine();
        }
        _longitude = dblongitude;
    }

    protected void setLatitude()
    {
        Console.WriteLine("Enter the latitude (29.5 - 33.5): ");
        string latitude = Console.ReadLine();
        double dblatitude;
        while (!double.TryParse(latitude, out dblatitude))
        {
            Console.WriteLine("Wrong Format, Try Again. Enter the latitude (29.5 - 33.5): ");
            latitude = Console.ReadLine();
        }
        _latitude = dblatitude;
    }

    protected void setDesc()
    {
        Console.WriteLine("Enter the Description (10-500 charechters): ");
        string desc = Console.ReadLine();
        _desc = desc;
    }
}