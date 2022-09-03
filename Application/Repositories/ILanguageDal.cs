using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Repositories
{
    public interface ILanguageDal : IAsyncRepository<Language>, IRepository<Language>
    {
    }
}
