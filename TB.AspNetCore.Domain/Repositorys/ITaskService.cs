using System.Threading.Tasks;
using TB.AspNetCore.Domain.Config;
using TB.AspNetCore.Domain.Models.Web;

namespace TB.AspNetCore.Domain.Repositorys
{
    public interface ITaskService
    {
        //获取任务列表
        Result GetTaskList();
        //添加任务
        Task<Result> AddTaskAsync(TaskScheduleModel model);
        //修改任务
        Task<Result> ModifyTaskAsync(TaskScheduleModel model);
        //删除任务
        Task<Result> DelTaskAsync(TaskScheduleModel model);
        //暂停任务
        Result PauseTask();
        //开启任务
        Result StartTask();
    }
}
