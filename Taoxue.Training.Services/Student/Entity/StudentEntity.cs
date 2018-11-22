using HZC.Database;
using System;
using System.ComponentModel.DataAnnotations;

namespace Taoxue.Training.Services
{
    [MyDataTable("Crm_Student")]
    public partial class StudentEntity : BaseEntity
    {
        /// <summary>
        /// 学生姓名
        /// </summary>
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Name { get; set; }

        /// <summary>
        /// 学生昵称
        /// </summary>
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string NickName { get; set; }

        /// <summary>
        /// 学生卡
        /// </summary>
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Card { get; set; }

        /// <summary>
        /// 关联销售
        /// </summary>
        public int SalerId { get; set; }

        /// <summary>
        /// 学生状态
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Mobile { get; set; }

        /// <summary>
        /// 微信OPENID
        /// </summary>
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Weixin { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        [MyDataField(UpdateIgnore = true)]
        public bool IsDel { get; set; }

    }
}
