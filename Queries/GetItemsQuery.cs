using MediatR;
using MyTestProject.Models;

namespace MyTestProject.Queries
{
    public class GetItemsQuery : IRequest<IEnumerable<Item>>
    {

    }
}
