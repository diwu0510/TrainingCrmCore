using System;

namespace Taoxue.Training.Services
{
    public partial class SchoolDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 机构编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 机构名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 机构平台登录密码
        /// </summary>
        public string Pw { get; set; }

        /// <summary>
        /// 是否可用
        /// </summary>
        public bool Enabled { get; set; }
    }
}
