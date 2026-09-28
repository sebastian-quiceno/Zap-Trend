using ZapTrendBackend.Application.Adapters.Repositories;
using ZapTrendBackend.Application.Ports.Security;
using ZapTrendBackend.Model.Entities;
using ZapTrendBackend.Model.Exceptions.User;

namespace ZapTrendBackend.Application.Authentication
{
    public class SignInUseCase
    {
        private readonly IUserRepository userRepository;
        private readonly IPasswordHasher passwordHasher;
        private readonly ITokenGenerator tokenGenerator;

        public SignInUseCase(IUserRepository userRepository, IPasswordHasher passwordHasher, ITokenGenerator tokenGenerator)
        {
            this.userRepository = userRepository;
            this.passwordHasher = passwordHasher;
            this.tokenGenerator = tokenGenerator;
        }

        public async Task<string> Execute(SignInRequestDTO dto)
        {
            User user = await userRepository.GetByUserNameAsync(dto.Username);
            if (!passwordHasher.Verify(dto.Password, user.PasswordHash))
                throw new IncorrectPasswordException("La contraseña ingresada es incorrecta");
            return tokenGenerator.Generate(user);

        }
    }
}
