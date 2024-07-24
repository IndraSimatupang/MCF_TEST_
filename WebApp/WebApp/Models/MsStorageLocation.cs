using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class MsStorageLocation
    {
        [Key]
        public string location_id { get; set; }
        public string location_name { get; set; }
    }
}
