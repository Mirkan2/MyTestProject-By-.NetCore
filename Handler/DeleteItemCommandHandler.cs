using MediatR;
using MyTestProject.Commands;
using MyTestProject.Repositories;

namespace MyTestProject.Handler
{
    public class DeleteItemCommandHandler : IRequestHandler<DeleteItemCommand, bool>
    {
        private readonly IItemRepository _repository;

        public DeleteItemCommandHandler(IItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
        {
            // Silme işlemi başarılıysa true, başarısızsa false döndürür.
            return await _repository.DeleteItemAsync(request.Id);
        }
    }
}
