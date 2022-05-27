using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataLayer;
using PC_Application.Cantral;
using BusinessLayer;
using PropertyLayer;

namespace PC_Application.Sync
{
    public partial class Master_Sync : Form
    {
        public Master_Sync()
        {
            InitializeComponent();
        }

        private void Master_Sync_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            lblLocal.Visible = false;
            lblCentral.Visible = false;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            lblLocal.Visible = true;
            lblCentral.Visible = true;

            bool local = false;
            bool Central = false;

            clsDb objData = new clsDb();
            try
            {
                objData.connect();
                lblLocal.Text = "Local Server : Connected";
                lblLocal.BackColor = Color.DarkGreen;
                local = true;
            }
            catch (Exception ex)
            {
                lblLocal.Text = "Local Server : Not Connected";
                lblLocal.BackColor = Color.Red;
                local = false;
            }
            finally
            {
                objData = null;
            }

            try
            {
                Service objLocal = new Service();
                objLocal.Url = clsGlobal.gstWebService;
                objLocal.Timeout = 60000;

                objLocal.HelloWorld();

                lblCentral.Text = "Central Server : Connected";
                lblCentral.BackColor = Color.DarkGreen;
                Central = true;
            }
            catch (Exception ex)
            {
                lblCentral.Text = "Central Server : Not Connected";
                lblCentral.BackColor = Color.Red;
                Central = false;
            }
            if (local == true && Central == true)
            {
                lstView.Visible = true;
                btnSync.Visible = true;
            }
            else
            {
                lstView.Visible = true;
                btnSync.Visible = true;
            }

        }

        private void btnSync_Click(object sender, EventArgs e)
        {


            foreach (ListViewItem lst in lstView.Items)
            {
                if (lst.Checked == true)
                {
                    Service objService = new Service();
                    BL_LogWriter objLog = new BL_LogWriter();
                    DataTable dt_Temp = new DataTable();
                    BL_Scheduler objSchedule = new BL_Scheduler();
                    try
                    {
                        objService.Url = clsGlobal.gstWebService;
                        objService.Timeout = 60000;
                        switch (lst.SubItems[0].Text)
                        {
                            case "Company Master":
                                dt_Temp = objService.STCCOMPANYMaster(clsGlobal.gstrPlantID);
                                objSchedule.Sync_Company_master(dt_Temp);
                                break;
                            case "Plant Master":
                                objSchedule.Sync_Plant_master(objService.STCPLANTMaster(clsGlobal.gstrPlantID));
                                break;
                            case "Line Master":
                                objSchedule.Sync_Line_master(objService.STCLINEMaster(clsGlobal.gstrPlantID));
                                break;
                            case "GTIN Master":
                                objSchedule.Sync_GTIN_master(objService.STCGTINMaster(clsGlobal.gstrPlantID));
                                break;
                            case "Consignee Master":
                                objSchedule.Sync_Consignee_master(objService.STCCONSIGNEEMaster(clsGlobal.gstrPlantID));
                                break;
                            case "Printer Master":
                                objSchedule.Sync_Printer_master(objService.STCPRINTERMaster(clsGlobal.gstrPlantID));
                                break;
                            case "Label Design Master":
                                objSchedule.Sync_LabelDesign_master(objService.STCLABEL_DESIGNMaster(clsGlobal.gstrPlantID));
                                break;
                        }
                        lst.SubItems[0].BackColor  = Color.Green;
                       
                    }
                    catch (Exception ex)
                    {
                       // lst.SubItems[1].Text = "Failed";
                        objLog.WriteErrorLog(this.Name.ToString(), "btnSync_Click", "Error", ex.Message.ToString(), "PC Client", PL_Login.UserID,PL_Login.PlantCode);
                    }
                    finally
                    {
                        objLog = null;
                        objService = null;
                    }
                }
            }
        }
    }
}
