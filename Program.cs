using IntelligencePipeline.Models.Reports;
using IntelligencePipeline.Pipeline;

class Program
{
    static void Main()
    {
        DroneReport drone = new DroneReport(1, DateTime.Now, 33.0, 35.0, "shooting at peuple", 134, 50);
        Console.WriteLine(drone);
        ReportPipeline pip = new ReportPipeline();
        pip.ProcessReport(drone);
        Console.WriteLine(pip.NextReportId);
        pip.DisplayStatistics();
        //Console.WriteLine(pip.);
    }
}