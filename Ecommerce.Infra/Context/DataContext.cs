using Ecommerce.Shared.Utils;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Ecommerce.Infra.Context
{
    public class DataContext : IDisposable
    {

        public SqlConnection Connection { get; set; }

        public DataContext()
        {
            Connection = new SqlConnection(Seetings.ConnectionString);
            Connection.Open();
        }

        public void Dispose()
        {
            if (Connection.State != ConnectionState.Closed)
                Connection.Close();
        }


    }
}
