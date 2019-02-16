using System.ComponentModel.DataAnnotations;

namespace Entity.Req
{
    /// <summary>
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
}
