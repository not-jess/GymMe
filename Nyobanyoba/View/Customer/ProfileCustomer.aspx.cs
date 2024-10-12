using Nyobanyoba.Controller;
using Nyobanyoba.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace Nyobanyoba.View.Customer
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["user"] == null)
                {
                    Response.Redirect("~/View/LoginPage.aspx");
                }

                int uid = Convert.ToInt32(Session["user"]);
                MsUser user = UserController.GetUserById(uid);
                UsernameTxt.Text = user.UserName;
                EmailTxt.Text = user.UserEmail;
                dobTxt.Text = user.UserDOB.ToString("yyyy-MM-dd");
                GenderRB.SelectedValue = user.UserGender;
            }
        }

        protected void UpdateProfileBtn_Click(object sender, EventArgs e)
        {
            String name = UsernameTxt.Text;
            String email = EmailTxt.Text;
            String gender = GenderRB.Text;
            String dob = dobTxt.Text;

            MsUser user = UserController.GetUserById(Convert.ToInt32(Session["user"]));

            var response = UserController.UpdateUserInfo(user.UserID, name, email, dob, gender);

            if (!response.Success)
            {
                UpdateProfileFeedbackLbl.Text = response.Message;
                return;
            }
            else
            {
                UpdateProfileFeedbackLbl.Text = response.Message;
            }

            Session["user"] = response.Payload.UserID.ToString();

            if (Request.Cookies["user_cookie"] != null)
            {
                Request.Cookies["user_cookie"].Value = response.Payload.UserID.ToString();
            }
        }

        protected void UpdatePasswordBtn_Click(object sender, EventArgs e)
        {
            String oldPass = OldPasswordTxt.Text;
            String newPass = NewPasswordTxt.Text;

            MsUser user = UserController.GetUserById(Convert.ToInt32(Session["user"]));

            var response = UserController.UpdateUserPassword(user.UserID, oldPass, newPass);

            if (!response.Success)
            {
                UpdatePasswordFeedbackLbl.Text = response.Message;
                return;
            }
            else
            {
                UpdatePasswordFeedbackLbl.Text = response.Message;
            }

            Session["user"] = response.Payload.UserID.ToString();

            if (Request.Cookies["user_cookie"] != null)
            {
                Request.Cookies["user_cookie"].Value = response.Payload.UserID.ToString();
            }
        }
    }
}