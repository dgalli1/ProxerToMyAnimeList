using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProxerToMyAnimeList
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void cb_directImport_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Enabled = !groupBox1.Enabled;
        }

        private void bn_export_Click(object sender, EventArgs e)
        {
            Proxer.getWatchlist(tb_proxerWatchlist.Text);
        }
    }
}
