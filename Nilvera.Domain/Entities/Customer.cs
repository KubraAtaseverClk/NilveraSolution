using Nilvera.Domain.Common;

namespace Nilvera.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Address { get; set; }
    }
}
