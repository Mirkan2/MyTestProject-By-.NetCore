using MediatR;
using MyTestProject.Commands;
using MyTestProject.Models;
using MyTestProject.Repositories;

namespace MyTestProject.Handler
{
    public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, int>
    {
        private readonly IItemRepository _repository;
        public CreateItemCommandHandler(IItemRepository repository)
        {
            _repository = repository;
        }
        public async Task<int> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            return await _repository.AddItemAsync(new Item { Name = request.Name });
        }
    }
}
