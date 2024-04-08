using AutoMapper;
using SpotifyPrototype.Application.Account.Dto;
using SpotifyPrototype.Domain.Account.Aggregates;
using SpotifyPrototype.Domain.Streaming.Aggregates;
using SpotifyPrototype.Domain.Transaction.Aggregates;
using SpotifyPrototype.Repository.Repository;
using SpotifyPrototype.Domain.Core.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyPrototype.Application.Account
{
    public class UserService
    {
        private IMapper Mapper { get; set; }
        private UserRepository UserRepository { get; set; }
        private PlanRepository PlanRepository { get; set; }

        public UserService(IMapper mapper, UserRepository userRepository, PlanRepository planRepository)
        {
            Mapper = mapper;
            UserRepository = userRepository;
            PlanRepository = planRepository;
        }

        public UserDto Create(UserDto dto)
        {
            if (this.UserRepository.Exists(x => x.Email == dto.Email))
                throw new Exception("User already exists in the database");

            Plan plan = this.PlanRepository.GetById(dto.PlanId);

            if (plan == null)
                throw new Exception("Plan does not exist or not found");

            Card card = this.Mapper.Map<Card>(dto.Card);

            User user = new User();
            user.CreateAccount(dto.Name, dto.Email, dto.Password, dto.DateOfBirth, plan, card);

            //TODO: SAVE TO DATABASE
            this.UserRepository.Save(user);
            var result = this.Mapper.Map<UserDto>(user);

            return result;
        }

        public UserDto Get(Guid id)
        {
            var user = this.UserRepository.GetById(id);
            var result = this.Mapper.Map<UserDto>(user);
            return result;
        }

        public UserDto Authenticate(String email, String password)
        {
            var user = this.UserRepository.Find(x => x.Email == email && x.Password == password.HashSHA256()).FirstOrDefault();
            var result = this.Mapper.Map<UserDto>(user);
            return result;
        }

    }
}
