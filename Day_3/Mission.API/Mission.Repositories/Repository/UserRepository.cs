using Microsoft.EntityFrameworkCore;
using Mission.Entity;
using Mission.Entity.ViewModel.Login;
using Mission.Repositories.iRepository;
using System.Threading.Tasks;
using Mission.Entity.ViewModel.Login;


namespace Mission.Repositories.Repository
{
    public class UserRepository(MissionDbContext dbContext) : iUserRepository
    {
        private readonly MissionDbContext _context = dbContext;

        public async Task<(UserLoginResponseModel? response, string message)> LogiUser(UserLoginRequestModel model)
        {
            var user = await _context.Users.Where(u => u.Email.ToLower() == model.Email.ToLower()).FirstOrDefaultAsync();

            if (user == null)
            {
                return (null, "User doesn't exist for the given emailaddress");
            }

            if (user.Password != model.Password)
            {
                return (null, "Password doesn't matched");
            }

            var response = new UserLoginResponseModel()
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                UserType = user.UserType,
                UserImage = user.UserImage,
            };

            return (response, "Login Successfully");
        }
    }
}
