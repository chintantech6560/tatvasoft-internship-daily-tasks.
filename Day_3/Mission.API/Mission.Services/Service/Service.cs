using Mission.Entity.ViewModel;
using Mission.Entity.ViewModel.Login;
using Mission.Repositories.iRepository;
using Mission.Services.IService;
using System.Threading.Tasks;

namespace Mission.Services.Service
{
    public class Service(iUserRepository userRepository) : iService
    {
        private readonly iUserRepository _userRepository = userRepository;
        public async Task<ResponseResult> LogiUser(UserLoginRequestModel model)
        {
            var (response, message) = await _userRepository.LogiUser(model);

            var result = new ResponseResult()
            {
                Data = response,
                Message = message
            };

            if (response == null)
            {
                result.Result = ResponseStatus.Error;
            }
            else
            {

                result.Result = ResponseStatus.Success;
            }

            return result;
        }
    }
}
