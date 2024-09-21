﻿using AutoMapper;
using BugTracker.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Application.Features.IssueStatus.Queries
{
    public class GetAllIssueStatusesHandler : IRequestHandler<GetAllIssueStatusesQuery, List<IssueStatusDto>>
    {
        private readonly IMapper _mapper;
        private readonly IIssueStatusRepository _issueStatusRepository;

        public GetAllIssueStatusesHandler(IMapper mapper, IIssueStatusRepository issueStatusRepository)
        {
            _mapper = mapper;
            _issueStatusRepository = issueStatusRepository;
        }
        public async Task<List<IssueStatusDto>> Handle(GetAllIssueStatusesQuery request, CancellationToken cancellationToken)
        {
            var statuses = await _issueStatusRepository.GetAllAsync();
            var result = _mapper.Map<List<IssueStatusDto>>(statuses);
            return result;
        }
    }
}
