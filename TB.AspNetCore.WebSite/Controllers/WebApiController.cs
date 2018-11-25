using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TB.AspNetCore.Domain.Config;
using TB.AspNetCore.Domain.Enums;
using TB.AspNetCore.Domain.Models;
using TB.AspNetCore.Domain.Models.Web;
using TB.AspNetCore.Domain.Repositorys;

namespace TB.AspNetCore.WebSite.Controllers
{
    [Produces("application/json")]
    [Route("webapi/[action]")]
    public class WebApiController : WebBase
    {
        public IAccountService accountService { get; set; }

        public IPermissionService _permissionService { get; set; }

        public ITaskService _taskService { get; set; }
        #region 登录模块
        [AllowAnonymous]
        [HttpPost]
        public Result Login([FromBody]BackstageUserAdd model)
        {
            return accountService.Login(model);
        }

        [HttpGet]
        public Result Logout()
        {
            Result result = new Result();
            return accountService.LogoutUser();
        }
        #endregion

        #region 添加后台管理员
        [HttpPost]
        public Result AddMemberAdd_Update([FromBody]BackstageUserAdd model)
        {
            if (!string.IsNullOrEmpty(model.Id))
            {
                return accountService.UpdateAccount(model);
            }
            return accountService.AddAccount(model);
        }
        /// <summary>
        /// 密码修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public Result MemberPwd_Update([FromBody]BackstageUserAdd model)
        {
            return accountService.UpdatePwd(model);
        }
        [HttpGet]
        public Result GetBackstageUser(string id)
        {
            return accountService.GetBackstageUser(id);
        }
        /// <summary>
        /// 禁用用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public Result SetMemberState([FromBody]BackstageUserAdd model)
        {
            if (model.AccountStatus == AccountStatus.Normal)
            {
                model.AccountStatus = AccountStatus.Disabled;
            }
            else
            {
                model.AccountStatus = AccountStatus.Normal;
            }
            return accountService.UpdateAccount(model);
        }
        #endregion

        #region 后台用户列表
        public Result BackstageUser([FromBody]AccountSearchModel model)
        {
            return accountService.GetBackstageUserList(model);
        }
        #endregion

        #region 角色模块
        [HttpPost]
        public Result GetRoles()
        {
            return _permissionService.GetRoles();
        }
        [HttpPost]
        public Result SaveRoles([FromBody]RoleModel model)
        {
            return _permissionService.SaveRoles(model);
        }
        [HttpPost]
        public Result DeleteRoles([FromBody]RoleModel model)
        {
            return _permissionService.DeleteRoles(model);
        }
        #endregion

        #region 计划任务模块
        [HttpPost]
        public Result GetTaskList()
        {
            return _taskService.GetTaskList();
        }
        [HttpPost]
        public async Task<Result> AddTaskAsync([FromBody]TaskScheduleModel model)
        {
            if (model != null && !string.IsNullOrEmpty(model.Id)&&!model.Id.Equals("-1"))
            {
                return await _taskService.ModifyTaskAsync(model);
            }
            return await _taskService.AddTaskAsync(model);
        }

        public async Task<Result> DelTaskAsync([FromBody]TaskScheduleModel model)
        {
            return await _taskService.DelTaskAsync(model);
        }
        #endregion
    }
}