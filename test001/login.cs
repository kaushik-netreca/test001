using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Collections.Specialized;
using System.IO;

namespace test001
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void Btn_login_Click(object sender, EventArgs e)
        {
            string user_name = txb_user_name.Text;
            if ((string.IsNullOrWhiteSpace(txb_access_code.Text)) || (string.IsNullOrWhiteSpace(txb_password.Text)) || (string.IsNullOrWhiteSpace(txb_user_name.Text)))
            {
                MessageBox.Show("All Fields are Mandatory", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txb_access_code.Text.Length != 6)
            {
                MessageBox.Show("Access Code length must be 6", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://wrp-api.posmasterus.com/wsdb/wholesale/submaster-user/login/smcode/" + txb_access_code.Text);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = "{\"req_data_length\":1,\"req_data\":[{\"id\":\"" + txb_user_name.Text + "\",\"pw\":\"" + txb_password.Text + "\"}]}";
                    Console.WriteLine(json);
                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    Console.WriteLine(result);
                    if (result.Contains("message_login"))
                    {
                        MessageBox.Show("INVALID LOGIN. Please try again" + "\n" + "API RESPONSE : " + result , "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txb_access_code.Text = "";
                        txb_user_name.Text = "";
                        txb_password.Text = "";
                    }
                    else if (result.Contains("[ERROR]"))
                    {
                        MessageBox.Show("Access Code INVALID", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (result.Contains("login_response"))
                    {
                        // MessageBox.Show("VALID LOGIN" + "\n" + "API RESPONSE : " + result, "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //txb_access_code.Text = "";
                        //txb_user_name.Text = "";
                        // txb_password.Text = "";
                        this.Hide();
                        home_page home = new home_page(user_name);
                        home.Show();
                    }
                }
            }
        }
    }
}
