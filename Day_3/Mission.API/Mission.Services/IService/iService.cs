using Mission.Entity.ViewModel;
using Mission.Entity.ViewModel.Login;
using System.Threading.Tasks;

namespace Mission.Services.IService
{
    public interface iService
    {
        Task<ResponseResult> LogiUser(UserLoginRequestModel model);
    }
}
