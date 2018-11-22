using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HZC.Core;
using Taoxue.Training.Services;
using Taoxue.Training.Website.Extensions;
using HZC.Utils;

namespace Taoxue.Training.WebSite.Areas.Manage.Controllers
{
    //[Authorize]
    public class SchoolController : AdminBaseController
    {
        private readonly SchoolService service = new SchoolService();

        public SchoolController()
        { }

        #region 列表页
        public ActionResult Index()
        {
            InitUI();
            return View();
        }

        public JsonResult Get(SchoolSearchParam param)
        {
            var list = service.Fetch(param);
            return Json(ResultUtil.Success<IEnumerable<SchoolEntity>>(list));
        }
        #endregion

        #region 创建
        public IActionResult Create()
        {
            InitUI();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create(IFormCollection collection)
        {
            SchoolEntity entity = new SchoolEntity();
            TryUpdateModelAsync(entity);
            entity.Enabled = true;
            entity.Pw = AESEncryptUtil.Encrypt("123456");
            var result = service.Create(entity, AppUser);
            // 如果有缓存，注意在这里要清空缓存

            return Json(result);
        }
        #endregion

        #region 修改
        public IActionResult Edit(int id)
        {
            var entity = service.Load(id);
            if (entity == null)
            {
                return NotFound();
            }
            else
            {
                InitUI();
                return View(entity);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Edit(int id, IFormCollection collection)
        {
            SchoolEntity entity = new SchoolEntity();
            TryUpdateModelAsync(entity);
            var result = service.Update(entity, AppUser);
            // 如果有缓存，注意在这里要清空缓存

            return Json(result);
        }
        #endregion

        #region 删除
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Delete(int id)
        {
            var entity = service.Load(id);
            if (entity == null)
            {
                return Json(ResultUtil.AuthFail("请求的数据不存在"));
            }
            var result =  service.Remove(entity, AppUser);
            // 如果有缓存，注意在这里要清空缓存

            return Json(result);
        }
        #endregion

        #region 辅助方法
        private void InitUI()
        {
        }
        #endregion
    }
}
