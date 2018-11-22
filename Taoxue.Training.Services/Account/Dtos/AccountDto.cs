using System;

namespace Taoxue.Training.Services
{
    public partial class AccountDto
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 机构ID
        /// </summary>
        public int SchoolId { get; set; }

        /// <summary>
        /// 登录账号
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 员工姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 登录密码
        /// </summary>
        public string Pw { get; set; }

        /// <summary>
        /// 角色
        /// </summary>
        public string RoleIds { get; set; }

        /// <summary>
        /// 是否可用
        /// </summary>
        public bool Enabled { get; set; }

    }
}
