using turbo_engine.Data.VO;
using turbo_engine.Model;

namespace turbo_engine.Repository
{
    public interface IUserRepository
    {
        User? ValidateCredentials(UserVO user);

        User? ValidateCredentials(string username);

        bool RevokeToken(string username);

        User? RefreshUserInfo(User user);
    }
}
