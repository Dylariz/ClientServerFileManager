using System;
using System.Windows.Forms;

namespace FMClient;

public partial class InputDialog : Form
{
    public string InputText { get; private set; } = string.Empty;
    
    public InputDialog(string comment)
    {
        InitializeComponent();
        commentLabel.Text = comment;
    }

    private void buttonOK_Click(object sender, EventArgs e)
    {
        InputText = promptTextBox.Text;
        DialogResult = DialogResult.OK;
        Close();
    }

    private void buttonCancel_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }


    private void InputDialog_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char) Keys.Enter)
        {
            InputText = promptTextBox.Text;
            DialogResult = DialogResult.OK;
            Close();
        }
        else if (e.KeyChar == (char) Keys.Escape)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}