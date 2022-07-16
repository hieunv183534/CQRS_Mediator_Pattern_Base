using NOM.SMSGATEWAY.Domain._Base.Core;
using NOM.SMSGATEWAY.Domain.Models;
using NOM.SMSGATEWAY.WebApi.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace NOM.SMSGATEWAY.WebApi.Controllers
{
    public class HomeController : ApiController
    {
        private readonly IConfiguration Configuration;
        private readonly ILogger<HomeController> _logger;
        List<SerialPort> serialPort = new List<SerialPort>();
        Dictionary<string, int> numberPort = new Dictionary<string, int>();
        Dictionary<string, string> recport = new Dictionary<string, string>();
        public DataTable tableSim = new DataTable();
        public DataTable tableMessages = new DataTable();
        public DataTable tableReceiveMessages = new DataTable();
        public DataTable tableContent = new DataTable();
        DataTableSim classDataTableSim = new DataTableSim();
        bool Pause = false;
        Dictionary<string, bool> onoffSim = new Dictionary<string, bool>();
        Dictionary<string, bool> recordIFF = new Dictionary<string, bool>();
        Dictionary<string, int> Keyidbyte = new Dictionary<string, int>();
        Dictionary<string, string> recportName = new Dictionary<string, string>();



        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            Configuration = configuration;
            Init();
        }



        [HttpPost(Name = "SendSms")]
        public string SendSms(Sms sm)
        {
            var myKeyValue = Configuration["SendType"];

            if (myKeyValue.ToString() == "1")
            {
                if (Configuration["COM"].Contains(","))
                {
                    string[] vs = Configuration["COM"].Split(",");
                    foreach (string v in vs)
                    {
                        foreach (var sp in serialPort)
                        {
                            if (sp.PortName == v.Trim())

                                return SendShortMessage(sp, sm.MobileNumber, sm.Content);

                        }

                    }
                }
                else
                {
                    foreach (var sp in serialPort)
                    {
                        if (sp.PortName == Configuration["COM"])

                            return SendShortMessage(sp, sm.MobileNumber, sm.Content);

                    }
                }

            }
            if (myKeyValue.ToString() == "2")
            {
                string stt = "";
                foreach (var sp in serialPort)
                {
                    stt = SendShortMessage(sp, sm.MobileNumber, sm.Content);
                    if (stt.Contains("SUCCESS"))
                    {
                        break;
                    }

                }
                return stt;
            }
            if (myKeyValue.ToString() == "3")
            {
                string stt = "";
                foreach (var sp in serialPort)
                {
                    stt = SendShortMessage(sp, sm.MobileNumber, sp.PortName);
                    if (stt.Contains("SUCCESS"))
                    {
                        break;
                    }

                }
                return stt;
            }
            Thread thread2 = new Thread(delegate ()
            {
                foreach (var sp in serialPort)
                {
                    int count = numberPort[sp.PortName];
                    Thread thread1 = new Thread(delegate ()
                    {
                        if (true)
                        {
                            SendShortMessage(sp, sm.MobileNumber, sm.Content);
                        }
                    });
                    thread1.IsBackground = true;
                    thread1.Start();
                    // CheckForIllegalCrossThreadCalls = false;
                    Thread.Sleep(50);
                }
            });
            thread2.IsBackground = true;
            thread2.Start();
            return "";
        }
        protected void Init()
        {

            using (var searcher = new System.Management.ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE Caption like '%(COM%'"))
            {
                tableSim = classDataTableSim.dataTableSim();
                tableMessages = classDataTableSim.dataTableMessages();
                tableReceiveMessages = classDataTableSim.dataTableReceiveMessages();
                string[] ports = SerialPort.GetPortNames();
                int countport = ports.Count();
                if (countport > 90)
                {
                    Array.Sort(ports, (a, b) => int.Parse(Regex.Replace(a, "[^0-9]", "")) - int.Parse(Regex.Replace(b, "[^0-9]", "")));
                }
                List<string> seriportName = new List<string>(ports);
                int count = 0;
                var lstPortfullname = searcher.Get().Cast<ManagementBaseObject>().ToList().Select(p => p["Caption"].ToString());
                foreach (var port in seriportName)
                {
                    var spName = lstPortfullname.FirstOrDefault(s => s.Contains("(" + port + ")") && s.Contains("XR21V1414"));
                    if (spName != null)
                    {

                        SerialPort sp;
                        sp = new SerialPort(port, 115200, Parity.None, 8, StopBits.One);
                        sp.Handshake = Handshake.RequestToSend
                            ;
                        sp.DataReceived += SerialPort_DataReceived;
                        sp.ReadTimeout = 3000;
                        sp.WriteTimeout = 3000;


                        recport.Add(sp.PortName, "");
                        serialPort.Add(sp);
                        numberPort.Add(sp.PortName, count);
                        onoffSim.Add(sp.PortName, true);
                        recordIFF.Add(sp.PortName, false);
                        Keyidbyte.Add(sp.PortName, 1);
                        if (countport > 90)
                        {
                            tableSim.Rows.Add(sp.PortName, true, "", "", "");
                            recportName.Add(sp.PortName, sp.PortName);
                        }
                        else
                        {
                            tableSim.Rows.Add("COM" + (count + 1), true, "", "", "");
                            recportName.Add(sp.PortName, "COM" + (count + 1));
                        }
                        count++;

                    }
                }

            }

        }
        protected void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string rec = "";
            string rec2 = "";
            SerialPort sp = (SerialPort)sender;
            byte[] buffer = new byte[sp.ReadBufferSize];
            int bytesRead = 0;
            try
            {
                bytesRead = sp.Read(buffer, 0, buffer.Length);
            }
            catch (Exception ex)
            {
            }
            rec += Encoding.ASCII.GetString(buffer, 0, bytesRead);
            rec2 = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            recport[sp.PortName] += rec;
            if (Pause == false)
            {
                if (rec.Contains("CPIN: NOT READY"))
                {
                    rec = "";
                    int count = numberPort[sp.PortName];
                    recport[sp.PortName] = "";
                    // ChangeGridTestSim(count, "NOT READY", "", "");
                }
            }
        }
        protected string SendShortMessage(SerialPort sp, string numnerPhone, string Content)
        {
            // DataTable dt = tableSim;
            int count = numberPort[sp.PortName];
            string Status = "";
            try
            {
                if (!sp.IsOpen)
                    sp.Open();
            }
            catch
            {
                return "LOCK";
            }
            // recport[sp.PortName] = "";
            sp.Write("AT+CPIN?; \r");
            Thread.Sleep(500);
            if (!recport[sp.PortName].Contains("CPIN: READY"))
            {
                //ChangeGridTestSim(count, "NOT READY", "", "");
                return "NOT READY";
            }
            // ChangeGridTestSim(count, "Sending...", "", "");
            sp.Write("AT+CSCS=\"GSM\"; \r");
            Thread.Sleep(100);
            sp.Write("AT+CMGF=1; \r");
            Thread.Sleep(100);
            sp.Write("AT+CSMP=17,173,0,0; \r");
            Thread.Sleep(100);
            sp.Write("AT+CMGS=" + "\"" + numnerPhone + "\"" + "\r");
            Thread.Sleep(500);
            sp.Write(StringUtil.RemoveSign4VietnameseString(Content) + (char)26);
            Thread.Sleep(6000);
            if (recport[sp.PortName].Contains("CMS ERROR"))
            {
                if (recport[sp.PortName].Contains("CMS ERROR: 28") || recport[sp.PortName].Contains("CMS ERROR: 58"))
                {
                    // Chặn sim
                    Status = "Bị chặn";
                }
                else if (recport[sp.PortName].Contains("CMS ERROR: 38"))
                {
                    // Chặn ND
                    Status = "CMS ERROR: 38";
                }
                else
                {
                    Status = "CMS ERROR";
                }
            }
            else if (recport[sp.PortName].Contains("CMGS:"))
            {
                Status = "Success | Port:" + sp.PortName;
            }
            else if (recport[sp.PortName].Contains("ERROR"))
            {

                Status = "ERROR";
            }
            else
            {
                Status = "Not response";
            }
            try
            {
                sp.Close();
            }
            catch { }
            return Status;
            // ChangeGridTestSim(count, Status, "", Content);
        }
    }
}
