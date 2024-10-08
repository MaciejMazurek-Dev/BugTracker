﻿using AutoMapper;
using BugTracker.Application.Contracts.Persistence;
using MediatR;

namespace BugTracker.Application.Features.Issue.Queries.GetAllIssues
{
    public class GetAllIssuesHandler :
        IRequestHandler<GetAllIssuesQuery, List<IssuesDto>>
    {
        private readonly IMapper _mapper;
        private readonly IIssueRepository _issueRepository;

        public GetAllIssuesHandler(IMapper mapper, IIssueRepository issueRepository)
        {
            this._mapper = mapper;
            this._issueRepository = issueRepository;
        }
        public async Task<List<IssuesDto>> Handle(GetAllIssuesQuery request, CancellationToken cancellationToken)
        {
            var issues = await _issueRepository.GetAllAsync();

            var data = _mapper.Map<List<IssuesDto>>(issues);

            return data;
        }
    }
}
