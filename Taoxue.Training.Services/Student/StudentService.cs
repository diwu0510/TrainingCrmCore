using HZC.Core;
using HZC.Database;
using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace Taoxue.Training.Services
{
    public partial class StudentService : BaseService<StudentEntity>
    {

        public StudentService(string sectionName = "") : base(sectionName)
        { }

        #region 重写实体验证
        protected override string ValidateCreate(StudentEntity entity, AppUser user)
        {
            return string.Empty;
        }

        protected override string ValidateUpdate(StudentEntity entity, AppUser user)
        {
            return string.Empty;
        }

        protected override string ValidateDelete(StudentEntity entity, AppUser user)
        {
            return string.Empty;
        }
        #endregion
    }
}

