using DHICN.PAAS.SDK.WWTP.MainBus.Api;
using DHICN.PAAS.SDK.WWTP.MainBus.Client;
using DHICN.PAAS.SDK.WWTP.MainBus.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_PaaS_SDK_Examples_CSharp
{
    public  class intelligent_denitrification_example
    {
        /// <summary>
        /// 获取全流程水质数据
        /// </summary>
        /// <returns></returns>
        public Result<List<DosingParameterOutput>> Example()
        {
            #region 参数设置
            string Token = "xxxx";//如需试用，请联系DHI中国获取使用许可和认证信息
            string BasePath = "http://localhost";
            string tenantId = "xxxx-xxxx ";
            string productLine = "1A";
            int category = 1;
            #endregion

            #region 参数构建
            Configuration configuration = new Configuration();
            configuration.AccessToken = Token;
            configuration.BasePath = BasePath;
            configuration.DefaultHeader.Add("tenantId", tenantId);
            configuration.DefaultHeader.Add("Authorization", Token);
            #endregion

            #region 服务调用
            IntelligentDenitrificationApi intelligentDenitrificationApi = new IntelligentDenitrificationApi(configuration);
            var response = intelligentDenitrificationApi.ApiIntelligentDenitrificationGetDosingParameterGet(category, productLine);
            #endregion

            return response;
        }
    }
}
