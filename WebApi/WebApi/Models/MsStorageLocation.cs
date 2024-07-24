using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
public class MsStorageLocation
{
    [Key]
    public int location_id { get; set; }
    public string location_name { get; set; }
}
}
