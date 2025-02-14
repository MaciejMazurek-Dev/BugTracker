﻿using BugTracker.Application.Features.Issue.Queries.GetAllIssues;
using BugTracker.Application.Features.Issue.Queries.GetIssueById;
using BugTracker.Application.Features.Issue.Commands.CreateIssue;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using BugTracker.Application.Features.Issue.Commands.UpdateIssue;
using BugTracker.Application.Features.Issue.Commands.DeleteIssue;
using BugTracker.Application.Contracts.Identity;
using Microsoft.AspNetCore.Authorization;
using BugTracker.Application.Features.Issue.Queries.GetIssuesByFilter;

namespace BugTracker.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class IssueController : ControllerBase
    {
        private readonly IMediator _mediator;

        public IssueController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<IssueDto>>> Get()
        {
            var issues =  await _mediator.Send(new GetAllIssuesQuery());
            return Ok(issues);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IssueDetailsDto>> Get(int id)
        {
            var issue = await _mediator.Send(new GetIssueByIdQuery { Id = id });
            return Ok(issue);
        }

        [HttpGet("filters")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<IssuesByFilterDto>>> GetIssuesByFilter(
            [FromQuery] int? type,
            [FromQuery] int? priority,
            [FromQuery] int? status)
        {
            var issues = await _mediator.Send(
                new GetIssuesByFilterQuery
                {
                    IssueTypeId = type,
                    IssuePriorityId = priority,
                    IssueStatusId = status
                });
            return Ok(issues);
        }
            

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post(CreateIssueCommand createIssueCommand)
        {
            var issueId = await _mediator.Send(createIssueCommand);
            return CreatedAtAction(nameof(Get), new {id = issueId});
        }
        
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Put(UpdateIssueCommand updateIssueCommand)
        {
            await _mediator.Send(updateIssueCommand);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteIssueCommand { Id = id });
            return NoContent();
        }
    }
}
