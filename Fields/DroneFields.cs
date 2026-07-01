namespace IntelligencePipeline.Fields.Drone;
class DroneFields
{
    public int _altitude { get; private set; }
    public int _imageQuality { get; private set; }


    public void setData()
    {
        setAltitud();
        setImageQ();
    }

    protected void setAltitud()
    {
        Console.WriteLine("Enter the altitude (100 - 10000): ");
        string altitude = Console.ReadLine();
        int dbaltitude;
        while (!int.TryParse(altitude, out dbaltitude))
        {
            Console.WriteLine("Wrong Format, Try Again. Enter the altitude (100 - 10000): ");
            altitude = Console.ReadLine();
        }
        _altitude = dbaltitude;
    }

    protected void setImageQ()
    {
        Console.WriteLine("Enter the Image Quality (1 - 100): ");
        string ImageQ = Console.ReadLine();
        int dbImageQ;
        while (!int.TryParse(ImageQ, out dbImageQ))
        {
            Console.WriteLine("Wrong Format, Try Again. Enter the Image Quality (1 - 100): ");
            ImageQ = Console.ReadLine();
        }
        _imageQuality = dbImageQ;
    }
}
