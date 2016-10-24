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

public partial class Visits : System.Web.UI.Page
{

    string str_g;


    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {

            Session.Add("str_sess_VisitSelectedFriendId", null);


            if (IsPostBack == false)
            {
                ProcessLoadVisitsGridview();
            }

        }
        catch (Exception ex)
        {

        }

    }








    protected void grdvwPeopleMet_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdvwPeopleMet.PageIndex = e.NewPageIndex;
        ProcessLoadVisitsGridview();

    }

    protected void grdvwPeopleMet_SelectedIndexChanged(object sender, EventArgs e)
    {

        string strVisitId = "";
        string strFriendId = "";


        strVisitId = grdvwPeopleMet.SelectedDataKey.Values[0].ToString();
        strFriendId = grdvwPeopleMet.SelectedDataKey.Values[1].ToString();


        if (strFriendId != null)
        {

            if (strFriendId != "")
            {

                Session.Add("str_sess_VisitSelectedFriendId", null);

                Session["str_sess_VisitSelectedFriendId"] = strFriendId;


                if (ProcessVerifySelectedFriendIdSessionVariableAvailable())
                {
                    Response.Redirect("FriendDemographic.aspx");
                }

            }

        }

    }









    private bool ProcessLoadVisitsGridview()
    {

        bool blnLoaded = false;


        try
        {

            DataTable dtVisits = new DataTable();


            str_g = "SELECT DISTINCT VISIT.visit_id, FRIEND.friend_id, FRIEND.name, VISIT.browser_type,";
            str_g = str_g + "  VISIT.browser_platform, VISIT.visit_date,";
            str_g = str_g + " SWITCH(VISIT.can_send_mail = True,'Yes',  VISIT.can_send_mail = False,'No') AS [can_send_mail]";
            str_g = str_g + " FROM VISIT";
            str_g = str_g + " INNER JOIN FRIEND";
            str_g = str_g + " ON VISIT.friend_id = FRIEND.friend_id";
            str_g = str_g + " ORDER BY VISIT.visit_date DESC ;";



            if (ProcessGetRecords(str_g, ref dtVisits))
            {
                grdvwPeopleMet.DataSource = dtVisits;
                grdvwPeopleMet.DataBind();                
            }


            grdvwPeopleMet.Visible = true;


            if (grdvwPeopleMet.Rows.Count > 0)
            {
                blnLoaded = true;
            }


            return blnLoaded;

        }
        catch (Exception ex)
        {
            return blnLoaded;
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








    private bool ProcessVerifySelectedFriendIdSessionVariableAvailable()


    {

        bool blnAvailable;

        blnAvailable = false;


        if (Session["str_sess_VisitSelectedFriendId"] != null)
        {

            if (Session["str_sess_VisitSelectedFriendId"].ToString() != "")
            {
                blnAvailable = true;
            }

        }


        return blnAvailable;

    }


}