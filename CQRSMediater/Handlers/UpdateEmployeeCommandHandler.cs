using CQRSMediater.Command;
using CQRSMediater.Models;
using CQRSMediater.Repositories;
using MediatR;

namespace CQRSMediater.Handlers
{
    public class UpdateEmployeeCommandHandler:IRequestHandler<UpdateEmployeeCommand,int>
    {
        private readonly IEmployeeRepository _employeeRepository;
        public UpdateEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<int> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
           var employee = await _employeeRepository.GetEmployeeByIdAsync(request.Id);
            if (employee == null) return default;
            employee.Name = request.Name;
            employee.Address = request.Address;
            employee.Email = request.Email;
            employee.Phone = request.Phone;
            return await _employeeRepository.UpdateEmployeeAsync(employee);
        }
    }
}
