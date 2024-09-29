using MediatR;

namespace CQRSMediater.Command
{
    public class DeleteEmployeeCommand :IRequest<int>
    {
        

        public int Id { get; set; }
    }
}
