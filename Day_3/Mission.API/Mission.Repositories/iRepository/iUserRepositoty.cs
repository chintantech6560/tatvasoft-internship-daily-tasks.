using Mission.Entity.ViewModel.Login;
using System.Threading.Tasks;

namespace Mission.Repositories.iRepository
{
    public interface iUserRepository
    {
        Task<(UserLoginResponseModel? response, string message)> LogiUser(UserLoginRequestModel model);
    }
}
