using MediatR;
using MyTestProject.Commands;
using MyTestProject.Models;
using MyTestProject.Repositories;

namespace MyTestProject.Handlers
{
    public class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommand, bool>
    {
        private readonly IItemRepository _repository;

        public UpdateItemCommandHandler(IItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
        {
            var item = new Item { Id = request.Id, Name = request.Name };
            return await _repository.UpdateItemAsync(item);
        }
    }
}
