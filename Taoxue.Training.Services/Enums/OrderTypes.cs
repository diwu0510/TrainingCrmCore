using System.ComponentModel;

namespace Taoxue.Training.Services
{
    /// <summary>
    /// 订单类型
    /// </summary>
    public enum OrderTypes
    {
        [Description("新订单")]
        New = 1,
        [Description("续费")]
        Renew = 2
    }
}
