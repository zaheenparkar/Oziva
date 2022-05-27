using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using PropertyLayer;

namespace PC_Application.Scanning
{
    public partial class frmOnlineScanning1 : Form
    {
        public frmOnlineScanning1()
        {
            InitializeComponent();
        }

        public int Reply(string strIP)
        { 
            System.Net.NetworkInformation.Ping pingme = new System.Net.NetworkInformation.Ping();
            System.Net.NetworkInformation.PingReply Reply;
            Reply = pingme.Send(strIP);
            if (Reply.Status == System.Net.NetworkInformation.IPStatus.Success )
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public void SaveBarcode(string strBarcode)
        {
            BusinessLayer.BL_Scanning objScan = new BusinessLayer.BL_Scanning();
            ListViewItem lstitem = new ListViewItem(strBarcode.Replace("*", ""));
            try
            {
                if(strBarcode.Trim() == "NOREAD")
                {
                    lblFail.Text = (Convert.ToInt32(lblFail.Text) + 1).ToString();
                    listView1.Items.Add(lstitem).BackColor = Color.Red;
                }
                else
                {
                    Int32 intStatus = objScan.InsertSecData_Single(strBarcode, PL_Login.UserID.ToString().Trim());
                    switch(intStatus)
                    {
                        case 0:
                            lblFail.Text = (Convert.ToInt32(lblFail.Text) + 1).ToString();
                            listView1.Items.Add(lstitem).BackColor = Color.Red;
                            break;
                        case 1:
                            listView1.Items.Add(lstitem).BackColor = Color.Green;
                            lblPass.Text = (Convert.ToInt32(lblPass.Text) + 1).ToString();
                            break;
                        case 2:
                            lblFail.Text = (Convert.ToInt32(lblFail.Text) + 1).ToString();
                            listView1.Items.Add(lstitem).BackColor = Color.Red;
                            break;
                    }
                }

            }
            catch (Exception ex)
            {
            }
            finally
            {
                objScan = null;
            }
        }

        private void frmOnlineScanning_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            this.WindowState = FormWindowState.Maximized;
            if (lblLine.Text.Trim() == string.Empty)
            {
                lblLine.Text = PC_Application.Properties.Settings.Default.strLine.ToString();
            }
            
            BusinessLayer.BL_Printing objPrint = new BusinessLayer.BL_Printing();
            try
            {
                DataTable dt = new DataTable();
                dt = objPrint.BL_GetOnlineScan_Info(lblLine.Text.Trim());
                if (dt.Rows.Count != 0)
                {
                    textBox1.Text = dt.Rows[0][3].ToString();
                    textBox3.Text = dt.Rows[0][4].ToString();
                    textBox2.Text = dt.Rows[0][1].ToString();
                    textBox4.Text = dt.Rows[0][2].ToString();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                objPrint = null;
            }

            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
            if (!backgroundWorker2.IsBusy)
            {
                backgroundWorker2.RunWorkerAsync();
            }

            timer1.Enabled = true;
            timer2.Enabled = true;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //MessageBox.Show("01");
            clsNetwork objcls = new clsNetwork();
            try
            {
                clsNetwork.InitializeTCPClient(IPAddress.Parse(textBox2.Text.Trim()), int.Parse(textBox4.Text.Trim()));
                string strBarcode = clsNetwork.ReceiveDataFromServer();

                if (strBarcode.Trim() != string.Empty)
                {
                    if (strBarcode.Trim() != "NOREAD*")
                    {
                        strBarcode = strBarcode.Replace("*", "").Trim();
                        SaveBarcode(strBarcode);
                    }
                    else
                    {
                        lblFail.Text = (Convert.ToInt32(lblFail.Text) + 1).ToString();
                        ListViewItem lstitem = new ListViewItem(strBarcode.Replace("*", ""));
                        listView1.Items.Add(lstitem).BackColor = Color.Red;
                    }
                }
            }
            catch (Exception ex){}
            finally
            {
                label16.Text = "Total Count = " + listView1.Items.Count.ToString();
                listView1.Items[listView1.Items.Count - 1].EnsureVisible();
                clsNetwork.TerminateTCPClient();
                objcls = null;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            if (Reply(textBox1.Text.Trim()) == 0)
            {
                label6.BackColor = Color.Red;
            }
            else
            {
                label6.BackColor = Color.Green;
            }

            if (Reply(textBox2.Text.Trim()) == 0)
            {
                label7.BackColor = Color.Red;
            }
            else
            {
                label7.BackColor = Color.Green;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (!backgroundWorker2.IsBusy)
            {
                backgroundWorker2.RunWorkerAsync();
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }
    }
}
