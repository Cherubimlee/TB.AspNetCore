using System;
using System.Collections.Generic;
using System.Text;

namespace TB.AspNetCore.Domain.Config
{
    /// <summary>
    /// 预配置常量
    /// </summary>
    public class TbConstant
    {
        /// <summary>
        /// 验证码
        /// </summary>
        public const string WEBSITE_VERIFICATION_CODE = "ValidateCode";
        /// <summary>
        /// 是否展示所有数据标志
        /// </summary>
        public const string ShowAllDataCookie = "ShowAllData";
        /// <summary>
        /// 上次登录路径
        /// </summary>
        public const string LAST_LOGIN_PATH = "LAST_LOGIN_PATH";
        /// <summary>
        /// 公司名称
        /// </summary>
        public const string CompanyName = "星辰无限";
        /// <summary>
        /// 网站授权协议
        /// </summary>
        public const string WEBSITE_AUTHENTICATION_SCHEME = "Web";
        /// <summary>
        /// 日志配置容器名
        /// </summary>
        public const string Log4RepositoryKey = "TBLog";
        
        /// <summary>
        /// Log4Net 日志配置文件
        /// </summary>
        public const string Log4netKey = "Log4NetConfig";

        /// <summary>
        /// Redis配置options
        /// </summary>
        public const string RedisOptionsKey = "RedisConfig";

        /// <summary>
        /// RedisCon配置option
        /// </summary>
        public const string RedisConOptionsKey = "RedisConConfig";
    }
}
