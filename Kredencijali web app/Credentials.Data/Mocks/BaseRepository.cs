using Credentials.Data.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;

namespace Credentials.Data.Mocks
{
    public class BaseRepository<T> : IBaseRepository<T> where T : Base
    {
        #region Dependecy Injection

        private readonly IConnectionString connectionString;

        #endregion Dependecy Injection

        #region Constructors

        /// <summary>
        /// Custom constructor
        /// </summary>
        /// <param name="connectionString"></param>
        public BaseRepository(IConnectionString connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public BaseRepository()
        {
        }

        #endregion Constructors

        #region CRUD
        /// <summary>
        /// Get one values from database 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public T GetOne(int Id)
        {
            using (var db = new SqlConnection(connectionString.GetDbConnectionString()))
            {
                var obj = db.Get<T>(Id);

                return obj;
            }
        }

        /// <summary>
        /// Get all data from one table
        /// </summary>
        /// <returns></returns>
        public List<T> GetAll()
        {
            using (var db = new SqlConnection(connectionString.GetDbConnectionString()))
            {
                var obj = db.GetList<T>();

                return obj.ToList();
            }
        }

        /// <summary>
        /// Insert value into one table
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int? Create(T obj)
        {
            using (var db = new SqlConnection(connectionString.GetDbConnectionString()))
            {
                obj.DatumKreiranja = DateTime.Now;
                obj.DatumPromene = DateTime.Now;

                var resultObj = db.Insert<T>(obj);

                return resultObj;
            }
        }

        /// <summary>
        /// Delete value from one table
        /// </summary>
        /// <param name="Id"></param>
        public void DeleteById(int Id)
        {
            using (var db = new SqlConnection(connectionString.GetDbConnectionString()))
            {
                var resultObj = db.Delete<T>(Id);
            }
        }

        /// <summary>
        /// Update one value from table
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int Update(T obj)
        {
            using (var db = new SqlConnection(connectionString.GetDbConnectionString()))
            {
                obj.DatumPromene = DateTime.Now;

                var resultObj = db.Update<T>(obj);

                return resultObj;
            }
        }
        #endregion
    }
}