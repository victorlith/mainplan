using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Drawing;

namespace Cockpit_Menplan
{
    public partial class TelaPrincipal : Form
    {
        NotifyIcon notify = new NotifyIcon();

        public TelaPrincipal()
        {
            InitializeComponent();
        }

        private void timerCockpit_Tick(object sender, EventArgs e)
        {
            lbHoraAtual.Text = DateTime.Now.ToString("HH:mm:ss");
            lbDataAtual.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void TelaPrincipal_Load(object sender, EventArgs e)
        {
            timerCockpit.Enabled = true;
            timerCockpit.Start();
            
        }

        private void MinimizarTela()
        {
            //this.WindowState = FormWindowState.Minimized;
        }

        private void lbHoraAtual_Click(object sender, EventArgs e)
        {

        }

        private void btnSharePoint_Click(object sender, EventArgs e)
        {
            Process.Start("https://softwaresylith.sharepoint.com/sites/MenplanDrive");
            MinimizarTela();
        }

        private void btnServidor_Click(object sender, EventArgs e)
        {
            Process.Start(@"\\PC-01\Servidor");
            MinimizarTela();
        }

        private void btnSafety4life_Click(object sender, EventArgs e)
        {
            Process.Start("safety4life.pptx");
            MinimizarTela();
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            Process.Start("https://sso.godaddy.com/v1?region=am1&saas=1&app=ox&path=v1%2Fsaml%2Fox&realm=pass&status=24");
            MinimizarTela();
        }

        private void btnBancodoc_Click(object sender, EventArgs e)
        {
            Process.Start("https://bancodoc.com.br/");
            MinimizarTela();
        }

        private void btnAppMenplan_Click(object sender, EventArgs e)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string path = Path.Combine(currentDirectory, @"\\PC-01\Servidor\0. Programas\Cockpit-Menplan\Projeto M\bin\Debug\Menplan - Industrial Services.exe");
            MinimizarTela();
            Process.Start(path);
            
        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void TelaPrincipal_Resize(object sender, EventArgs e)
        {

            /*if (WindowState == FormWindowState.Minimized)
            {
                this.Hide();

                notify.Icon = new System.Drawing.Icon("icone_menplan.ico");
                notify.Visible = true;
                notify.Text = "Cockpit Menplan";

                notify.BalloonTipIcon = ToolTipIcon.Info;
                notify.BalloonTipTitle = "Cockpit Menplan";
                notify.BalloonTipText = "O Cockpit Menplan esta sendo executado em segundo plano";
                notify.ShowBalloonTip(500);
            }*/
            
            
        }

        private void notify_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();

            this.WindowState = FormWindowState.Normal;
            this.notify.Visible = false;
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }
    }
}
