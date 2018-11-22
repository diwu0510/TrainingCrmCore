using System;

namespace Taoxue.Training.Services
{
    public partial class OrdersDto
    {
        /// <summary>
        /// Id
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
        public string Remark { get; set; }

    }
}
