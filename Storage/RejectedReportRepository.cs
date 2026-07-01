using IntelligencePipeline.Models.Enums;
using IntelligencePipeline.Models.Reports;
using System.Net.NetworkInformation;

namespace IntelligencePipeline.Storage;

class RejectedReportRepository
{
    private List<Report> _rejectedReports;

    //constractor
    public RejectedReportRepository()
    {
        _rejectedReports = new List<Report>();
    }

    //add rejected report to rejected list (after validations)
    public void Add(Report report)
    {
        _rejectedReports.Add(report);
    }

    //get all rejected reports
    public List<Report> GetAll()
    {
        return _rejectedReports;
    }

    //get total amount of rejected reports
    public int GetTotalCount()
    {
        return _rejectedReports.Count;
    }

    //get rejected report by rejection reason
    public List<Report> GetByReason(string reasonKeyword)
    {
        List<Report> rejectedByReason = new List<Report>();
        foreach (Report report in _rejectedReports)
        {
            if (report.RejectionReason == reasonKeyword)
            {
                rejectedByReason.Add(report);
            }
        }
        return rejectedByReason;
    }
}