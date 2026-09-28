using System;
using System.Collections.Generic;
using System.Text;
using ZapTrendBackend.Application.Adapters.Repositories;
using ZapTrendBackend.Application.Ports.Security;
using ZapTrendBackend.Model.Entities;
using ZapTrendBackend.Model.Exceptions;
using ZapTrendBackend.Model.Exceptions.User;

namespace ZapTrendBackend.Application.Authentication
{
    public class SignUpUseCase
    {
        private readonly IUserRepository userRepository;
        private readonly IPasswordHasher passwordHasher;

        public SignUpUseCase(IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            this.userRepository = userRepository;
            this.passwordHasher = passwordHasher;
        }

        public async Task Execute(SignUpRequestDTO dto) {
            if (await userRepository.ExistByEmail(dto.Mail)){
                throw new DocumentAlreadyExistsException("El email ingresado para crear el usuario ya existe");
            }
            if (await userRepository.ExistByUsername(dto.Username))
            {
                throw new DocumentAlreadyExistsException("El nombre de usuario ingresado para crear el usuario ya existe");
            }
            if (await userRepository.ExistByDocument(dto.Document, dto.DocumentType))
            {
                throw new DocumentAlreadyExistsException("El documento ingresado para crear el usuario  ya existe");
            }

            string passwordHashed = passwordHasher.Hash(dto.Password);

            User user = new UserBuilder()
                .WithCredentials(dto.Username, passwordHashed)
                .WithFullName(dto.Name, dto.SecondName)
                .WithIdentityDocument(dto.DocumentType, dto.Document)
                .WithBirthday(dto.Birthday)
                .WithContactInfo(dto.Phone, dto.Mail)
                .Build();

            await userRepository.SaveAsync(user);

        }
    }
}
