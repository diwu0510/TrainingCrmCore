using HZC.Database;

namespace Taoxue.Training.Services
{
    public partial class CourseSearchParam : SearchParam
    {
        public string Key { get; set; }

        public int? SchoolId { get; set; }

        public bool? Enabled { get; set; }

        public override MySearchUtil ToSearchUtil()
        {
            MySearchUtil util = MySearchUtil.New().AndEqual("IsDel", false);

            if (!string.IsNullOrWhiteSpace(Key))
            {
                util.AndContains("Name", Key.Trim());
            }

            if (!Enabled.HasValue)
            {
                util.AndEqual("Enabled", true);
            }
            else
            {
                util.AndEqual("Enabled", Enabled.Value);
            }

            if (SchoolId.HasValue)
            {
                util.AndEqual("SchoolId", SchoolId);
            }

            util.OrderBy(SetOrderBy());

            return util;
        }
    }
}
