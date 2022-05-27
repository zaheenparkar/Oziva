using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BCIL.Socket.Client;
using System.Net;
using System.Threading;
using MicroScanTest;
using PropertyLayer;

namespace PC_Application.Scanning
{
    public partial class frmMicroscan : Form
    {
        public frmMicroscan()
        {
            InitializeComponent();
        }

        MicroScan _MicroScan;
        delegate void dlgMsScan(string Barcode, SocketService Client);

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

            GenerateClient(0);
            Application.DoEvents();

            if (!backgroundWorker2.IsBusy)
            {
                backgroundWorker2.RunWorkerAsync();
            }

            timer1.Enabled = true;
            timer2.Enabled = true;
        }

        //private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    //MessageBox.Show("01");
        //    clsNetwork objcls = new clsNetwork();
        //    try
        //    {
        //        clsNetwork.InitializeTCPClient(IPAddress.Parse(textBox2.Text.Trim()), int.Parse(textBox4.Text.Trim()));
        //        string strBarcode = clsNetwork.ReceiveDataFromServer();

        //        if (strBarcode.Trim() != string.Empty)
        //        {
        //            if (strBarcode.Trim() != "NOREAD*")
        //            {
        //                strBarcode = strBarcode.Replace("*", "").Trim();
        //                SaveBarcode(strBarcode);
        //            }
        //            else
        //            {
        //                lblFail.Text = (Convert.ToInt32(lblFail.Text) + 1).ToString();
        //                ListViewItem lstitem = new ListViewItem(strBarcode.Replace("*", ""));
        //                listView1.Items.Add(lstitem).BackColor = Color.Red;
        //            }
        //        }
        //    }
        //    catch (Exception ex){}
        //    finally
        //    {
        //        label16.Text = "Total Count = " + listView1.Items.Count.ToString();
        //        listView1.Items[listView1.Items.Count - 1].EnsureVisible();
        //        clsNetwork.TerminateTCPClient();
        //        objcls = null;
        //    }
        //}

