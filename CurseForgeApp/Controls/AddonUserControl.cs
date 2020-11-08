using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using CurseForgeApp.Models;

namespace CurseForgeApp.Controls
{
    public partial class AddonUserControl : UserControl
    {
        readonly Addon _addon;

        public AddonUserControl(Addon addon)
        {
            _addon = addon;

            InitializeComponent();

            var thumbnail = _addon.Attachments
                .Where(xa => !string.IsNullOrEmpty(xa.ThumbnailUrl))
                .FirstOrDefault();

            if (thumbnail != null)
                imgAddonThumbnail.ImageLocation = thumbnail.ThumbnailUrl;

            lbAddonName.Text = _addon.Name;
            //lbAuthors.Text = string.Join(", ", _addon.Authors.Select(x => x.Name).ToArray());

            authorsContainer.Controls.Clear();
            authorsContainer.Controls.AddRange(_addon.Authors.Select(x =>
            {
                string apos = _addon.Authors.LastOrDefault() != x ? "," : string.Empty;

                var label = new LinkLabel
                {
                    AutoSize = true,
                    Margin = new Padding(0),
                    Padding = new Padding(0),
                    Text = string.Concat(x.Name, apos),
                    Tag = x.Url,
                    LinkBehavior = LinkBehavior.NeverUnderline
                };

                Fonts.NotoSans.ApplyFontTo(label);

                label.LinkArea = new LinkArea(0, x.Name.Length);
                label.LinkClicked += OnAuthorLinkClicked;

                return label;
            }).Take(4).ToArray());

            txtAddonDescription.Text = _addon.Summary;

            Fonts.NotoSans.ApplyFontTo(this, lbAddonName, authorsContainer, btnView, txtAddonDescription);
        }

        private void OnAuthorLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!(sender is LinkLabel link))
                return;

            Process.Start(link.Tag.ToString());
        }
    }
}
