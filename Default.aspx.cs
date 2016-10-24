using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Xml;
using System.Web.Services;

public partial class _Default : System.Web.UI.Page
{

    string str_g;


    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {

            Session.Add("str_sess_HelloWorldName", null);


            HttpRequest httpRequest = HttpContext.Current.Request;

            Session.Add("str_sess_BrowserCanSendMail", null);
            Session["str_sess_BrowserCanSendMail"] = httpRequest.Browser.CanSendMail.ToString();

            Session.Add("str_sess_BrowserPlatform", null);
            Session["str_sess_BrowserPlatform"] = httpRequest.Browser.Platform.ToString();

            Session.Add("str_sess_BrowserType", null);
            Session["str_sess_BrowserType"] = httpRequest.Browser.Type.ToString();


            if (IsPostBack == false)
            {
                txtIntroduceYourself.Focus();
            }

        }
        catch (Exception ex)
        {


        }

    }



    protected void cmdIntroduceYourself_Click(object sender, EventArgs e)
    {

        try
        {

            if (ProcessValidateName())
            {

                if (ProcessCaptureFriend())
                {

                    if (ProcessCaptureVisit())
                    {

                        Session.Add("str_sess_HelloWorldName", null);
                        Session["str_sess_HelloWorldName"] = txtIntroduceYourself.Text;

                        ClientScript.RegisterStartupScript(GetType(), "openwindow", "<script type=text/javascript> window.open('Hello.aspx'); </script>");

                    }

                }

            
            }
            else
            {

            }

        }
        catch (Exception ex)
        {

        }



    }






    private bool ProcessValidateName()
    {

        bool blnValidated = true;


        try
        {

            ProcessClearErrorLabel();


            if (txtIntroduceYourself.Text == "")
            {
                blnValidated = false;

                ProcessDisplayErrorLabel("Please Tell Me Your Name.");

                txtIntroduceYourself.Focus();

                return blnValidated;
            }

            return blnValidated;


        }
        catch (Exception ex)
        {
            return blnValidated;
        }

    }






    private bool ProcessCaptureFriend()
    {

        bool blnCaptured = false;

        int intReturnedFriendId = 0;


        try
        {

            Session.Add("str_sess_HelloWorldCurrentFriendYesNo", null);
            Session.Add("str_sess_HelloWorldCurrentFriend_ID", null);


            if (ProcessValidateNameDoesNotExist(ref intReturnedFriendId))
            {

                string strCurrentDate = "";

                strCurrentDate = DateTime.Now.ToString();



                if (strCurrentDate != "")
                {

                    str_g = "INSERT INTO FRIEND";
                    str_g = str_g + " (name, creation_date)";
                    str_g = str_g + " SELECT ";
                    str_g = str_g + "'" + txtIntroduceYourself.Text.Replace("'", "''") + "', ";
                    str_g = str_g + "'" + strCurrentDate + "' ;";


                    blnCaptured = ProcessInserRecord(str_g);


                } //if (strCurrentDate != "")...END


                if (blnCaptured)
                {

                    int intNewlyCreatedFriendId = 0;

                    Session["str_sess_HelloWorldCurrentFriendYesNo"] = "NO";


                    intNewlyCreatedFriendId = ProcessGetNewlyCreatedFriendId(strCurrentDate);

                    if (intNewlyCreatedFriendId > 0)
                    {
                        Session["str_sess_HelloWorldCurrentFriend_ID"] = intNewlyCreatedFriendId.ToString();
                    }

                }

            }  //if (ProcessValidateNameDoesNotExist())...END
            else
            {
                
                Session["str_sess_HelloWorldCurrentFriendYesNo"] = "YES";

                Session["str_sess_HelloWorldCurrentFriend_ID"] = intReturnedFriendId.ToString();

                blnCaptured = true;
            }


            return blnCaptured;

        }
        catch (Exception ex)
        {
            return blnCaptured;
        }


    }


    private bool ProcessValidateNameDoesNotExist(ref int iintReturnedFriendId)
    {

        bool blnDoesNotExist = true;

        int intFriendId = 0;

        DataTable dtFriendExists = new DataTable();


        try
        {

            iintReturnedFriendId = 0;


            str_g = "SELECT TOP 1 friend_id";
            str_g = str_g + " FROM FRIEND";
            str_g = str_g + " WHERE name = '" + txtIntroduceYourself.Text.Replace("'", "''") + "'";


            if (ProcessGetRecords(str_g, ref dtFriendExists))
            {

                foreach (DataRow row in dtFriendExists.Rows)
                {

                    if (row.IsNull("friend_id") == false)
                    {
                        intFriendId = row.Field<int>("friend_id");
                    }


                } //foreach (DataRow row in dtFriendExists.Rows)...END


                dtFriendExists.Dispose();

            }


            if (intFriendId > 0)
            {
                blnDoesNotExist = false;
            }


            iintReturnedFriendId = intFriendId;

            return blnDoesNotExist;

        }
        catch (Exception ex)
        {
            return blnDoesNotExist;
        }


    }


    private int ProcessGetNewlyCreatedFriendId(string istrCurrentDate)
    {

        int intNewId = 0;

        DataTable dtNewId = new DataTable();

        try
        {

            if (istrCurrentDate != "")
            {

                str_g = "SELECT TOP 1 friend_id";
                str_g = str_g + " FROM FRIEND";
                str_g = str_g + " WHERE name = '" + txtIntroduceYourself.Text.Replace("'", "''") + "'";
                str_g = str_g + " AND creation_date = #" + istrCurrentDate + "#";
                str_g = str_g + " ORDER BY creation_date DESC ;";

                if (ProcessGetRecords(str_g, ref dtNewId))
                {

                    foreach (DataRow row in dtNewId.Rows)
                    {

                        if (row.IsNull("friend_id") == false)
                        {
                            intNewId = row.Field<int>("friend_id");
                        }


                    }  //foreach (DataRow row in dtNewId.Rows)...END


                }  //if (ProcessGetRecords(str_g, dtNewId))...END


            }  //if (istrCurrentDate != "")...END


            return intNewId;

        }
        catch (Exception ex)
        {
            return intNewId;
        }

    }


    private bool ProcessCaptureVisit()
    {

        bool blnCaptured = false;

        try
        {


            str_g = ConstructCaptureVisitSql();


            if (str_g != "")
            {

                if (ProcessInserRecord(str_g))
                {
                    blnCaptured = true;
                }

            }


            return blnCaptured;
        }
        catch (Exception ex)
        {
            return blnCaptured;
        }


    }


    private string ConstructCaptureVisitSql()
    {

        string strsql = "";


        try
        {

            if (ProcessVerifyFriendIdSessionVariableAvailable())
            {
                strsql = "INSERT INTO VISIT";
                strsql = strsql + " (friend_id, visit_date";

                if (ProcessVerifyBrowserPlatformSessionVariableAvailable())
                {
                    strsql = strsql + ", browser_platform";
                }


                if (ProcessVerifyBrowserTypeSessionVariableAvailable())
                {
                    strsql = strsql + ", browser_type";
                }


                if (ProcessVerifyCanSendMailSessionVariableAvailable())
                {
                    strsql = strsql + ", can_send_mail";
                }


                strsql = strsql + ")";


                strsql = strsql + " SELECT ";
                strsql = strsql + Session["str_sess_HelloWorldCurrentFriend_ID"].ToString() + ", ";
                strsql = strsql + " Date()";


                if (ProcessVerifyBrowserPlatformSessionVariableAvailable())
                {
                    string strPlatform = Session["str_sess_BrowserPlatform"].ToString();

                    if (strPlatform.Length > 50)
                    {
                        strsql = strsql + ", '" + strPlatform.Substring(0, 50) + "'";
                    }
                    else
                    {
                        strsql = strsql + ", '" + strPlatform + "'";
                    }

                }


                if (ProcessVerifyBrowserTypeSessionVariableAvailable())
                {

                    string strType = Session["str_sess_BrowserType"].ToString();

                    if (strType.Length > 50)
                    {
                        strsql = strsql + ", '" + strType.Substring(0, 50) + "'";
                    }
                    else
                    {
                        strsql = strsql + ", '" + strType + "'";
                    }

                    
                }


                if (ProcessVerifyCanSendMailSessionVariableAvailable())
                {

                    string strCanSendMail = Session["str_sess_BrowserCanSendMail"].ToString();


                    if (strCanSendMail == "YES")
                    {
                        strsql = strsql + ", 1";
                    }
                    else
                    {
                        strsql = strsql + ", 0";
                    }

                }



                strsql = strsql + " ;";

            }

            return strsql;

        }
        catch (Exception ex)
        {
            return strsql;
        }
    }







    private bool ProcessInserRecord(string istrSql)
    {

        bool blnInserted = false;

        int intRowsAffected = 0;


        try
        {

            if (istrSql != "")
            {


                OleDbConnection connHelloWorldDb = new OleDbConnection(ConfigurationManager.ConnectionStrings["HelloWorldDbConnectionString"].ConnectionString);

                //(connHelloWorldDb)Connection delacred and instantiated elsewhere
                connHelloWorldDb.Open();

                OleDbCommand cmdInsert = new OleDbCommand(str_g, connHelloWorldDb);


                intRowsAffected = cmdInsert.ExecuteNonQuery();
                cmdInsert.Dispose();


                connHelloWorldDb.Close();
                connHelloWorldDb.Dispose();


                if (intRowsAffected > 0)
                {
                    blnInserted = true;
                }

            }  //if (istrSql != "")...END



            return blnInserted;

        }
        catch (Exception ex)
        {
            return blnInserted;
        }

    }


    private bool ProcessGetRecords(string istrSql, ref DataTable idtReturnRecords)
    {

        bool blnHasRows = false;

        try
        {

            if (istrSql != "")
            {

                using (OleDbConnection connHelloWorld = new OleDbConnection(ConfigurationManager.ConnectionStrings["HelloWorldDbConnectionString"].ConnectionString))
                {

                    connHelloWorld.Open();

                    OleDbCommand cmdGetRecords = new OleDbCommand(str_g, connHelloWorld);

                    cmdGetRecords.CommandTimeout = 0;


                    OleDbDataAdapter adaptGetRecords = new OleDbDataAdapter(cmdGetRecords);
                    idtReturnRecords = new DataTable();

                    adaptGetRecords.Fill(idtReturnRecords);

                    if (idtReturnRecords.Rows.Count > 0)
                    {
                        blnHasRows = true;
                    }


                    cmdGetRecords.Dispose();
                    adaptGetRecords.Dispose();

                    connHelloWorld.Close();


                }  //using (OleDbConnection connHelloWorld = new OleDbConnection(ConfigurationManager.ConnectionStrings["HelloWorldDbConnectionString"].ConnectionString))...END

            }  //if (istrSql != "")...END



            return blnHasRows;


        }
        catch (Exception ex)
        {
            return blnHasRows;
        }

    }







    private void ProcessClearErrorLabel()
    {
        lblHelloError.Text = "";
        lblHelloError.Visible = false;
    }


    private void ProcessDisplayErrorLabel(string istrMsg)
    {
        lblHelloError.Text = istrMsg;
        lblHelloError.Visible = true;
    }







    private bool ProcessVerifyNameSessionVariableAvailable()
    {

        bool blnAvailable;

        blnAvailable = false;


        if (Session["str_sess_HelloWorldName"] != null)
        {

            if (Session["str_sess_HelloWorldName"].ToString() != "")
            {
                blnAvailable = true;
            }

        }


        return blnAvailable;

    }


    private bool ProcessVerifyFriendYesNoSessionVariableAvailable()

    {

        bool blnAvailable;

        blnAvailable = false;


        if (Session["str_sess_HelloWorldCurrentFriendYesNo"] != null)
        {

            if (Session["str_sess_HelloWorldCurrentFriendYesNo"].ToString() != "")
            {
                blnAvailable = true;
            }

        }


        return blnAvailable;

    }


    private bool ProcessVerifyFriendIdSessionVariableAvailable()

    {

        bool blnAvailable;

        blnAvailable = false;


        if (Session["str_sess_HelloWorldCurrentFriend_ID"] != null)
        {

            if (Session["str_sess_HelloWorldCurrentFriend_ID"].ToString() != "")
            {
                blnAvailable = true;
            }

        }


        return blnAvailable;

    }


    private bool ProcessVerifyCanSendMailSessionVariableAvailable()


    {

        bool blnAvailable;

        blnAvailable = false;


        if (Session["str_sess_BrowserCanSendMail"] != null)
        {

            if (Session["str_sess_BrowserCanSendMail"].ToString() != "")
            {
                blnAvailable = true;
            }

        }


        return blnAvailable;

    }
        

    private bool ProcessVerifyBrowserPlatformSessionVariableAvailable()


    {

        bool blnAvailable;

        blnAvailable = false;


        if (Session["str_sess_BrowserPlatform"] != null)
        {

            if (Session["str_sess_BrowserPlatform"].ToString() != "")
            {
                blnAvailable = true;
            }

        }


        return blnAvailable;

    }
        
            
    private bool ProcessVerifyBrowserTypeSessionVariableAvailable()


    {

        bool blnAvailable;

        blnAvailable = false;


        if (Session["str_sess_BrowserType"] != null)
        {

            if (Session["str_sess_BrowserType"].ToString() != "")
            {
                blnAvailable = true;
            }

        }


        return blnAvailable;

    }
        







}