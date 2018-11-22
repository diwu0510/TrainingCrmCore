using HZC.Database;
using System;

namespace Taoxue.Training.Services
{
    public partial class PaymentSearchParam : SearchParam
    {
        public string Key { get; set; }

        public int? SchoolId { get; set; }

        public int? StudentId { get; set; }

        public string StudentName { get; set; }

        public string PaymentMethod { get; set; }

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

            if (!string.IsNullOrWhiteSpace(StudentName))
            {
                util.AndContains("StudentName", StudentName.Trim());
            }

            if (!string.IsNullOrWhiteSpace(PaymentMethod))
            {
                util.AndContains("PaymentMethod", PaymentMethod.Trim());
            }

            util.OrderBy(SetOrderBy());

            return util;
        }
    }
}
