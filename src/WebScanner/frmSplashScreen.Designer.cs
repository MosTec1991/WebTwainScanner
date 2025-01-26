using System.ComponentModel;

namespace WebScanner;

partial class FrmSplashScreen
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
        components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSplashScreen));
        icoSystenTry = new System.Windows.Forms.NotifyIcon(components);
        mnuSystemTry = new System.Windows.Forms.ContextMenuStrip(components);
        settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        runAtStartupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        useLastUsedOptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        pbSplashScreen = new System.Windows.Forms.PictureBox();
        mnuSystemTry.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)pbSplashScreen).BeginInit();
        SuspendLayout();
        // 
        // icoSystenTry
        // 
        icoSystenTry.ContextMenuStrip = mnuSystemTry;
        icoSystenTry.Icon = ((System.Drawing.Icon)resources.GetObject("icoSystenTry.Icon"));
        icoSystenTry.Text = "TWAIN Scan App";
        icoSystenTry.Visible = true;
        // 
        // mnuSystemTry
        // 
        mnuSystemTry.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { settingToolStripMenuItem, exitToolStripMenuItem });
        mnuSystemTry.Name = "mnuSystemTry";
        mnuSystemTry.Size = new System.Drawing.Size(112, 48);
        // 
        // settingToolStripMenuItem
        // 
        settingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { runAtStartupToolStripMenuItem, useLastUsedOptionToolStripMenuItem });
        settingToolStripMenuItem.Name = "settingToolStripMenuItem";
        settingToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
        settingToolStripMenuItem.Text = "Setting";
        // 
        // runAtStartupToolStripMenuItem
        // 
        runAtStartupToolStripMenuItem.Name = "runAtStartupToolStripMenuItem";
        runAtStartupToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
        runAtStartupToolStripMenuItem.Text = "Run At Startup";
        runAtStartupToolStripMenuItem.Click += runAtStartupToolStripMenuItem_Click;
        // 
        // useLastUsedOptionToolStripMenuItem
        // 
        useLastUsedOptionToolStripMenuItem.Name = "useLastUsedOptionToolStripMenuItem";
        useLastUsedOptionToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
        useLastUsedOptionToolStripMenuItem.Text = "Use Last Used Option";
        useLastUsedOptionToolStripMenuItem.Click += useLastUsedOptionToolStripMenuItem_Click;
        // 
        // exitToolStripMenuItem
        // 
        exitToolStripMenuItem.Name = "exitToolStripMenuItem";
        exitToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
        exitToolStripMenuItem.Text = "Exit";
        exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
        // 
        // pbSplashScreen
        // 
        pbSplashScreen.Image = ((System.Drawing.Image)resources.GetObject("pbSplashScreen.Image"));
        pbSplashScreen.Location = new System.Drawing.Point(0, 0);
        pbSplashScreen.Name = "pbSplashScreen";
        pbSplashScreen.Size = new System.Drawing.Size(450, 450);
        pbSplashScreen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        pbSplashScreen.TabIndex = 1;
        pbSplashScreen.TabStop = false;
        // 
        // FrmSplashScreen
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(450, 450);
        Controls.Add(pbSplashScreen);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "SplashScreen";
        Load += FrmSplashScreen_Load;
        mnuSystemTry.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)pbSplashScreen).EndInit();
        ResumeLayout(false);
    }

    private System.Windows.Forms.PictureBox pbSplashScreen;

    private System.Windows.Forms.NotifyIcon icoSystenTry;

    #endregion

    private ContextMenuStrip mnuSystemTry;
    private ToolStripMenuItem settingToolStripMenuItem;
    private ToolStripMenuItem runAtStartupToolStripMenuItem;
    private ToolStripMenuItem useLastUsedOptionToolStripMenuItem;
    private ToolStripMenuItem exitToolStripMenuItem;
}