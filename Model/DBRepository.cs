using Microsoft.EntityFrameworkCore;
using Model;
using Model.client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Model
{
     
    public class DBRepository<T> where T : class, new()
    {


        private DbContext _dataContext = null;

        public DBRepository(DbContext dbContext)
        {
            _dataContext = dbContext;
        }
         
        #region 数据集对象


        public DbContext dataContext
        {
            get
            {
                 return _dataContext;
            }
            set
            {
                _dataContext = value;
            }
        }

        #endregion

        #region 提交更改
        /// <summary>
        /// 提交更改
        /// </summary>
        /// <returns></returns>
        public int Submit()
        {
            try
            {
                int num = dataContext.SaveChanges();
                //dataContext.Dispose();
                //dataContext = new gechilaEntities();
                return num;
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
                return -1;
            }

        }
        #endregion

        #region 增
        /// <summary>
        ///  新增实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public bool Add(T entity, bool IsSubmit = false)
        {
            try
            {
                dataContext.Entry<T>(entity).State = EntityState.Added;
                if (IsSubmit)
                    return (dataContext.SaveChanges() > 0);
                else return true;
            }
            catch (DbEntityValidationException dbEx)
            {
                throw;
            }

        }
        #endregion

        #region 删
        /// <summary>
        /// 删除实体列表
        /// </summary>
        /// <param name="entityList">实体列表</param>
        /// <returns></returns>
        public int Delete(IList<T> entityList, bool IsSubmit = false)
        {

            foreach (var entity in entityList)
            {
                dataContext.Set<T>().Attach(entity);
                dataContext.Entry<T>(entity).State = EntityState.Deleted;
            }
            if (IsSubmit)
                return dataContext.SaveChanges();
            else return entityList.Count;
        }



        // <summary>
        /// 删除
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="IsSubmit">同时确认提交</param>
        /// <returns></returns>
        public bool Delete(T entity, bool IsSubmit = false)
        {
            if (entity == null)
            {
                return false;
            }
            dataContext.Set<T>().Attach(entity);
            dataContext.Entry<T>(entity).State = EntityState.Deleted;
            if (IsSubmit)
                return (dataContext.SaveChanges() > 0);
            else return true;
        }

        #endregion

        #region 改
        public int Update(IList<T> entityList, bool IsSubmit = false)
        {

            foreach (var entity in entityList)
            {
                dataContext.Set<T>().Attach(entity);
                dataContext.Entry<T>(entity).State = EntityState.Modified;
            }
            if (IsSubmit)
                return dataContext.SaveChanges();
            else return entityList.Count;
        }


        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public bool Update(T entity, bool IsSubmit = false)
        {
            dataContext.Set<T>().Attach(entity);
            dataContext.Entry<T>(entity).State = EntityState.Modified;
            if (IsSubmit)
            {
                if (dataContext.SaveChanges() > 0)
                {
                    return true;
                }
                else return false;
            }
            else return true;
        }
        #endregion

        #region 查

        /// <summary>
        /// 根据主键查询
        /// </summary>
        /// <param name="keyValues">主键</param>
        /// <returns></returns>
        public T FindByID(object id)
        {
            object[] keyValues = new object[] { id };
            return this.Find(keyValues);
        }

        /// <summary>
        /// 根据主键查询
        /// </summary>
        /// <param name="keyValues">主键</param>
        /// <returns></returns>
        public T Find(params object[] keyValues)
        {
            return dataContext.Set<T>().Find(keyValues);
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <param name="isEdit">是否需要编辑（如果只是查询，建议使用false）</param>
        /// <returns></returns>
        public IQueryable<T> SelectAll(bool isEdit = false)
        {
            if (!isEdit)
                return dataContext.Set<T>().Where(p => true).AsNoTracking();
            else return dataContext.Set<T>().Where(p => true);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="wherelambda">Lamda查询条件</param>
        /// <param name="isEdit">是否需要编辑（如果只是查询，建议使用false）</param>
        /// <returns></returns>
        public IQueryable<T> Select(Func<T, bool> wherelambda, bool isEdit = false)
        {
            if (!isEdit)
                return dataContext.Set<T>().Where<T>(wherelambda).AsQueryable().AsNoTracking();
            else return dataContext.Set<T>().Where<T>(wherelambda).AsQueryable();
        }


        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="S">返回类型</typeparam>
        /// <param name="pageSize">页面大小</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="whereLambda">查询条件lamda表达式  实例：c => true </param>
        /// <param name="isOrderBy">是否需要排序</param>
        /// <param name="isAsc">是否升序</param>
        /// <param name="orderByLambda">排序lamda表达式  实例：c => c.ID </param>
        /// <param name="isEdit">是否需要编辑（如果只是查询，建议使用false）</param>
        /// <returns></returns>
        public IQueryable<T> Select<S>(int pageSize, int pageIndex,
           Func<T, bool> whereLambda, bool isOrderBy = false, bool isAsc = false, Func<T, S> orderByLambda = null, bool isEdit = false)
        {
            var tempData = dataContext.Set<T>().Where<T>(whereLambda);

            if (isOrderBy)
            {
                //排序获取当前页的数据
                if (isAsc)
                {
                    tempData = tempData.OrderBy<T, S>(orderByLambda);
                }
                else
                {
                    tempData = tempData.OrderByDescending<T, S>(orderByLambda);
                }
            }
            tempData = tempData.Skip<T>(pageSize * (pageIndex - 1)).Take<T>(pageSize).AsQueryable();
            if (!isEdit)
                return tempData.AsQueryable().AsNoTracking();
            else return tempData.AsQueryable();
        }



        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="S">返回类型</typeparam>
        /// <param name="pageSize">页面大小</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="total">返回总数</param>
        /// <param name="whereLambda">查询条件lamda表达式  实例：c => true </param>
        /// <param name="isOrderBy">是否需要排序</param>
        /// <param name="isAsc">是否升序</param>
        /// <param name="orderByLambda">排序lamda表达式  实例：c => c.ID </param>
        /// <param name="isEdit">是否需要编辑（如果只是查询，建议使用false）</param>
        /// <returns></returns>
        public IQueryable<T> Select<S>(int pageSize, int pageIndex, out int total,
           Func<T, bool> whereLambda, bool isOrderBy = false, bool isAsc = false, Func<T, S> orderByLambda = null, bool isEdit = false)
        {
            total = dataContext.Set<T>().Count(whereLambda);
            return Select(pageSize, pageIndex, whereLambda, isOrderBy, isAsc, orderByLambda, isEdit);
        }

        /// <summary>
        /// 数量
        /// </summary>
        /// <param name="whereLambda">查询条件lamda表达式  实例：c => true </param>
        /// <returns></returns>
        public int Count(Func<T, bool> whereLambda)
        {
            try
            {
                return dataContext.Set<T>().Count(whereLambda);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        #endregion

        #region 获取模型对象，方便特殊查询
        /// <summary>
        /// 获取模型对象，方便特殊查询
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> DbQuery
        {
            get
            {
                return dataContext.Set<T>().AsNoTracking();
            }
        }

        /// <summary>
        /// 获取模型对象，方便特殊查询
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> DbSet
        {
            get
            {
                //dataContext = new gechilaEntities();
                return dataContext.Set<T>().AsTracking();
            }
        }
        #endregion

        #region 直接执行sql语句,一般用于批量删除/修改
        /// <summary>
        /// 执行sql语句
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="dbParameters">参数</param>
        /// <returns>返回影响条数</returns>
        public int ExecuteSqlCommand(string sql, params object[] dbParameters)
        {
            return dataContext.Database.ExecuteSqlCommand(sql, dbParameters);
        }
        #endregion

        #region 批量导入

        ///// <summary>
        ///// 批量插入
        ///// </summary>
        ///// <param name="entitys"></param>
        //public static bool Bluk(IList<T> entitys,string tableName)
        //{
        //    try
        //    {
        //        if (DBRepository.dataContext.Database.Connection.State != ConnectionState.Open)
        //        {
        //            DBRepository.dataContext.Database.Connection.Open(); //打开Connection连接  
        //        }

        //        //调用BulkInsert方法,将entitys集合数据批量插入到数据库的tolocation表中  
        //        BulkInsert1((SqlConnection)DBRepository.dataContext.Database.Connection, tableName, entitys);

        //        if (DBRepository.dataContext.Database.Connection.State != ConnectionState.Closed)
        //        {
        //            DBRepository.dataContext.Database.Connection.Close(); //关闭Connection连接  
        //        }
        //        return true;
        //    }
        //    catch(Exception ex)
        //    {
        //        throw ex;
        //        return false;
        //    }


        //}

        /// <summary>  
        /// 批量插入  
        /// </summary>  
        /// <typeparam name="T">泛型集合的类型</typeparam>  
        /// <param name="conn">连接对象</param>  
        /// <param name="tableName">将泛型集合插入到本地数据库表的表名</param>  
        /// <param name="list">要插入大泛型集合</param>  
        private void BulkInsert1(SqlConnection conn, string tableName, IList<T> list)
        {
            using (var bulkCopy = new SqlBulkCopy(conn))
            {
                bulkCopy.BatchSize = list.Count;
                bulkCopy.DestinationTableName = tableName;

                var table = new DataTable();
                var props = TypeDescriptor.GetProperties(typeof(T))

                    .Cast<PropertyDescriptor>()
                    .Where(propertyInfo => propertyInfo.PropertyType.Namespace.Equals("System"))
                    .ToArray();

                foreach (var propertyInfo in props)
                {
                    bulkCopy.ColumnMappings.Add(propertyInfo.Name, propertyInfo.Name);
                    table.Columns.Add(propertyInfo.Name, Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType);
                }

                var values = new object[props.Length];
                foreach (var item in list)
                {
                    for (var i = 0; i < values.Length; i++)
                    {
                        values[i] = props[i].GetValue(item);
                    }

                    table.Rows.Add(values);
                }

                bulkCopy.WriteToServer(table);
            }
        }
        #endregion

    }
}
