using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Net.Mail;
using System.ServiceProcess;
using System.Threading;

namespace EMailServices
{
    public partial class Service1 : ServiceBase
    {
        //private System.Timers.Timer Schedular = new System.Timers.Timer();
        private double servicePollInterval;
        public string randomuserID;
        public string randompassword;
        public string orderid;
        public string deliveryid;
        public SqlDataAdapter da;
        public SqlConnection con;
        string connectionStrings = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

        public Service1()
        {
            InitializeComponent();
            servicePollInterval = 2000;
        }

        //[Conditional("DEBUG_SERVICE")]
        //private static void DebugMode()
        //{
        //    Debugger.Break();
        //}

        protected override void OnStart(string[] args)
        {
            try
            {
                //DebugMode();
                //System.Diagnostics.Debugger.Launch();

                this.WriteToFile("PRVS Notification Service started {0}");
                DateTime now = DateTime.Now;
                DateTime sendTime = DateTime.Today.AddHours(1);
                long msUntilSendTime = 2000;// (long)(sendTime - now).TotalMilliseconds;

                Schedular = new System.Threading.Timer(new TimerCallback(ExecuteServiceAction), null, msUntilSendTime, (long)Timeout.Infinite);
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", ex.ToString(), EventLogEntryType.Error);
            }


        }

        public void ExecuteServiceAction(object state)
        {
            DateTime now = DateTime.Now;
            DateTime sendTime = DateTime.Today.AddHours(1);

            // If it's already past send time execute action, 
            // extend time and wait until tomorrow.
            if (now > sendTime)
            {
                // Not shown.
                sendTime = sendTime.AddDays(1.0);
            }
            ScheduleService();
            long msUntilSendTime = (long)(sendTime - now).TotalMilliseconds;
            Schedular.Change(2000, Timeout.Infinite);
        }

        public void onDebug()
        {
            OnStart(null);
        }

        protected override void OnStop()
        {
            this.WriteToFile("PRVS Notification Service stopped {0}");
            //this.Schedular.Stop();
            this.Schedular.Dispose();
        }
        private Timer Schedular;   //Thread timer

        private void SchedularCallback(object e)
        {
            this.WriteToFile("Simple Service Log: {0}");
            //this.ScheduleService();
        }

