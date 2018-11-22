using System;

namespace Taoxue.Training.Services
{
    public partial class StudentDto
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 学生姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 学生昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 学生卡
        /// </summary>
        public string Card { get; set; }

        /// <summary>
        /// 关联销售
        /// </summary>
        public int SalerId { get; set; }

        /// <summary>
        /// 学生状态
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 微信OPENID
        /// </summary>
        public string Weixin { get; set; }
    }
}
