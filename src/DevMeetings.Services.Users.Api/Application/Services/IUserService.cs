using System;
using System.Threading.Tasks;
using DevMeetings.Services.Users.Api.Application.InputModels;

namespace DevMeetings.Services.Users.Api.Application.Services
{
    public interface IUserService
    {
         Task<Guid> Add(UserInputModel userInputModel);
    }
}