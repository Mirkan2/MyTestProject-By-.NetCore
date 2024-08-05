using MediatR;

namespace MyTestProject.Commands
{
    public class CreateItemCommand : IRequest<int>
    {
        public string Name { get; set; }
    }
}
