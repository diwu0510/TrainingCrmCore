using HZC.Database;

namespace Taoxue.Training.Services
{
    public partial class SchoolSearchParam : SearchParam
    {
        public string Key { get; set; }

        public override MySearchUtil ToSearchUtil()
        {
            MySearchUtil util = MySearchUtil.New().AndEqual("IsDel", false);

            if (!string.IsNullOrWhiteSpace(Key))
            {
                util.AndContains("Name", Key.Trim());
            }

            util.OrderBy(SetOrderBy());

            return util;
        }
    }
}
