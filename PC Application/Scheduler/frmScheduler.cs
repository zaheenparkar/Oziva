using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using BusinessLayer;
using PropertyLayer;
using DataLayer;
using System.Windows.Forms;

namespace Scheduler
{
    public partial class frmScheduler : Form
    {
        BL_Scheduler objSchedule;
        BL_Scanning objScanning;
        

        public frmScheduler()
        {
            InitializeComponent();
        }

        private void frmScheduler_Load(object sender, EventArgs e)
        {
            PL_File.servicePath = clsDb.GetGlobleDetails("SERVICE");
            ListBox1.Select();
            txtdbpath.Text = Application.StartupPath + "\\dbTracknTrace.mdb";
            lblate.Text = DateTime.Now.ToString();
            StartTer();
            StartSec();
            StartMapping();
            StartRejection();
        }

        public void StartTer()
        {
            objSchedule = new BL_Scheduler();
            objScanning = new BL_Scanning();
            DataTable dt=new DataTable();
            DataTable dtIn=new DataTable();
            DataTable dtOut=new DataTable();
            int i = 0;

            try
            {
                Timer1.Enabled = false;
                dt=objScanning.GetTerScanning();
                dtIn=objScanning.GetInward();
                dtOut=objScanning.GetOutward();

                if (dt.Rows.Count > 0)
                {
                    objSchedule.BLUpdateValidation(dt, "T");
                    i = objScanning.DeleteSyncData(dt, "T");
                }

                if (dtIn.Rows.Count > 0)
                {
                    objSchedule.BLUpdateInward(dtIn);
                    i = objScanning.DeleteSyncData(dtIn, "I");
                }

                if (dtOut.Rows.Count > 0)
                {
                    objSchedule.BLUpdateOutward(dtOut);
                    i = objScanning.DeleteSyncData(dtOut, "O");
                }

                Timer1.Enabled = true;
                ListBox1.Items.Add("Connecting :- Function Calling [Tertiary] :- Success " + DateTime.Now.ToString() + " Return Result : " + i);
            }
            catch (Exception ex)
            {

                ListBox1.Items.Add("Connecting :- Function Calling [Tertiary] :- Failed " + DateTime.Now.ToString() + " Return Result : " + i);
                ListBox1.Items.Add("Error Code : " + ex.ToString());
            }
            finally
            {
                objSchedule=null;objScanning=null;dt=null;
                dtIn=null;dtOut=null;
            }
        }

        public void StartSec()
        {
            objScanning = new BL_Scanning();
            objSchedule = new BL_Scheduler();
            DataTable dt;
            
            int i = 0;
            try
            {
                Timer1.Enabled = false;
                dt = new DataTable("temp");
                dt = objScanning.GetSecScanning();

                if (dt.Rows.Count > 0)
                {
                    try
                    {
                        objSchedule.BLUpdateValidation(dt, "S");
                        i = objScanning.DeleteSyncData(dt, "S");
                    }
                    catch
                    {
                        i = 1;
                    }
                }


                Timer1.Enabled = true;
                ListBox1.Items.Add("Connecting :- Function Calling [Secondary] :- Success " + DateTime.Now.ToString() + " Return Result : " + i);
            }
            catch (Exception ex)
            {
                ListBox1.Items.Add("Connecting :- Function Calling [Secondary] :- Failed " + DateTime.Now.ToString() + " Return Result : " + i);
                ListBox1.Items.Add("Error Code : " + ex.ToString());
            }
            finally
            {
                objSchedule = null; objScanning = null; dt = null;
            }
        }

        public void StartMapping()
        {
            objScanning = new BL_Scanning();
            objSchedule = new BL_Scheduler();
            DataTable dt = new DataTable();
            int i = 0;
            try
            {
                Timer1.Enabled = false;
                dt = objScanning.GetMapping();

                if (dt.Rows.Count > 0)
                {
                    objSchedule.BLUpdateMapping(dt);
                    i = objScanning.DeleteSyncData(dt, "M");
                }

                Timer1.Enabled = true;
                ListBox1.Items.Add("Connecting :- Function Calling [Mapping] :- Success " + DateTime.Now.ToString() + " Return Result : " + i);

            }
            catch (Exception ex)
            {
                ListBox1.Items.Add("Connecting :- Function Calling [Mapping] :- Failed " + DateTime.Now.ToString() + " Return Result : " + i);
                ListBox1.Items.Add("Error Code : " + ex.ToString());
            }
            finally
            {
                objSchedule = null; objScanning = null; dt = null;
            }
        }

        public void StartRejection()
        {
            objScanning = new BL_Scanning();
            objSchedule = new BL_Scheduler();
            DataTable dtSec = new DataTable();
            DataTable dtTer = new DataTable();

            int i = 0;
            try
            {
                Timer1.Enabled = false;
                dtSec = objScanning.GetSecReject();
                dtTer = objScanning.GetTerReject();

                if (dtSec.Rows.Count > 0)
                {
                    objSchedule.BLUpdateRejection(dtSec, "SR", PL_Login.PlantCode);
                    i = objScanning.DeleteSyncData(dtSec, "SR");
                }
                if (dtTer.Rows.Count > 0)
                {
                    objSchedule.BLUpdateRejection(dtTer, "TR", PL_Login.PlantCode);
                    i = objScanning.DeleteSyncData(dtTer, "TR");
                }

                Timer1.Enabled = true;
                ListBox1.Items.Add("Connecting :- Function Calling [Rejection] :- Success " + DateTime.Now.ToString() + " Return Result : " + i);

            }
            catch (Exception ex)
            {
                ListBox1.Items.Add("Connecting :- Function Calling [Rejection] :- Failed " + DateTime.Now.ToString() + " Return Result : " + i);
                ListBox1.Items.Add("Error Code : " + ex.ToString());
            }
            finally
            {
                objSchedule = null; objScanning = null; dtTer = null; dtSec = null;
            }
        }


        private void Timer2_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void ListBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show(ListBox1.SelectedItem.ToString());
        }

        private void frmScheduler_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                NotifyIcon1.Visible = true;
                this.Hide();
            }
        }

        private void ShowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void HideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                StartTer();
                StartSec();
                StartMapping();
            }
            catch (Exception ex)
            {

            }
        }





    }
}
