﻿using AutoMapper;
using Blazored.LocalStorage;
using BugTracker.BlazorUI.Contracts;
using BugTracker.BlazorUI.Models.Issue;
using BugTracker.BlazorUI.Services.HttpClientBase;

namespace BugTracker.BlazorUI.Services
{
    public class IssueService : HttpClientService, IIssueService
    {
        private readonly IMapper _mapper;

        public IssueService(IClient client, ILocalStorageService localStorageService, IMapper mapper) 
            : base(client, localStorageService)
        {
            _mapper = mapper;
        }
        public async Task<List<IssueVM>> GetAllIssues()
        {
            var issues = await _client.IssueAllAsync();
            return _mapper.Map<List<IssueVM>>(issues);

        }

        public async Task<IssueDetailsVM> GetIssueById(int id)
        {
            var issue = await _client.IssueGETAsync(id);
            return _mapper.Map<IssueDetailsVM>(issue);
        }

        public async Task CreateIssue(CreateIssueVM issue)
        {
            var command = _mapper.Map<CreateIssueCommand>(issue);
            await _client.IssuePOSTAsync(command);
        }

        public async Task DeleteIssue(int id)
        {
            await _client.IssueDELETEAsync(id);
        }

        public async Task UpdateIssue(IssueDetailsVM issue)
        {
            var issueCommand = _mapper.Map<UpdateIssueCommand>(issue);
            await _client.IssuePUTAsync(issueCommand);
        }
    }
}
