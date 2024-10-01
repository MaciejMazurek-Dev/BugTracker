﻿using AutoMapper;
using BugTracker.Application.Contracts.Persistence;
using MediatR;

namespace BugTracker.Application.Features.Issue.Queries.GetIssueById
{
    public class GetIssueByIdHandler : IRequestHandler<GetIssueByIdQuery, IssueByIdDto>
    {
        private readonly IMapper _mapper;
        private readonly IIssueRepository _issueRepository;

        public GetIssueByIdHandler(IMapper mapper, IIssueRepository issueRepository)
        {
            _mapper = mapper;
            _issueRepository = issueRepository;
        }
        public async Task<IssueByIdDto> Handle(GetIssueByIdQuery request, CancellationToken cancellationToken)
        {
            var issue = await _issueRepository.GetIssueById(request.Id);
            return _mapper.Map<IssueByIdDto>(issue);
        }
    }
}