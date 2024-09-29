using CQRSMediater.Models;
using MediatR;

namespace CQRSMediater.Queries
{
    public class GetEmployeeListQuery : IRequest<List<Employee>>
    {

    }
}
