using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PortalTest
{
    public partial class FormPortalConfig : Form
    {
        FormMain frmMain;

        public FormPortalConfig(FormMain frmMain)
        {
            InitializeComponent();
            this.frmMain = frmMain;
        }

        private void btnIrQuery_Click(object sender, EventArgs e)
        {
            string errStr;
            numIrTime.Value = frmMain.gate.Gate_GetIrDelay(out errStr);
            if (!string.IsNullOrEmpty(errStr))
            {
                MessageBox.Show(errStr);
            }
        }

        private void btnIrConfig_Click(object sender, EventArgs e)
        {
            string errStr;
            if (frmMain.gate.Gate_SetIrDelay((byte)numIrTime.Value, out errStr))
                MessageBox.Show("设置成功");
            else
                MessageBox.Show("设置失败:" + errStr);
        }
    }
}
