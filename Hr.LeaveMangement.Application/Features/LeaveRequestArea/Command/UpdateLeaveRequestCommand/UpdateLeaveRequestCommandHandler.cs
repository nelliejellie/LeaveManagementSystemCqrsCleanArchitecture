using AutoMapper;
using Hr.LeaveManagement.Domain;
using Hr.LeaveMangement.Application.Contracts.Email;
using Hr.LeaveMangement.Application.Contracts.Persistence;
using Hr.LeaveMangement.Application.Exceptions;
using Hr.LeaveMangement.Application.Logger;
using Hr.LeaveMangement.Application.Models.Email;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Hr.LeaveMangement.Application.Features.LeaveRequestArea.Command.UpdateLeaveRequestCommand
{
    public class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand, Unit>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailSender;
        private readonly IAppLogger<UpdateLeaveRequestCommandHandler> _logger;


        public UpdateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, ILeaveTypeRepository leaveTypeRepository, IMapper mapper, IEmailService emailSender, IAppLogger<UpdateLeaveRequestCommandHandler> logger)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
            _emailSender = emailSender;
            _logger = logger;
        }
        public async Task<Unit> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var leaveRequest = await _leaveRequestRepository.GetByIdAsync(request.Id);

            if (leaveRequest == null)
                throw new NotFoundException(nameof(LeaveRequest), request.Id);

            await _leaveRequestRepository.UpdateAsync(leaveRequest);

            _mapper.Map(request, leaveRequest);
            await _leaveRequestRepository.UpdateAsync(leaveRequest);

            try
            {
                var email = new EmailEntity
                {
                    Receipient = string.Empty,
                    Body = $"Your leave request for {request.StartDate:D} to {request.EndDate:D} " +
                                       $"has been updated successfully.",
                    Title = "Leave Request Submitted"
                };
                await _emailSender.SendEmail(email);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
            }


            return Unit.Value;
        }
    }
}
