using IntelligencePipeline.Models.Reports;
using IntelligencePipeline.Pipeline;
using IntelligencePipeline.Storage;
using IntelligencePipeline.Fields.Common;
using IntelligencePipeline.Fields.Drone;
using IntelligencePipeline.Fields.Radar;
using IntelligencePipeline.Fields.Soldier;




class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("===Welcom to report storage===");
        Console.WriteLine("""
            To create a report - 1
            To get and search reports - 2
            """);
        string choice1 = Console.ReadLine();

        if (choice1 == "1")
        {
            addReport();
        }

    }

    private static void DisplayReport(Report report)
    {

    }

    private static void DisplayValidatedReports(List<Report> repository)
    {
        foreach (Report report in repository)
        {
            Console.WriteLine(report);
        }
    }


    private static void DisplayRejectedReports(List<Report> rejRepository)
    {
        foreach (Report rejReport in rejRepository)
        {
            Console.WriteLine(rejReport);
        }
    }

    protected static void addReport()
    {
        Console.WriteLine("""
            for Drone report - 1
            for Soldier Report - 2
            for Signal Report - 3
            for Radar Report - 4
            """);
        string choice2 = Console.ReadLine();

        CommonFields common = new CommonFields();
        common.setData();
        ReportPipeline pip = new ReportPipeline();

        if (choice2 == "1")
        { 
            DroneFields dronefields = new DroneFields();
            dronefields.setData();
            DroneReport report = new DroneReport(pip.NextReportId, common._timestamp, common._latitude, common._longitude, common._desc,
                dronefields._altitude, dronefields._imageQuality);
            pip.ProcessReport(report);
            pip.DisplayStatistics();
        }

        if (choice2 == "2")
        {
            SoldierFields soldierfields = new SoldierFields();
            soldierfields.setData();
            SoldierReport report = new SoldierReport(pip.NextReportId, common._timestamp, common._latitude, common._longitude, common._desc,
                soldierfields._soldiername, soldierfields._soldierid, soldierfields._unit, soldierfields._confidencelevel);
            pip.ProcessReport(report);
            pip.DisplayStatistics();
        }



        if (choice2 == "4")
        {
            RadarFields radarfields = new RadarFields();
            radarfields.setData();
            RadarReport report = new RadarReport(pip.NextReportId, common._timestamp, common._latitude, common._longitude, common._desc,
                radarfields._speed, radarfields._direction, radarfields._distance);
            pip.ProcessReport(report);
            pip.DisplayStatistics();
        }
    }
}