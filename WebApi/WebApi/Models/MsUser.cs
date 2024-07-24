using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
public class MsUser
{
    public long user_id { get; set; }
    public string user_name { get; set; }
    public string password { get; set; }
    public bool is_active { get; set; }
}

}
