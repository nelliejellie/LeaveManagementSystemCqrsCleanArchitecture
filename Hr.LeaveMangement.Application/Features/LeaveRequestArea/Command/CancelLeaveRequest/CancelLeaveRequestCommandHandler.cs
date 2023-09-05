using Hr.LeaveMangement.Application.Contracts.Email;
using Hr.LeaveMangement.Application.Contracts.Persistence;
using Hr.LeaveMangement.Application.Exceptions;
using Hr.LeaveMangement.Application.Models.Email;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Hr.LeaveMangement.Application.Features.LeaveRequestArea.Command.CancelLeaveRequest
{
    public class CancelLeaveRequestCommandHandler : IRequestHandler<CancelLeaveRequestCommand, Unit>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IEmailService _emailSender;

        public CancelLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository,
        ILeaveAllocationRepository leaveAllocationRepository,
        IEmailService emailSender)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _leaveAllocationRepository = leaveAllocationRepository;
            _emailSender = emailSender;
        }

        public async Task<Unit> Handle(CancelLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var leaveRequest = await _leaveRequestRepository.GetByIdAsync(request.Id);

            if (leaveRequest is null)
                throw new NotFoundException(nameof(leaveRequest), request.Id);

            leaveRequest.Cancelled = true;
            await _leaveRequestRepository.UpdateAsync(leaveRequest);

            // if already approved, re-evaluate the employee's allocations for the leave type
            if (leaveRequest.Approved == true)
            {
                int daysRequested = (int)(leaveRequest.EndDate - leaveRequest.Startdate).TotalDays;
                var allocation = await _leaveAllocationRepository.GetUserAllocations(leaveRequest.RequestingEmployeeId, leaveRequest.LeaveTypeId);
                allocation.NumberOfDays += daysRequested;

                await _leaveAllocationRepository.UpdateAsync(allocation);
            }


            // send confirmation email
            try
            {
                var email = new EmailEntity
                {
                    Receipient = string.Empty, /* Get email from employee record */
                    Body = $"Your leave request for {leaveRequest.Startdate:D} to {leaveRequest.EndDate:D} has been cancelled successfully.",
                    Title = "Leave Request Cancelled"
                };

                await _emailSender.SendEmail(email);
            }
            catch (Exception)
            {
                // log error
            }

            return Unit.Value;
        }
    }
}
