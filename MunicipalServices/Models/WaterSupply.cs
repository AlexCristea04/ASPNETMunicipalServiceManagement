using System.ComponentModel.DataAnnotations;
namespace MunicipalServices.Models;

public class WaterSupply
{
    [Key] 
    public int WaterSupplyId { get; set; }

    [Required] 
    public string Location { get; set; }

    [Required] 
    [Range(0, double.MaxValue, ErrorMessage = "Consumption must be a positive value.")]
    public double DailyConsumption { get; set; }

    [Range(1, 10, ErrorMessage = "Rating must be between 1 and 10.")]
    public int WaterQualityRating { get; set; }
}