﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Application.Features.Issue.Commands.DeleteIssue
{
    public class DeleteIssueCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
