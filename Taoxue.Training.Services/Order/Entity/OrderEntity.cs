using HZC.Database;
using System;
using System.ComponentModel.DataAnnotations;

namespace Taoxue.Training.Services
{
    [MyDataTable("Crm_Orders")]
    public partial class OrderEntity : BaseEntity
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
        public string StudentName { get; set; }

        /// <summary>
        /// 销售员
        /// </summary>
        public int SalerId { get; set; }

        /// <summary>
        /// 订单类型
        /// </summary>
        public int OrderType { get; set; }

        /// <summary>
        /// 订单总额
        /// </summary>
        public int OrderTotal { get; set; }

        /// <summary>
        /// 优惠券
        /// </summary>
        public int Coupon { get; set; }

        /// <summary>
        /// 折扣
        /// </summary>
        public int Discount { get; set; }

        /// <summary>
        /// 使用账户余额
        /// </summary>
        public int Balance { get; set; }

        /// <summary>
        /// 实际成交价格
        /// </summary>
        public int ClosingCost { get; set; }

        /// <summary>
        /// 已付款
        /// </summary>
        public int ActualPayment { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Remark { get; set; }

        /// <summary>
        /// IsDel
        /// </summary>
        [MyDataField(UpdateIgnore = true)]
        public bool IsDel { get; set; }

    }
}
