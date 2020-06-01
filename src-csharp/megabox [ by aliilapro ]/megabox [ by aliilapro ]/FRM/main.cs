using System;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace megabox___by_aliilapro__.FRM
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void main_Load(object sender, EventArgs e)
        {
            btncopy.Visible = false;
            lblsts.Text = "App is running ...";
        }

        private void btnget_Click(object sender, EventArgs e)
        {
            lblsts.Text = "Getting ...";
            lblsts.ForeColor = Color.White;
            if (txtfileid.Text == "")
            {
                lblsts.Text = "Enter File ID.";
                lblsts.ForeColor = Color.Red;
                MessageBox.Show("Enter File ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                if (txtfilename.Text == "")
                {
                    lblsts.Text = "Enter File name + Format.";
                    lblsts.ForeColor = Color.Red;
                    MessageBox.Show("Enter File name + Format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    try
                    {
                        WebClient webClient = new WebClient();
                        string r = new WebClient().DownloadString("https://corona-api.000webhostapp.com/mega/m.php?id=" + txtfileid.Text);
                        if (r.Contains("error"))
                        {
                            lblsts.Text = "Check file id.";
                            lblsts.ForeColor = Color.Red;
                            MessageBox.Show("Check file id.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else if (r.Contains("userstorage.mega.co.nz"))
                        {
                            lblsts.Text = "Done.";
                            lblsts.ForeColor = Color.Lime;
                            txtlink.Text = r.ToString() + "/" + txtfilename.Text;
                            btncopy.Visible = true;
                        }
                        else
                        {
                            lblsts.Text = "Check file id or Try again.";
                            lblsts.ForeColor = Color.Red;
                            MessageBox.Show("Check file id or Try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblsts.Text = "...";
                        lblsts.ForeColor = Color.White;
                    }
                }
            }
        }

        private void btncopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtlink.Text);
            MessageBox.Show("Link successfully copied.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btngithub_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/ALIILAPRO");
        }

        private void btntel_Click(object sender, EventArgs e)
        {
            Process.Start("https://t.me/source_pro");
        }

        private void btnyoutube_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.youtube.com/channel/UCsq5dmDDFD02d6JF2UdtMow");
        }
    }
}
