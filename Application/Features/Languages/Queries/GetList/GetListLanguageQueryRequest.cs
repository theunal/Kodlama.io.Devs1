using Core.Application.Requests;
using MediatR;

namespace Application.Features.Languages.Queries.GetList
{
    public class GetListLanguageQueryRequest : IRequest<GetListLanguageQueryResponse>
    {
        public PageRequest PageRequest { get; set; }
    }
}
