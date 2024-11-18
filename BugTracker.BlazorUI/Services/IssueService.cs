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
        
        public async Task CreateIssue(CreateIssueVM issue)
        {
            CreateIssueCommand createIssueCommand = new CreateIssueCommand()
            {
                IssuePriorityId = issue.IssuePriorityId,
                Summary = issue.Summary,
                IssueTypeId = issue.IssueTypeId,
            };
            await _client.IssuePOSTAsync(createIssueCommand);
            
        }

        public Task DeleteIssue(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<IssueVM>> GetAllIssues()
        {
            var issues = await _client.IssueAllAsync();
            return _mapper.Map<List<IssueVM>>(issues);

        }

        public async Task<IssueVM> GetIssueById(int id)
        {
            var issue = await _client.IssueGETAsync(id);
            return _mapper.Map<IssueVM>(issue);
        }

        public Task UpdateIssue(int id, IssueVM issue)
        {
            throw new NotImplementedException();
        }
    }
}