namespace Entity
{
    /// <summary>
    /// 基础响应类 统一响应code
    /// </summary>
    public class BaseRsp<T>
    {
        #region 字段
        /// <summary>
        /// 响应code
        /// </summary>
        public int RspCode { get; set; }

        /// <summary>
        /// 响应消息 
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 响应数据
        /// </summary>
        public T Data { get; set; }
        #endregion

        
        #region 执行方法
        /// <summary>
        /// 执行成功
        /// </summary>
        /// <param name="data">响应数据</param>
        /// <param name="message">响应消息</param>
        /// <returns></returns>
        public static BaseRsp<T> RspOk(T data, string message = "执行成功")
        {
            return new BaseRsp<T>() { RspCode = 200, Message = message, Data = data };
        }

        /// <summary>
        /// 执行失败（业务逻辑错误）
        /// </summary>
        /// <param name="data">响应数据</param>
        /// <param name="message">响应消息</param>
        /// <returns></returns>
        public static BaseRsp<T> RspFail(T data, string message = "执行失败")
        {
            return new BaseRsp<T>() { RspCode = 201, Message = message, Data = data };
        }

        /// <summary>
        /// 执行异常
        /// </summary>
        /// <param name="data">响应数据</param>
        /// <param name="message">响应消息</param>
        /// <returns></returns>
        public static BaseRsp<T> RspError(T data, string message = "执行异常")
        {
            return new BaseRsp<T>() { RspCode = 500, Message = message, Data = data };
        }


        /// <summary>
        /// 自定义响应消息
        /// </summary>
        /// <param name="data">响应数据</param>
        /// <param name="rspCode">响应异常</param>
        /// <param name="message">响应消息</param>
        /// <returns></returns>
        public static BaseRsp<T> RspCustom(T data, int rspCode, string message)
        {
            return new BaseRsp<T>() { RspCode = rspCode, Message = message, Data = data };
        } 
        #endregion
    }
}
