using PortalAPI;
using PortalAPI.EntityClass;
using System;
using System.Data;
using System.Windows.Forms;

namespace PortalTest
{
    public partial class FormMain : Form
    {
        #region 字段
        public CommonGate gate = null;
        volatile bool isTriggerScan = false;
        object LockRxdTagData = new object();
        DataTable mDt = null;
        DateTime dateTime;
        public volatile UInt32 totalCount;
        public volatile UInt32 lastCount;
        public System.Timers.Timer myStatTimer = new System.Timers.Timer(1000);
        #endregion

        #region 窗体函数
        public FormMain()
        {
            InitializeComponent();
            initTagDataTable();
            myStatTimer.Elapsed += new System.Timers.ElapsedEventHandler(myStatTimer_Elapsed);
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btnDisconn.Enabled)
                btnDisconn_Click(null, EventArgs.Empty);
            Environment.Exit(Environment.ExitCode);
        }
        #endregion

        #region 菜单、按钮
        private void MI_Conn_Click(object sender, EventArgs e)
        {
            FormConn frm = new FormConn();
            if (frm.ShowDialog() == DialogResult.OK)
                btnConn_Click(null, EventArgs.Empty);
        }

        private void MI_ScanConfig_Click(object sender, EventArgs e)
        {
            FormScanConfig frm = new FormScanConfig(this);
            frm.ShowDialog();
        }

        private void MI_PortalConfig_Click(object sender, EventArgs e)
        {
            FormPortalConfig frm = new FormPortalConfig(this);
            frm.ShowDialog();
        }

        private void btnConn_Click(object sender, EventArgs e)
        {            
            bool isSuc = false;
            gate = new CommonGate("Portal1");
            if (gate.Connect())
            {
                isSuc = true;
                // TODO: 添加事件
                gate.OnTagDataReceived += Gate_OnTagDataReceived;
                gate.OnTriggerRxdDataState += Gate_OnTriggerRxdDataState;
                setText(lblMsg, "连接成功！");
            }
            else
                setText(lblMsg, "连接失败！");

            if (isSuc)
                changeState(demoState.Connected);
        }

        private void btnDisconn_Click(object sender, EventArgs e)
        {            
            gate.Disconnect();
            // 删除事件
            gate.OnTagDataReceived -= Gate_OnTagDataReceived;
            gate.OnTriggerRxdDataState -= Gate_OnTriggerRxdDataState;

            changeState(demoState.Disconnected);
            setText(lblMsg, "断开连接");
            gate = null;
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            bool isSuc = false;
            cleanDisplay();            
            this.dateTime = DateTime.Now;
            myStatTimer.Start();

            totalCount = 0;
            if (!isTriggerScan)
            {
                isSuc = scan(gate);
            }
            else
                isSuc = true;
            if (isSuc)
            {
                changeState(demoState.Scaning);
                setText(lblMsg, "正在扫描...");
            }
        }

        private bool scan(CommonGate gate)
        {
            string errStr;
            bool isSuc = false;
            if (gate.Reader1Enable)
            {
                byte pt = 0x00;
                switch (gate.ReaderProtocol)
                {
                    case ProtocolVersion.CRP:
                        pt = 0x01;
                        break;
                    case ProtocolVersion.LRP:
                        pt = 0x03;
                        break;
                    case ProtocolVersion.RRP:
                        pt = 0x05;
                        break;
                }
                TriggerFrameParameter p = gate.Gate_GetTriggerFrame(pt,out errStr);
                if (gate.Gate_Inventory(p.ScanParam, 0x01,out errStr))
                    isSuc = true;
            }
            if (gate.Reader2Enable)
            {
                byte pt = 0x00;
                switch (gate.ReaderProtocol)
                {
                    case ProtocolVersion.CRP:
                        pt = 0x02;
                        break;
                    case ProtocolVersion.LRP:
                        pt = 0x04;
                        break;
                    case ProtocolVersion.RRP:
                        pt = 0x06;
                        break;
                }
                TriggerFrameParameter p = gate.Gate_GetTriggerFrame(pt,out errStr);
                if (gate.Gate_Inventory(p.ScanParam, 0x02,out errStr))
                    isSuc = true;
            }
            return isSuc;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            string errStr;
            this.BeginInvoke((MethodInvoker)delegate
            {
                bool isSuc = false;
                if (!isTriggerScan)
                {
                    if (gate.Gate_StopInventory(out errStr))
                        isSuc = true;
                }
                else
                    isSuc = true;
                myStatTimer.Stop();// 停止计时                
                if (isSuc)
                {
                    changeState(demoState.Stop);
                    setText(lblMsg, "扫描停止！");
                }
            });
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            cleanDisplay();
            setText(lblAvgSpeed, "000");
            setText(lblScanTime, "00:00:00");
            setText(lblSpeed, "000");
            setText(lblTotal, "000");
            totalCount = 0;
            lastCount = 0;
            dateTime = DateTime.Now;
        }

        void myStatTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            TimeSpan ts = new TimeSpan();
            ts = DateTime.Now.Subtract(this.dateTime);
            string rtime = String.Format("{0}:{1}:{2}",
                (ts.Days * 24 + ts.Hours).ToString().PadLeft(2, '0'),
                ts.Minutes.ToString().PadLeft(2, '0'),
                ts.Seconds.ToString().PadLeft(2, '0'));
            setText(this.lblScanTime, rtime);

            string aSpeed = "0";
            if (totalCount > 0)
            {
                aSpeed = String.Format("{0:D}", (totalCount * 1000 / (int)ts.TotalMilliseconds));
                setText(this.lblAvgSpeed, aSpeed.PadLeft(3, '0'));
            }

