using HZC.Database;
using System;
using System.ComponentModel.DataAnnotations;

namespace Taoxue.Training.Services
{
    [MyDataTable("Crm_OrderDetails")]
    public partial class OrderDetailsEntity : BaseEntity
    {
        /// <summary>
        /// 订单ID
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// 商品类型
        /// </summary>
        public int GoodsType { get; set; }

        /// <summary>
        /// 商品ID
        /// </summary>
        public int GoodsId { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string GoodsName { get; set; }

        /// <summary>
        /// 商品数量
        /// </summary>
        public int GoodsCount { get; set; }

        /// <summary>
        /// 原始单价
        /// </summary>
        public int OriginUnitPrice { get; set; }

        /// <summary>
        /// 成交单价
        /// </summary>
        public int ClosingUnitPrice { get; set; }

        /// <summary>
        /// 原始总价
        /// </summary>
        [MyDataField(Ignore = true)]
        public int OriginTotal { get; set; }

        /// <summary>
        /// 成交总价
        /// </summary>
        [MyDataField(Ignore = true)]
        public int ClosingCost { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Remark { get; set; }

    }
}
