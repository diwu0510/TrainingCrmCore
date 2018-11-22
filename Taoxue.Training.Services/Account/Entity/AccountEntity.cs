using HZC.Database;
using System;
using System.ComponentModel.DataAnnotations;

namespace Taoxue.Training.Services
{
    [MyDataTable("Crm_Account")]
    public partial class AccountEntity : BaseEntity
    {
        /// <summary>
        /// 机构ID
        /// </summary>
        [MyDataField(UpdateIgnore = true)]
        public int SchoolId { get; set; }

        /// <summary>
        /// 登录账号
        /// </summary>
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [MyDataField(UpdateIgnore = true)]
        public string Account { get; set; }

        /// <summary>
        /// 员工姓名
        /// </summary>
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Name { get; set; }

        /// <summary>
        /// 登录密码
        /// </summary>
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Pw { get; set; }

        /// <summary>
        /// 角色
        /// </summary>
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string RoleIds { get; set; }

        /// <summary>
        /// 是否可用
        /// </summary>
        [MyDataField(UpdateIgnore = true)]
        public bool Enabled { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        [MyDataField(UpdateIgnore = true)]
        public bool IsDel { get; set; }

    }
}
