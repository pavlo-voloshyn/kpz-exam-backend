using System.ComponentModel.DataAnnotations;

namespace R.DAL.Models;

public class EntityBase
{
    [Key]
    public int Id { get; set; }
}
