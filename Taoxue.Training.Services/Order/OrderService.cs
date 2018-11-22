using HZC.Core;
using HZC.Database;
using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AutoMapper;

namespace Taoxue.Training.Services
{
    public partial class OrderService : BaseService<OrderEntity>
    {
        public OrderService(string sectionName = "") : base(sectionName)
        { }

        public Result Create(OrderCreateDto entity, SchoolUser user)
        {
            string error;
            
            #region 检验 订单
            error = ValidNewOrder(entity, user);
            if (!string.IsNullOrWhiteSpace(error))
            {
                return ResultUtil.Fail(error);
            }
            #endregion

            #region 检验订单明细
            error = ValidNewOrderDetails(entity.Details, user);
            if (!string.IsNullOrWhiteSpace(error))
            {
                return ResultUtil.Fail(error);
            }
            #endregion

            #region 检验订单金额
            int originTotal = entity.Details.Sum(i => i.OriginUnitPrice * i.GoodsCount);
            int closingCost = entity.Details.Sum(i => i.ClosingUnitPrice * i.GoodsCount);

            if (closingCost != entity.ClosingCost)
            {
                return ResultUtil.Fail("订单总额与订单明细不匹配");
            } 
            #endregion
            
            var order = Mapper.Map<OrderEntity>(entity);
            order.SchoolId = user.SchoolId;
            order.BeforeCreate(user);

            List<OrderDetailsEntity> details = new List<OrderDetailsEntity>();
            using (var conn = db.GetConnection())
            {
                conn.Open();
                using (var trans = conn.BeginTransaction())
                {
                    try
                    {
                        // 创建订单
                        var orderId = db.Create(order);

                        // 创建明细
                        foreach (var detail in entity.Details)
                        {
                            var temp = Mapper.Map<OrderDetailsEntity>(detail);
                            temp.OrderId = orderId;
                            temp.BeforeCreate(user);
                            details.Add(temp);
                        }
                        db.Create(details);
                        
                        if (order.ActualPayment > 0)
                        {
                            // 创建付款记录
                            var payment = new PaymentEntity
                            {
                                SchoolId = user.SchoolId,
                                StudentId = entity.StudentId,
                                StudentName = entity.StudentName,
                                OrderId = orderId,
                                PaymentMethod = entity.PaymentMethod,
                                PaymentAmount = entity.ActualPayment
                            };
                            payment.BeforeCreate(user);

                            db.Create(payment);
                        }

                        trans.Commit();
                        return ResultUtil.Success();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        return ResultUtil.Exception(ex);
                    }
                }
            }
        }

        private string ValidNewOrder(OrderCreateDto entity, AppUser user)
        {
            if (entity.Details.Count == 0)
            {
                return "订单明细不能为空";
            }

            if (entity.StudentId == 0)
            {
                return "请指定有效学生";
            }

            if (entity.Coupon < 0 || entity.Discount < 0 || entity.Discount > 100 || entity.Balance < 0)
            {
                return "不合法的优惠金额，请检查优惠券、折扣、余额是否是有效参数";
            }

            if (entity.ClosingCost < 0)
            {
                return "成交价必须大于等于0";
            }

            if (entity.ActualPayment < 0)
            {
                return "实际支付金额不能小于0";
            }

            if (entity.ActualPayment > 0 && string.IsNullOrWhiteSpace(entity.PaymentMethod))
            {
                return "支付方式不能为空";
            }

            return string.Empty;
        }

        private string ValidNewOrderDetails(List<OrderDetailsCreateDto> details, SchoolUser user)
        {
            var errors = new List<string>();
            foreach (var detail in details)
            {
                var error = ValidNewOrderDetail(detail);
                if (!string.IsNullOrWhiteSpace(error))
                {
                    errors.Add(error);
                }
            }
            return string.Join(";", errors);
        }

        private string ValidNewOrderDetail(OrderDetailsCreateDto detail)
        {
            if (detail.GoodsCount <= 0)
            {
                return $"{detail.GoodsName}的数量必须大于0";
            }
            if (detail.ClosingUnitPrice < 0)
            {
                return $"{detail.GoodsName}的成交单价必须大于等于0";
            }
            return string.Empty;
        }

        #region 重写实体验证
        protected override string ValidateCreate(OrderEntity entity, AppUser user)
        {
            return string.Empty;
        }

        protected override string ValidateUpdate(OrderEntity entity, AppUser user)
        {
            return string.Empty;
        }

        protected override string ValidateDelete(OrderEntity entity, AppUser user)
        {
            return string.Empty;
        }
        #endregion
    }
}

