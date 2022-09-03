using Application.Features.Languages.Rules;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Languages.Commands.AddLanguage
{
    public class AddLanguageCommandHandler :
        IRequestHandler<AddLanguageCommandRequest, AddLanguageCommandResponse>
    {
        private readonly ILanguageDal languageDal;
        private readonly IMapper mapper;
        private readonly LanguageBusinessRules languageBusinessRules;

        public AddLanguageCommandHandler(ILanguageDal languageDal, IMapper mapper, LanguageBusinessRules languageBusinessRules)
        {
            this.languageDal = languageDal;
            this.mapper = mapper;
            this.languageBusinessRules = languageBusinessRules;
        }

        public async Task<AddLanguageCommandResponse> Handle(AddLanguageCommandRequest request,
            CancellationToken cancellationToken)
        {
            await languageBusinessRules.LanguageNameAlreadyExists(request.Name);

            var mappedBrand = mapper.Map<Language>(request);
            var createdBrand = await languageDal.AddAsync(mappedBrand);
            return mapper.Map<AddLanguageCommandResponse>(createdBrand);
        }
    }
}
