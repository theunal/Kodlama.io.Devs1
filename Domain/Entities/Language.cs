using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class Language : Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
