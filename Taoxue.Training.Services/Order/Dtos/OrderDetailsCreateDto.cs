using System;
using System.Collections.Generic;
using System.Text;

namespace Taoxue.Training.Services
{
    public class OrderDetailsCreateDto
    {
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
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
