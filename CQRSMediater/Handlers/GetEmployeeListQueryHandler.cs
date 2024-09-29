using CQRSMediater.Models;
using CQRSMediater.Queries;
using CQRSMediater.Repositories;
using MediatR;

namespace CQRSMediater.Handlers
{
    public class GetEmployeeListQueryHandler : IRequestHandler<GetEmployeeListQuery, List<Employee>>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetEmployeeListQueryHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<List<Employee>> Handle(GetEmployeeListQuery request, CancellationToken cancellationToken)
        {
            return await _employeeRepository.GetEmployeesListAsync();
        }
    }
}
