using System.Threading.Tasks;
using Mission.Repositories.iRepository;
using Mission.Services.IService;
using Mission.Entity.ViewModel;
using Mission.Entity.ViewModel.Login;

namespace Mission.Services.Service
{
    public class Service : iService
    {
        private readonly iUserRepository _userRepository;
        private readonly JWTService _jWTService;

        public Service(iUserRepository userRepository, JWTService jWTService)
        {
            _userRepository = userRepository;
            _jWTService = jWTService;
        }

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
                result.Data = _jWTService.GenerateJwtToken(response);
                result.Result = ResponseStatus.Success;
            }

            return result;
        }
    }
}
