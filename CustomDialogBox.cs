using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicDLP {
    public enum CustomDialogBoxButtons {
        OkCancel,
        YesNo,
        MessageBox
    }

    public partial class CustomDialogBox : Form {
        public CustomDialogBox(string title, string message) {
            InitializeComponent();

            Text = title;
            lblTitle.Text = title;
            lblMessage.Text = message;
        }

        public CustomDialogBox(string title, string message, CustomDialogBoxButtons buttons) {
            InitializeComponent();

            Text = title;
            lblTitle.Text = title;
            lblMessage.Text = message;

            switch (buttons) {
                case CustomDialogBoxButtons.YesNo:
                    btnDefault1.Text = "Yes";
                    btnDefault2.Text = "No";

                    btnDefault1.DialogResult = DialogResult.Yes;
                    btnDefault2.DialogResult = DialogResult.No;
                    break;
                case CustomDialogBoxButtons.OkCancel:
                    btnDefault1.Text = "OK";
                    btnDefault2.Text = "Cancel";

                    btnDefault1.DialogResult = DialogResult.OK;
                    btnDefault2.DialogResult = DialogResult.Cancel;

                    break;
                default:
                    btnDefault1.Visible = false;

                    btnDefault2.Text = "OK";
                    btnDefault2.DialogResult = DialogResult.OK;
                    break;
            }
        }
    }
}
