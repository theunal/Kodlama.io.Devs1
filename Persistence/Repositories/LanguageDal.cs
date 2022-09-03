using Application.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class LanguageDal : EfRepositoryBase<Language, DataContext>, ILanguageDal
    {
        public LanguageDal(DataContext context) : base(context)
        {
        }
    }
}
