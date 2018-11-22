using System.ComponentModel;

namespace Taoxue.Training.Services
{
    /// <summary>
    /// 课时操作类型
    /// </summary>
    public enum ClassOperateTypes
    {
        [Description("增加课时")]
        Add,
        [Description("减少课时")]
        Reduce
    }
}
