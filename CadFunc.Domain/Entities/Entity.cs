using System.ComponentModel.DataAnnotations;

namespace CadFunc.Domain.Entities
{
    public abstract class Entity
    {
        [Key]
        public int Id { get; protected set; }
    }
}
