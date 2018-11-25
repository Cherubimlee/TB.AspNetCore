using System.Threading.Tasks;
using TB.AspNetCore.Domain.Models.Web;

namespace TB.AspNetCore.Domain.Config
{
    public interface IJobCenter
    {
        /// <summary>
        /// 添加定时任务
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        Task<Result> AddScheduleJobAsync(TaskScheduleModel m);

        /// <summary>
        /// 暂停定时任务
        /// </summary>
        /// <param name="jobGroup"></param>
        /// <param name="jobName"></param>
        /// <returns></returns>
        Task<Result> StopScheduleJobAsync(string jobGroup, string jobName);

        /// <summary>
        /// 恢复定时任务
        /// </summary>
        /// <param name="jobGroup"></param>
        /// <param name="jobName"></param>
        /// <returns></returns>
        Task<Result> RunScheduleJobAsync(TaskScheduleModel m);
    }
}
