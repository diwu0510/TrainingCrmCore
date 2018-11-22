using System;
using System.Collections.Generic;
using System.Text;

namespace Taoxue.Training.Services
{
    public class OrderCreateDto
    {
        public OrderCreateDto()
        {
            Details = new List<OrderDetailsCreateDto>();
        }

        /// <summary>
        /// 学生Id
        /// </summary>
        public int StudentId { get; set; }

        /// <summary>
        /// 学生姓名
        /// </summary>
        public string StudentName { get; set; }

        /// <summary>
        /// 销售ID
        /// </summary>
        public int SalerId { get; set; } 

        /// <summary>
        /// 订单类型
        /// </summary>
        public int OrderType { get; set; }

        /// <summary>
        /// 折扣
        /// </summary>
        public int Discount { get; set; } = 100;

        /// <summary>
        /// 优惠券
        /// </summary>
        public int Coupon { get; set; } = 0;

        /// <summary>
        /// 账户余额
        /// </summary>
        public int Balance { get; set; } = 0;

        /// <summary>
        /// 成交价格
        /// </summary>
        public int ClosingCost { get; set; } = 0;

        /// <summary>
        /// 实际支付
        /// </summary>
        public int ActualPayment { get; set; } = 0;

        /// <summary>
        /// 支付方式
        /// </summary>
        public string PaymentMethod { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 订单明细
        /// </summary>
        public List<OrderDetailsCreateDto> Details { get; set; }
    }
}
