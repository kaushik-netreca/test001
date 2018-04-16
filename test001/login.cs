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
using Timer = System.Timers.Timer;

namespace test001
{
    public partial class login : Form
    {
        public login()
        {
            //intializing a timer to execute a functionevery x seconds
            InitializeComponent();
            Timer t = new Timer(5000);
            t.AutoReset = true;
            t.Elapsed += new System.Timers.ElapsedEventHandler(t_Elapsed);
            t.Start();
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
                        MessageBox.Show("INVALID LOGIN. Please try again", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        this.Hide();
                        home_page home = new home_page(user_name);
                        home.Show();
                    }
                }
            }
        }

        public static void t_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //timer2.Interval = 4000;
            Console.WriteLine("===>>TIMER TICK STARTED -----");
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

                    // Reading server version, reboot flag and shutdown flag
                    web.Headers.Add("X-Authorization", "authorizationString");
                    string response1 = web.DownloadString("http://localhost:8045/search/" + id);     //hard coding [needs to be changed] 
                    response1 = Regex.Replace(response1, "[^0-9]+", string.Empty);
                    var ver = response1.Substring(response1.Length - 1);
                    var rbt_flag = response1.Substring(response1.Length - 3, 1);
                    var shd_flag = response1.Substring(response1.Length - 2, 1);
                    int x  = Int32.Parse(ver);
                    int xr = Int32.Parse(rbt_flag);
                    int xs = Int32.Parse(shd_flag);

                    Console.WriteLine("===>> SERVER VERSION : {0}", ver);
                    Console.WriteLine("===>> SERVER REBOOT FLAG : {0}", rbt_flag);
                    Console.WriteLine("===>> SERVER SHUTDOWN FLAG : {0}", shd_flag);

                    //Compare local and server versions
                    if (x == integers[0])
                    {
                        Console.WriteLine("===>> SAME VERSIONS. No Update Required");
                    }
                    else
                    {
                        Console.WriteLine("===>> UPDATE REQUIRED");
                        //If versions are different on server and local, write server version to local and delete local and download new contents from server
                        //Delete the existing file
                        System.IO.File.WriteAllText(@"C:\Users\Kaushik\test\app_version.txt", ver.ToString());
                        Console.WriteLine("===>> UPDATE LOCAL VERSION to SERVER VERSION");
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

                    //Compare local and server reboot flags
                    // if different writes server flag to local and restart
                    if (rbt_flag != local_reboot_flag)
                    {
                        System.IO.File.WriteAllText(@"C:\Users\Kaushik\test\app_reboot_flag.txt", xr.ToString());
                        Console.WriteLine("===>> UPDATE LOCAL VERSION to SERVER VERSION");
                        Application.Restart();
                        Console.WriteLine(" Different RESTART FLAGS from server and local");
                    }
                    else
                    {
                        Console.WriteLine(" SAME RESTART FLAGS from server and local");
                    }
                    //Compare local and server shutdown flags
                    // if different writes server flag to local and shutdown
                    if (shd_flag != local_shutdown_flag)
                    {
                        System.IO.File.WriteAllText(@"C:\Users\Kaushik\test\app_shutdown_flag.txt", xs.ToString());
                        Application.Exit();
                        Console.WriteLine(" Different SHUTDOWN FLAGS from server and local");
                    }
                    else
                    {
                        Console.WriteLine(" SAME SHUTDOWN FLAGS from server and local");
                    }
                }

                //Sending status to the API
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:8045/app-status/" + id + "/" + local_version + "/" + local_reboot_flag + "/" + local_shutdown_flag + "/");
                Console.WriteLine("[STATUS API] : {0}", httpWebRequest);
                httpWebRequest.Method = "GET";
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                httpResponse.Close();
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}