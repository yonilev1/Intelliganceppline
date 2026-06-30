using System;
using IntelligencePipeline.Models.Enums;
namespace IntelligencePipeline.Models.Reports;


abstract class Report
{
    private int _reportId;
    private DateTime _timestamp;
    private double _latitude;
    private double _longitude;
    private string _description;
    private ReportStatus _status;
    private Priority _priority;
    private Classification _classification;
    private int _reliabilityScore;
    private string _rejectionReason;

    public int ReportId { get => _reportId;
        private set
        {
            _reportId = value;
        }
    }

    public DateTime Timestamp
    {
        get => _timestamp;
        set
        {
            if (value <= DateTime.Now && value >= new DateTime(2020, 1, 1))
                _timestamp = value;
        }
    }

    public double Latitude { 
        get => _latitude;
        set
        {
            if (value >= 29.5 && value <= 33.5)
                _latitude = value;
        }
    }

    public double Longitude {
        get => _longitude;
        set
        {
            if (value >= 34.0 && value <= 36.0)
                _longitude = value;
        }
     }

    public string Description
    {
        get => _description;
        set
        {
            if (value.Length >= 10 && value.Length <= 500)
                _description = value;
        }
    }

    public ReportStatus Status { 
        get => _status;
        set
        {
            _status = value;
        }
     }

    public Priority Priority { 
        get => _priority;
        set 
        {
            _priority = value;
        }
    }

    public Classification Classification { 
        get => _classification;
        set 
        {
            _classification = value;
        }
    }

    public int ReliabilityScore { 
        get => _reliabilityScore;
        private set 
        {
            _reliabilityScore = value;
        }
    }

    public string RejectionReason {
        get => _rejectionReason;
        set
        {
            _rejectionReason = value;
        }
    }
}