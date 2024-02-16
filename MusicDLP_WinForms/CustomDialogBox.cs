using System.Windows.Forms;

namespace MusicDLP_WinForms
{
    public enum CustomDialogBoxButtons
    {
        OkCancel,
        YesNo,
        MessageBox
    }

    public partial class CustomDialogBox : Form
    {
        public CustomDialogBox(string title, string message)
        {
            InitializeComponent();

            SetTitleAndMessage(title, message);
        }

        public CustomDialogBox(string title, string message, bool isProgressDialog)
        {
            InitializeComponent();

            SetTitleAndMessage(title, message);
            SetProgressDialog(isProgressDialog);
        }

        public CustomDialogBox(string title, string message, CustomDialogBoxButtons buttons)
        {
            InitializeComponent();

            SetTitleAndMessage(title, message);
            SetDefaultButtons(buttons);
        }

        public void SetTitleAndMessage(string title, string message)
        {
            Text = title;
            lblTitle.Text = title;
            lblMessage.Text = message;
        }

        public void SetProgressDialog(bool flag)
        {
            progress.Visible = flag;
        }

        public void SetDefaultButtons(CustomDialogBoxButtons buttons)
        {
            switch (buttons)
            {
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