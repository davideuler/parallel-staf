namespace ParaStaf
{
    partial class ParaStafForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ParaStafForm));
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.lstHostList = new System.Windows.Forms.ListBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.lstRunResult = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDeleteFile = new System.Windows.Forms.Button();
            this.btnAddFile = new System.Windows.Forms.Button();
            this.txtFileFolderName = new System.Windows.Forms.TextBox();
            this.lstSyncFileFolders = new System.Windows.Forms.ListBox();
            this.lstFilesBack = new System.Windows.Forms.ListBox();
            this.txtCommand = new System.Windows.Forms.TextBox();
            this.txtCheckCondition = new System.Windows.Forms.TextBox();
            this.chkDisableParallel = new System.Windows.Forms.CheckBox();
            this.chkStafCommand = new System.Windows.Forms.CheckBox();
            this.chkNoCheck = new System.Windows.Forms.CheckBox();
            this.chkNoSync = new System.Windows.Forms.CheckBox();
            this.txtConsoleOutput = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtHostAdd = new System.Windows.Forms.TextBox();
            this.btnAddHost = new System.Windows.Forms.Button();
            this.btnDelHost = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnDeleteFileBack = new System.Windows.Forms.Button();
            this.btnAddFileBack = new System.Windows.Forms.Button();
            this.txtFilesBack = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnPing = new System.Windows.Forms.Button();
            this.chkShowDebugInfo = new System.Windows.Forms.CheckBox();
            this.btnShowRunLog = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnQuitWithoutSave = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstHostList
            // 
            this.lstHostList.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lstHostList.FormattingEnabled = true;
            this.lstHostList.ItemHeight = 15;
            this.lstHostList.Location = new System.Drawing.Point(13, 38);
            this.lstHostList.Name = "lstHostList";
            this.lstHostList.Size = new System.Drawing.Size(152, 124);
            this.lstHostList.TabIndex = 1;
            this.toolTip.SetToolTip(this.lstHostList, "remote STAF hosts to run commands");
            // 
            // txtResult
            // 
            this.txtResult.BackColor = System.Drawing.SystemColors.Info;
            this.txtResult.Location = new System.Drawing.Point(303, 17);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResult.Size = new System.Drawing.Size(913, 186);
            this.txtResult.TabIndex = 9;
            this.toolTip.SetToolTip(this.txtResult, "Running Log of Command/Commands");
            // 
            // lstRunResult
            // 
            this.lstRunResult.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lstRunResult.FormattingEnabled = true;
            this.lstRunResult.ItemHeight = 15;
            this.lstRunResult.Location = new System.Drawing.Point(183, 38);
            this.lstRunResult.Name = "lstRunResult";
            this.lstRunResult.Size = new System.Drawing.Size(105, 124);
            this.lstRunResult.TabIndex = 6;
            this.toolTip.SetToolTip(this.lstRunResult, "STAF commands run result on each host. The run result is checked by regex conditi" +
                    "on against command output");
            this.lstRunResult.SelectedIndexChanged += new System.EventHandler(this.lstRunResult_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDeleteFile);
            this.groupBox2.Controls.Add(this.btnAddFile);
            this.groupBox2.Controls.Add(this.txtFileFolderName);
            this.groupBox2.Controls.Add(this.lstSyncFileFolders);
            this.groupBox2.Location = new System.Drawing.Point(27, 429);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(253, 223);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "File/Folder to sync to";
            this.toolTip.SetToolTip(this.groupBox2, "Files and folders to sync to remote STAF host before run STAF commands");
            // 
            // btnDeleteFile
            // 
            this.btnDeleteFile.Location = new System.Drawing.Point(171, 177);
            this.btnDeleteFile.Name = "btnDeleteFile";
            this.btnDeleteFile.Size = new System.Drawing.Size(67, 24);
            this.btnDeleteFile.TabIndex = 4;
            this.btnDeleteFile.Text = "D&elete";
            this.btnDeleteFile.UseVisualStyleBackColor = true;
            this.btnDeleteFile.Click += new System.EventHandler(this.btnDeleteFile_Click);
            // 
            // btnAddFile
            // 
            this.btnAddFile.Location = new System.Drawing.Point(15, 178);
            this.btnAddFile.Name = "btnAddFile";
            this.btnAddFile.Size = new System.Drawing.Size(135, 24);
            this.btnAddFile.TabIndex = 3;
            this.btnAddFile.Text = "Add &File/Folder";
            this.btnAddFile.UseVisualStyleBackColor = true;
            this.btnAddFile.Click += new System.EventHandler(this.btnAddFile_Click);
            // 
            // txtFileFolderName
            // 
            this.txtFileFolderName.Location = new System.Drawing.Point(16, 148);
            this.txtFileFolderName.Name = "txtFileFolderName";
            this.txtFileFolderName.Size = new System.Drawing.Size(222, 25);
            this.txtFileFolderName.TabIndex = 1;
            // 
            // lstSyncFileFolders
            // 
            this.lstSyncFileFolders.AllowDrop = true;
            this.lstSyncFileFolders.FormattingEnabled = true;
            this.lstSyncFileFolders.HorizontalScrollbar = true;
            this.lstSyncFileFolders.ItemHeight = 15;
            this.lstSyncFileFolders.Location = new System.Drawing.Point(16, 25);
            this.lstSyncFileFolders.Name = "lstSyncFileFolders";
            this.lstSyncFileFolders.Size = new System.Drawing.Size(222, 109);
            this.lstSyncFileFolders.TabIndex = 0;
            this.lstSyncFileFolders.DragOver += new System.Windows.Forms.DragEventHandler(this.lstSyncFileFolders_DragOver);
            this.lstSyncFileFolders.DragDrop += new System.Windows.Forms.DragEventHandler(this.lstSyncFileFolders_DragDrop);
            this.lstSyncFileFolders.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstSyncFileFolders_MouseDown);
            this.lstSyncFileFolders.DragEnter += new System.Windows.Forms.DragEventHandler(this.lstSyncFileFolders_DragEnter);
            this.lstSyncFileFolders.DragLeave += new System.EventHandler(this.lstSyncFileFolders_DragLeave);
            // 
            // lstFilesBack
            // 
            this.lstFilesBack.AllowDrop = true;
            this.lstFilesBack.FormattingEnabled = true;
            this.lstFilesBack.HorizontalScrollbar = true;
            this.lstFilesBack.ItemHeight = 15;
            this.lstFilesBack.Location = new System.Drawing.Point(15, 25);
            this.lstFilesBack.Name = "lstFilesBack";
            this.lstFilesBack.Size = new System.Drawing.Size(231, 109);
            this.lstFilesBack.TabIndex = 0;
            this.toolTip.SetToolTip(this.lstFilesBack, "Files and Folders to get back after running STAF commands");
            this.lstFilesBack.DragOver += new System.Windows.Forms.DragEventHandler(this.lstFilesBack_DragOver);
            this.lstFilesBack.DragDrop += new System.Windows.Forms.DragEventHandler(this.lstFilesBack_DragDrop);
            this.lstFilesBack.DragEnter += new System.Windows.Forms.DragEventHandler(this.lstFilesBack_DragEnter);
            // 
            // txtCommand
            // 
            this.txtCommand.Location = new System.Drawing.Point(0, 18);
            this.txtCommand.Multiline = true;
            this.txtCommand.Name = "txtCommand";
            this.txtCommand.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtCommand.Size = new System.Drawing.Size(532, 80);
            this.txtCommand.TabIndex = 0;
            this.toolTip.SetToolTip(this.txtCommand, "Commands would be run on each remote STAF host");
            // 
            // txtCheckCondition
            // 
            this.txtCheckCondition.Location = new System.Drawing.Point(0, 15);
            this.txtCheckCondition.Multiline = true;
            this.txtCheckCondition.Name = "txtCheckCondition";
            this.txtCheckCondition.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtCheckCondition.Size = new System.Drawing.Size(532, 76);
            this.txtCheckCondition.TabIndex = 0;
            this.toolTip.SetToolTip(this.txtCheckCondition, "Regex to match on each STAF command output on each host");
            // 
            // chkDisableParallel
            // 
            this.chkDisableParallel.AutoSize = true;
            this.chkDisableParallel.Location = new System.Drawing.Point(586, 253);
            this.chkDisableParallel.Name = "chkDisableParallel";
            this.chkDisableParallel.Size = new System.Drawing.Size(157, 19);
            this.chkDisableParallel.TabIndex = 14;
            this.chkDisableParallel.Text = "Disable &Parallel";
            this.toolTip.SetToolTip(this.chkDisableParallel, "Disable parallel job execution on different hosts, so we can easily check the log" +
                    " one by one");
            this.chkDisableParallel.UseVisualStyleBackColor = true;
            // 
            // chkStafCommand
            // 
            this.chkStafCommand.AutoSize = true;
            this.chkStafCommand.Location = new System.Drawing.Point(586, 228);
            this.chkStafCommand.Name = "chkStafCommand";
            this.chkStafCommand.Size = new System.Drawing.Size(157, 19);
            this.chkStafCommand.TabIndex = 16;
            this.chkStafCommand.Text = "Run Staf Command";
            this.toolTip.SetToolTip(this.chkStafCommand, resources.GetString("chkStafCommand.ToolTip"));
            this.chkStafCommand.UseVisualStyleBackColor = true;
            // 
            // chkNoCheck
            // 
            this.chkNoCheck.AutoSize = true;
            this.chkNoCheck.Location = new System.Drawing.Point(749, 228);
            this.chkNoCheck.Name = "chkNoCheck";
            this.chkNoCheck.Size = new System.Drawing.Size(93, 19);
            this.chkNoCheck.TabIndex = 20;
            this.chkNoCheck.Text = "No Check";
            this.toolTip.SetToolTip(this.chkNoCheck, "Don\'t check the output");
            this.chkNoCheck.UseVisualStyleBackColor = true;
            // 
            // chkNoSync
            // 
            this.chkNoSync.AutoSize = true;
            this.chkNoSync.Location = new System.Drawing.Point(881, 228);
            this.chkNoSync.Name = "chkNoSync";
            this.chkNoSync.Size = new System.Drawing.Size(149, 19);
            this.chkNoSync.TabIndex = 21;
            this.chkNoSync.Text = "No Sync To/From";
            this.toolTip.SetToolTip(this.chkNoSync, "Don\'t sync to and from STAF host");
            this.chkNoSync.UseVisualStyleBackColor = true;
            // 
            // txtConsoleOutput
            // 
            this.txtConsoleOutput.BackColor = System.Drawing.SystemColors.Info;
            this.txtConsoleOutput.Location = new System.Drawing.Point(586, 343);
            this.txtConsoleOutput.Name = "txtConsoleOutput";
            this.txtConsoleOutput.Size = new System.Drawing.Size(657, 309);
            this.txtConsoleOutput.TabIndex = 22;
            this.txtConsoleOutput.Text = "";
            this.toolTip.SetToolTip(this.txtConsoleOutput, "Standard out and err for each STAF command run on each host");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 15);
            this.label1.TabIndex = 0;
            // 
            // txtHostAdd
            // 
            this.txtHostAdd.Location = new System.Drawing.Point(18, 173);
            this.txtHostAdd.Name = "txtHostAdd";
            this.txtHostAdd.Size = new System.Drawing.Size(100, 25);
            this.txtHostAdd.TabIndex = 3;
            // 
            // btnAddHost
            // 
            this.btnAddHost.Location = new System.Drawing.Point(126, 172);
            this.btnAddHost.Name = "btnAddHost";
            this.btnAddHost.Size = new System.Drawing.Size(90, 23);
            this.btnAddHost.TabIndex = 4;
            this.btnAddHost.Text = "&Add";
            this.btnAddHost.UseVisualStyleBackColor = true;
            this.btnAddHost.Click += new System.EventHandler(this.btnAddHost_Click);
            // 
            // btnDelHost
            // 
            this.btnDelHost.Location = new System.Drawing.Point(222, 172);
            this.btnDelHost.Name = "btnDelHost";
            this.btnDelHost.Size = new System.Drawing.Size(75, 23);
            this.btnDelHost.TabIndex = 5;
            this.btnDelHost.Text = "&Delete";
            this.btnDelHost.UseVisualStyleBackColor = true;
            this.btnDelHost.Click += new System.EventHandler(this.btnDelHost_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtResult);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lstRunResult);
            this.groupBox1.Controls.Add(this.lstHostList);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnDelHost);
            this.groupBox1.Controls.Add(this.txtHostAdd);
            this.groupBox1.Controls.Add(this.btnAddHost);
            this.groupBox1.Location = new System.Drawing.Point(27, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1222, 209);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Staf Host List";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(185, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Run Result";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Staf Host List";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnDeleteFileBack);
            this.groupBox3.Controls.Add(this.btnAddFileBack);
            this.groupBox3.Controls.Add(this.txtFilesBack);
            this.groupBox3.Controls.Add(this.lstFilesBack);
            this.groupBox3.Location = new System.Drawing.Point(299, 429);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(260, 223);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "File/Folder to sync from";
            // 
            // btnDeleteFileBack
            // 
            this.btnDeleteFileBack.Location = new System.Drawing.Point(167, 178);
            this.btnDeleteFileBack.Name = "btnDeleteFileBack";
            this.btnDeleteFileBack.Size = new System.Drawing.Size(79, 24);
            this.btnDeleteFileBack.TabIndex = 4;
            this.btnDeleteFileBack.Text = "Dele&te";
            this.btnDeleteFileBack.UseVisualStyleBackColor = true;
            this.btnDeleteFileBack.Click += new System.EventHandler(this.btnDeleteFileBack_Click);
            // 
            // btnAddFileBack
            // 
            this.btnAddFileBack.Location = new System.Drawing.Point(18, 177);
            this.btnAddFileBack.Name = "btnAddFileBack";
            this.btnAddFileBack.Size = new System.Drawing.Size(143, 24);
            this.btnAddFileBack.TabIndex = 3;
            this.btnAddFileBack.Text = "Add File/Folde&r";
            this.btnAddFileBack.UseVisualStyleBackColor = true;
            this.btnAddFileBack.Click += new System.EventHandler(this.btnAddFileBack_Click);
            // 
            // txtFilesBack
            // 
            this.txtFilesBack.Location = new System.Drawing.Point(18, 147);
            this.txtFilesBack.Name = "txtFilesBack";
            this.txtFilesBack.Size = new System.Drawing.Size(228, 25);
            this.txtFilesBack.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtCommand);
            this.groupBox4.Location = new System.Drawing.Point(27, 216);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(532, 106);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Commands To Run on STAF hosts";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(930, 279);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(57, 31);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "&Save ";
            this.toolTip.SetToolTip(this.btnSave, "Save all inputs");
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(668, 280);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(66, 30);
            this.btnRun.TabIndex = 12;
            this.btnRun.Text = "&Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtCheckCondition);
            this.groupBox5.Location = new System.Drawing.Point(27, 328);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(532, 94);
            this.groupBox5.TabIndex = 13;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Output To Check (regex match on command output)";
            // 
            // btnPing
            // 
            this.btnPing.Location = new System.Drawing.Point(586, 280);
            this.btnPing.Name = "btnPing";
            this.btnPing.Size = new System.Drawing.Size(62, 30);
            this.btnPing.TabIndex = 15;
            this.btnPing.Text = "&Ping";
            this.btnPing.UseVisualStyleBackColor = true;
            this.btnPing.Click += new System.EventHandler(this.btnPing_Click);
            // 
            // chkShowDebugInfo
            // 
            this.chkShowDebugInfo.AutoSize = true;
            this.chkShowDebugInfo.Checked = true;
            this.chkShowDebugInfo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowDebugInfo.Location = new System.Drawing.Point(749, 253);
            this.chkShowDebugInfo.Name = "chkShowDebugInfo";
            this.chkShowDebugInfo.Size = new System.Drawing.Size(237, 19);
            this.chkShowDebugInfo.TabIndex = 17;
            this.chkShowDebugInfo.Text = "Show STAF cmd and response";
            this.chkShowDebugInfo.UseVisualStyleBackColor = true;
            // 
            // btnShowRunLog
            // 
            this.btnShowRunLog.Location = new System.Drawing.Point(749, 280);
            this.btnShowRunLog.Name = "btnShowRunLog";
            this.btnShowRunLog.Size = new System.Drawing.Size(116, 30);
            this.btnShowRunLog.TabIndex = 18;
            this.btnShowRunLog.Text = "Show Run &Log";
            this.btnShowRunLog.UseVisualStyleBackColor = true;
            this.btnShowRunLog.Click += new System.EventHandler(this.btnShowRunLog_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(1004, 279);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(57, 31);
            this.btnQuit.TabIndex = 23;
            this.btnQuit.Text = "&Quit";
            this.toolTip.SetToolTip(this.btnQuit, "Save inputs and quit");
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnQuitWithoutSave
            // 
            this.btnQuitWithoutSave.Location = new System.Drawing.Point(1078, 279);
            this.btnQuitWithoutSave.Name = "btnQuitWithoutSave";
            this.btnQuitWithoutSave.Size = new System.Drawing.Size(155, 31);
            this.btnQuitWithoutSave.TabIndex = 24;
            this.btnQuitWithoutSave.Text = "Quit &Without Save";
            this.btnQuitWithoutSave.UseVisualStyleBackColor = true;
            this.btnQuitWithoutSave.Click += new System.EventHandler(this.btnQuitWithoutSave_Click);
            // 
            // ParaStafForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1255, 674);
            this.Controls.Add(this.btnQuitWithoutSave);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.txtConsoleOutput);
            this.Controls.Add(this.chkNoSync);
            this.Controls.Add(this.chkNoCheck);
            this.Controls.Add(this.chkStafCommand);
            this.Controls.Add(this.btnShowRunLog);
            this.Controls.Add(this.chkShowDebugInfo);
            this.Controls.Add(this.btnPing);
            this.Controls.Add(this.chkDisableParallel);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ParaStafForm";
            this.Text = "Parallel STAF - Run your tasks on multi platforms parallely in an intuitive way";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstHostList;
        private System.Windows.Forms.TextBox txtHostAdd;
        private System.Windows.Forms.Button btnAddHost;
        private System.Windows.Forms.Button btnDelHost;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lstSyncFileFolders;
        private System.Windows.Forms.TextBox txtFileFolderName;
        private System.Windows.Forms.Button btnDeleteFile;
        private System.Windows.Forms.Button btnAddFile;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnDeleteFileBack;
        private System.Windows.Forms.Button btnAddFileBack;
        private System.Windows.Forms.TextBox txtFilesBack;
        private System.Windows.Forms.ListBox lstFilesBack;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtCommand;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtCheckCondition;
        private System.Windows.Forms.ListBox lstRunResult;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.CheckBox chkDisableParallel;
        private System.Windows.Forms.Button btnPing;
        private System.Windows.Forms.CheckBox chkStafCommand;
        private System.Windows.Forms.CheckBox chkShowDebugInfo;
        private System.Windows.Forms.Button btnShowRunLog;
        private System.Windows.Forms.CheckBox chkNoCheck;
        private System.Windows.Forms.CheckBox chkNoSync;
        private System.Windows.Forms.RichTextBox txtConsoleOutput;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button btnQuitWithoutSave;
    }
}

