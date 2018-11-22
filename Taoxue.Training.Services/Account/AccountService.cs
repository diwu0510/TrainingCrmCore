using HZC.Core;
using HZC.Database;
using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace Taoxue.Training.Services
{
    public partial class AccountService : BaseService<AccountEntity>
    {
        public AccountService(string sectionName = "") : base(sectionName)
        { }

        

        #region 重写实体验证
        protected override string ValidateCreate(AccountEntity entity, AppUser user)
        {
            return string.Empty;
        }

        protected override string ValidateUpdate(AccountEntity entity, AppUser user)
        {
            return string.Empty;
        }

        protected override string ValidateDelete(AccountEntity entity, AppUser user)
        {
            return string.Empty;
        }
        #endregion
    }
}

