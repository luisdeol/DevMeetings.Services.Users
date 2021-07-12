using System;
using System.Threading.Tasks;
using DevMeetings.Services.Users.Api.Application.InputModels;
using DevMeetings.Services.Users.Core.Entities;
using DevMeetings.Services.Users.Core.Repositories;
using DevMeetings.Services.Users.Core.ValueObjects;
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
            var user = User.Create(userInputModel.FullName, userInputModel.Profession, userInputModel.Email);

            await _repository.AddAsync(user);

            foreach (var @event in user.Events) {
                var routingKey = @event.GetType().Name.ToDashCase();

                _messageBusClient.Publish(@event, routingKey, "user-service");
            }
            
            return user.Id;
        }

        public async Task Update(UpdateUserInputModel updateUserInputModel)
        {
            var user = await _repository.GetByIdAsync(updateUserInputModel.Id);

            user.Update(updateUserInputModel.Profession, 
                new Address(
                    updateUserInputModel.Street,
                    updateUserInputModel.Number,
                    updateUserInputModel.City,
                    updateUserInputModel.State,
                    updateUserInputModel.ZipCode));
            
            foreach (var @event in user.Events) {
                var routingKey = @event.GetType().Name.ToDashCase();
                Console.WriteLine(routingKey);
                _messageBusClient.Publish(@event, routingKey, "user-service");
            }

            await _repository.UpdateAsync(user);
        }
    }
}