        private DataTable GetNewCustomers()
        {
            DataTable dt = null;
            using (SqlConnection con = new SqlConnection(this.connectionStrings))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "USP_GET_MAIL_NOTIFY_CUSTOMERS";
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        dt = new DataTable();
                        sda.Fill(dt);
                    }
                }
            }
            return dt;
        }

        private DataSet GetUserLoginDetails(string customerID)
        {
            DataSet dsRandomCredentials = new DataSet();
            using (SqlConnection con = new SqlConnection(this.connectionStrings))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "USP_LOGIN_DETAILS";
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.AddWithValue("@Action", "I");
                    cmd.Parameters.AddWithValue("@Customer_ID", Convert.ToInt32(customerID));
                    
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dsRandomCredentials);
                    }
                }
            }
            return dsRandomCredentials;
        }


        public void ScheduleService()
        {
            //Schedular = new Timer(new TimerCallback(SchedularCallback));
            DateTime scheduledTime = DateTime.Parse(System.Configuration.ConfigurationManager.AppSettings["ScheduledTime"]);
            DateTime scheduledTime2 = DateTime.Parse(System.Configuration.ConfigurationManager.AppSettings["ScheduledTime2"]);
            if (DateTime.Now >= scheduledTime && DateTime.Now <= scheduledTime2)
            {
                DataTable dt = new DataTable();
                try
                {
                    dt = GetNewCustomers();
                    if (dt.Rows.Count > 0)
                    {
                        
                        foreach (DataRow row in dt.Rows)
                        {
                            string name = row["CUSTOMER_NAME"] != DBNull.Value ? row["CUSTOMER_NAME"].ToString() : string.Empty;
                            string email = row["CUSTOMER_EMAIL"] != DBNull.Value ? row["CUSTOMER_EMAIL"].ToString() : string.Empty;
                            string customerID = row["CUSTOMER_MASTER_ID"] != DBNull.Value ? row["CUSTOMER_MASTER_ID"].ToString() : string.Empty;
                            string salesTeamEmailID = row["SALES_TEAM_EMP_MAIL"] != DBNull.Value ? row["SALES_TEAM_EMP_MAIL"].ToString() : string.Empty;
                            WriteToFile("Trying to send email to: " + name + " " + email);

                            DataSet dsRandomCredentials = new DataSet();
                            //Get User Login Details
                            dsRandomCredentials = GetUserLoginDetails(customerID);
                            randomuserID = dsRandomCredentials.Tables[0].Rows[0]["UserID"].ToString();
                            randompassword = dsRandomCredentials.Tables[0].Rows[0]["PASSWORD"].ToString();
                            orderid = dsRandomCredentials.Tables[1].Rows[0]["SALES_ORDER_MASTER_ID"].ToString();
                            deliveryid = dsRandomCredentials.Tables[1].Rows[0]["DELIVERY_ORDER_MASTER_ID"].ToString();
                            string axptaSalesOrderId = dsRandomCredentials.Tables[1].Rows[0]["SALES_ORDER_ID"].ToString();
                            string axptaDeliveryOrderId = dsRandomCredentials.Tables[1].Rows[0]["DELIVERY_ID"].ToString();
                            string TargetEmailAddress = System.Configuration.ConfigurationManager.AppSettings["TargetEmailAddress"];
                            string subject = "REGISTER YOUR ORDER DETAILS";
                            string body = GetMailHeader(name, orderid, axptaSalesOrderId, deliveryid, axptaDeliveryOrderId, randomuserID, randompassword);
                            // Sending mail to Customer and Sales PIC Team
                            SendMail(TargetEmailAddress, email, subject, body, salesTeamEmailID);
                            WriteToFile("Email sent successfully to: " + name + " " + email);
                            int? deliveryID = !string.IsNullOrEmpty(deliveryid) ? Convert.ToInt32(deliveryid) : default(int?);
                            UpdateNoitfiedCustomer(deliveryID);
                            //this.ScheduleService();
                        }
                        //Updating GSG Notified Customer status in PRVS so that next time ScheduleService no need to send to mail to notified customer again
                        //UpdateNoitfiedCustomer();
                    }

                }
                catch (Exception ex)
                {
                    WriteToFile("Simple Service Error on: {0} " + ex.Message + ex.StackTrace);

                    //Stop the Windows Service.
                    using (System.ServiceProcess.ServiceController serviceController = new System.ServiceProcess.ServiceController("SimpleService"))
                    {
                        serviceController.Stop();
                    }
                }
            }
        }

        //Get Mail Header
        private string GetMailHeader(string name, string orderid, string axptaSalesOrderId, string deliveryid, string axptaDeliveryOrderId, string randomuserID, string randompassword)
        {
            string body = string.Format("Dear {0},<br /><br />", name);
            body = body + string.Format("Please use the below URL to fill the required details for your Order with Gunnung Steel <br/><br />");
            body = body + String.Format("<a href=\"https://prvms.gunungsteel.com/Gunnung/GSGCustomer/User_Login.aspx/?OrderID={0}&&DeliveryID={1}\" +orderid, deliveryid > Click here to Login </a>" + "<br /><br />" + Environment.NewLine, orderid, deliveryid);
            body = body + string.Format("<b>User Name</b>: {0}<br/>" + Environment.NewLine, randomuserID);
            body = body + string.Format("<b>Password</b>: {1}<br/>", Environment.NewLine, randompassword);
            body = body + string.Format("<b>Sales Order No</b>: {1}<br/>", System.Environment.NewLine, axptaSalesOrderId);
            body = body + string.Format("<b>Delivery Order No</b>: {1}<br/><br/><br/>", System.Environment.NewLine, axptaDeliveryOrderId);
            body = body + string.Format("<b>Thanks and Regards</b><br/>");
            body = body + string.Format("Gunung Admin Group");
            return body;
        }

        //Sending mail to Customer
        private void SendMail(string fromMailAddress, string toMailAddress, string subject, string body, string ccMailAddress = "")
        {
            using (MailMessage mm = new MailMessage(fromMailAddress, toMailAddress))
            {
                if (!String.IsNullOrEmpty(ccMailAddress))
                {
                    foreach (var ccMailId in ccMailAddress.Split(new[] { ';', ',' }))
                    {
                        mm.CC.Add(new MailAddress(ccMailId));
                    }
                }
                mm.Subject = subject;
                mm.Body = body;
                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = System.Configuration.ConfigurationManager.AppSettings["smtpserver"];
                smtp.Port = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["SmtpPort"]);
                smtp.EnableSsl = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["SmtpSslEnabled"]);
                System.Net.NetworkCredential credentials = new System.Net.NetworkCredential();
                credentials.UserName = fromMailAddress;
                credentials.Password = System.Configuration.ConfigurationManager.AppSettings["TargetEmailPassword"];
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = credentials;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Port = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["SmtpPort"]);

                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate(object s,
                System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                System.Security.Cryptography.X509Certificates.X509Chain chain,
                System.Net.Security.SslPolicyErrors sslPolicyErrors)
                {
                    return true;
                };

                smtp.Send(mm);
            }
        }

        //Updating notified customers status in PRVS
        private bool UpdateNoitfiedCustomer(int? deliveryOrderMasterId)
        {
            DataTable dt = new DataTable();
            string status = string.Empty;
            using (SqlConnection con = new SqlConnection(connectionStrings))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "USP_UPDATE_MAIL_NOTIFIED_CUSTOMERS";
                    cmd.Parameters.AddWithValue("@DELIVERY_ORDER_MASTER_ID", deliveryOrderMasterId);
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }

                    if (dt.Rows.Count > 0)
                    {
                        status = dt.Rows[0]["IsNotifiedStatusUpdated"].ToString();
                    }
                }
            }
            return Convert.ToBoolean(status); ;
        }

        private void WriteToFile(string text)
        {
            string path = @"E:\GSG\NotificationLog.txt";
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(string.Format(text, DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt")));
                writer.Close();
            }
        }

    }
}