            int speed = (int)(totalCount - lastCount);
            if (speed < 0)
                speed = (int)totalCount;
            string speedStr = String.Format("{0:D}", speed);
            setText(this.lblSpeed, speedStr.PadLeft(3, '0'));
            string tCount = mDt.Rows.Count.ToString();
            setText(lblTotal, tCount.PadLeft(3, '0'));
            lastCount = totalCount;
        }

        private void setText(Label ctrl, string txt)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                ctrl.Text = txt;
            });
        }
        #endregion

        #region 接收事件
        private void Gate_OnTriggerRxdDataState(string readerName, PortalAPI.EntityClass.Gate_TriggerRxdDataStateParameter state)
        {            
            isTriggerScan = true;
            if (state.IsStart)
                btnScan_Click(null, EventArgs.Empty);
            else 
                btnStop_Click(null, EventArgs.Empty);
            isTriggerScan = false;
        }

        private void Gate_OnTagDataReceived(string readerName, PortalAPI.EntityClass.RxdTagData tagData)
        {
            if (tagData != null)
                display(readerName, tagData);
        }

        private void display(string readerName, RxdTagData tagData)
        {
            dataGridView1.BeginInvoke((MethodInvoker)delegate
            {
                //计算读取速度
                this.totalCount++; 
                bool isAdd = true;
                byte antenna = tagData.Antenna;
                string epc = Util.ConvertByteArrayToHexWordString(tagData.EPC);
                string tid = Util.ConvertByteArrayToHexWordString(tagData.TID);
                string user = Util.ConvertByteArrayToHexWordString(tagData.UserData);
                string rssi = tagData.RSSI.ToString();
                string time = DateTime.Now.ToString("HH:mm:ss.fff");            
                
                lock (LockRxdTagData)
                {
                    if (mDt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in mDt.Rows)
                        {
                            if (dr["Portal"].ToString() == readerName
                                    && dr["EPC"].ToString() == epc
                                    && dr["TID"].ToString() == tid
                                    && dr["UserData"].ToString() == user)
                                isAdd = false;

                            if (!isAdd)
                            {
                                dr["ReadCount"] = int.Parse(dr["ReadCount"].ToString()) + 1;
                                dr[3 + antenna] = int.Parse(dr[3 + antenna].ToString()) + 1;
                                dr["RSSI"] = rssi;
                                dr["TimeStamp"] = time;
                                break;
                            }
                        }
                    }
                    if (isAdd)
                    {
                        DataRow mydr = mDt.NewRow();
                        mydr[0] = epc;
                        mydr[1] = tid;
                        mydr[2] = user;
                        mydr[3] = "1";
                        mydr[4] = "0";
                        mydr[5] = "0";
                        mydr[6] = "0";
                        mydr[7] = "0";
                        mydr[8] = "0";
                        mydr[9] = "0";
                        mydr[10] = "0";
                        mydr[11] = "0";
                        mydr[3 + antenna] = "1";
                        mydr[12] = rssi;
                        mydr[13] = readerName;
                        mydr[14] = time;
                        mDt.Rows.Add(mydr);                        
                    }
                }                
            });
        }
        #endregion

        #region 软件状态改变
        private void changeState(demoState state)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                switch (state)
                {
                    case demoState.Connected:
                    case demoState.Stop:
                        btnConn.Enabled = false;
                        btnDisconn.Enabled = true;                        
                        btnScan.Enabled = true;
                        btnStop.Enabled = true;                        

                        MI_Conn.Enabled = true;
                        MI_ScanConfig.Enabled = true;
                        MI_PortalConfig.Enabled = true;
                        break;
                    case demoState.Disconnected:
                        btnConn.Enabled = true;
                        btnDisconn.Enabled = false;
                        btnScan.Enabled = false;
                        btnStop.Enabled = false;

                        MI_Conn.Enabled = true;
                        MI_ScanConfig.Enabled = false;
                        MI_PortalConfig.Enabled = false;
                        break;
                    case demoState.Scaning:
                        btnConn.Enabled = false;
                        btnDisconn.Enabled = true;
                        btnScan.Enabled = false;
                        btnStop.Enabled = true;

                        MI_Conn.Enabled = false;
                        MI_ScanConfig.Enabled = false;
                        MI_PortalConfig.Enabled = false;
                        break;
                }
            });
        }

        private enum demoState
        {
            Connected,
            Disconnected,
            Scaning,
            Stop
        }
        #endregion

        #region 清空数据
        private void cleanDisplay()
        {
            dataGridView1.BeginInvoke((MethodInvoker)delegate
            {
                lock (LockRxdTagData)
                {
                    mDt.Rows.Clear();
                }
            });
        }
        #endregion

        #region 绑定数据表
        private void initTagDataTable()
        {
            if (this.InvokeRequired)
                this.BeginInvoke(new MethodInvoker(initTagDataTableMethod));
            else
                initTagDataTableMethod();
        }

        private void initTagDataTableMethod()
        {
            mDt = new DataTable();
            mDt.Columns.Add("EPC");
            mDt.Columns.Add("TID");
            mDt.Columns.Add("UserData");
            mDt.Columns.Add("ReadCount");
            mDt.Columns.Add("ANT1");
            mDt.Columns.Add("ANT2");
            mDt.Columns.Add("ANT3");
            mDt.Columns.Add("ANT4");
            mDt.Columns.Add("ANT5");
            mDt.Columns.Add("ANT6");
            mDt.Columns.Add("ANT7");
            mDt.Columns.Add("ANT8");
            mDt.Columns.Add("RSSI");
            mDt.Columns.Add("Portal");
            mDt.Columns.Add("TimeStamp");            
            this.dataGridView1.DataSource = mDt;
        }
        #endregion
    }
}
