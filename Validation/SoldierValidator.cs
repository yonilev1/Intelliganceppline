using IntelligencePipeline.Models.Reports;
using IntelligencePipeline.Validation;
using System.ComponentModel.DataAnnotations;

class SoldierValidator : BaseValidator
{
    //validate common, validate specific and return success or error message
    public override ValidationResult ValidateSpecificFields(Report report)
    {
        ValidationResult commonValid = Validate(report);
        if (commonValid.IsValid)
        {
            if (report.GetSourceType() == "Soldier")
            {
                SoldierReport sr = (SoldierReport)report;
                if (sr.SoldierName.Length >= 2 && sr.SoldierName.Length <= 50)
                {
                    if (int.TryParse(sr.SoldierID, out int sidint) && sidint >= 1000000 && sidint <= 9999999)
                    {
                        if (sr.Unit.Length >= 2 && sr.Unit.Length <= 50)
                        {
                            if (sr.ConfidenceLevel >= 1 && sr.ConfidenceLevel <= 5)
                            {
                                return ValidationResult.Success();
                            }
                            else
                                return ValidationResult.Failure("Invalid ConfidenceLevel: must be between 1 - 5");
                        }
                        else
                            return ValidationResult.Failure("Invalid Unit: Length must be between 2 - 50");
                    }
                    else
                        return ValidationResult.Failure("Invalid SoldierID: must be between 7 digit int");
                }
                else
                    return ValidationResult.Failure("Invalid SoldierName: Length must be between 2 - 50");
            }
            else
                return ValidationResult.Failure("Invalid Report Type: must be Soldier Report");

        }
        return ValidationResult.Failure(commonValid.ErrorMessage);
    }
}