using Hr.LeaveManagement.Domain;

namespace Hr.LeaveMangement.Application.Contracts.Persistence
{
    public interface ILeaveTypeRepository : IGenericRepository<LeaveType>
    {
        Task<bool> IsLeaveTypeUnique(string name);
    }
}
