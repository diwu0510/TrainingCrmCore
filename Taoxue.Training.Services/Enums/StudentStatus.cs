using System.ComponentModel;

namespace Taoxue.Training.Services
{
    public enum StudentStatus
    {
        [Description("在校")]
        In = 1,
        [Description("离校")]
        Out = 2
    }
}
