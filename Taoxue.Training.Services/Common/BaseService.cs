using HZC.Core;
using HZC.Database;
using System;
using System.Collections.Generic;

namespace Taoxue.Training.Services
{
    public class BaseService<T> where T : BaseEntity
    {
        protected readonly MyDbUtil db;

        public BaseService(string sectionName = "")
        {
            if (!string.IsNullOrWhiteSpace(sectionName))
            {
                db = new MyDbUtil(sectionName);
            }
            else
            {
                db = new MyDbUtil();
            }
        }

        #region 增删改
        /// <summary>
        /// 创建实体
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <param name="user">操作人</param>
        /// <returns></returns>
        public virtual Result Create(T entity, AppUser user, Action Cb = null)
        {
            var error = ValidateCreate(entity, user);
            if (!string.IsNullOrWhiteSpace(error))
            {
                return ResultUtil.AuthFail(error);
            }
            entity.BeforeCreate(user);
            var id = db.Create<T>(entity);
            if (id > 0)
            {
                if (Cb != null)
                {
                    Cb();
                }
                return ResultUtil.Success<int>(id);
            }
            else
            {
                return ResultUtil.Fail();
            }
        }

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <param name="user">操作人</param>
        /// <returns></returns>
        public virtual Result Update(T entity, AppUser user, Action Cb = null)
        {
            var error = ValidateUpdate(entity, user);
            if (!string.IsNullOrWhiteSpace(error))
            {
                return ResultUtil.AuthFail(error);
            }
            entity.BeforeUpdate(user);
            var row = db.Update<T>(entity);
            if (row > 0)
            {
                Cb?.Invoke();
                return ResultUtil.Success();
            }
            else
            {
                return ResultUtil.Fail();
            }
        }

        /// <summary>
        /// 移除实体-逻辑删除
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <param name="user">操作人</param>
        /// <returns></returns>
        public virtual Result Remove(T entity, AppUser user, Action<int> Cb = null)
        {
            var error = ValidateDelete(entity, user);
            if (!string.IsNullOrWhiteSpace(error))
            {
                return ResultUtil.AuthFail(error);
            }

            var row = db.Update<T>(KeyValuePairs.New()
                .Add("IsDel", true)
                .Add("Updator", user.Name)
                .Add("UpdateAt", DateTime.Now),
                MySearchUtil.New().AndEqual("Id", entity.Id));
            Cb?.Invoke(row);
            if (row > 0)
            {
                return ResultUtil.Success();
            }
            else
            {
                return ResultUtil.Fail();
            }
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <param name="user">操作人</param>
        /// <returns></returns>
        public virtual Result Delete(T entity, AppUser user, Action Cb = null)
        {
            var error = ValidateDelete(entity, user);
            if (!string.IsNullOrWhiteSpace(error))
            {
                return ResultUtil.AuthFail(error);
            }

            var row = db.Delete<T>(entity.Id);
            if (row > 0)
            {
                Cb?.Invoke();
                return ResultUtil.Success();
            }
            else
            {
                return ResultUtil.Fail();
            }
        }
        #endregion

        #region 获取实体列表
        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <param name="util">查询参数</param>
        /// <returns></returns>
        public virtual IEnumerable<T> Fetch(ISearchParam param)
        {
            return db.Fetch<T>(param.ToSearchUtil());
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="util">查询参数</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页数量</param>
        /// <returns></returns>
        public virtual PageList<T> Query(ISearchParam param, int pageIndex = 1, int pageSize = 20)
        {
            return db.Query<T>(param.ToSearchUtil(), pageIndex, pageSize);
        }
        #endregion

        #region 加载一个实体
        /// <summary>
        /// 加载一个实体
        /// </summary>
        /// <param name="id">实体ID</param>
        /// <returns></returns>
        public virtual T Load(int id)
        {
            return db.Load<T>(id);
        }

        /// <summary>
        /// 加载一个实体
        /// </summary>
        /// <param name="util">查询参数</param>
        /// <returns></returns>
        public virtual T Load(ISearchParam param)
        {
            return db.Load<T>(param.ToSearchUtil());
        } 
        #endregion

        #region 增删改验证
        /// <summary>
        /// 创建实体验证
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        protected virtual string ValidateCreate(T entity, AppUser user)
        {
            return string.Empty;
        }

        /// <summary>
        /// 更新实体验证
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        protected virtual string ValidateUpdate(T entity, AppUser user)
        {
            return string.Empty;
        }

        /// <summary>
        /// 删除实体验证
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        protected virtual string ValidateDelete(T entity, AppUser user)
        {
            return string.Empty;
        }
        #endregion
    }
}
