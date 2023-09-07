using Hr.LeaveManagement.BlazorUI.Contracts;
using Hr.LeaveManagement.BlazorUI.Models.LeaveTypes;
using Hr.LeaveManagement.BlazorUI.Services.Base;

namespace Hr.LeaveManagement.BlazorUI.Services
{
    public class LeaveTypeService : BaseHttpService, ILeaveTypeService
    {
        public LeaveTypeService(IClient client) : base(client)
        {
        }

        public Task<Response<Guid>> CreateLeaveType(LeaveTypeVm leaveType)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Guid>> DeleteLeaveType(int id)
        {
            throw new NotImplementedException();
        }

        public Task<LeaveTypeVm> GetLeaveTypeDetails(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<LeaveTypeVm>> GetLeaveTypes()
        {
            throw new NotImplementedException();
        }

        public Task<Response<Guid>> UpdateLeaveType(int id, LeaveTypeVm leaveType)
        {
            throw new NotImplementedException();
        }
    }
}
