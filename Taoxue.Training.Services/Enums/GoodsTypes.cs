using System.ComponentModel;

namespace Taoxue.Training.Services
{
    /// <summary>
    /// 商品类型
    /// </summary>
    public enum GoodsTypes
    {
        [Description("课程")]
        Course = 1,
        [Description("其他物品")]
        Goods = 2
    }
}
