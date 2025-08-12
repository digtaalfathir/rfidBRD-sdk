using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace PortalTest
{
    public partial class FormConn : Form
    {
        XmlDocument xmlDoc = new XmlDocument();
        XmlNode root = null;
        string fileName = PortalAPI.APIPath.folderName + "\\PortalConfigFile.xml";
        public FormConn()
        {
            InitializeComponent();
            xmlDoc.Load(fileName);
            root = xmlDoc.DocumentElement;
        }

        private void FormConn_Load(object sender, EventArgs e)
        {
            // 加载串口
            string[] comPorts = System.IO.Ports.SerialPort.GetPortNames();
            foreach (string s in comPorts)
            {
                cbPort.Items.Add(s);
            }

            // 读取配置文件
            XmlNode node = root.SelectSingleNode("Client[@Name='Portal1']//Port");
            if (node.Attributes["Type"].Value == "RS232")
            {
                rbCom.Checked = true;
                string[] sAry = node.InnerText.Split(',');
                cbPort.Text = sAry[0];
                cbBaud.Text = sAry[1];
            }
            else
            {
                rbTcp.Checked = true;
                string[] sAry = node.InnerText.Split(':');
                txtIp.Text = sAry[0];
                numPort.Value = int.Parse(sAry[1]);
            }
        }

        private void btnConn_Click(object sender, EventArgs e)
        {
            saveConfig();
            this.DialogResult = DialogResult.OK;
        }

        private void saveConfig()
        {
            XmlNode node = root.SelectSingleNode("Client[@Name='Portal1']//Port");
            if (rbCom.Checked)
            {
                node.Attributes["Type"].Value = "RS232";
                node.InnerText = cbPort.Text + "," + cbBaud.Text;
            }
            else
            {
                node.Attributes["Type"].Value = "TcpClient";
                node.InnerText = txtIp.Text + ":" + numPort.Value;
            }
            xmlDoc.Save(fileName);
        }

        private void btnDisconn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbPortType_CheckedChanged(object sender, EventArgs e)
        {
            gbTcp.Enabled = rbTcp.Checked;
            gbCom.Enabled = rbCom.Checked;
        }
    }
}
