using HZC.Database;
using System.ComponentModel.DataAnnotations;

namespace Taoxue.Training.Services
{
    [MyDataTable("Crm_School")]
    public partial class SchoolEntity : BaseEntity
    {
        /// <summary>
        /// 机构编码
        /// </summary>
        [MyDataField(UpdateIgnore = true)]
        public string Code { get; set; }

        /// <summary>
        /// 机构名称
        /// </summary>
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Name { get; set; }

        /// <summary>
        /// 机构平台登录密码
        /// </summary>
        [MyDataField(UpdateIgnore = true)]
        public string Pw { get; set; }

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
