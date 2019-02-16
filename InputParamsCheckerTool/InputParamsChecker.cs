using Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;

namespace InputParamsCheckerTool
{
    /// <summary>
    /// 输入参数验证
    /// </summary>
    public class InputParamsCheck
    {
        /// <summary>
        /// 执行输入输入参数验证
        /// </summary>
        /// <typeparam name="TResponse">响应类型</typeparam>
        /// <typeparam name="TRequest">请求类型</typeparam>
        /// <param name="fun">具体执行方法</param>
        /// <param name="request">请求信</param>
        /// <param name="logCategory">日志分类</param>
        /// <param name="filter">日志搜索</param>
        /// <returns></returns>
        public static BaseRsp<TResponse> Excute<TResponse, TRequest>(Func<BaseRsp<TResponse>> fun, TRequest request, string logCategory, string filter) where TRequest : new()
        {
            var stopwatch = Stopwatch.StartNew();//记录时间

            BaseRsp<TResponse> response = null;//返回信息

            if (request == null) //请求参数为空验证
            {
                response = BaseRsp<TResponse>.RspFail(default(TResponse), "请求实体必传");
            }
            else
            {
                var context = new ValidationContext(request);//参数验证
                var errResults = new List<ValidationResult>();
                Validator.TryValidateObject(request, context, errResults, true);

                if (errResults != null && errResults.Count > 0)
                {
                    var errorMsg = string.Format("请求参数非法，详情：{0}", string.Join("|", errResults.Select(w => w.ErrorMessage)));
                    response = BaseRsp<TResponse>.RspFail(default(TResponse), errorMsg);
                }
                else
                {
                    response = fun();
                }
            }
            stopwatch.Stop();

            //记录执行日志
            var logContent = string.Format("日志-->响应内容：{0}，请求内容：{1}", JsonConvert.SerializeObject(response), JsonConvert.SerializeObject(request));
            Log(logContent, logCategory, filter);

            return response;
        }

        /// <summary>
        /// 日志记录
        /// </summary>
        /// <param name="logContent">日志内容</param>
        /// <param name="logCategory">日志类别</param>
        /// <param name="filter">日志过滤条件</param>
        private static void Log(string logContent, string logCategory, string filter)
        {
            //todo
        }
    }
}
