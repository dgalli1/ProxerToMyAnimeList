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
            if(Proxer.getWatchlist(tb_proxerWatchlist.Text))
            {
                lb_status.Text=Proxer.list_animes.Count +" Animes wurden auf Proxer gefunden";
                if(groupBox1.Enabled)
                {//direct import

                    Proxer.authenticate(tb_username.Text, tb_password.Text);
                    Proxer.add();
                }
                else
                {//xmlExport not implemented
                    Proxer.authenticate("daYMAN007", "Openfimg12");
                }
            }
            else
            {
                lb_status.Text = "Error: Hast du die Richtige URL eingegeben und die Berechtigungen überprüft?";
            }
            
        }

        private void bn_delete_wholeList_Click(object sender, EventArgs e)
        {
            Proxer.authenticate(tb_username.Text, tb_password.Text);
            Proxer.RemoveAll();
        }
    }
}
