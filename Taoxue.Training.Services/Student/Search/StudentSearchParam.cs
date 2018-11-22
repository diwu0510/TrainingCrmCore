using HZC.Database;
using System;

namespace Taoxue.Training.Services
{
    public partial class StudentSearchParam : SearchParam
    {
        public string Key { get; set; }

        public int? SchoolId { get; set; }

        public string Card { get; set; }

        public int? SalerId { get; set; }

        public string Mobile { get; set; }

        public override MySearchUtil ToSearchUtil()
        {
            MySearchUtil util = MySearchUtil.New().AndEqual("IsDel", false);

            if (SchoolId.HasValue)
            {
                util.AndEqual("SchoolId", SchoolId.Value);
            }

            if (!string.IsNullOrWhiteSpace(Key))
            {
                util.AndContains("Name", Key.Trim());
            }

            if (!string.IsNullOrWhiteSpace(Card))
            {
                util.AndEqual("Card", Card.Trim());
            }

            if (SalerId.HasValue)
            {
                util.AndEqual("SalerId", SalerId.Value);
            }

            if (!string.IsNullOrWhiteSpace(Mobile))
            {
                util.AndContains("Mobile", Mobile.Trim());
            }

            util.OrderBy(SetOrderBy());

            return util;
        }
    }
}
