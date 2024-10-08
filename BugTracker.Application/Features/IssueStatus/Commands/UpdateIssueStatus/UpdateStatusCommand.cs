﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Application.Features.IssueStatus.Commands.UpdateIssueStatus
{
    public class UpdateStatusCommand : IRequest<Unit>
    {
        public string Name { get; set; } = string.Empty;
    }
}
