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


public partial class FriendDemographic : System.Web.UI.Page
{

    string str_g;


    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {


            if (IsPostBack == false)
            {

                Session.Add("str_sess_FriendDemoId", null);


                if (ProcessVerifySelectedFriendIdSessionVariableAvailable())
                {
                    ProcessLoadSelectedFriendsDemographicInfo();
                }

            }


        }
        catch (Exception ex)
        {

        }

    }







    protected void cmdRemember_Click(object sender, EventArgs e)
    {

        try
        {

            if (ProcessVerifyRememberControlsFilled())
            {

                if (ProcessUpdateWhatIRemember())
                {

                }

            }

        }
        catch (Exception ex)
        {

        }

    }

    protected void cmdPickADifferentFriend_Click(object sender, EventArgs e)
    {

        try
        {
            Response.Redirect("Visits.aspx");
        }
        catch (Exception ex)
        {

        }

    }









    private bool ProcessLoadSelectedFriendsDemographicInfo()
    {

        bool blnLoaded = false;


        try
        {

            ProcessResetDemographicControls();


            DataTable dtDemo = new DataTable();

            int intFriendDemoId = 0;
            string strName = "";
            string strBirthdayDate = "";
            string strCellNumber = "";
            string strEmailAddress = "";
            string strFavoriteFood = "";


            str_g = "SELECT FRIEND_DEMO.friend_demo_id, FRIEND.name, FRIEND_DEMO.birthday_date, FRIEND_DEMO.cell_number,";
            str_g = str_g + " FRIEND_DEMO.email_address, FRIEND_DEMO.favorite_food";
            str_g = str_g + " FROM FRIEND_DEMO";
            str_g = str_g + " INNER JOIN FRIEND";
            str_g = str_g + " ON FRIEND_DEMO.friend_id = FRIEND.friend_id";
            str_g = str_g + " WHERE FRIEND_DEMO.friend_id = " + Session["str_sess_VisitSelectedFriendId"].ToString() + " ;";


            if (ProcessGetRecords(str_g, ref dtDemo))
            {

                foreach (DataRow row in dtDemo.Rows)
                {

                    if (row.IsNull("friend_demo_id") == false)
                    {
                        intFriendDemoId = row.Field<int>("friend_demo_id");
                    }

                    if (row.IsNull("name") == false)
                    {
                        strName = row.Field<string>("name");
                    }
                    

                    if (row.IsNull("birthday_date") == false)
                    {
                        strBirthdayDate = row.Field<string>("birthday_date");
                    }

                    if (row.IsNull("cell_number") == false)
                    {
                        strCellNumber = row.Field<string>("cell_number");
                    }

                    if (row.IsNull("email_address") == false)
                    {
                        strEmailAddress = row.Field<string>("email_address");
                    }

                    if (row.IsNull("favorite_food") == false)
                    {
                        strFavoriteFood = row.Field<string>("favorite_food");
                    }



                }  //foreach (DataRow row in dtDemo.Rows)...END


                if (strName != "")
                {
                    lblFriendName.Text = strName;
                    lblFriendName.Visible = true;
                }

                txtBirthday.Text = strBirthdayDate;
                txtCellNumber.Text = strCellNumber;
                txtEmailAddress.Text = strEmailAddress;
                txtFavoriteFood.Text = strFavoriteFood;


            }  //if (ProcessGetRecords(str_g, ref dtDemo))...END


            return blnLoaded;

        }
        catch (Exception ex)
        {
            return blnLoaded;
        }

    }


    private bool ProcessUpdateWhatIRemember()
    {
        bool blnIRemember = false;

        string strRememberMessage = "";

        try
        {

            ProcessClearDemographicErrorLabel();


            if (ProcessIRememberYou())
            {

                if (ProcessVerifySelectedFriendDemoIdSessionVariableAvailable())
                {

                    str_g = "UPDATE FRIEND_DEMO";
                    str_g = str_g + " SET birthday_date = '" + txtBirthday.Text + "', ";
                    str_g = str_g + " cell_number = '" + txtCellNumber.Text + "', ";
                    str_g = str_g + " email_address= '" + txtEmailAddress.Text + "', ";
                    str_g = str_g + " favorite_food = '" + txtFavoriteFood.Text + "'";
                    str_g = str_g + " WHERE friend_demo_id = " + Session["str_sess_FriendDemoId"].ToString() + " ;";

                    strRememberMessage = "Always Good To Catch Up";

                }

            }
            else
            {

                if (ProcessVerifySelectedFriendIdSessionVariableAvailable())
                {

                    str_g = "INSERT INTO FRIEND_DEMO";
                    str_g = str_g + " (friend_id, birthday_date, cell_number, email_address, favorite_food)";
                    str_g = str_g + " SELECT ";
                    str_g = str_g + Session["str_sess_VisitSelectedFriendId"].ToString() + ", ";
                    str_g = str_g + "'" + txtBirthday.Text + "', ";
                    str_g = str_g + "'" + txtCellNumber.Text + "', ";
                    str_g = str_g + "'" + txtEmailAddress.Text + "', ";
                    str_g = str_g + "'" + txtFavoriteFood.Text + "' ;";

                    strRememberMessage = "Thank You For Sharing";

                }

            }

            if (str_g != "")
            {

                if (ProcessInserRecord(str_g))
                {
                    blnIRemember = true;

                    ProcessDisplayDemographicErrorLabel(strRememberMessage);
                }

            }

            return blnIRemember;

        }
        catch (Exception ex)
        {
            return blnIRemember;
        }

    }


    private bool ProcessIRememberYou()
    {

        bool blnIRememberYou = false;

        int intFriendDemoId = 0;

        try
        {

            DataTable dtRemember = new DataTable();

            str_g = "SELECT FRIEND_DEMO.friend_demo_id";
            str_g = str_g + " FROM FRIEND_DEMO";
            str_g = str_g + " WHERE friend_id = " + Session["str_sess_VisitSelectedFriendId"].ToString() + " ;";
            

            if (ProcessGetRecords(str_g, ref dtRemember))
            {

                foreach (DataRow row in dtRemember.Rows)
                {

                    if (row.IsNull("friend_demo_id") == false)
                    {
                        intFriendDemoId = row.Field<int>("friend_demo_id");
                    }

                }

            }


            if (intFriendDemoId > 0)
            {
                Session["str_sess_FriendDemoId"] = intFriendDemoId.ToString();

                blnIRememberYou = true;
            }

            return blnIRememberYou;

        }
        catch (Exception ex)
        {
            return blnIRememberYou;
        }

    }








    private bool ProcessVerifyRememberControlsFilled()
    {

        bool blnFilled = true;

        try
        {

            ProcessClearDemographicErrorLabel();

            if (txtBirthday.Text == "" && txtCellNumber.Text == "" && txtEmailAddress.Text == "" && txtFavoriteFood.Text == "")
            {

                blnFilled = false;

                ProcessDisplayDemographicErrorLabel("Tell Me A Little About Yourself");

                if (txtBirthday.Text == "")
                {
                    txtBirthday.Focus();
                }

                if (txtCellNumber.Text == "")
                {
                    txtCellNumber.Focus();
                }

                if (txtEmailAddress.Text == "")
                {
                    txtEmailAddress.Focus();
                }

                if (txtFavoriteFood.Text == "")
                {
                    txtFavoriteFood.Focus();
                }

                return blnFilled;

            }

            return blnFilled;

        }
        catch (Exception ex)
        {
            return blnFilled;
        }

    }








    private void ProcessClearDemographicErrorLabel()
    {
        lblFriendDemographicError.Text = "";
        lblFriendDemographicError.Visible = false;
    }


    private void ProcessDisplayDemographicErrorLabel(string istrMsg)
    {
        lblFriendDemographicError.Text = istrMsg;
        lblFriendDemographicError.Visible = true;
    }












    


    private void ProcessResetDemographicControls()
    {

        try
        {

            lblFriendName.Text = "";
            lblFriendName.Visible = false;

            txtBirthday.Text = "";
            txtCellNumber.Text = "";
            txtEmailAddress.Text = "";
            txtFavoriteFood.Text = "";

        }
        catch (Exception ex)
        {

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


    private bool ProcessUpdateRecord(string istrSql)
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


    private bool ProcessVerifySelectedFriendDemoIdSessionVariableAvailable()
    {

        bool blnAvailable;

        blnAvailable = false;


        if (Session["str_sess_FriendDemoId"] != null)
        {

            if (Session["str_sess_FriendDemoId"].ToString() != "")
            {
                blnAvailable = true;
            }

        }


        return blnAvailable;

    }


    
}