using MediatR;

namespace MyTestProject.Commands
{
    public class DeleteItemCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }

}
