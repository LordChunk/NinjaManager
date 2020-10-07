using System.ComponentModel.DataAnnotations;

namespace ModelLayer
{
    public abstract class ModelBase
    {
        [Required]
        public int Id { get; set; }
    }
}