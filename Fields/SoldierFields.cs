namespace IntelligencePipeline.Fields.Soldier;

class SoldierFields
{
    public string _soldiername{ get; private set; }
    public string _soldierid { get; private set; }
    public string _unit { get; private set; }
    public int _confidencelevel { get; private set; }


    public void setData()
    {
        setSoldiername();
        setSoldierid();
        setUnit();
        setConf();
    }

    protected void setSoldiername()
    {
        Console.WriteLine("Enter the soldier name (2-50 chars): ");
        string name = Console.ReadLine();
        _soldiername = name;
    }

    protected void setSoldierid()
    {
        Console.WriteLine("Enter the soldier id (7 digits): ");
        string id = Console.ReadLine();
        _soldierid = id;
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
