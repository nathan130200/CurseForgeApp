using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CurseForgeApp.Models;

namespace CurseForgeApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            Fonts.NotoSans.ApplyFontTo(this, txtSearch, btnSearch);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            btnSearch.PerformClick();
        }

        private async void BtnSearch_Click(object sender, EventArgs e)
        {
            btnSearch.Enabled = false;
            addonsContainer.Controls.Clear();

            var result = await AddonService.GetAddonsAsync(filter: txtSearch.Text);//.ConfigureAwait(false);

            foreach (var item in result)
            {
                var control = item.GetControl();
                addonsContainer.Controls.Add(control);

                if (item != result.LastOrDefault())
                    addonsContainer.Controls.Add(new Panel
                    {
                        Height = 1,
                        BorderStyle = BorderStyle.Fixed3D,
                        Width = control.Width,
                        AutoSizeMode = AutoSizeMode.GrowAndShrink,
                        MinimumSize = new Size(1, 1),
                        MaximumSize = new Size(int.MaxValue, 1),
                        BackColor = Color.DarkGray
                    });
            }

            btnSearch.Enabled = true;
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            //btnSearch.PerformClick();
        }
    }
}
