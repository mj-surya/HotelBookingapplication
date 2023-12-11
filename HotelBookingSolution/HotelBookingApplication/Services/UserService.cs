﻿using HotelBookingApplication.Interfaces;
using HotelBookingApplication.Models.DTOs;
using HotelBookingApplication.Models;
using System.Security.Cryptography;
using System.Text;

namespace HotelBookingApplication.Services
{
    public class UserService: IUserService
    {
        private readonly IRepository<string, User> _repository;
        private readonly ITokenService _tokenService;

        public UserService(IRepository<string, User> repository,ITokenService tokenService)
        {
            _repository = repository;
            _tokenService = tokenService;
        }
        /// <summary>
        /// Gets user details with userId
        /// </summary>
        /// <param name="id">UserId</param>
        /// <returns>Returns user details</returns>
        public User GetById(string id)
        {
            var user = _repository.GetById(id);
            return user;
        }

        /// <summary>
        /// Logins an user by validating the credentials
        /// </summary>
        /// <param name="userDTO">Login credentails</param>
        /// <returns>Returns token on successfull login</returns>
        public UserDTO Login(UserDTO userDTO)
        {
            var user = _repository.GetById(userDTO.Email);
            if (user != null)
            {
                HMACSHA512 hmac = new HMACSHA512(user.Key);
                var userpass = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDTO.Password));
                for (int i = 0; i < userpass.Length; i++)
                {
                    if (user.Password[i] != userpass[i])
                        return null;
                }
                userDTO.Role = user.Role;
                userDTO.Token = _tokenService.GetToken(userDTO);
                userDTO.Password = "";
                userDTO.Name = user.Name;
                return userDTO;
            }
            return null;
        }
        /// <summary>
        /// Registers a new user into the application
        /// </summary>
        /// <param name="userRegisterDTO">Contains user data for registeration purpose</param>
        /// <returns>Returns token on successfull registeration</returns>
        public UserDTO Register(UserRegisterDTO userRegisterDTO)
        {
            HMACSHA512 hmac = new HMACSHA512();
            User user = new User()
            {
                Email = userRegisterDTO.Email,
                Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(userRegisterDTO.Password)),
                Phone = userRegisterDTO.Phone,
                Name = userRegisterDTO.Name,
                Address= userRegisterDTO.Address,
                Key = hmac.Key,
                Role = userRegisterDTO.Role
            };
            var result = _repository.Add(user);
            if (result != null)
            {
                userRegisterDTO.Token = _tokenService.GetToken(userRegisterDTO);
                userRegisterDTO.Password = "";
                userRegisterDTO.ReTypePassword = "";
                return userRegisterDTO;
            }
            return null;

        }
        /// <summary>
        /// Updates user details
        /// </summary>
        /// <param name="id">User Id</param>
        /// <param name="userDTO">Data to update</param>
        /// <returns>Returns the updated user details</returns>
        public UpdateUserDto Update(string id,UpdateUserDto userDTO)
        {
             var user = _repository.GetById(id);
            if(user != null)
            {
                user.Address = userDTO.Address;
                user.Phone = userDTO.Phone;
                user.Name = userDTO.Name;
                var result = _repository.Update(user);
                return userDTO;
            }
            return null;
        }
    }
}
