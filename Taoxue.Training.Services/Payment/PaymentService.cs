using HZC.Core;
using HZC.Database;
using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace Taoxue.Training.Services
{
    public partial class PaymentService : BaseService<PaymentEntity>
    {

        public PaymentService(string sectionName = "") : base(sectionName)
        { }

        #region 重写实体验证
        protected override string ValidateCreate(PaymentEntity entity, AppUser user)
        {
            return string.Empty;
        }

        protected override string ValidateUpdate(PaymentEntity entity, AppUser user)
        {
            return string.Empty;
        }

        protected override string ValidateDelete(PaymentEntity entity, AppUser user)
        {
            return string.Empty;
        }
        #endregion
    }
}

