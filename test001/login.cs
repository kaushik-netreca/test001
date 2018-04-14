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
using System.Net.NetworkInformation;
using System.Collections.Specialized;
using System.IO;
using Microsoft.Win32;
using System.Management;
using System.Text.RegularExpressions;
using System.Net.Http;

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

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 4000;
            try
            {
                //Reading version from local text file. Could be changed later
                string id = System.IO.File.ReadAllText(@"C:\Users\Kaushik\test\app_id.txt");
                string local_reboot_flag = System.IO.File.ReadAllText(@"C:\Users\Kaushik\test\app_reboot_flag.txt");
                string local_shutdown_flag = System.IO.File.ReadAllText(@"C:\Users\Kaushik\test\app_shutdown_flag.txt");
                string local_version = System.IO.File.ReadAllText(@"C:\Users\Kaushik\test\app_version.txt");
                string[] integerSrings = local_version.Split(new char[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                int[] integers = new int[integerSrings.Length];
                for (int n = 0; n < integerSrings.Length; n++)
                {
                    integers[n] = int.Parse(integerSrings[n]);
                }
                Console.WriteLine("===>> LOCAL VERSION : {0}", integers[0]);

                using (WebClient web = new WebClient())
                {
                    // Reading server version
                    web.Headers.Add("X-Authorization", "authorizationString");
                    string response1 = web.DownloadString("http://localhost:8045/search/" + local_version);
                    response1 = Regex.Replace(response1, "[^0-9]+", string.Empty);
                    int x = Int32.Parse(response1);

                    Console.WriteLine("===>> SERVER VERSION : {0}", x);

                    //Compare local and server versions
                    if (x == integers[0])
                    {
                        Console.WriteLine("===>> SAME VERSIONS. No Update Required");
                    }
                    else
                    {
                        Console.WriteLine("===>> UPDATE REQUIRED");
                        //If versions are different on server and local, delete local and download new contents from server
                        //Delete the existing file
                        if (System.IO.File.Exists(@"C:\Users\Kaushik\test\updated_file.txt"))
                        {
                            System.IO.File.Delete(@"C:\Users\Kaushik\test\updated_file.txt");
                        }

                        //Download new file from server
                        using (WebClient fileDownload = new WebClient())
                        {
                            fileDownload.DownloadFile("http://storage.ezdigitalboard.com/test_tobedeleted.txt", @"C:\Users\Kaushik\test\updated_file.txt");
                        }
                        Console.WriteLine("===>> FILES UPDATED");
                    }
                }

                //Sending status to the API
                WebRequest request = new WebRequest.Create("http://localhost:8045/app-status/" + id + "/" + local_version + "/" + local_reboot_flag + "/" + local_shutdown_flag + "/");
                Console.WriteLine("[STATUS API] : {0}", request);
                request.Method = "GET";
                WebResponse response = request.GetResponse();
                response.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
