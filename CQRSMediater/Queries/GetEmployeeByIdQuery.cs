using CQRSMediater.Models;
using MediatR;

namespace CQRSMediater.Queries
{
    public class GetEmployeeByIdQuery : IRequest<Employee>
    {
        public int Id { get; set; }
    }
}
