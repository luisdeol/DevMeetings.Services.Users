using System;
using System.Threading.Tasks;
using DevMeetings.Services.Users.Api.Application.InputModels;
using DevMeetings.Services.Users.Core.Entities;
using DevMeetings.Services.Users.Core.Repositories;
using DevMeetings.Services.Users.Infrastructure.MessageBus;

namespace DevMeetings.Services.Users.Api.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMessageBusClient _messageBusClient;
        public UserService(IUserRepository repository, IMessageBusClient messageBusClient)
        {
            _repository = repository;
            _messageBusClient = messageBusClient;
        }

        public async Task<Guid> Add(UserInputModel userInputModel)
        {
            var user = User.Create(userInputModel.FullName, userInputModel.Profession);

            await _repository.AddAsync(user);

            foreach (var @event in user.Events) {
                _messageBusClient.Publish(@event, "user-services/user-created", "user-services");
            }
            
            return user.Id;
        }
    }
}