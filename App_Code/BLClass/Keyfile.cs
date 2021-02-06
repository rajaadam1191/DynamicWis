using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

using Lab;

namespace Lab
{
   public  class Keyfile
    {
     
       public string Date;
       public string _fromDate;
       public string _toDate;
       public string _Data;
       public string _Dynvalueid;
       public string _Shift;
       public string _Unit;
       public string _Machine;

       public string Machine
       {
           get
           {
               return _Machine;
           }
           set
           {
               if (value == "")
               {
               }
               _Machine = value;
           }
       }
       public string Unit
       {
           get
           {
               return _Unit;
           }
           set
           {
               if (value == "")
               {
               }
               _Unit = value;
           }
       }
       public string Shift
       {
           get
           {
               return _Shift;
           }
           set
           {
               if (value == "")
               {
               }
               _Shift = value;
           }
       }
       public string Dynvalueid
       {
           get
           {
               return _Dynvalueid;
           }
           set
           {
               if (value == "")
               {
               }
               _Dynvalueid = value;
           }
       }
       public string Data
       {
           get
           {
               return _Data;
           }
           set
           {
               if (value == "")
               {
               }
               _Data = value;
           }
       }
       public string ToDate
       {
           get
           {
               return _toDate;
           }
           set
           {
               if (value == "")
               {
               }
               _toDate = value;
           }
       }
       public string Fromdate
       {
           get
           {
               return _fromDate;
           }
           set
           {
               if (value == "")
               {
               }
               _fromDate = value;
           }
       }
       public string  prdate
       {
           get
           {
               return Date;
           }
           set
           {
               if (value == "")
               {
                   //throw new Exception("please enter prodcode..");
               }
               Date = value;
           }
       }
       public void InsertIns(Keyfile p)
       {
           DAclass db = new DAclass();
           SqlParameter objpara1 = new SqlParameter("@Date", p.Date);
           db.parameters.Add(objpara1);
           foreach (SqlParameter a in db.parameters)
           {
               a.Direction = ParameterDirection.Input;
           }
           db.ExecuteNonQuery("InsertIns");
       }
       public DataSet DeleteIns(Keyfile p)
       {
           DAclass db = new DAclass();
           DataSet ds = new DataSet();
           //SqlParameter objpara1 = new SqlParameter("@Date", p.Date);
           //db.parameters.Add(objpara1);
           foreach (SqlParameter a in db.parameters)
           {
               a.Direction = ParameterDirection.Input;
           }
           ds = db.ExecuteDataset("DeleteIns");
           return (ds);

       }
       public DataSet bindins()
       {
           DAclass db = new DAclass();
           DataSet ds = new DataSet();
           ds = db.ExecuteDataset("bindins");
           return (ds);
       }

       public DataSet ViewRunChart(Keyfile p)
       {
           DAclass db = new DAclass();
           DataSet ds = new DataSet();
           SqlParameter objpara1 = new SqlParameter("@fromdate", p.Fromdate);
           db.parameters.Add(objpara1);
           SqlParameter objpara2 = new SqlParameter("@todate", p.ToDate);
           db.parameters.Add(objpara2);
           SqlParameter objpara3 = new SqlParameter("@data", p.Data);
           db.parameters.Add(objpara3);
           SqlParameter objpara4 = new SqlParameter("@shift", p.Shift);
           db.parameters.Add(objpara4);
           SqlParameter objpara5 = new SqlParameter("@unit", p.Unit);
           db.parameters.Add(objpara5);
           SqlParameter objpara6 = new SqlParameter("@mach", p.Machine);
           db.parameters.Add(objpara6);
           SqlParameter objpara7 = new SqlParameter("@DynValueid", p.Dynvalueid);
           db.parameters.Add(objpara7);
           ds = db.ExecuteDataset("viewrunchart");
           return (ds);
       }
    }
}
