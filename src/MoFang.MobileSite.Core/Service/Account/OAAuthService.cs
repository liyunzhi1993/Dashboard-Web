using MoFang.MobileSite.Core.Model.User;
using MoFang.MobileSite.Domain.Consts;
using MoFang.MobileSite.Domain.Entity;
using MoFang.MobileSite.Core.Redis;
using System;
using System.Linq;
using System.Threading.Tasks;
using MoFang.MobileSite.Core.Model;
using MoFang.MobileSite.Core.Utility;
using Newtonsoft.Json;
using MoFang.MobileSite.Core.Model.OA;
using MoFang.MobileSite.Domain.Enums;

namespace MoFang.MobileSite.Core.Service
{
    /// <summary>
    /// OA认证服务
    /// </summary>
    /// 时间：2018/1/17
    /// 修改：李允智
    /// <seealso cref="MoFang.MobileSite.Core.Service.ServiceBase" />
    public class OAAuthService : ServiceBase
    {
        private const string TOKEN_KEY = "OAUserToken";
        public OAAuthService(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {

        }

        /// <summary>
        /// 编辑用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Result> EditUserInfo(string id, UserModel model)
        {
            var redis = this.RedisProvider.GetDatabase();
            var originalModel=redis.JsonGet<UserModel>(TOKEN_KEY + id);
            await redis.StringSetAsync(TOKEN_KEY + id, JsonConvert.SerializeObject(MapperProvider.Map(model, originalModel)));
            return Result.SuccessResult(model);
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// 时间：2018/1/17
        /// 修改：李允智
        public UserModel Get(string id)
        {
            var redis = this.RedisProvider.GetDatabase();

            return redis.JsonGet<UserModel>(TOKEN_KEY + id);
        }

        /// <summary>
        /// OA登录
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        /// 时间：2018/1/17
        /// 修改：李允智
        public async Task<Result<string>> OALogin(LoginModel model)
        {
            try
            {
                var url = DashboardConfig.SSOAuthurizationServerBasePath + "/Token";
                var postData = "grant_type=password&username=" + model.UserName + "&password=" + model.Password;
                var ret = await WebHelper.Post(url, postData);
                SsoAuthurizationModel result = JsonConvert.DeserializeObject<SsoAuthurizationModel>(ret.ToString());
                string token = this.GenerateAndStoreToken(model.UserName, model.RememberPassword);
                return Result.SuccessResult(token);
            }
            catch (Exception)
            {
                return Result<string>.ErrorResult("用户名或密码不匹配");
            }
        }

        /// <summary>
        /// OA登出
        /// </summary>
        /// 时间：2018/1/17
        /// 修改：李允智
        public void OALogOut()
        {
            if (this.OASecurityManager.Token != null)
            {
                var database = this.RedisProvider.GetDatabase();
                string key = RedisKeys.GetTokenCacheKey(OASecurityManager.Token);
                database.KeyDelete(key);
            }
        }

        /// <summary>
        /// 持久化Redis Token
        /// </summary>
        /// <param name="userID">The user identifier.</param>
        /// <param name="rememberPassword">if set to <c>true</c> [remember password].</param>
        /// <returns></returns>
        /// 时间：2018/1/17
        /// 修改：李允智
        private string GenerateAndStoreToken(string userID, bool rememberPassword)
        {
            var redis = this.RedisProvider.GetDatabase();
            string token = EncryptHelper.EncryptMD5(Guid.NewGuid().ToString());
            string key = RedisKeys.GetTokenCacheKey(token);
            redis.StringSet(key, userID);
            if (!rememberPassword)
            {
                redis.KeyExpire(key, DateTime.Now.AddDays(7));
            }
            else
            {
                redis.KeyExpire(key, DateTime.Now.AddDays(30));
            }

            //用户信息是写到Redis里的
            string userToken = TOKEN_KEY + userID;
            var user=redis.JsonGet<UserModel>(userToken);
            if (user==null)
            {
                UserModel _user = new UserModel();
                _user.UserName = userID;
                _user.Avatar = DashboardConfig.DefaultAvatar;
                _user.Sex=SexType.female;
                _user.NickName = userID;
                redis.StringSetAsync(userToken, JsonConvert.SerializeObject(_user));
            }
            return token;
        }
    }
}
