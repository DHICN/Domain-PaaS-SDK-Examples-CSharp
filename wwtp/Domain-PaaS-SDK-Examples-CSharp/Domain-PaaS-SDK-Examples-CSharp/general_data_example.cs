using DHICN.PAAS.SDK.WWTP.MainBus.Api;
using DHICN.PAAS.SDK.WWTP.MainBus.Client;
using DHICN.PAAS.SDK.WWTP.MainBus.Model;

namespace Domain_PaaS_SDK_Examples_CSharp
{
    public class general_data_example
    {
        /// <summary>
        /// 获取全流程水质数据
        /// </summary>
        /// <returns></returns>
        public Result<List<EntireProcessWqOut>> Example()
        {
            #region 参数设置
            string Token = "xxxx";//如需试用，请联系DHI中国获取使用许可和认证信息
            string BasePath = "http://localhost";
            string tenantId = "xxxx-xxxx ";
            string productLine = "1A";
            string startTime = "2023-05-10 16:56:00";
            string endTime = "2023-05-12 16:56:00";
            string modelName = "在线滚动模型";
            #endregion

            #region 参数构建
            Configuration configuration = new Configuration();
            configuration.AccessToken = Token;
            configuration.BasePath = BasePath;
            configuration.DefaultHeader.Add("tenantId", tenantId);
            configuration.DefaultHeader.Add("Authorization", Token);
            #endregion

            #region 服务调用
            GeneralDataApi instance = new GeneralDataApi(configuration);
            var response = instance.ApiV2OutputEntireProcessTsByProductlineGet(productLine, startTime, endTime, modelName);
            #endregion

            return response;
        }
    }
}
