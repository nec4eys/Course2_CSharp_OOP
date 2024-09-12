namespace TemperatureTask
{
    partial class MainForm
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            okButton = new Button();
            temperatureOutputText = new Label();
            temperatureTypeInput = new ComboBox();
            temperatureInput = new TextBox();
            mainPanel = new TableLayoutPanel();
            inputPanel = new Panel();
            temperatureTypeOutput = new ComboBox();
            toText = new Label();
            fromText = new Label();
            mainPanel.SuspendLayout();
            inputPanel.SuspendLayout();
            SuspendLayout();
            // 
            // okButton
            // 
            okButton.Anchor = AnchorStyles.None;
            okButton.Location = new Point(79, 137);
            okButton.Name = "okButton";
            okButton.Size = new Size(120, 30);
            okButton.TabIndex = 0;
            okButton.Text = "Перевести";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += okButton_Click;
            // 
            // temperatureOutputText
            // 
            temperatureOutputText.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            temperatureOutputText.Font = new Font("Segoe UI", 11F);
            temperatureOutputText.Location = new Point(3, 71);
            temperatureOutputText.Name = "temperatureOutputText";
            temperatureOutputText.Size = new Size(273, 53);
            temperatureOutputText.TabIndex = 1;
            temperatureOutputText.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // temperatureTypeInput
            // 
            temperatureTypeInput.FormattingEnabled = true;
            temperatureTypeInput.Items.AddRange(new object[] { "C", "K", "F" });
            temperatureTypeInput.Location = new Point(147, 3);
            temperatureTypeInput.Name = "temperatureTypeInput";
            temperatureTypeInput.Size = new Size(121, 23);
            temperatureTypeInput.TabIndex = 4;
            // 
            // temperatureInput
            // 
            temperatureInput.Location = new Point(3, 3);
            temperatureInput.Name = "temperatureInput";
            temperatureInput.Size = new Size(111, 23);
            temperatureInput.TabIndex = 5;
            // 
            // mainPanel
            // 
            mainPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            mainPanel.ColumnCount = 1;
            mainPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            mainPanel.Controls.Add(okButton, 0, 2);
            mainPanel.Controls.Add(temperatureOutputText, 0, 1);
            mainPanel.Controls.Add(inputPanel, 0, 0);
            mainPanel.Location = new Point(12, 12);
            mainPanel.Name = "mainPanel";
            mainPanel.RowCount = 3;
            mainPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            mainPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 53F));
            mainPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 56F));
            mainPanel.Size = new Size(279, 180);
            mainPanel.TabIndex = 4;
            // 
            // inputPanel
            // 
            inputPanel.Controls.Add(temperatureTypeOutput);
            inputPanel.Controls.Add(toText);
            inputPanel.Controls.Add(temperatureInput);
            inputPanel.Controls.Add(fromText);
            inputPanel.Controls.Add(temperatureTypeInput);
            inputPanel.Dock = DockStyle.Fill;
            inputPanel.Location = new Point(3, 3);
            inputPanel.Name = "inputPanel";
            inputPanel.Size = new Size(273, 65);
            inputPanel.TabIndex = 2;
            // 
            // temperatureTypeOutput
            // 
            temperatureTypeOutput.FormattingEnabled = true;
            temperatureTypeOutput.Items.AddRange(new object[] { "C", "K", "F" });
            temperatureTypeOutput.Location = new Point(147, 31);
            temperatureTypeOutput.Name = "temperatureTypeOutput";
            temperatureTypeOutput.Size = new Size(121, 23);
            temperatureTypeOutput.TabIndex = 7;
            // 
            // toText
            // 
            toText.Anchor = AnchorStyles.None;
            toText.AutoSize = true;
            toText.Location = new Point(120, 34);
            toText.Name = "toText";
            toText.Size = new Size(14, 15);
            toText.TabIndex = 6;
            toText.Text = "В";
            toText.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // fromText
            // 
            fromText.Anchor = AnchorStyles.None;
            fromText.AutoSize = true;
            fromText.Location = new Point(120, 6);
            fromText.Name = "fromText";
            fromText.Size = new Size(21, 15);
            fromText.TabIndex = 5;
            fromText.Text = "Из";
            fromText.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(304, 461);
            Controls.Add(mainPanel);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Temperature";
            mainPanel.ResumeLayout(false);
            inputPanel.ResumeLayout(false);
            inputPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button okButton;
        private Label temperatureOutputText;
        private ComboBox temperatureTypeInput;
        private TextBox temperatureInput;
        private TableLayoutPanel mainPanel;
        private Label fromText;
        private Panel inputPanel;
        private ComboBox temperatureTypeOutput;
        private Label toText;
    }
}
