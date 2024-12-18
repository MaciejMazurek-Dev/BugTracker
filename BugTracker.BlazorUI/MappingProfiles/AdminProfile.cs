﻿using AutoMapper;
using BugTracker.BlazorUI.Models.User;
using BugTracker.BlazorUI.Services.HttpClientBase;

namespace BugTracker.BlazorUI.MappingProfiles
{
    public class AdminProfile : Profile
    {
        public AdminProfile()
        {
            CreateMap<UserModel, UserVM>();
        }
    }
}
