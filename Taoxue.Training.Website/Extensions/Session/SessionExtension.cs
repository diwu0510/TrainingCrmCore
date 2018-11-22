using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Taoxue.Training.Website.Extensions
{
    public static class SessionExtension
    {
        /// <summary>
        /// 设置对象Session
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="session"></param>
        /// <param name="key">session名称</param>
        /// <param name="value">要保存的对象</param>
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        /// <summary>
        /// 从session中获取对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="session"></param>
        /// <param name="key">保存对象的session名称</param>
        /// <returns></returns>
        public static T Get<T>(this ISession session, string key)
        {
            var str = session.GetString(key);
            if (!string.IsNullOrWhiteSpace(str))
            {
                return JsonConvert.DeserializeObject<T>(str);
            }
            return default(T);
        }
    }
}
