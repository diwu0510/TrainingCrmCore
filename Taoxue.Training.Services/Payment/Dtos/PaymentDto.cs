using System;

namespace Taoxue.Training.Services
{
    public partial class PaymentDto
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
        /// 学生ID
        /// </summary>
        public int StudentId { get; set; }

        /// <summary>
        /// 学生姓名
        /// </summary>
        public string StudentName { get; set; }

        /// <summary>
        /// 订单ID
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// 支付方式
        /// </summary>
        public string PaymentMethod { get; set; }

        /// <summary>
        /// 支付金额
        /// </summary>
        public int PaymentAmount { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

    }
}