        void GenerateClient(Int32 Row)
        {
            try
            {
                // Array.Resize<MicroScan>(ref _MicroScan, Row);
                _MicroScan = new MicroScan(textBox2.Text.Trim(), int.Parse(textBox4.Text.Trim()));
                _MicroScan.OnDataReceive += new MicroScan.delDataRecevie(frmFMScanning_OnDataReceive);
                //btnStop.Enabled = true;
                // btnExit.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        void frmFMScanning_OnDataReceive(SocketService Client, string barcode)
        {
            try
            {
                MsScan(barcode, Client);
            }
            catch (Exception ex)
            {
                // ClsGlobalClass.AppLog.LogMessage(BcilLib.EventNotice.EventTypes.evtError, "(FMScanning)(frmFMScanning_OnDataReceive):: " + Client.Config.RemoteIP + "," + barcode, ex.Message);
            }
        }

        void MsScan(string Barcode, SocketService Client)
        {
            string _sReturn = "";
            try
            {
                if (this.InvokeRequired)
                    this.Invoke(new dlgMsScan(MsScan), Barcode, Client);
                else
                {
                    if (Client.Config.RemoteIP.ToString() == textBox2.Text.Trim())
                    {
                        string[] str = Barcode.Split('*');
                        for (int i = 0; i <= str.Count() - 1; i++)
                        {
                            SaveBarcode(str[i].ToString() + "*");
                        }

                    }
                    #region BlockCode

                    //for (int i = 0; i < dgvFMScanningMaster.RowCount; i++)
                    //{
                    //    if (Client.Config.RemoteIP.ToString()=="192.168.1.10")
                    //    {
                    //        if (Barcode == "NOREAD")
                    //        {
                    //            #region Commented
                    //            //dgvFMScanningMaster.Rows[i].Cells[12].Value = Barcode;
                    //            //dgvFMScanningMaster.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.Red; 
                    //            #endregion
                    //            Client.Send("<L1>");
                    //            return;
                    //        }
                    //        if (_HtLegacyCheck.ContainsKey(dgvFMScanningMaster.Rows[i].Cells[7].Value.ToString()) == false)
                    //        {
                    //            if (_SecPack.CheckInLegecyMaster(dgvFMScanningMaster.Rows[i].Cells[7].Value.ToString()) == true)
                    //                _HtLegacyCheck.Add(dgvFMScanningMaster.Rows[i].Cells[7].Value.ToString(), dgvFMScanningMaster.Rows[i].Cells[7].Value.ToString());
                    //            else
                    //            {
                    //                MessageBox.Show("Please define lot in legacy Master", "Information");
                    //                return;
                    //            }
                    //        }

                    //        //***************************************************************************
                    //        //***************************************************************************
                    //        //Auto lot selection after complet the pack size

                    //        //----------Modified By:Naveen Kumar------------------//

                    //        string[] _check = Barcode.Split('/');

                    //        if (_check.Length == 6 || _check.Length == 3)
                    //        {
                    //            DataTable _dtNewAssign = _SecPack._CheckPackSize(dgvFMScanningMaster.Rows[i].Cells[7].Value.ToString());
                    //            if (_dtNewAssign.Rows.Count > 0)
                    //            {
                    //                if (_check.Length == 3)
                    //                {


                    //                    string dot = _dtNewAssign.Rows[0]["DOT"].ToString();
                    //                    string dop = _dtNewAssign.Rows[0]["DOP"].ToString();
                    //                    string ValidUpto = _dtNewAssign.Rows[0]["ValidUpto"].ToString();
                    //                    if (string.IsNullOrEmpty(dot) || string.IsNullOrEmpty(dop) || string.IsNullOrEmpty(ValidUpto))
                    //                    {
                    //                        MessageBox.Show("Please check DOT/DOP/VALIDUPTO in PackageMaster", "Information");
                    //                        return;

                    //                    }


                    //                    Barcode += "/" + dot + "/" + dop + "/" + ValidUpto;


                    //                }

                    //                if (_dtNewAssign.Rows[0]["LotStatus"].ToString() == "1")
                    //                {
                    //                    string _sAssignLot = Barcode.Split('/')[1].Trim();
                    //                    _dtNewAssign = null;
                    //                    _dtNewAssign = _SecPack._CheckPackSize(_sAssignLot);
                    //                    if (_dtNewAssign.Rows.Count > 0)
                    //                    {
                    //                        if (_dtNewAssign.Rows[0]["LotStatus"].ToString() != "1")
                    //                        {
                    //                            string _sRet = "";
                    //                            if (_SecPack.IsLotRunningInLine(_sAssignLot.Trim()) == false)
                    //                            {
                    //                                dgvFMScanningMaster.Rows[i].Cells[12].Value = "Lot already running@12";
                    //                                dgvFMScanningMaster.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.Pink;
                    //                                Client.Send("<L1>");
                    //                                return;
                    //                            }
                    //                            _sRet = _SecPack.EditLot(dgvFMScanningMaster.Rows[i].Cells[5].Value.ToString().Trim(), _sAssignLot.Trim()
                    //                                                           , _dtNewAssign.Rows[0]["LotQuantity"].ToString().Trim()
                    //                                                           , _dtNewAssign.Rows[0]["PackSize"].ToString().Trim()
                    //                                                           , ClsGlobalClass.PlantCode
                    //                                                           , ClsGlobalClass.UserId
                    //                                                           , dgvFMScanningMaster.Rows[i].Cells[9].Value.ToString().Trim()
                    //                                                           , dgvFMScanningMaster.Rows[i].Cells[2].Value.ToString().Trim()
                    //                                                           , dgvFMScanningMaster.Rows[i].Cells[3].Value.ToString().Trim()
                    //                                                           );


                    //                            if (_sRet == "1")
                    //                            {
                    //                                dgvFMScanningMaster.Rows[i].Cells[6].Value = _dtNewAssign.Rows[0]["LotQuantity"].ToString();
                    //                                dgvFMScanningMaster.Rows[i].Cells[7].Value = _sAssignLot.Trim();
                    //                                dgvFMScanningMaster.Rows[i].Cells[8].Value = _dtNewAssign.Rows[0]["PackSize"].ToString();
                    //                                dgvFMScanningMaster.Rows[i].Cells[14].Value = _dtNewAssign.Rows[0]["LotQuantity"].ToString() + "/" + _dtNewAssign.Rows[0]["ScanQuantity"].ToString();
                    //                                Application.DoEvents();
                    //                            }
                    //                            if (_sRet == "-5")
                    //                            {
                    //                                dgvFMScanningMaster.Rows[i].Cells[12].Value = "Lot already completed@3";
                    //                                dgvFMScanningMaster.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.Pink;
                    //                                Client.Send("<L1>");
                    //                                return;
                    //                            }
                    //                        }
                    //                    }

                    //                }
                    //            }
                    //            //***************************************************************************
                    //            //***************************************************************************
                    //            _sReturn = _SecPack.ScanData(Client.Config.RemoteIP.ToString()
                    //                                        , dgvFMScanningMaster.Rows[i].Cells[10].Value.ToString()
                    //                                        , Barcode
                    //                                        , ClsGlobalClass.UserId
                    //                                        , dgvFMScanningMaster.Rows[i].Cells[14].Value.ToString()
                    //                                        , dgvFMScanningMaster.Rows[i].Cells[7].Value.ToString()
                    //                                        , dgvFMScanningMaster.Rows[i].Cells[8].Value.ToString()
                    //                                        , dgvFMScanningMaster.Rows[i].Cells[6].Value.ToString()
                    //                                        , dgvFMScanningMaster.Rows[i].Cells[5].Value.ToString()
                    //                                        );
                    //            string[] _Arr = _sReturn.Split('|');
                    //            if (_Arr.Length > 1)
                    //            {
                    //                if (_Arr[0].ToString() == "Y")
                    //                {
                    //                    dgvFMScanningMaster.Rows[i].Cells[12].Value = Barcode;
                    //                    dgvFMScanningMaster.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.YellowGreen;
                    //                    dgvFMScanningMaster.Rows[i].Cells[14].Value = dgvFMScanningMaster.Rows[i].Cells[6].Value + "/" + _Arr[1];
                    //                }
                    //                else
                    //                {
                    //                    dgvFMScanningMaster.Rows[i].Cells[12].Value = _Arr[1].ToString();
                    //                    dgvFMScanningMaster.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.Pink;
                    //                    Client.Send("<L1>");
                    //                    return;
                    //                }
                    //            }
                    //            else
                    //            {
                    //                dgvFMScanningMaster.Rows[i].Cells[12].Value = Barcode;
                    //                //dgvFMScanningMaster.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.Red;
                    //                Client.Send("<L1>");
                    //                return;
                    //            }
                    //            break;
                    //        }
                    //        else
                    //        {
                    //            MessageBox.Show("Invalid Packet", "Information");
                    //            return;


                    //        }
                    //    }

                    //}
                    #endregion Block
                }
            }
            catch (Exception ex)
            {
                // ClsGlobalClass.AppLog.LogMessage(BcilLib.EventNotice.EventTypes.evtError, "(FMScanning)(ShowData1):: " + Client.Config.RemoteIP + "," + _sReturn + "," + Barcode, ex.Message);
                throw;
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

        private void frmMicroscan_FormClosing(object sender, FormClosingEventArgs e)
        {
            Close();
            Dispose();
        }
    }
}
