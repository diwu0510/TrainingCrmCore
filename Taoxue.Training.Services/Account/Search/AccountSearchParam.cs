using HZC.Database;
using System;

namespace Taoxue.Training.Services
{
    public partial class AccountSearchParam : SearchParam
    {
        public string Key { get; set; }

        public int? SchoolId { get; set; }

        public string Account { get; set; }

        public string Name { get; set; }

        public string RoleIds { get; set; }

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

            if (!string.IsNullOrWhiteSpace(Account))
            {
                util.AndContains("Account", Account.Trim());
            }

            if (!string.IsNullOrWhiteSpace(Name))
            {
                util.AndContains("Name", Name.Trim());
            }

            if (!string.IsNullOrWhiteSpace(RoleIds))
            {
                util.AndContains("RoleIds", RoleIds.Trim());
            }

            util.OrderBy(SetOrderBy());

            return util;
        }
    }
}
