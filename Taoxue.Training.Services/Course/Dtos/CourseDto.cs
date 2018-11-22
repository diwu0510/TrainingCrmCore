using System;

namespace Taoxue.Training.Services
{
    public partial class CourseDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 课程名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 课程单价
        /// </summary>
        public int UnitPrice { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 是否有效
        /// </summary>
        public bool Enabled { get; set; }

    }
}
