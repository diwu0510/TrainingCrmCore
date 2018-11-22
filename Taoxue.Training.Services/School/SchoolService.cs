using HZC.Core;
using HZC.Database;
using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace Taoxue.Training.Services
{
    public partial class SchoolService : BaseService<SchoolEntity>
    {
        public SchoolService(string sectionName = "") : base(sectionName)
        { }

        #region 重写实体验证
        protected override string ValidateCreate(SchoolEntity entity, AppUser user)
        {
            if (string.IsNullOrWhiteSpace(entity.Code))
            {
                return "机构编号不能为空";
            }

            if (string.IsNullOrWhiteSpace(entity.Name))
            {
                return "机构名称不能为空";
            }

            var count = db.GetCount<SchoolEntity>(MySearchUtil.New()
                .AndEqual("Code", entity.Code.Trim())
                .AndNotEqual("Id", entity.Id));
            if (count > 0)
            {
                return "机构编号已经存在";
            }
            return string.Empty;
        }

        protected override string ValidateUpdate(SchoolEntity entity, AppUser user)
        {
            return ValidateCreate(entity, user);
        }

        protected override string ValidateDelete(SchoolEntity entity, AppUser user)
        {
            return string.Empty;
        }
        #endregion
    }
}

