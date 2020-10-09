using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public abstract class ModelBase
    {
        [Required]
        public int Id { get; set; }
    }
}