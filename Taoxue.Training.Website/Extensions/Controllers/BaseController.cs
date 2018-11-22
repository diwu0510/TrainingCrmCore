using log4net;
using Microsoft.AspNetCore.Mvc;

namespace Taoxue.Training.Website.Extensions
{
    public class BaseController : Controller
    {
        #region 日志
        private ILog _log;

        protected ILog Log
        {
            get
            {
                if (_log == null)
                {
                    string area = "";
                    if (ControllerContext.RouteData.Values["area"] != null)
                    {
                        area = ControllerContext.RouteData.Values["area"].ToString() + "-";
                    }
                    string controller = ControllerContext.RouteData.Values["controller"].ToString();
                    string action = ControllerContext.RouteData.Values["action"].ToString();

                    _log = LogManager.GetLogger(Log4NetConfig.RepositoryName, area + controller + "-" + action);
                }
                return _log;
            }
        } 
        #endregion
    }
}
