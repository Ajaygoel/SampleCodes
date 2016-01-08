#region usings

using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using OnlineCoding.Domain.Entities;

#endregion

namespace OnlineCoding.Dal.Contexts
{
    public class OnlineCompilerContext : DbContext
    {
        public virtual DbSet<CompilerClient> CompilerClients { get; set; }

        public virtual DbSet<CompileResult> CompileResults { get; set; }

        public virtual DbSet<TestResult> TestResults { get; set; }

        #region Constructors

        static OnlineCompilerContext()
        {
            Database.SetInitializer<OnlineCompilerContext>(null);
        }

        /// <summary>
        ///     needed for effort library to inject in fake connection for tests
        /// </summary>
        /// <param name="connection"></param>
        public OnlineCompilerContext(DbConnection connection)
            : base(connection, true)
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public OnlineCompilerContext()
            : base("default")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        #endregion

        #region Public Methods

        public IEnumerable<T> ExcuteQuery<T>(string query)
        {
            var data = Database.SqlQuery<T>(query).ToList();
            return data;
        }

        public dynamic ExcuteQuery(string query, Type type)
        {
            var data = Database.SqlQuery(type, query);
            return data;
        }


        public static OnlineCompilerContext Create()
        {
            return new OnlineCompilerContext();
        }

        #endregion
    }
}