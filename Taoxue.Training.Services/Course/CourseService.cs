using HZC.Core;
using HZC.Database;
using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace Taoxue.Training.Services
{
    public partial class CourseService : BaseService<CourseEntity>
    {

        public CourseService(string sectionName = "") : base(sectionName)
        { }

        #region 重写实体验证
        protected override string ValidateCreate(CourseEntity entity, AppUser user)
        {
            if (string.IsNullOrWhiteSpace(entity.Name))
            {
                return "课程名称不能为空";
            }

            if (entity.UnitPrice < 0)
            {
                return "课程单价不能低于0";
            }

            return string.Empty;
        }

        protected override string ValidateUpdate(CourseEntity entity, AppUser user)
        {
            return ValidateCreate(entity, user);
        }

        protected override string ValidateDelete(CourseEntity entity, AppUser user)
        {
            return string.Empty;
        }
        #endregion
    }
}

