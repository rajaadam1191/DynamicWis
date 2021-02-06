<%@ Application Language="C#"%>

<script runat="server">
    void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on application startup

    }

    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown

    }

    void Application_Error(object sender, EventArgs e)
    {
        // Code that runs when an unhandled error occurs
        Exception exc = Server.GetLastError();
        if (exc.Message.Contains("NoCatch"))
            return;

        if (exc.Message != "File does not exist." && exc.Message != null)
        {
            ExceptionLogging.SendExcepToDB(exc);
        }

        //if (exc is HttpUnhandledException)
        //{
        //    // Pass the error on to the error page.
        //    //Server.Transfer("ErrorPage.aspx?handler=Application_Error%20-%20Global.asax", true);
        //    ExceptionLogging.SendExcepToDB(exc);
        //}
    }

    void Session_Start(object sender, EventArgs e)
    {
        // Code that runs when a new session is started
        Session.Timeout = 3000;

    }
    protected void Application_BeginRequest(Object sender, EventArgs e)
    {
        Context.Items.Add("Request_Start_Time", DateTime.Now);
    }
    public override void Init()
    {
        base.Init();

        EndRequest += Application_EndRequest;
    }
    private void Application_EndRequest(Object sender, EventArgs e)
    {

        Exception exc = Server.GetLastError();
        if (exc != null)
        {
            if (exc.Message.Contains("NoCatch"))
                return;
        }

        TimeSpan tsDuration = DateTime.Now.Subtract((DateTime)Context.Items["Request_Start_Time"]);
        //        ExceptionLogging.sqlqueryRequest(HttpContext.Request.Url.AbsoluteUri.ToString(), Context.Items["Request_Start_Time"].ToString(), DateTime.Now.ToString(), tsDuration.ToString(), exc);
        string starttime = (string)Context.Items["Request_Start_Time"].ToString();
        if (String.IsNullOrEmpty(starttime))
        {
            //Response.Write("<!-- Empty Message! -->");
            //ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "alert('Enter the UCL and LCL !');", true);

        }
        else
        {
            ExceptionLogging.sqlqueryRequest(Context.Items["Request_Start_Time"].ToString(), DateTime.Now.ToString(), tsDuration.ToString(), exc);
        }

    }
    public void WriteFile(string strText)
    {
        string filepath = Request.PhysicalApplicationPath + "RequestError.txt";
        System.IO.StreamWriter strWriter = new System.IO.StreamWriter(Request.PhysicalApplicationPath + "RequestError.txt", true);
        string str = DateTime.Now + " " + strText;
        strWriter.WriteLine(str);
        strWriter.Close();
        strWriter.Dispose();
        GC.Collect();
    }
    void Session_End(object sender, EventArgs e)
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.
        Session["User_ID"] = "";
        Session["User_Name"] = "";
        Session["Logtime"] = "";
        Session["LogDate"] = "";
        Session["PID_ID"] = "";
        Session["Clear"] = "";
        Session["Shift"] = "";
        Session["PartNo"] = "";
        Session["Operation"] = "";
        Session["MachineName"] = "";
        Session["Page"] = "";
        Session["User_Role"] = "";
        Session["fromdate"] = "";
        //Session["todatedate"] = "";
        Session["pidno"] = "";
        Session["Process"] = "";
        //  Session["AdmPidno"] = "";


    }
       
</script>
