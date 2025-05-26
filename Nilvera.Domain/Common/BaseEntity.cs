using System.ComponentModel.DataAnnotations;

namespace Nilvera.Domain.Common
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
