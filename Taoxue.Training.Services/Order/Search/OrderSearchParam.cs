using HZC.Database;
using System;

namespace Taoxue.Training.Services
{
    public partial class OrderSearchParam : SearchParam
    {
        public string Key { get; set; }

        public int? SchoolId { get; set; }

        public int? StudentId { get; set; }

        public int? SalerId { get; set; }

        public string OrderType { get; set; }

        public string ActualPayment { get; set; }

        public override MySearchUtil ToSearchUtil()
        {
            MySearchUtil util = MySearchUtil.New().AndEqual("IsDel", false);

            if (!string.IsNullOrWhiteSpace(Key))
            {
                // util.AndContains(new string[] { "Title", "Name" }, Key.Trim());
            }

            if (SchoolId.HasValue)
            {
                util.AndEqual("SchoolId", SchoolId.Value);
            }

            if (StudentId.HasValue)
            {
                util.AndEqual("StudentId", StudentId.Value);
            }

            if (SalerId.HasValue)
            {
                util.AndEqual("SalerId", SalerId.Value);
            }

            if (!string.IsNullOrWhiteSpace(OrderType))
            {
                util.AndContains("OrderType", OrderType.Trim());
            }

            if (!string.IsNullOrWhiteSpace(ActualPayment))
            {
                util.AndContains("ActualPayment", ActualPayment.Trim());
            }

            util.OrderBy(SetOrderBy());

            return util;
        }
    }
}
