using AutoMapper;
using Hr.LeaveManagement.Domain;
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

namespace Hr.LeaveMangement.Application.Features.LeaveRequestArea.Command.CreateLeaveRequestCommand
{
    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, Unit>
    {
        private readonly IEmailService _emailSender;
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        //private readonly IUserService _userService;
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;

        public CreateLeaveRequestCommandHandler(IEmailService emailSender,
            IMapper mapper, ILeaveTypeRepository leaveTypeRepository, ILeaveRequestRepository leaveRequestRepository, ILeaveAllocationRepository leaveAllocationRepository)
        {
            _emailSender = emailSender;
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
            _leaveRequestRepository = leaveRequestRepository;
            //this._userService = userService;
            _leaveAllocationRepository = leaveAllocationRepository;
        }
        public async Task<Unit> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateLeaveRequestCommandValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid Leave Request", validationResult);

            // Get requesting employee's id
            //var employeeId = _userService.UserId;
            //Console.WriteLine(employeeId);
            // Check on employee's allocation
            //var allocation = await _leaveAllocationRepository.GetUserAllocations(employeeId, request.LeaveTypeId);
            // if allocations aren't enough, return validation error with message
            //if (allocation is null)
            //{
            //    validationResult.Errors.Add(new FluentValidation.Results.ValidationFailure(nameof(request.LeaveTypeId), "You do not have any allocations for this leave type."));
            //    throw new BadRequestException("Invalid Leave Request", validationResult);
            //}

            int daysRequested = (int)(request.EndDate - request.StartDate).TotalDays;

            //if (daysRequested > allocation.NumberOfDays)
            //{
            //    validationResult.Errors.Add(new FluentValidation.Results.ValidationFailure(nameof(request.EndDate), "You do not have enough days for this request"));
            //    throw new BadRequestException("Invalid Leave Request", validationResult);
            //}

            // Create leave request
            var leaveRequest = _mapper.Map<LeaveRequest>(request);
            //leaveRequest.RequestingEmployeeId = employeeId;
            //leaveRequest.DateRequested = DateTime.Now;
            await _leaveRequestRepository.CreateAsync(leaveRequest);

            try
            {
                var email = new EmailEntity
                {
                    Receipient = string.Empty, /* Get email from employee record */
                    Body = $"Your leave request for {request.StartDate:D} to {request.EndDate:D} " +
                                $"has been submitted successfully.",
                    Title = "Leave Request Submitted"
                };

                await _emailSender.SendEmail(email);

                

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
               

            }
            return Unit.Value;
        }
    }
}
