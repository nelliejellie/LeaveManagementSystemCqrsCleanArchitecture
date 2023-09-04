﻿using Hr.LeaveMangement.Application.Logger;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.LeaveManagement.Infrastructure.Logger
{
    public class LoggerAdapter<T> : IAppLogger<T>
    {
        private readonly ILogger<T> _logger;
        public LoggerAdapter(ILoggerFactory logger)
        {
            _logger = logger.CreateLogger<T>();
        }
        public void LogInformation(string message, params object[] args)
        {
            _logger.LogInformation(message, args);
        }

        public void LogWarning(string message, params object[] args)
        {
            _logger?.LogWarning(message, args);
        }
    }
}
