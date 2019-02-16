### 介绍
#### 背景
 - 解决日常API接口参数验证的问题，
 - 摆脱代码中充斥大量的字段if判定请求，
 - 添加了日志记录，监控日志执行情况
 
#### 使用方法
 - eg.我们需要在注册时验证注册信息，我们做如下几步：
     1. 给注册信息实体的字段加上特性参数，比如如下要验证昵称是否为空，我们只要加一个Required特性
   ```/// <summary>
    /// 注册信息
    /// </summary>
    public class RegistInfoReq
    {
        /// <summary>
        /// 昵称
        /// </summary>
        [Required(ErrorMessage = "昵称必填")]
        public string NickName { get; set; }
    }
    ```

     2. 调用InputParamsCheck类下的Excute方法，
         - 传入请求参数
         - 传入注册方法
         - 该方法贯彻了AOP思想，以环绕的方式将“注册主体逻辑”嵌入在验证方法中；方法实现会抓取实体实体上的特性进行验证，如果验证通过，就会执行具体的注册逻辑
         ```//正规参数注册
            var registB = new RegistInfoReq() { NickName = "小明" };
            var rspB= InputParamsCheck.Excute(() =>
            {
                return BaseRsp<bool>.RspOk(true);
            }, registB, "用户注册", "注册B");
        ```
              
       