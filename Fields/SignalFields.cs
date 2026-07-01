namespace IntelligencePipeline.Fields.Signal;
using IntelligencePipeline.Models.Enums;

class SignalFields
{
    public double _frequency { get; private set; }
    public string _content { get; private set; }
    public Language  _language { get; private set; }
    public int _signalstrength { get; private set; }


    public void setData()
    {
        setFrequency();
        setContent();
        setLanguage();
        setSignalstrength();
    }

    protected void setFrequency()
    {
        Console.WriteLine("Enter the frequency (1.0-3000.0): ");
        string frequency = Console.ReadLine();
        double dbfrequency;
        while (!double.TryParse(frequency, out dbfrequency))
        {
            Console.WriteLine("Wrong Format, Try Again. Enter the frequency (1.0-3000.0): ");
            frequency = Console.ReadLine();
        }
        _frequency = dbfrequency;
    }

    protected void setContent()
    {
        Console.WriteLine("Enter the contant (5-1000 chars): ");
        string content = Console.ReadLine();
        _content = content;
    }

    protected void setUnit()
    {
        Console.WriteLine("Enter the unit (2-50 charss): ");
        string unit = Console.ReadLine();
        _unit = unit;
    }

    protected void setConf()
    {
        Console.WriteLine("Enter the confidance level (1-5): ");
        string conflevel = Console.ReadLine();
        int dbconflevel;
        while (!int.TryParse(conflevel, out dbconflevel))
        {
            Console.WriteLine("Wrong Format, Try Again. Enter the confidance level (1-5): ");
            conflevel = Console.ReadLine();
        }
        _confidencelevel = dbconflevel;
    }
}
