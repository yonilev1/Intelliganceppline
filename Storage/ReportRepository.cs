using IntelligencePipeline.Models.Enums;
using IntelligencePipeline.Models.Reports;
using System.Net.NetworkInformation;

namespace IntelligencePipeline.Storage;

class ReportRepository
{
    private List<Report> _reports;

    //constractor
    public ReportRepository()
    {
        _reports = new List<Report>();
    }

    //add report to list (after validations)
    public void Add(Report report)
    {
        _reports.Add(report);
    }

    //get all reports
    public List<Report> GetAll()
    {
        return _reports;
    }

    //get all reports with specific status
    public List<Report> GetByStatus(ReportStatus status)
    {
        List<Report> statusReports = new List<Report>();
        foreach (Report report in _reports)
        {
            if (report.Status == status)
                statusReports.Add(report);
        }
        return statusReports;
    }

    //get all reports with specific priority
    public List<Report> GetByPriority(Priority priority)
    {
        List<Report> statusPriority = new List<Report>();
        foreach (Report report in _reports)
        {
            if (report.Priority == priority)
                statusPriority.Add(report);
        }
        return statusPriority;
    }

    //get all reports that description contains keyword (not from content - cuz only Signal has content)
    public List<Report> Search(string keyword)
    {
        List<Report> containsKeyword = new List<Report>();
        foreach (Report report in _reports)
        {
            if (report.Description.Contains(keyword))
                containsKeyword.Add(report);
        }
        return containsKeyword;

    }

    //search by id, return report. if does not exist return null
    public Report? GetById(int reportId)
    {
        foreach (Report report in _reports)
        {
            if (report.ReportId == reportId)
                return report;
        }
        return null;
    }

    //update status
    public void UpdateStatus(int reportId, ReportStatus newStatus)
    {
        foreach (Report report in _reports)
        {
            if (report.ReportId == reportId)
            {
                report.Status = newStatus;
                return;
            }
        }
    }

    //get total amount of reports
    public int GetTotalCount()
    {
        return _reports.Count;
    }

    //get total by specific status
    public int GetCountByStatus(ReportStatus status)
    {
        int count = 0;
        foreach (Report report in _reports)
            if (report.Status == status)
                count++;
        return count;
    }
}