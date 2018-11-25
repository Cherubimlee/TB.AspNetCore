using System.ComponentModel;

namespace TB.AspNetCore.Domain.Enums
{
    public enum ErrorCode
    {
        /// <summary>
        /// 账户不可用
        /// </summary>
        [Description("账户不可用")]
        AccountDisabled = 10,
        /// <summary>
        /// 已存在
        /// </summary>
        [Description("用户,数据已存在")]
        Existed = 100,
        /// <summary>
        /// 无效的输入
        /// </summary>
        [Description("无效的输入")]
        InvalidData = 300,
        /// <summary>
        /// 密码不正确
        /// </summary>
        [Description("密码不正确")]
        InvalidPassword = 306,
        /// <summary>
        /// token不正确
        /// </summary>
        [Description("token不正确")]
        InvalidToken = 307,
        /// <summary>
        /// 未登录
        /// </summary>
        [Description("未登录")]
        Unauthorized = 401,

        /// <summary>
        /// 权限不足,拒绝访问
        /// </summary>
        [Description("权限不足,拒绝访问")]
        Forbidden = 403,

        /// <summary>
        /// 不存在
        /// </summary>
        [Description("数据,页面不存在")]
        NotFound = 404,

        /// <summary>
        /// 系统错误
        /// </summary>
        [Description("系统错误")]
        SystemError = 500,

        #region 600
        /// <summary>
        /// 请重新登录
        /// </summary>
        [Description("请重新登录")]
        Relogin = 600,

        /// <summary>
        /// 暂未开放
        /// </summary>
        [Description("暂未开放")]
        NoDo = 605,
        #endregion
    }
}
