using Npgsql;
using RezervationSystem.Core.GlobalVariablesFolder;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace RezervationSystem.DataAccess.PostgreSQL
{
    public class PGDatabase : IDisposable
    {
        public string conn = MyGlobalVariablesStatic.connectionString;

        public NpgsqlConnection connString = null;
        public NpgsqlCommand cmdString = null;
        public NpgsqlDataReader rdrString = null;
        private static bool _IsDisposed = false;

        public PGDatabase()
        {

            try
            {
                connString = new NpgsqlConnection(conn);
            }
            catch (Exception)
            {

                throw;
            }

        }
        ~PGDatabase()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(true);
        }

        void IDisposable.Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(true);
        }

        protected virtual void Dispose(bool IsDisposing)
        {
            if (_IsDisposed)
                return;

            if (IsDisposing)
            {
                this.connClose();
            }
            _IsDisposed = true;
        }
        public int Cmd(string sql)
        {
            connString = new NpgsqlConnection(conn);

            if (connString.State == ConnectionState.Closed)
                connString.Open();
            int kayit = 0;

            cmdString = new NpgsqlCommand(sql, connString);
            kayit = cmdString.ExecuteNonQuery();

            return kayit;
        }
        public int CountKac(string sql)
        {
            connString = new NpgsqlConnection(conn);

            if (connString.State == ConnectionState.Closed)
                connString.Open();

            cmdString = new NpgsqlCommand(sql, connString);
            int kayit = Convert.ToInt32(cmdString.ExecuteScalar().ToString());
            return kayit;
        }
        public string SayiKac(string sql)
        {
            connString = new NpgsqlConnection(conn);

            if (connString.State == ConnectionState.Closed)
                connString.Open();

            cmdString = new NpgsqlCommand(sql, connString);
            string kayit = cmdString.ExecuteScalar().ToString();
            return kayit;
        }
        public NpgsqlDataReader Reader(string sql)
        {
            connString.Open();

            cmdString = new NpgsqlCommand(sql, connString);
            rdrString = cmdString.ExecuteReader(CommandBehavior.CloseConnection);

            return rdrString;
        }


        public NpgsqlConnection connClose()
        {
            if (connString != null) connString.Close();
            if (connString != null) connString.Dispose();
            if (cmdString != null && cmdString.Connection != null) cmdString.Connection.Close();
            if (cmdString != null && cmdString.Connection != null) cmdString.Connection.Dispose();
            if (cmdString != null) cmdString.Dispose();
            if (rdrString != null) rdrString.Close();
            if (rdrString != null) rdrString.Dispose();
            return connString;
        }

    }
}
