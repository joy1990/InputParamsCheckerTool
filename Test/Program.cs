using Entity;
using Entity.Req;
using InputParamsCheckerTool;
using Newtonsoft.Json;
using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //非法参数注册
            var registA = new RegistInfoReq();
            var rspA = InputParamsCheck.Excute(() =>
            {
                return BaseRsp<bool>.RspOk(true);
            }, registA, "用户注册", "注册A");


            //正规参数注册
            var registB = new RegistInfoReq() { NickName = "小明" };
            var rspB= InputParamsCheck.Excute(() =>
            {
                return BaseRsp<bool>.RspOk(true);
            }, registB, "用户注册", "注册B");


            //打印结果
            Console.WriteLine(string.Format("A注册结果：{0}", JsonConvert.SerializeObject(rspA)));
            Console.WriteLine(string.Format("B注册结果：{0}", JsonConvert.SerializeObject(rspB)));

            Console.Read();

        }
    }
}
