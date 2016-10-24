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

public partial class Hello : System.Web.UI.Page
{


    string str_g;



    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {

            if (IsPostBack == false)
            {

                string strHello = "";


                ProcessClearHelloLabel();


                if (ProcessVerifyNameSessionVariableAvailable())
                {

                    if (ProcessVerifyFriendYesNoSessionVariableAvailable())
                    {

                        if (Session["str_sess_HelloWorldCurrentFriendYesNo"].ToString() == "YES")
                        {
                            strHello = "Hello " + Session["str_sess_HelloWorldName"].ToString() + ", ";
                            strHello = strHello + " Welcome Back To The ''World''.";
                        }
                        else
                        {
                            strHello = "Hello " + Session["str_sess_HelloWorldName"].ToString() + ", ";
                            strHello = strHello + " Welcome To The ''World''.";
                        }  //if (Session["str_sess_HelloWorldCurrentFriendYesNo"].ToString() == "YES")...END


                    }
                    else
                    {
                        strHello = "Hello " + Session["str_sess_HelloWorldName"].ToString() + ", ";
                        strHello = strHello + " Welcome To The ''World''.";
                    }  //if (ProcessVerifyFriendYesNoSessionVariableAvailable())...END

                }
                else
                {
                    strHello = "Hello!  Do I Know You?";
                }  //if (ProcessVerifyNameSessionVariableAvailable())...END


                ProcessDisplayHelloLabel(strHello);

            }  //if (IsPostBack == false)...END

        }
        catch (Exception ex)
        {

        }


    }







    protected void cmdCloseWindow_Click(object sender, EventArgs e)
    {

        try
        {
            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.close()", true);
        }
        catch (Exception ex)
        {

        }

    }







    private void ProcessClearHelloLabel()
    {
        lblSayHello.Text = "";
        lblSayHello.Visible = false;
    }


    private void ProcessDisplayHelloLabel(string istrMsg)
    {
        lblSayHello.Text = istrMsg;
        lblSayHello.Visible = true;
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




}