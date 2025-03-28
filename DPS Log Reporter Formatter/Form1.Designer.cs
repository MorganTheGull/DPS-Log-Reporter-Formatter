namespace DPS_Log_Reporter_Formatter;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
        labelTitle = new System.Windows.Forms.Label();
        comboboxMarkup = new System.Windows.Forms.ComboBox();
        label1 = new System.Windows.Forms.Label();
        labelLogLinks = new System.Windows.Forms.Label();
        labelOutput = new System.Windows.Forms.Label();
        buttonFormat = new System.Windows.Forms.Button();
        textBoxLinks = new System.Windows.Forms.TextBox();
        textBoxFormatted = new System.Windows.Forms.TextBox();
        comboboxClassifications = new System.Windows.Forms.ComboBox();
        label2 = new System.Windows.Forms.Label();
        SuspendLayout();
        // 
        // labelTitle
        // 
        labelTitle.Font = new System.Drawing.Font("Segoe UI", 40F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline)));
        labelTitle.Location = new System.Drawing.Point(3, 3);
        labelTitle.Name = "labelTitle";
        labelTitle.Size = new System.Drawing.Size(780, 100);
        labelTitle.TabIndex = 0;
        labelTitle.Text = "DPS Log Reporter Formatter";
        labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // comboboxMarkup
        // 
        comboboxMarkup.Font = new System.Drawing.Font("Segoe UI", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        comboboxMarkup.FormattingEnabled = true;
        comboboxMarkup.Items.AddRange(new object[] { "Discord", "None" });
        comboboxMarkup.Location = new System.Drawing.Point(26, 186);
        comboboxMarkup.Name = "comboboxMarkup";
        comboboxMarkup.Size = new System.Drawing.Size(350, 53);
        comboboxMarkup.TabIndex = 2;
        comboboxMarkup.Text = "Discord";
        // 
        // label1
        // 
        label1.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Bold);
        label1.Location = new System.Drawing.Point(26, 103);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(350, 60);
        label1.TabIndex = 1;
        label1.Text = "Markup Options";
        label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // labelLogLinks
        // 
        labelLogLinks.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Bold);
        labelLogLinks.Location = new System.Drawing.Point(26, 242);
        labelLogLinks.Name = "labelLogLinks";
        labelLogLinks.Size = new System.Drawing.Size(350, 100);
        labelLogLinks.TabIndex = 3;
        labelLogLinks.Text = "Log Links";
        labelLogLinks.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // labelOutput
        // 
        labelOutput.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Bold);
        labelOutput.Location = new System.Drawing.Point(399, 242);
        labelOutput.Name = "labelOutput";
        labelOutput.Size = new System.Drawing.Size(350, 100);
        labelOutput.TabIndex = 4;
        labelOutput.Text = "Output";
        labelOutput.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // buttonFormat
        // 
        buttonFormat.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Bold);
        buttonFormat.Location = new System.Drawing.Point(3, 655);
        buttonFormat.Name = "buttonFormat";
        buttonFormat.Size = new System.Drawing.Size(780, 100);
        buttonFormat.TabIndex = 5;
        buttonFormat.Text = "FORMAT";
        buttonFormat.UseVisualStyleBackColor = true;
        buttonFormat.Click += buttonFormat_Click;
        // 
        // textBoxLinks
        // 
        textBoxLinks.AcceptsReturn = true;
        textBoxLinks.Location = new System.Drawing.Point(26, 345);
        textBoxLinks.Multiline = true;
        textBoxLinks.Name = "textBoxLinks";
        textBoxLinks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        textBoxLinks.Size = new System.Drawing.Size(350, 304);
        textBoxLinks.TabIndex = 6;
        // 
        // textBoxFormatted
        // 
        textBoxFormatted.Location = new System.Drawing.Point(399, 345);
        textBoxFormatted.Multiline = true;
        textBoxFormatted.Name = "textBoxFormatted";
        textBoxFormatted.ReadOnly = true;
        textBoxFormatted.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        textBoxFormatted.Size = new System.Drawing.Size(350, 304);
        textBoxFormatted.TabIndex = 7;
        // 
        // comboboxClassifications
        // 
        comboboxClassifications.Font = new System.Drawing.Font("Segoe UI", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        comboboxClassifications.FormattingEnabled = true;
        comboboxClassifications.Items.AddRange(new object[] { "All Categories", "Only Main Categories", "Only Sub Categories", "None" });
        comboboxClassifications.Location = new System.Drawing.Point(399, 186);
        comboboxClassifications.Name = "comboboxClassifications";
        comboboxClassifications.Size = new System.Drawing.Size(350, 53);
        comboboxClassifications.TabIndex = 9;
        comboboxClassifications.Text = "Only Sub Categories";
        // 
        // label2
        // 
        label2.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Bold);
        label2.Location = new System.Drawing.Point(399, 103);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(350, 60);
        label2.TabIndex = 8;
        label2.Text = "Classifications";
        label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.SystemColors.ControlDarkDark;
        ClientSize = new System.Drawing.Size(784, 761);
        Controls.Add(comboboxClassifications);
        Controls.Add(label2);
        Controls.Add(textBoxFormatted);
        Controls.Add(textBoxLinks);
        Controls.Add(buttonFormat);
        Controls.Add(labelOutput);
        Controls.Add(labelLogLinks);
        Controls.Add(comboboxMarkup);
        Controls.Add(label1);
        Controls.Add(labelTitle);
        Text = "DPS Log Reporter Formatter";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.ComboBox comboboxClassifications;
    private System.Windows.Forms.Label label2;

    private System.Windows.Forms.TextBox textBoxFormatted;

    private System.Windows.Forms.TextBox textBoxLinks;

    private System.Windows.Forms.Label labelLogLinks;
    private System.Windows.Forms.Label labelOutput;
    private System.Windows.Forms.Button buttonFormat;

    private System.Windows.Forms.ComboBox comboboxMarkup;

    private System.Windows.Forms.Label label1;

    private System.Windows.Forms.Label labelTitle;

    #endregion
}