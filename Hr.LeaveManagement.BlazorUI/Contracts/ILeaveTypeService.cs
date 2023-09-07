using Hr.LeaveManagement.BlazorUI.Models.LeaveTypes;
using Hr.LeaveManagement.BlazorUI.Services.Base;
using System.Threading.Tasks;

namespace Hr.LeaveManagement.BlazorUI.Contracts
{
    public interface ILeaveTypeService
    {
        Task<List<LeaveTypeVm>> GetLeaveTypes();
        Task<LeaveTypeVm> GetLeaveTypeDetails(int id);
        Task<Response<Guid>> CreateLeaveType(LeaveTypeVm leaveType);
        Task<Response<Guid>> UpdateLeaveType(int id, LeaveTypeVm leaveType);
        Task<Response<Guid>> DeleteLeaveType(int id);
    }
}
