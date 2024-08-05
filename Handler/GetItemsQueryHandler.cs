using MediatR;
using MyTestProject.Models;
using MyTestProject.Queries;
using MyTestProject.Repositories;

namespace MyTestProject.Handler
{
    public class GetItemsQueryHandler : IRequestHandler<GetItemsQuery, IEnumerable<Item>>
    {
        private readonly IItemRepository _repository;
        public GetItemsQueryHandler(IItemRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Item>> Handle(GetItemsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetItemsAsync();
        }
    }
}
