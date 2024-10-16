using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MunicipalServices.Models;

public class Facility
{
    [Key] 
    public int FacilityId { get; set; }

    [Required] 
    [StringLength(50)] 
    public string FacilityType { get; set; }

    [ForeignKey("Park")]
    public int ParkId { get; set; }
    public Park Park { get; set; }
}