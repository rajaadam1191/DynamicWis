using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace Lab
{
    public class DAclass
    {
        private IDbCommand cmd = new SqlCommand();
        SqlConnection con = new SqlConnection();

        #region Constructor

        public DAclass()
        {
            //con.ConnectionString = System.Configuration.ConfigurationSettings.AppSettings["Constr"];
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Constr"].ToString();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
        }

        #endregion

        #region ExecuteNonQuery without Argument

        public void ExecuteNonQuery()
        {
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch
            {
                throw;
            }

        }

        #endregion

        #region ExecuteNonQuery With Argument

        public void ExecuteNonQuery(String commandText1)
        {
            try
            {
                cmd.CommandText = commandText1;
                this.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }


        }

        #endregion       


        public object ExecuteScalar()
        {
            object obj = null;
            try
            {
                con.Open();
                obj = cmd.ExecuteScalar();
                con.Close();
            }
            catch
            {

                throw;

            }
            return obj;
        }

  public object ExecuteScalar(string commandtext)
    {
        object obj = null;
        try
         {
            cmd.CommandText = commandtext;
            obj =this.ExecuteScalar();
        }
        catch
              {
                 throw;
              }
        return obj;
   }


        #region Execute DataSet Without Argument

        public DataSet ExecuteDataset()
        {
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter();
                DataSet ds = new DataSet();
                adp.SelectCommand = (SqlCommand)cmd;
                adp.Fill(ds);
                return (ds);

            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region Execute DataSet With Argument

        public DataSet ExecuteDataset(String commandText2)
        {
            try
            {
                DataSet ds = new DataSet();
                cmd.CommandText = commandText2;
                ds = this.ExecuteDataset();
                return (ds);
            }
            catch
            {
                throw;
            }
        }

        #endregion

        #region Parameter Passing

        public IDataParameterCollection parameters
        {
            get
            {
                return this.cmd.Parameters;
            }
        }

        #endregion


        
    }
}

