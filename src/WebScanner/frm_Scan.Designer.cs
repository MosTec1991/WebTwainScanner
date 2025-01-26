using System.ComponentModel;

namespace WebScanner;

partial class FrmScan
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmScan));
        cboDevice = new System.Windows.Forms.ComboBox();
        btnDeviceRefresh = new System.Windows.Forms.Button();
        groupBox1 = new System.Windows.Forms.GroupBox();
        btnBack = new System.Windows.Forms.Button();
        cboColor = new System.Windows.Forms.ComboBox();
        btnSend = new System.Windows.Forms.Button();
        btnScan = new System.Windows.Forms.Button();
        cboDpi = new System.Windows.Forms.ComboBox();
        cboFeeder = new System.Windows.Forms.ComboBox();
        label1 = new System.Windows.Forms.Label();
        label4 = new System.Windows.Forms.Label();
        label2 = new System.Windows.Forms.Label();
        label3 = new System.Windows.Forms.Label();
        groupBox2 = new System.Windows.Forms.GroupBox();
        pnlScanedPages = new System.Windows.Forms.FlowLayoutPanel();
        groupBox3 = new System.Windows.Forms.GroupBox();
        btnRotateLeft = new System.Windows.Forms.Button();
        btnRotateRight = new System.Windows.Forms.Button();
        btnDeletePage = new System.Windows.Forms.Button();
        pbViewScannedPage = new System.Windows.Forms.PictureBox();
        groupBox1.SuspendLayout();
        groupBox2.SuspendLayout();
        groupBox3.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)pbViewScannedPage).BeginInit();
        SuspendLayout();
        // 
        // cboDevice
        // 
        cboDevice.FormattingEnabled = true;
        cboDevice.Location = new System.Drawing.Point(64, 22);
        cboDevice.Name = "cboDevice";
        cboDevice.Size = new System.Drawing.Size(192, 23);
        cboDevice.TabIndex = 0;
        cboDevice.SelectedIndexChanged += cboDevice_SelectedIndexChanged;
        // 
        // btnDeviceRefresh
        // 
        btnDeviceRefresh.Enabled = false;
        btnDeviceRefresh.Location = new System.Drawing.Point(262, 22);
        btnDeviceRefresh.Name = "btnDeviceRefresh";
        btnDeviceRefresh.Size = new System.Drawing.Size(64, 23);
        btnDeviceRefresh.TabIndex = 1;
        btnDeviceRefresh.Text = "Refresh";
        btnDeviceRefresh.UseVisualStyleBackColor = true;
        btnDeviceRefresh.Click += btnDeviceRefresh_Click;
        // 
        // groupBox1
        // 
        groupBox1.Controls.Add(btnBack);
        groupBox1.Controls.Add(cboColor);
        groupBox1.Controls.Add(btnSend);
        groupBox1.Controls.Add(btnScan);
        groupBox1.Controls.Add(cboDpi);
        groupBox1.Controls.Add(cboDevice);
        groupBox1.Controls.Add(btnDeviceRefresh);
        groupBox1.Controls.Add(cboFeeder);
        groupBox1.Controls.Add(label1);
        groupBox1.Controls.Add(label4);
        groupBox1.Controls.Add(label2);
        groupBox1.Controls.Add(label3);
        groupBox1.Location = new System.Drawing.Point(10, 10);
        groupBox1.Name = "groupBox1";
        groupBox1.Size = new System.Drawing.Size(334, 173);
        groupBox1.TabIndex = 2;
        groupBox1.TabStop = false;
        groupBox1.Text = "Device";
        // 
        // btnBack
        // 
        btnBack.Location = new System.Drawing.Point(226, 138);
        btnBack.Name = "btnBack";
        btnBack.Size = new System.Drawing.Size(100, 26);
        btnBack.TabIndex = 5;
        btnBack.Text = "Back";
        btnBack.UseVisualStyleBackColor = true;
        btnBack.Click += btnBack_Click;
        // 
        // cboColor
        // 
        cboColor.FormattingEnabled = true;
        cboColor.Location = new System.Drawing.Point(64, 109);
        cboColor.Name = "cboColor";
        cboColor.Size = new System.Drawing.Size(192, 23);
        cboColor.TabIndex = 9;
        // 
        // btnSend
        // 
        btnSend.Enabled = false;
        btnSend.Location = new System.Drawing.Point(114, 138);
        btnSend.Name = "btnSend";
        btnSend.Size = new System.Drawing.Size(106, 26);
        btnSend.TabIndex = 4;
        btnSend.Text = "Send";
        btnSend.UseVisualStyleBackColor = true;
        btnSend.Click += btnSend_Click;
        // 
        // btnScan
        // 
        btnScan.Enabled = false;
        btnScan.Location = new System.Drawing.Point(8, 138);
        btnScan.Name = "btnScan";
        btnScan.Size = new System.Drawing.Size(100, 26);
        btnScan.TabIndex = 3;
        btnScan.Text = "Scan";
        btnScan.UseVisualStyleBackColor = true;
        btnScan.Click += btnScan_Click;
        // 
        // cboDpi
        // 
        cboDpi.FormattingEnabled = true;
        cboDpi.Location = new System.Drawing.Point(64, 80);
        cboDpi.Name = "cboDpi";
        cboDpi.Size = new System.Drawing.Size(192, 23);
        cboDpi.TabIndex = 8;
        // 
        // cboFeeder
        // 
        cboFeeder.FormattingEnabled = true;
        cboFeeder.Location = new System.Drawing.Point(64, 51);
        cboFeeder.Name = "cboFeeder";
        cboFeeder.Size = new System.Drawing.Size(192, 23);
        cboFeeder.TabIndex = 7;
        // 
        // label1
        // 
        label1.Location = new System.Drawing.Point(8, 26);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(50, 19);
        label1.TabIndex = 3;
        label1.Text = "Device:";
        // 
        // label4
        // 
        label4.Location = new System.Drawing.Point(8, 113);
        label4.Name = "label4";
        label4.Size = new System.Drawing.Size(50, 19);
        label4.TabIndex = 6;
        label4.Text = "Color:";
        // 
        // label2
        // 
        label2.Location = new System.Drawing.Point(8, 55);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(50, 19);
        label2.TabIndex = 4;
        label2.Text = "Feeder:";
        // 
        // label3
        // 
        label3.Location = new System.Drawing.Point(8, 84);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(50, 19);
        label3.TabIndex = 5;
        label3.Text = "DPI:";
        // 
        // groupBox2
        // 
        groupBox2.Controls.Add(pnlScanedPages);
        groupBox2.Location = new System.Drawing.Point(10, 189);
        groupBox2.Name = "groupBox2";
        groupBox2.Size = new System.Drawing.Size(334, 362);
        groupBox2.TabIndex = 6;
        groupBox2.TabStop = false;
        groupBox2.Text = "Scanned Pages";
        // 
        // pnlScanedPages
        // 
        pnlScanedPages.AutoScroll = true;
        pnlScanedPages.Location = new System.Drawing.Point(0, 20);
        pnlScanedPages.Name = "pnlScanedPages";
        pnlScanedPages.Size = new System.Drawing.Size(334, 330);
        pnlScanedPages.TabIndex = 0;
        // 
        // groupBox3
        // 
        groupBox3.Controls.Add(btnRotateLeft);
        groupBox3.Controls.Add(btnRotateRight);
        groupBox3.Controls.Add(btnDeletePage);
        groupBox3.Controls.Add(pbViewScannedPage);
        groupBox3.Location = new System.Drawing.Point(350, 10);
        groupBox3.Name = "groupBox3";
        groupBox3.Size = new System.Drawing.Size(426, 541);
        groupBox3.TabIndex = 7;
        groupBox3.TabStop = false;
        groupBox3.Text = "View";
        // 
        // btnRotateLeft
        // 
        btnRotateLeft.Enabled = false;
        btnRotateLeft.Location = new System.Drawing.Point(64, 19);
        btnRotateLeft.Name = "btnRotateLeft";
        btnRotateLeft.Size = new System.Drawing.Size(38, 26);
        btnRotateLeft.TabIndex = 12;
        btnRotateLeft.Text = "RL";
        btnRotateLeft.UseVisualStyleBackColor = true;
        btnRotateLeft.Click += btnRotateLeft_Click;
        // 
        // btnRotateRight
        // 
        btnRotateRight.Enabled = false;
        btnRotateRight.Location = new System.Drawing.Point(108, 19);
        btnRotateRight.Name = "btnRotateRight";
        btnRotateRight.Size = new System.Drawing.Size(38, 26);
        btnRotateRight.TabIndex = 11;
        btnRotateRight.Text = "RR";
        btnRotateRight.UseVisualStyleBackColor = true;
        btnRotateRight.Click += btnRotateRight_Click;
        // 
        // btnDeletePage
        // 
        btnDeletePage.Enabled = false;
        btnDeletePage.Location = new System.Drawing.Point(20, 19);
        btnDeletePage.Name = "btnDeletePage";
        btnDeletePage.Size = new System.Drawing.Size(38, 26);
        btnDeletePage.TabIndex = 10;
        btnDeletePage.Text = "D";
        btnDeletePage.UseVisualStyleBackColor = true;
        btnDeletePage.Click += btnDeletePage_Click;
        // 
        // pbViewScannedPage
        // 
        pbViewScannedPage.Location = new System.Drawing.Point(5, 55);
        pbViewScannedPage.Name = "pbViewScannedPage";
        pbViewScannedPage.Size = new System.Drawing.Size(415, 474);
        pbViewScannedPage.TabIndex = 0;
        pbViewScannedPage.TabStop = false;
        // 
        // FrmScan
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(784, 560);
        Controls.Add(groupBox3);
        Controls.Add(groupBox2);
        Controls.Add(groupBox1);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        Icon = ((System.Drawing.Icon)resources.GetObject("$this.Icon"));
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "Scan New Page";
        groupBox1.ResumeLayout(false);
        groupBox2.ResumeLayout(false);
        groupBox3.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)pbViewScannedPage).EndInit();
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button btnDeletePage;
    private System.Windows.Forms.Button btnRotateRight;
    private System.Windows.Forms.Button btnRotateLeft;

    private System.Windows.Forms.ComboBox cboDevice;
    private System.Windows.Forms.Button btnDeviceRefresh;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.ComboBox cboFeeder;
    private System.Windows.Forms.ComboBox cboDpi;
    private System.Windows.Forms.ComboBox cboColor;
    private System.Windows.Forms.Button btnScan;
    private System.Windows.Forms.Button btnSend;
    private System.Windows.Forms.Button btnBack;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.GroupBox groupBox3;

    #endregion

    private System.Windows.Forms.FlowLayoutPanel pnlScanedPages;
    private System.Windows.Forms.PictureBox pbViewScannedPage;
}