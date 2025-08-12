using PortalAPI;
using PortalAPI.EntityClass;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PortalTest
{
    public partial class FormScanConfig : Form
    {
        FormMain frmMain;
        public FormScanConfig(FormMain frmMain)
        {
            InitializeComponent();
            this.frmMain = frmMain;
        }

        private void FormScanConfig_Load(object sender, EventArgs e)
        {
            if (frmMain.gate.IsConnected)
                cbReaders.Items.Add(frmMain.gate.GateName);
            cbReaders.Text = frmMain.gate.GateName;
        }

        private void cbReaders_SelectedIndexChanged(object sender, EventArgs e)
        {
            string errStr;
            string rn = cbReaders.Items[cbReaders.SelectedIndex].ToString();

            cbProtocol1.Text = cbProtocol2.Text = frmMain.gate.ReaderProtocol.ToString();
            switch(frmMain.gate.ReaderProtocol)
            {
                case ProtocolVersion.CRP:
                    ckbUser1.Enabled = ckbUser2.Enabled = true;
                    numUserPtr1.Enabled = numUserPtr2.Enabled = true;
                    numUserLen1.Enabled = numUserLen1.Enabled = true;
                    groupBox3.Enabled = true;
                    groupBox5.Enabled = true;
                    ckbSelect1.Enabled = true;
                    ckbSelect2.Enabled = true;
                    break;
                case ProtocolVersion.LRP:
                    ckbUser1.Enabled = ckbUser2.Enabled = false;
                    numUserPtr1.Enabled = numUserPtr2.Enabled = false;
                    numUserLen1.Enabled = numUserLen1.Enabled = false;
                    groupBox3.Enabled = false;
                    groupBox5.Enabled = false;
                    ckbSelect1.Enabled = false;
                    ckbSelect2.Enabled = false;
                    break;
                case ProtocolVersion.RRP:
                    ckbUser1.Enabled = ckbUser2.Enabled = false;
                    numUserPtr1.Enabled = numUserPtr2.Enabled = false;
                    numUserLen1.Enabled = numUserLen1.Enabled = false;
                    groupBox3.Enabled = true;
                    groupBox5.Enabled = true;
                    ckbSelect1.Enabled = false;
                    ckbSelect2.Enabled = false;
                    break;
            }

            #region 查工作读写器
            byte[] param = frmMain.gate.Gate_GetWorkReader(out errStr);
            gbReader1.Enabled = ckbReader1.Checked = (param[1] == 0x01) ? true : false;
            gbReader2.Enabled = ckbReader2.Checked = (param[2] == 0x01) ? true : false;
            #endregion

            #region 查功率
            Dictionary<byte, Dictionary<byte, byte>> recv = frmMain.gate.Gate_GetPowerList(out errStr);
            foreach (byte key in recv.Keys)
            {
                switch (key)
                {
                    case 0x01:
                        {
                            if (recv[key].Count >= 1)
                                cbAnt11.Text = recv[key][1].ToString();
                            if (recv[key].Count >= 2)
                                cbAnt12.Text = recv[key][2].ToString();
                            if (recv[key].Count >= 3)
                                cbAnt13.Text = recv[key][3].ToString();
                            if (recv[key].Count >= 4)
                                cbAnt14.Text = recv[key][4].ToString();
                        }
                        break;
                    case 0x02:
                        {
                            if (recv[key].Count >= 1)
                                cbAnt21.Text = recv[key][1].ToString();
                            if (recv[key].Count >= 2)
                                cbAnt22.Text = recv[key][2].ToString();
                            if (recv[key].Count >= 3)
                                cbAnt23.Text = recv[key][3].ToString();
                            if (recv[key].Count >= 4)
                                cbAnt24.Text = recv[key][4].ToString();
                        }
                        break;
                }
            }
            #endregion

            #region 查询触发配置
            Log.Debug("查询触发配置");
            if (frmMain.gate.Reader1Enable)
            {                
                byte pt = 0x00;
                switch (frmMain.gate.ReaderProtocol)
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
                TriggerFrameParameter triggerParam = frmMain.gate.Gate_GetTriggerFrame(pt,out errStr);
                if (triggerParam != null && triggerParam.ScanParam != null)
                {                    
                    if ((triggerParam.ScanParam.Antenna & 0x01) > 0)
                        ckbAnt11.Checked = true;
                    if ((triggerParam.ScanParam.Antenna & 0x02) > 0)
                        ckbAnt12.Checked = true;
                    if ((triggerParam.ScanParam.Antenna & 0x04) > 0)
                        ckbAnt13.Checked = true;
                    if ((triggerParam.ScanParam.Antenna & 0x08) > 0)
                        ckbAnt14.Checked = true;
                    if (triggerParam.ScanParam.IsLoop)
                        rbLoop1.Checked = true;
                    else
                        rbSingle1.Checked = true;
                    if (triggerParam.ScanParam.TidParameter != null)
                    {
                        ckbTID1.Checked = true;
                        if (triggerParam.ScanParam.TidParameter.Length > 0)
                        {
                            numTidLen1.Value = (decimal)(triggerParam.ScanParam.TidParameter[1]);
                        }
                    }
                    else
                        ckbTID1.Checked = false;
                    if (triggerParam.ScanParam.UserDataParameter != null)
                    {
                        ckbUser1.Checked = true;
                        if (triggerParam.ScanParam.UserDataParameter.Length >= 3)
                        {
                            numUserPtr1.Value = (decimal)((triggerParam.ScanParam.UserDataParameter[0] << 8) + triggerParam.ScanParam.UserDataParameter[1]);
                            numUserLen1.Value = (decimal)(triggerParam.ScanParam.UserDataParameter[2]);
                        }
                    }
                    else
                        ckbUser1.Checked = false;
                    if (triggerParam.ScanParam.SelectTagParameter != null)
                    {
                        ckbSelect1.Checked = true;
                        if (triggerParam.ScanParam.SelectTagParameter.Length >= 4)
                        {
                            cbMB1.SelectedIndex = triggerParam.ScanParam.SelectTagParameter[0] - 1;
                            numPtr1.Value = (decimal)((triggerParam.ScanParam.SelectTagParameter[1] << 8) + triggerParam.ScanParam.SelectTagParameter[2]);
                            numlen1.Value = (decimal)(triggerParam.ScanParam.SelectTagParameter[3]);
                            byte[] d = new byte[triggerParam.ScanParam.SelectTagParameter.Length - 4];
                            txtData1.Text = Util.ConvertByteArrayToHexString(d);
                        }
                    }
                    else
                        ckbSelect1.Checked = false;

                }
                else
                {
                    // 默认参数
                    ckbAnt11.Checked = false;
                    ckbAnt12.Checked = false;
                    ckbAnt13.Checked = false;
                    ckbAnt14.Checked = false;
                    rbLoop1.Checked = true;
                    ckbTID1.Checked = false;
                    ckbUser1.Checked = false;
                    ckbSelect1.Checked = false;
                }

                byte[] tBuff = frmMain.gate.Gate_GetTriggerFrameBuff(pt,out errStr);
                textBox1.Text = PortalAPI.Util.ConvertByteArrayToHexString(tBuff);
            }

            if (frmMain.gate.Reader2Enable)
            {
                byte pt = 0x00;
                switch (frmMain.gate.ReaderProtocol)
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
                TriggerFrameParameter triggerParam = frmMain.gate.Gate_GetTriggerFrame(pt,out errStr);
                if (triggerParam != null &&triggerParam.ScanParam != null)
                {
                    if ((triggerParam.ScanParam.Antenna & 0x01) > 0)
                        ckbAnt21.Checked = true;
                    if ((triggerParam.ScanParam.Antenna & 0x02) > 0)
                        ckbAnt22.Checked = true;
                    if ((triggerParam.ScanParam.Antenna & 0x04) > 0)
                        ckbAnt23.Checked = true;
                    if ((triggerParam.ScanParam.Antenna & 0x08) > 0)
                        ckbAnt24.Checked = true;
                    if (triggerParam.ScanParam.IsLoop)
                        rbLoop2.Checked = true;
                    else
                        rbSingle2.Checked = true;
                    if (triggerParam.ScanParam.TidParameter != null)
                    {
                        ckbTID2.Checked = true;
                        if (triggerParam.ScanParam.TidParameter.Length > 0)
                        {
                            numTidLen2.Value = (decimal)(triggerParam.ScanParam.TidParameter[1]);
                        }
                    }
                    else
                        ckbTID2.Checked = false;
                    if (triggerParam.ScanParam.UserDataParameter != null)
                    {
                        ckbUser2.Checked = true;
                        if (triggerParam.ScanParam.UserDataParameter.Length >= 3)
                        {
                            numUserPtr2.Value = (decimal)((triggerParam.ScanParam.UserDataParameter[0] << 8) + triggerParam.ScanParam.UserDataParameter[1]);
                            numUserLen2.Value = (decimal)(triggerParam.ScanParam.UserDataParameter[2]);
                        }
                    }
                    else
                        ckbUser2.Checked = false;
                    if (triggerParam.ScanParam.SelectTagParameter != null)
                    {
                        ckbSelect2.Checked = true;
                        if (triggerParam.ScanParam.SelectTagParameter.Length >= 4)
                        {
                            cbMB2.SelectedIndex = triggerParam.ScanParam.SelectTagParameter[0] - 1;
                            numPtr2.Value = (decimal)((triggerParam.ScanParam.SelectTagParameter[1] << 8) + triggerParam.ScanParam.SelectTagParameter[2]);
                            numlen2.Value = (decimal)(triggerParam.ScanParam.SelectTagParameter[3]);
                            byte[] d = new byte[triggerParam.ScanParam.SelectTagParameter.Length - 4];
                            txtData2.Text = Util.ConvertByteArrayToHexString(d);
                        }
                    }
                    else
                        ckbSelect2.Checked = false;
                }
                else
                {
                    // 默认参数
                    ckbAnt21.Checked = false;
                    ckbAnt22.Checked = false;
                    ckbAnt23.Checked = false;
                    ckbAnt24.Checked = false;
                    rbLoop2.Checked = true;
                    ckbTID2.Checked = false;
                    ckbUser2.Checked = false;
                    ckbSelect2.Checked = false;
                }

                byte[] tBuff = frmMain.gate.Gate_GetTriggerFrameBuff(pt,out errStr);
                textBox2.Text = PortalAPI.Util.ConvertByteArrayToHexString(tBuff);
            }
            #endregion
        }

        private void ckbAnt_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox ckb = (CheckBox)sender;
            ComboBox cb = this.Controls.Find(ckb.Name.Replace("k", ""),true)[0] as ComboBox;
            cb.Enabled = ckb.Checked;
        }

        private void ckbTID_CheckedChanged(object sender, EventArgs e)
        {
            numTidLen1.Enabled = ckbTID1.Checked;
        }

        private void ckbUser_CheckedChanged(object sender, EventArgs e)
        {
            numUserPtr1.Enabled = numUserLen1.Enabled = ckbUser1.Checked;
        }

        private void ckbSelect_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox ckb = (CheckBox)sender;
            if (ckb.Name == "ckbSelect1")
                gbSelectParam1.Enabled = ckbSelect1.Checked;
            else
                gbSelectParam2.Enabled = ckbSelect2.Checked;
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            string rn = cbReaders.Items[cbReaders.SelectedIndex].ToString();
            string str = "";
            string errStr;

            #region 配置功率
            Dictionary<byte, Dictionary<byte, byte>> pl = new Dictionary<byte, Dictionary<byte, byte>>();
            if (gbAntReader1.Enabled)
            {
                Dictionary<byte, byte> subMsg = new Dictionary<byte, byte>();
                if (cbAnt11.SelectedIndex != -1)
                    subMsg.Add(0x01, (Byte)cbAnt11.SelectedIndex);
                if (cbAnt12.SelectedIndex != -1)
                    subMsg.Add(0x02, (Byte)cbAnt12.SelectedIndex);
                if (cbAnt13.SelectedIndex != -1)
                    subMsg.Add(0x03, (Byte)cbAnt13.SelectedIndex);
                if (cbAnt14.SelectedIndex != -1)
                    subMsg.Add(0x04, (Byte)cbAnt14.SelectedIndex);
                pl.Add(0x01, subMsg);
            }
            if (gbAntReader2.Enabled)
            {
                Dictionary<byte, byte> subMsg = new Dictionary<byte, byte>();
                if (cbAnt21.SelectedIndex != -1)
                    subMsg.Add(0x01, (Byte)cbAnt21.SelectedIndex);
                if (cbAnt22.SelectedIndex != -1)
                    subMsg.Add(0x02, (Byte)cbAnt22.SelectedIndex);
                if (cbAnt23.SelectedIndex != -1)
                    subMsg.Add(0x03, (Byte)cbAnt23.SelectedIndex);
                if (cbAnt24.SelectedIndex != -1)
                    subMsg.Add(0x04, (Byte)cbAnt24.SelectedIndex);
                pl.Add(0x02, subMsg);
            }
            if (frmMain.gate.Gate_SetPowerList(pl,out errStr))
                str += "功率设置成功。\r\n";
            else
                str+= "功率设置失败！\r\n";
            #endregion

            #region ScanTagParameter1
            ScanTagParameter scanParam1 = new ScanTagParameter();
            {
                #region 天线
                byte ant = 0x00;
                if (ckbAnt11.Checked)
                    ant += 0x01;
                if (ckbAnt12.Checked)
                    ant += 0x02;
                if (ckbAnt13.Checked)
                    ant += 0x04;
                if (ckbAnt14.Checked)
                    ant += 0x08;
                scanParam1.Antenna = ant;
                #endregion
                #region 扫描区域
                scanParam1.IsLoop = rbLoop1.Checked;

                if (ckbTID1.Checked)
                    scanParam1.TidParameter = new byte[] { 0x00, (byte)numTidLen1.Value };

                if (ckbUser1.Checked)
                    scanParam1.UserDataParameter = new byte[] { (byte)(((int)numUserPtr1.Value >> 8) & 0xff), (byte)((int)numUserPtr1.Value & 0xff), (byte)numUserLen1.Value };
                #endregion
                #region 标签选择
                if (ckbSelect1.Checked)
                {
                    byte[] selectData = Util.ConvertHexStringToByteArray(txtData1.Text.Trim());
                    int len = 4;
                    if (selectData != null)
                    {
                        len += selectData.Length;
                    }
                    scanParam1.SelectTagParameter = new byte[len];
                    scanParam1.SelectTagParameter[0] = (byte)(cbMB1.SelectedIndex + 1);
                    scanParam1.SelectTagParameter[1] = (byte)((int)(numPtr1.Value) >> 8);
                    scanParam1.SelectTagParameter[2] = (byte)((int)(numPtr1.Value) & 0xff);
                    scanParam1.SelectTagParameter[3] = (byte)numlen1.Value;
                    Array.Copy(selectData, 0, scanParam1.SelectTagParameter, 4, selectData.Length);
                }
                #endregion
            }
            #endregion

            #region ScanTagParameter2
            
            ScanTagParameter scanParam2 = new ScanTagParameter();
            {
                #region 天线
                byte ant = 0x00;
                if (ckbAnt21.Checked)
                    ant += 0x01;
                if (ckbAnt22.Checked)
                    ant += 0x02;
                if (ckbAnt23.Checked)
                    ant += 0x04;
                if (ckbAnt24.Checked)
                    ant += 0x08;
                scanParam2.Antenna = ant;
                #endregion
                #region 扫描区域
                scanParam2.IsLoop = rbLoop2.Checked;

                if (ckbTID2.Checked)
                    scanParam2.TidParameter = new byte[] { 0x00, (byte)numTidLen2.Value };

                if (ckbUser2.Checked)
                    scanParam2.UserDataParameter = new byte[] { (byte)(((int)numUserPtr2.Value >> 8) & 0xff), (byte)((int)numUserPtr2.Value & 0xff), (byte)numUserLen2.Value };
                #endregion
                #region 标签选择
                if (ckbSelect2.Checked)
                {
                    byte[] selectData = Util.ConvertHexStringToByteArray(txtData2.Text.Trim());
                    int len = 4;
                    if (selectData != null)
                    {
                        len += selectData.Length;
                    }
                    scanParam2.SelectTagParameter = new byte[len];
                    scanParam2.SelectTagParameter[0] = (byte)(cbMB2.SelectedIndex + 1);
                    scanParam2.SelectTagParameter[1] = (byte)((int)(numPtr2.Value) >> 8);
                    scanParam2.SelectTagParameter[2] = (byte)((int)(numPtr2.Value) & 0xff);
                    scanParam2.SelectTagParameter[3] = (byte)numlen2.Value;
                    Array.Copy(selectData, 0, scanParam2.SelectTagParameter, 4, selectData.Length);
                }
                #endregion
            }
            #endregion

            #region 配置读写器工作
            byte[] param = new byte[11];
            //param[0] = (byte)((rbWorkReaderLoop.Checked) ? 1 : 0);
            param[1] = (byte)((ckbReader1.Checked) ? 1 : 0);
            param[2] = (byte)((ckbReader2.Checked) ? 1 : 0);
            if (frmMain.gate.ReaderProtocol == ProtocolVersion.LRP)
            {
                param[3] = (byte)((ckbAnt11.Checked) ? 0xff : 0x01);
                param[4] = (byte)((ckbAnt12.Checked) ? 0xff : 0x01);
                param[5] = (byte)((ckbAnt13.Checked) ? 0xff : 0x01);
                param[6] = (byte)((ckbAnt14.Checked) ? 0xff : 0x01);
                param[7] = (byte)((ckbAnt21.Checked) ? 0xff : 0x01);
                param[8] = (byte)((ckbAnt22.Checked) ? 0xff : 0x01);
                param[9] = (byte)((ckbAnt23.Checked) ? 0xff : 0x01);
                param[10] = (byte)((ckbAnt24.Checked) ? 0xff : 0x01);
            }
            if (frmMain.gate.Gate_SetWorkReader(param,out errStr))
            {
                frmMain.gate.Reader1Enable = ckbReader1.Checked;
                frmMain.gate.Reader2Enable = ckbReader2.Checked;
                str += "读写器工作模式设置成功。\r\n";
            }
            else
                str += "读写器工作模式设置失败！\r\n";
            #endregion

            #region 配置触发消息           

            if (frmMain.gate.Reader1Enable)
            {
                TriggerFrameParameter triggerParam = new TriggerFrameParameter();
                triggerParam.Protocol = frmMain.gate.ReaderProtocol;
                triggerParam.ScanParam = scanParam1;
                triggerParam.Address = 0x01;
                if (frmMain.gate.Gate_SetTriggerFrame(triggerParam,out errStr))
                    str += "读写器1触发协议设置成功。\r\n";
                else
                    str += "读写器1触发协议设置失败！\r\n";
                  
            }
            if (frmMain.gate.Reader2Enable)
            {
                TriggerFrameParameter triggerParam = new TriggerFrameParameter();
                triggerParam.Protocol = frmMain.gate.ReaderProtocol;
                triggerParam.ScanParam = scanParam2;
                triggerParam.Address = 0x02;
                if (frmMain.gate.Gate_SetTriggerFrame(triggerParam,out errStr))
                    str += "读写器2触发协议设置成功。\r\n";
                else
                    str += "读写器2触发协议设置失败！\r\n";
            }
            #endregion

            MessageBox.Show("配置完成。\r\n" + str);

            #region 天线联动            
            frmMain.dataGridView1.Columns["ANT1"].Visible = ckbAnt11.Checked;
            frmMain.dataGridView1.Columns["ANT2"].Visible = ckbAnt12.Checked;
            frmMain.dataGridView1.Columns["ANT3"].Visible = ckbAnt13.Checked;
            frmMain.dataGridView1.Columns["ANT4"].Visible = ckbAnt14.Checked;

            frmMain.dataGridView1.Columns["ANT5"].Visible = ckbAnt21.Checked;
            frmMain.dataGridView1.Columns["ANT6"].Visible = ckbAnt22.Checked;
            frmMain.dataGridView1.Columns["ANT7"].Visible = ckbAnt23.Checked;
            frmMain.dataGridView1.Columns["ANT8"].Visible = ckbAnt24.Checked;
            #endregion
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbMB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMB1.Items[cbMB1.SelectedIndex].ToString() == "EPC")
                numPtr1.Value = 0x20;
            else
                numPtr1.Value = 0x00;
        }

        private void ckbReader1_CheckedChanged(object sender, EventArgs e)
        {
            string errStr;
            gbReader1.Enabled = ckbReader1.Checked;
            if (ckbReader1.Checked)
            {
                string rn = cbReaders.Items[cbReaders.SelectedIndex].ToString();
                #region 查功率
                Dictionary<byte, Dictionary<byte, byte>> recv = frmMain.gate.Gate_GetPowerList(out errStr);
                foreach (byte key in recv.Keys)
                {
                    switch (key)
                    {
                        case 0x01:
                            {
                                if (recv[key].Count >= 1)
                                    cbAnt11.Text = recv[key][1].ToString();
                                if (recv[key].Count >= 2)
                                    cbAnt12.Text = recv[key][2].ToString();
                                if (recv[key].Count >= 3)
                                    cbAnt13.Text = recv[key][3].ToString();
                                if (recv[key].Count >= 4)
                                    cbAnt14.Text = recv[key][4].ToString();
                            }
                            break;
                        case 0x02:
                            {
                                if (recv[key].Count >= 1)
                                    cbAnt21.Text = recv[key][1].ToString();
                                if (recv[key].Count >= 2)
                                    cbAnt22.Text = recv[key][2].ToString();
                                if (recv[key].Count >= 3)
                                    cbAnt23.Text = recv[key][3].ToString();
                                if (recv[key].Count >= 4)
                                    cbAnt24.Text = recv[key][4].ToString();
                            }
                            break;
                    }
                }
                #endregion
            }
        }

        private void ckbReader2_CheckedChanged(object sender, EventArgs e)
        {
            string errStr;
            gbReader2.Enabled = ckbReader2.Checked;
            if (ckbReader2.Checked)
            {
                string rn = cbReaders.Items[cbReaders.SelectedIndex].ToString();
                #region 查功率
                Dictionary<byte, Dictionary<byte, byte>> recv = frmMain.gate.Gate_GetPowerList(out errStr);
                foreach (byte key in recv.Keys)
                {
                    switch (key)
                    {
                        case 0x01:
                            {
                                if (recv[key].Count >= 1)
                                    cbAnt11.Text = recv[key][1].ToString();
                                if (recv[key].Count >= 2)
                                    cbAnt12.Text = recv[key][2].ToString();
                                if (recv[key].Count >= 3)
                                    cbAnt13.Text = recv[key][3].ToString();
                                if (recv[key].Count >= 4)
                                    cbAnt14.Text = recv[key][4].ToString();
                            }
                            break;
                        case 0x02:
                            {
                                if (recv[key].Count >= 1)
                                    cbAnt21.Text = recv[key][1].ToString();
                                if (recv[key].Count >= 2)
                                    cbAnt22.Text = recv[key][2].ToString();
                                if (recv[key].Count >= 3)
                                    cbAnt23.Text = recv[key][3].ToString();
                                if (recv[key].Count >= 4)
                                    cbAnt24.Text = recv[key][4].ToString();
                            }
                            break;
                    }
                }
                #endregion
            }
        }
    }
}
