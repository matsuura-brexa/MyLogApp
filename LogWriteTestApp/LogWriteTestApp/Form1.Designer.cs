using System.Windows.Forms;

namespace LogCompareTool
{
    public partial class Form1 : Form
    {
        private GroupBox grpMode;
        private RadioButton rdoLog4net;
        private RadioButton rdoNLog;
        private RadioButton rdoFileSystem;
        private RadioButton rdoStreamWriter;
        private Label lblProcess;
        private NumericUpDown numProcessCount;
        private Label lblLines;
        private NumericUpDown numLineCount;
        private Button btnStartTest;
        private TextBox txtResult;

        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.grpMode = new System.Windows.Forms.GroupBox();
            this.rdoStreamWriter = new System.Windows.Forms.RadioButton();
            this.rdoFileSystem = new System.Windows.Forms.RadioButton();
            this.rdoNLog = new System.Windows.Forms.RadioButton();
            this.rdoLog4net = new System.Windows.Forms.RadioButton();
            this.lblProcess = new System.Windows.Forms.Label();
            this.numProcessCount = new System.Windows.Forms.NumericUpDown();
            this.lblLines = new System.Windows.Forms.Label();
            this.numLineCount = new System.Windows.Forms.NumericUpDown();
            this.btnStartTest = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.grpMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numProcessCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLineCount)).BeginInit();
            this.SuspendLayout();
            // 
            // grpMode
            // 
            this.grpMode.Controls.Add(this.rdoStreamWriter);
            this.grpMode.Controls.Add(this.rdoFileSystem);
            this.grpMode.Controls.Add(this.rdoNLog);
            this.grpMode.Controls.Add(this.rdoLog4net);
            this.grpMode.Location = new System.Drawing.Point(12, 12);
            this.grpMode.Name = "grpMode";
            this.grpMode.Size = new System.Drawing.Size(360, 70);
            this.grpMode.TabIndex = 0;
            this.grpMode.TabStop = false;
            this.grpMode.Text = "ログ方式";
            // 
            // rdoStreamWriter
            // 
            this.rdoStreamWriter.AutoSize = true;
            this.rdoStreamWriter.Location = new System.Drawing.Point(260, 30);
            this.rdoStreamWriter.Name = "rdoStreamWriter";
            this.rdoStreamWriter.Size = new System.Drawing.Size(104, 17);
            this.rdoStreamWriter.TabIndex = 3;
            this.rdoStreamWriter.Text = "StreamWriter";
            this.rdoStreamWriter.UseVisualStyleBackColor = true;
            // 
            // rdoFileSystem
            // 
            this.rdoFileSystem.AutoSize = true;
            this.rdoFileSystem.Location = new System.Drawing.Point(170, 30);
            this.rdoFileSystem.Name = "rdoFileSystem";
            this.rdoFileSystem.Size = new System.Drawing.Size(90, 17);
            this.rdoFileSystem.TabIndex = 2;
            this.rdoFileSystem.Text = "FileSystem";
            this.rdoFileSystem.UseVisualStyleBackColor = true;
            // 
            // rdoNLog
            // 
            this.rdoNLog.AutoSize = true;
            this.rdoNLog.Location = new System.Drawing.Point(95, 30);
            this.rdoNLog.Name = "rdoNLog";
            this.rdoNLog.Size = new System.Drawing.Size(56, 17);
            this.rdoNLog.TabIndex = 1;
            this.rdoNLog.Text = "NLog";
            this.rdoNLog.UseVisualStyleBackColor = true;
            // 
            // rdoLog4net
            // 
            this.rdoLog4net.AutoSize = true;
            this.rdoLog4net.Checked = true;
            this.rdoLog4net.Location = new System.Drawing.Point(15, 30);
            this.rdoLog4net.Name = "rdoLog4net";
            this.rdoLog4net.Size = new System.Drawing.Size(70, 17);
            this.rdoLog4net.TabIndex = 0;
            this.rdoLog4net.TabStop = true;
            this.rdoLog4net.Text = "log4net";
            this.rdoLog4net.UseVisualStyleBackColor = true;
            // 
            // lblProcess
            // 
            this.lblProcess.AutoSize = true;
            this.lblProcess.Location = new System.Drawing.Point(12, 95);
            this.lblProcess.Name = "lblProcess";
            this.lblProcess.Size = new System.Drawing.Size(60, 13);
            this.lblProcess.TabIndex = 1;
            this.lblProcess.Text = "プロセス数";
            // 
            // numProcessCount
            // 
            this.numProcessCount.Location = new System.Drawing.Point(90, 93);
            this.numProcessCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numProcessCount.Name = "numProcessCount";
            this.numProcessCount.Size = new System.Drawing.Size(80, 19);
            this.numProcessCount.TabIndex = 2;
            this.numProcessCount.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // lblLines
            // 
            this.lblLines.AutoSize = true;
            this.lblLines.Location = new System.Drawing.Point(190, 95);
            this.lblLines.Name = "lblLines";
            this.lblLines.Size = new System.Drawing.Size(99, 13);
            this.lblLines.TabIndex = 3;
            this.lblLines.Text = "ログ行数/プロセス";
            // 
            // numLineCount
            // 
            this.numLineCount.Location = new System.Drawing.Point(290, 93);
            this.numLineCount.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numLineCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numLineCount.Name = "numLineCount";
            this.numLineCount.Size = new System.Drawing.Size(80, 19);
            this.numLineCount.TabIndex = 4;
            this.numLineCount.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // btnStartTest
            // 
            this.btnStartTest.Location = new System.Drawing.Point(12, 125);
            this.btnStartTest.Name = "btnStartTest";
            this.btnStartTest.Size = new System.Drawing.Size(358, 30);
            this.btnStartTest.TabIndex = 5;
            this.btnStartTest.Text = "テスト開始";
            this.btnStartTest.UseVisualStyleBackColor = true;
            this.btnStartTest.Click += new System.EventHandler(this.btnStartTest_Click);
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(12, 170);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResult.Size = new System.Drawing.Size(358, 220);
            this.txtResult.TabIndex = 6;
            this.txtResult.WordWrap = false;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(384, 411);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.btnStartTest);
            this.Controls.Add(this.numLineCount);
            this.Controls.Add(this.lblLines);
            this.Controls.Add(this.numProcessCount);
            this.Controls.Add(this.lblProcess);
            this.Controls.Add(this.grpMode);
            this.Name = "Form1";
            this.Text = "ログ比較ツール（マルチプロセス同時書き込み検証）";
            this.grpMode.ResumeLayout(false);
            this.grpMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numProcessCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLineCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}