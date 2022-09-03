using Application.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Languages.Rules
{
    public class LanguageBusinessRules
    {
        private readonly ILanguageDal languageDal;

        public LanguageBusinessRules(ILanguageDal languageDal)
        {
            this.languageDal = languageDal;
        }

        public async Task LanguageNameAlreadyExists(string name)
        {
            IPaginate<Language> result = await languageDal.GetListAsync(x => x.Name == name.Trim());
            if (result.Items.Any()) throw new BusinessException("Language name already exists.");
        }

        public async Task IsLanguageNameExists(int id)
        {
            var result = await languageDal.GetAsync(x => x.Id == id);
            if (result is null) throw new BusinessException("Language name does not exists.");
        }
    }
}
