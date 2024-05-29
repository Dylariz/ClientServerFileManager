using System.ComponentModel;

namespace FMClient;

partial class InputDialog
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.buttonOK = new System.Windows.Forms.Button();
        this.buttonCancel = new System.Windows.Forms.Button();
        this.promptTextBox = new System.Windows.Forms.TextBox();
        this.commentLabel = new System.Windows.Forms.Label();
        this.SuspendLayout();
        // 
        // buttonOK
        // 
        this.buttonOK.Location = new System.Drawing.Point(12, 63);
        this.buttonOK.Name = "buttonOK";
        this.buttonOK.Size = new System.Drawing.Size(75, 27);
        this.buttonOK.TabIndex = 0;
        this.buttonOK.Text = "ОК";
        this.buttonOK.UseVisualStyleBackColor = true;
        this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
        // 
        // buttonCancel
        // 
        this.buttonCancel.Location = new System.Drawing.Point(93, 63);
        this.buttonCancel.Name = "buttonCancel";
        this.buttonCancel.Size = new System.Drawing.Size(67, 27);
        this.buttonCancel.TabIndex = 1;
        this.buttonCancel.Text = "Отмена";
        this.buttonCancel.UseVisualStyleBackColor = true;
        this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
        // 
        // promptTextBox
        // 
        this.promptTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        this.promptTextBox.Location = new System.Drawing.Point(12, 31);
        this.promptTextBox.Name = "promptTextBox";
        this.promptTextBox.Size = new System.Drawing.Size(236, 26);
        this.promptTextBox.TabIndex = 2;
        // 
        // commentLabel
        // 
        this.commentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        this.commentLabel.Location = new System.Drawing.Point(12, 9);
        this.commentLabel.Name = "commentLabel";
        this.commentLabel.Size = new System.Drawing.Size(236, 19);
        this.commentLabel.TabIndex = 3;
        this.commentLabel.Text = "Введите название папки:";
        // 
        // InputDialog
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(261, 97);
        this.Controls.Add(this.commentLabel);
        this.Controls.Add(this.promptTextBox);
        this.Controls.Add(this.buttonCancel);
        this.Controls.Add(this.buttonOK);
        this.Name = "InputDialog";
        this.Text = "Окно ввода";
        this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InputDialog_KeyPress);
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private System.Windows.Forms.Label commentLabel;

    private System.Windows.Forms.TextBox promptTextBox;

    private System.Windows.Forms.Button buttonOK;
    private System.Windows.Forms.Button buttonCancel;

    #endregion
}