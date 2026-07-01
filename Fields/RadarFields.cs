namespace IntelligencePipeline.Fields.Radar;

class RadarFields
{
    public int _speed { get; private set; }
    public int _direction { get; private set; }
    public int _distance { get; private set; }


    public void setData()
    {
        setSpeed();
        setDirection();
        setDistance();
    }

    protected void setSpeed()
    {
        Console.WriteLine("Enter the speed (0 - 2000): ");
        string speed = Console.ReadLine();
        int dbspeed;
        while (!int.TryParse(speed, out dbspeed))
        {
            Console.WriteLine("Wrong Format, Try Again. Enter the speed (0 - 2000): ");
            speed = Console.ReadLine();
        }
        _speed = dbspeed;
    }

    protected void setDirection()
    {
        Console.WriteLine("Enter the diraction (0 - 359): ");
        string direction = Console.ReadLine();
        int dbdirection;
        while (!int.TryParse(direction, out dbdirection))
        {
            Console.WriteLine("Wrong Format, Try Again. Enter the diraction (0 - 359): ");
            direction = Console.ReadLine();
        }
        _direction = dbdirection;
    }

    protected void setDistance()
    {
        Console.WriteLine("Enter the distance (100 - 100000): ");
        string distance = Console.ReadLine();
        int dbdistance;
        while (!int.TryParse(distance, out dbdistance))
        {
            Console.WriteLine("Wrong Format, Try Again. Enter the distance (100 - 100000): ");
            distance = Console.ReadLine();
        }
        _distance = dbdistance;
    }
}
