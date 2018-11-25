using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TB.AspNetCore.Application.Action;

namespace TB.AspNetCore.WebSite.Controllers
{
    public class CaiWuController : WebBase
    {
        [Action("订单管理",ActionType.CaiwuManager,1)]
        public ViewResult Index()
        {
            return View();
        }
    }
}