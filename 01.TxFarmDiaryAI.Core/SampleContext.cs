using HxCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.VisualBasic.FileIO;
using Oracle.EntityFrameworkCore;
using Oracle.EntityFrameworkCore.Infrastructure;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Data;
using System.Linq;


namespace TxFarmDiaryAI
{
    public class SampleContext : DbContext
    {
        //public DbSet<SQL_TXFD_IMAGE_CART_Table> DS_XFD_IMAGE_CART { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        { 
            options.UseOracle(@"User Id=txfd'Password=cimage1004a;Data Source=fd.typesw.com:1521/ORCL;"); 
        }

        public SampleContext()
        {
            //this.ChangeTracker.LazyLoadingEnabled = false;
            //this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            this.Database.SetCommandTimeout(180); // 180초
            using (var conn = (OracleConnection)this.Database.GetDbConnection())
            {
                conn.Open();
                
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "ALTER SESSION SET NLS_DATE_FORMAT = 'YYYY-MM-DD HH24:MI:SS'";
                    cmd.ExecuteNonQuery();
                }
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "ALTER SESSION SET NLS_TIMESTAMP_FORMAT = 'YYYY-MM-DD HH24:MI:SS.FF'";
                    cmd.ExecuteNonQuery();
                }
                
                using (var cmd = conn.CreateCommand())
                {
                    string SQL = @"SELECT * FROM DUAL";
                    cmd.CommandText = SQL;
                    var rs = cmd.ExecuteReader();
                    foreach (var r in rs)
                    {
                        var row = r;
                    }
                }

                conn.Close();
            }
        }
    }
    
}
