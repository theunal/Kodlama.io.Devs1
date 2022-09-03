using MediatR;

namespace Application.Features.Languages.Queries.GetLanguageById
{
    public class GetLanguageByIdRequest : IRequest<GetLanguageByIdResponse>
    {
        public int Id { get; set; }
    }
}
