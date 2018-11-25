using System.ComponentModel;

namespace TB.AspNetCore.Domain.Enums
{
    public enum AccountType
    {
        [Description("超级管理员")]
        /// <summary>
        /// 管理员
        /// </summary>
        Admin = 1,
        /// <summary>
        /// 普通用户
        /// </summary>
        [Description("普通用户")]
        StandardUser = 2,
    }
}
