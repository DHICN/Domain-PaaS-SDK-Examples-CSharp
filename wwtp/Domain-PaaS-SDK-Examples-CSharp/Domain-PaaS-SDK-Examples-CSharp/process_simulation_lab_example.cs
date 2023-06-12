using DHICN.PAAS.SDK.ModelDriver.Api;
using DHICN.PAAS.SDK.ModelDriver.Model;
using DHICN.PAAS.SDK.ScenarioManager.Api;
using DHICN.PAAS.SDK.ScenarioManager.Client;
using DHICN.PAAS.SDK.ScenarioManager.Model;
using DHICN.PAAS.SDK.WWTP.MainBus.Api;
using DHICN.PAAS.SDK.WWTP.MainBus.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_PaaS_SDK_Examples_CSharp
{
    public class process_simulation_lab_example
    {
        /// <summary>
        /// 创建方案
        /// </summary>
        /// <returns></returns>
        public Result<DHICN.PAAS.SDK.ScenarioManager.Model.Scenario> Example1()
        {
            #region 参数设置
            string Token = "xxxx";//如需试用，请联系DHI中国获取使用许可和认证信息
            string BasePath = "http://localhost";
            string tenantId = "xxxx-xxxx ";
            string group_id = "1082b4f3-a699-4bcd-a7c0-2525fef824dc";
            string new_scenario_name = "dotnet sdk测试新方案1";
            string parent_scenario_id = "171c59d2-d649-458e-9680-12001d9e49f0";
            string sub_type = "WWTPMLab";
            string description = "高氮负荷进水模拟方案";
            string startTime = "2023-05-10 16:56:00";
            string endTime = "2023-05-12 16:56:00";
            #endregion

            #region 参数构建
            Configuration configuration = new Configuration();
            configuration.AccessToken = Token;
            configuration.BasePath = BasePath;
            configuration.DefaultHeader.Add("tenantId", tenantId);
            configuration.DefaultHeader.Add("Authorization", Token);

            CreateScenarioByGroupPara2 param = new CreateScenarioByGroupPara2();
            param.Description = description;
            param.StartTime = DateTime.Parse(startTime);
            param.EndTime = DateTime.Parse(endTime);
            param.GroupId = group_id;
            param.NewScenarioName = new_scenario_name;
            param.ParentScenarioId = parent_scenario_id;
            param.SubType = sub_type;

            #endregion

            #region 服务调用
            ScenarioManagerApi scenarioManagerApi = new ScenarioManagerApi(configuration);
            var response = scenarioManagerApi.ApiV2ScenarioManagerScenarioDfsCreateByGroupPost("V2", param);
            #endregion

            return response;
        }

        /// <summary>
        /// 计算方案
        /// </summary>
        /// <returns></returns>
        public DHICN.PAAS.SDK.ModelDriver.Client.Result<ModelOperationResult> Example2()
        {
            #region 参数设置
            string Token = "xxxx";//如需试用，请联系DHI中国获取使用许可和认证信息
            string BasePath = "http://localhost";
            string tenantId = "xxxx-xxxx ";
            string group_id = "1082b4f3-a699-4bcd-a7c0-2525fef824dc";
            string new_scenario_name = "dotnet sdk测试新方案1";
            string parent_scenario_id = "171c59d2-d649-458e-9680-12001d9e49f0";
            string sub_type = "WWTPMLab";
            string description = "高氮负荷进水模拟方案";
            string startTime = "2023-05-10 16:56:00";
            string endTime = "2023-05-12 16:56:00";
            #endregion

            #region 参数构建
            DHICN.PAAS.SDK.ModelDriver.Client.Configuration configuration = new DHICN.PAAS.SDK.ModelDriver.Client.Configuration();
            configuration.AccessToken = Token;
            configuration.BasePath = BasePath;
            configuration.DefaultHeader.Add("tenantId", tenantId);
            configuration.DefaultHeader.Add("Authorization", Token);

            string scenarioId = "9fe4e1d0-d800-4946-9287-71e24630bda3";
            var modelInfoDic = new Dictionary<string, object>
            {
                { "scenarioId", scenarioId },
                { "tenantId", tenantId },
                { "type", 19 }
            };

            ScenarioModelMessageInput scenarioModelMessageInput = new ScenarioModelMessageInput();
            scenarioModelMessageInput.ProjectName = "bz";
            scenarioModelMessageInput.TenantId = Guid.Parse(tenantId);
            scenarioModelMessageInput.ScenarioId = Guid.Parse(scenarioId);
            scenarioModelMessageInput.ModelType = "WWTP";
            scenarioModelMessageInput.Priority = 0;
            scenarioModelMessageInput.ModelInfo = JsonConvert.SerializeObject(modelInfoDic);

            #endregion

            #region 服务调用
            ModelRunApi modelRunApi = new ModelRunApi(configuration);
            var response = modelRunApi.ModelRunRunModelPost(scenarioModelMessageInput);
            #endregion

            return response;
        }

        /// <summary>
        /// 查询方案计算进度
        /// </summary>
        /// <returns></returns>
        public DHICN.PAAS.SDK.ModelDriver.Client.Result<List<CalculateStatusOutput>> Example3()
        {
            #region 参数设置
            string Token = "xxxx";//如需试用，请联系DHI中国获取使用许可和认证信息
            string BasePath = "http://localhost";
            string tenantId = "xxxx-xxxx ";
            #endregion

            #region 参数构建
            DHICN.PAAS.SDK.ModelDriver.Client.Configuration configuration = new DHICN.PAAS.SDK.ModelDriver.Client.Configuration();
            configuration.AccessToken = Token;
            configuration.BasePath = BasePath;
            configuration.DefaultHeader.Add("tenantId", tenantId);
            configuration.DefaultHeader.Add("Authorization", Token);

            string scenarioId = "9fe4e1d0-d800-4946-9287-71e24630bda3";
            #endregion

            #region 服务调用
            ModelRunApi modelRunApi = new ModelRunApi(configuration);
            var response = modelRunApi.ModelRunV2CalculateStatusPost(new List<Guid>() { Guid.Parse(scenarioId) });
            #endregion

            return response;
        }

        /// <summary>
        /// 获取计算日志
        /// </summary>
        /// <returns></returns>
        public DHICN.PAAS.SDK.ModelDriver.Client.Result<CalculateLogsOutput> Example4()
        {
            #region 参数设置
            string Token = "xxxx";//如需试用，请联系DHI中国获取使用许可和认证信息
            string BasePath = "http://localhost";
            string tenantId = "xxxx-xxxx ";
            #endregion

            #region 参数构建
            DHICN.PAAS.SDK.ModelDriver.Client.Configuration configuration = new DHICN.PAAS.SDK.ModelDriver.Client.Configuration();
            configuration.AccessToken = Token;
            configuration.BasePath = BasePath;
            configuration.DefaultHeader.Add("tenantId", tenantId);
            configuration.DefaultHeader.Add("Authorization", Token);

            string scenarioId = "9fe4e1d0-d800-4946-9287-71e24630bda3";
            #endregion

            #region 服务调用
            ModelRunApi modelRunApi = new ModelRunApi(configuration);
            var response = modelRunApi.ModelRunV2CalculateLogsGet(scenarioId);
            #endregion

            return response;
        }

        /// <summary>
        /// 获取计算方案的出水水质结果
        /// </summary>
        /// <returns></returns>
        public DHICN.PAAS.SDK.WWTP.MainBus.Client.Result<List<SimResultsOutupt>> Example5()
        {
            #region 参数设置
            string Token = "xxxx";//如需试用，请联系DHI中国获取使用许可和认证信息
            string BasePath = "http://localhost";
            string tenantId = "xxxx-xxxx ";
            #endregion

            #region 参数构建
            DHICN.PAAS.SDK.WWTP.MainBus.Client.Configuration configuration = new DHICN.PAAS.SDK.WWTP.MainBus.Client.Configuration();
            configuration.AccessToken = Token;
            configuration.BasePath = BasePath;
            configuration.DefaultHeader.Add("tenantId", tenantId);
            configuration.DefaultHeader.Add("Authorization", Token);

            string scenarioId = "9fe4e1d0-d800-4946-9287-71e24630bda3";
            #endregion

            #region 服务调用
            ProNumSimLabApi proNumSimLabApi = new ProNumSimLabApi(configuration);
            var response = proNumSimLabApi.ApiProNumSimLabSimResultsGet(scenarioId);
            #endregion

            return response;
        }
    }
}
