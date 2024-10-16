using System.ComponentModel.DataAnnotations;

namespace MunicipalServices.Models;
public class Park
{
    [Key] 
    public int ParkId { get; set; }

    [Required] 
    [StringLength(100)] 
    public string ParkName { get; set; }
    
    public ICollection<Facility> Facilities { get; set; }
}