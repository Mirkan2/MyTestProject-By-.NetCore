using MediatR;

namespace MyTestProject.Commands
{
    public class UpdateItemCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
