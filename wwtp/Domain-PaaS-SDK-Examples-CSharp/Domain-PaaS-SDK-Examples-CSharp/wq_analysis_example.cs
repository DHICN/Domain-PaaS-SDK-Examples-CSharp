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
    public class wq_analysis_example
    {
        /// <summary>
        /// 获取水质生物生长模拟数据
        /// </summary>
        /// <returns></returns>
        public Result<List<MicroOrganismOutput>> Example()
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
            WQAnalysisApi wQAnalysisApi = new WQAnalysisApi(configuration);
            var wq_response = wQAnalysisApi.V2WqAnalysisMicroOrganismGet(startTime, endTime, modelName, productLine);
            #endregion

            return wq_response;
        }
    }
}
