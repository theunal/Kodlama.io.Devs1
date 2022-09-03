using Application.Features.Languages.Models;
using Application.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Languages.Queries.GetList
{
    public class GetListLanguageQueryHandler :
        IRequestHandler<GetListLanguageQueryRequest, GetListLanguageQueryResponse>
    {
        private readonly ILanguageDal languageDal;
        private readonly IMapper mapper;

        public GetListLanguageQueryHandler(ILanguageDal languageDal, IMapper mapper)
        {
            this.languageDal = languageDal;
            this.mapper = mapper;
        }

        public async Task<GetListLanguageQueryResponse> Handle(GetListLanguageQueryRequest request,
            CancellationToken cancellationToken)
        {
            var result = await languageDal.GetListAsync(index: request.PageRequest.Page,
                size: request.PageRequest.PageSize);
            return new GetListLanguageQueryResponse
            {
                LanguageListModel = mapper.Map<LanguageListModel>(result)
            };
        }
    }
}
