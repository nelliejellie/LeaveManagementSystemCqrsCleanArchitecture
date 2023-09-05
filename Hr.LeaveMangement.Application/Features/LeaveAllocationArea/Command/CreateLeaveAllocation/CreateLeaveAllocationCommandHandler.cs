using AutoMapper;
using Hr.LeaveManagement.Domain;
using Hr.LeaveMangement.Application.Contracts.Persistence;
using Hr.LeaveMangement.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.LeaveMangement.Application.Features.LeaveAllocationArea.Command.CreateLeaveAllocation
{
    public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        //private readonly IUserService _userService;

        public CreateLeaveAllocationCommandHandler(
            ILeaveAllocationRepository leaveAllocationRepository,
            ILeaveTypeRepository leaveTypeRepository,
            IMapper mapper
            )
        {
            _mapper = mapper;
            _leaveAllocationRepository = leaveAllocationRepository;
            _leaveTypeRepository = leaveTypeRepository;
        }
        public  async Task<Unit> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateLeaveAllocationCommandValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid Leave Allocation Request", validationResult);

            // Get Leave type for allocations
            var leaveType = await _leaveTypeRepository.GetByIdAsync(request.LeaveTypeId);

            // Get Employees

            //var employees = await _userService.GetEmployees();

            //Get Period

            var period = DateTime.Now.Year;

            var allocations = new List<LeaveAllocation>();
            //foreach (var emp in employees)
            //{
            //    var allocationExists = await _leaveAllocationRepository.AllocationExists(emp.Id, request.LeaveTypeId, period);
            //    if (allocationExists == false)
            //    {
            //        allocations.Add(new Domain.LeaveAllocation
            //        {
            //            EmployeeId = emp.Id,
            //            LeaveTypeId = leaveType.Id,
            //            NumberOfDays = leaveType.DefaultDays,
            //            Period = period,
            //        });
            //    }
            //}
            if (allocations.Any())
            {
                await _leaveAllocationRepository.AddAllocations(allocations);
            }


            //Assign Allocations

            return Unit.Value;
        }
    }
}
