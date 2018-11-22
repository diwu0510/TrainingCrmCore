using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Taoxue.Training.Services
{
    /// <summary>
    /// 资金操作类型
    /// </summary>
    public enum PaymentOperateTypes
    {
        [Description("支付")]
        Pay = 1,
        [Description("退费")]
        Refund = 2
    }
}
