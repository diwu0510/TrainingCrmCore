using HZC.Database;
using System.ComponentModel.DataAnnotations;

namespace Taoxue.Training.Services
{
    [MyDataTable("Crm_Course")]
    public partial class CourseEntity : BaseEntity
    {
        /// <summary>
        /// 机构ID
        /// </summary>
        [MyDataField(UpdateIgnore = true)]
        public int SchoolId { get; set; }

        /// <summary>
        /// 课程名称
        /// </summary>
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Name { get; set; }

        /// <summary>
        /// 课程单价
        /// </summary>
        public int UnitPrice { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Remark { get; set; }

        /// <summary>
        /// 是否有效
        /// </summary>
        public bool Enabled { get; set; } = true;

        /// <summary>
        /// 是否删除
        /// </summary>
        [MyDataField(UpdateIgnore = true)]
        public bool IsDel { get; set; }

    }
}
