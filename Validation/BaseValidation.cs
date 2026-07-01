using IntelligencePipeline.Models.Reports;
using IntelligencePipeline.Validation;
using System.ComponentModel.DataAnnotations;

abstract class BaseValidator : IValidator
{
    public ValidationResult Validate(Report report)
    {
        //check if commot results and specific result pass.
        //pass - returns success message, if not return error message.
        ValidationResult commonChecks = ValidateCommonFields(report);
        if (commonChecks.IsValid)
        {
            ValidationResult specificChecks = ValidateSpecificFields(report);
            if (specificChecks.IsValid)
            {
                return ValidationResult.Success();
            }
            else
                return ValidationResult.Failure(specificChecks.ErrorMessage);
        }
        return ValidationResult.Failure(commonChecks.ErrorMessage);
    }


    //try to validate the input of common fields
    protected ValidationResult ValidateCommonFields(Report report)
    {
        if (report.Timestamp >= new DateTime(2020, 1, 1) && report.Timestamp <= DateTime.Now)
        {
                if (report.Latitude >= 29.5 && report.Latitude <= 33.5)
                {
                        if (report.Longitude >= 34.0 && report.Longitude <= 36.0)
                        {
                                if (report.Description.Length >= 10 && report.Description.Length <= 500)
                                {
                                    return ValidationResult.Success();
                                }
                                else
                                    return ValidationResult.Failure("Invalid Description: Length must be between 10 - 500");
                        }
                        else
                            return ValidationResult.Failure("Invalid Longitude: must be between 34.0 - 36.0");
                }
                else
                    return ValidationResult.Failure("Invalid Latitude: must be between 29.5 - 33.5");
        }
        else
            return ValidationResult.Failure("Invalid Timestamp: must be between 1.1.20 - Now");
    }

    protected abstract ValidationResult ValidateSpecificFields(Report report);
}