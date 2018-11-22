using HZC.Database;
using System;
using System.ComponentModel.DataAnnotations;

namespace Taoxue.Training.Services
{
    [MyDataTable("Crm_Payment")]
    public partial class PaymentEntity : BaseEntity
    {
        /// <summary>
        /// 机构ID
        /// </summary>
        public int SchoolId { get; set; }

        /// <summary>
        /// 学生ID
        /// </summary>
        public int StudentId { get; set; }

        /// <summary>
        /// 学生姓名
        /// </summary>
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string StudentName { get; set; }

        /// <summary>
        /// 订单ID
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// 支付方式
        /// </summary>
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string PaymentMethod { get; set; }

        /// <summary>
        /// 支付金额
        /// </summary>
        public int PaymentAmount { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Remark { get; set; }

    }
}
