namespace Bokka
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTicket = new System.Windows.Forms.Label();
            this.lblCP = new System.Windows.Forms.Label();
            this.cmbTicketUseEach = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtLimitCp = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbLimitTicket = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnMenuIndexClear = new System.Windows.Forms.Button();
            this.txtMenuIndexBivouac = new System.Windows.Forms.NumericUpDown();
            this.txtMenuIndexArea = new System.Windows.Forms.NumericUpDown();
            this.txtMenuIndexWorksCall = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnExec = new System.Windows.Forms.Button();
            this.toolStrip = new System.Windows.Forms.StatusStrip();
            this.lblMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.cmbPol = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.timDebug = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.lblX = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblY = new System.Windows.Forms.Label();
            this.laben13 = new System.Windows.Forms.Label();
            this.lblZ = new System.Windows.Forms.Label();
            this.btnPolAttach = new System.Windows.Forms.Button();
            this.btnPolUpdate = new System.Windows.Forms.Button();
            this.tips = new System.Windows.Forms.ToolTip(this.components);
            this.wkBokka = new System.ComponentModel.BackgroundWorker();
            this.label12 = new System.Windows.Forms.Label();
            this.lblDialogIndex = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblDialogOptionCount = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.txtDialogQuestion = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.lblPlayerName = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblIsMenuOpen = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnCouToWaypoint = new System.Windows.Forms.Button();
            this.btnWaypointToCOU = new System.Windows.Forms.Button();
            this.timMonitor = new System.Windows.Forms.Timer(this.components);
            this.label17 = new System.Windows.Forms.Label();
            this.lblTargetIndex = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lblDialogID = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.lblLoginStatus = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLimitCp)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMenuIndexBivouac)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMenuIndexArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMenuIndexWorksCall)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(2, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "チケット:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(105, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "CP:";
            // 
            // lblTicket
            // 
            this.lblTicket.AutoSize = true;
            this.lblTicket.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTicket.Location = new System.Drawing.Point(65, 3);
            this.lblTicket.Name = "lblTicket";
            this.lblTicket.Size = new System.Drawing.Size(29, 20);
            this.lblTicket.TabIndex = 0;
            this.lblTicket.Text = "99";
            // 
            // lblCP
            // 
            this.lblCP.AutoSize = true;
            this.lblCP.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblCP.Location = new System.Drawing.Point(145, 3);
            this.lblCP.Name = "lblCP";
            this.lblCP.Size = new System.Drawing.Size(91, 20);
            this.lblCP.TabIndex = 0;
            this.lblCP.Text = "9,999,999";
            // 
            // cmbTicketUseEach
            // 
            this.cmbTicketUseEach.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTicketUseEach.FormattingEnabled = true;
            this.cmbTicketUseEach.Location = new System.Drawing.Point(63, 14);
            this.cmbTicketUseEach.Name = "cmbTicketUseEach";
            this.cmbTicketUseEach.Size = new System.Drawing.Size(39, 22);
            this.cmbTicketUseEach.TabIndex = 1;
            this.cmbTicketUseEach.SelectedIndexChanged += new System.EventHandler(this.cmbTicketUseEach_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbTicketUseEach);
            this.groupBox1.Location = new System.Drawing.Point(6, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(230, 42);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "動作設定";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 14);
            this.label4.TabIndex = 3;
            this.label4.Text = "使用枚数:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtLimitCp);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cmbLimitTicket);
            this.groupBox2.Location = new System.Drawing.Point(6, 69);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(230, 42);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "停止条件";
            // 
            // txtLimitCp
            // 
            this.txtLimitCp.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.txtLimitCp.Location = new System.Drawing.Point(148, 15);
            this.txtLimitCp.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.txtLimitCp.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.txtLimitCp.Name = "txtLimitCp";
            this.txtLimitCp.Size = new System.Drawing.Size(76, 21);
            this.txtLimitCp.TabIndex = 6;
            this.txtLimitCp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtLimitCp.Value = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.txtLimitCp.ValueChanged += new System.EventHandler(this.txtLimitCp_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(113, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 14);
            this.label7.TabIndex = 3;
            this.label7.Text = "残CP:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 14);
            this.label6.TabIndex = 3;
            this.label6.Text = "残チケット:";
            // 
            // cmbLimitTicket
            // 
            this.cmbLimitTicket.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLimitTicket.FormattingEnabled = true;
            this.cmbLimitTicket.Location = new System.Drawing.Point(63, 14);
            this.cmbLimitTicket.Name = "cmbLimitTicket";
            this.cmbLimitTicket.Size = new System.Drawing.Size(39, 22);
            this.cmbLimitTicket.TabIndex = 1;
            this.cmbLimitTicket.SelectedIndexChanged += new System.EventHandler(this.cmbLimitTicket_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnMenuIndexClear);
            this.groupBox3.Controls.Add(this.txtMenuIndexBivouac);
            this.groupBox3.Controls.Add(this.txtMenuIndexArea);
            this.groupBox3.Controls.Add(this.txtMenuIndexWorksCall);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Location = new System.Drawing.Point(6, 112);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(230, 86);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "メニューインデックス";
            // 
            // btnMenuIndexClear
            // 
            this.btnMenuIndexClear.Location = new System.Drawing.Point(151, 15);
            this.btnMenuIndexClear.Name = "btnMenuIndexClear";
            this.btnMenuIndexClear.Size = new System.Drawing.Size(28, 65);
            this.btnMenuIndexClear.TabIndex = 3;
            this.btnMenuIndexClear.Text = "ク\r\nリ\r\nア";
            this.btnMenuIndexClear.UseVisualStyleBackColor = true;
            this.btnMenuIndexClear.Click += new System.EventHandler(this.btnMenuIndexClear_Click);
            // 
            // txtMenuIndexBivouac
            // 
            this.txtMenuIndexBivouac.Location = new System.Drawing.Point(110, 59);
            this.txtMenuIndexBivouac.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.txtMenuIndexBivouac.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.txtMenuIndexBivouac.Name = "txtMenuIndexBivouac";
            this.txtMenuIndexBivouac.Size = new System.Drawing.Size(40, 21);
            this.txtMenuIndexBivouac.TabIndex = 3;
            this.txtMenuIndexBivouac.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMenuIndexBivouac.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.txtMenuIndexBivouac.ValueChanged += new System.EventHandler(this.txtMenuIndexBivouac_ValueChanged);
            // 
            // txtMenuIndexArea
            // 
            this.txtMenuIndexArea.Location = new System.Drawing.Point(110, 37);
            this.txtMenuIndexArea.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.txtMenuIndexArea.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.txtMenuIndexArea.Name = "txtMenuIndexArea";
            this.txtMenuIndexArea.Size = new System.Drawing.Size(40, 21);
            this.txtMenuIndexArea.TabIndex = 3;
            this.txtMenuIndexArea.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMenuIndexArea.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.txtMenuIndexArea.ValueChanged += new System.EventHandler(this.txtMenuIndexArea_ValueChanged);
            // 
            // txtMenuIndexWorksCall
            // 
            this.txtMenuIndexWorksCall.Location = new System.Drawing.Point(110, 15);
            this.txtMenuIndexWorksCall.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.txtMenuIndexWorksCall.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.txtMenuIndexWorksCall.Name = "txtMenuIndexWorksCall";
            this.txtMenuIndexWorksCall.Size = new System.Drawing.Size(40, 21);
            this.txtMenuIndexWorksCall.TabIndex = 3;
            this.txtMenuIndexWorksCall.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMenuIndexWorksCall.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.txtMenuIndexWorksCall.ValueChanged += new System.EventHandler(this.txtMenuIndexWorksCall_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 61);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 14);
            this.label10.TabIndex = 3;
            this.label10.Text = "ビバック インデックス:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 39);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 14);
            this.label8.TabIndex = 3;
            this.label8.Text = "エリア インデックス:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(107, 14);
            this.label9.TabIndex = 3;
            this.label9.Text = "戦略物資 インデックス:";
            // 
            // btnExec
            // 
            this.btnExec.Font = new System.Drawing.Font("Meiryo UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnExec.Location = new System.Drawing.Point(6, 198);
            this.btnExec.Name = "btnExec";
            this.btnExec.Size = new System.Drawing.Size(230, 34);
            this.btnExec.TabIndex = 3;
            this.btnExec.Text = "開　　始";
            this.btnExec.UseVisualStyleBackColor = true;
            this.btnExec.Click += new System.EventHandler(this.btnExec_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblMessage});
            this.toolStrip.Location = new System.Drawing.Point(0, 260);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(242, 22);
            this.toolStrip.TabIndex = 4;
            this.toolStrip.Text = "statusStrip1";
            // 
            // lblMessage
            // 
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(52, 17);
            this.lblMessage.Text = "メッセージ";
            // 
            // cmbPol
            // 
            this.cmbPol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPol.FormattingEnabled = true;
            this.cmbPol.Location = new System.Drawing.Point(35, 232);
            this.cmbPol.Name = "cmbPol";
            this.cmbPol.Size = new System.Drawing.Size(150, 22);
            this.cmbPol.TabIndex = 1;
            this.tips.SetToolTip(this.cmbPol, "POLを選択");
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 235);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 14);
            this.label11.TabIndex = 3;
            this.label11.Text = "POL:";
            // 
            // timDebug
            // 
            this.timDebug.Tick += new System.EventHandler(this.timDebug_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Meiryo UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(242, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 14);
            this.label3.TabIndex = 3;
            this.label3.Text = "X:";
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Location = new System.Drawing.Point(257, 37);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(44, 14);
            this.lblX.TabIndex = 3;
            this.lblX.Text = "-999.9";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Meiryo UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.Location = new System.Drawing.Point(371, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 14);
            this.label5.TabIndex = 3;
            this.label5.Text = "Y:";
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Location = new System.Drawing.Point(386, 37);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(44, 14);
            this.lblY.TabIndex = 3;
            this.lblY.Text = "-999.9";
            // 
            // laben13
            // 
            this.laben13.AutoSize = true;
            this.laben13.Font = new System.Drawing.Font("Meiryo UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.laben13.Location = new System.Drawing.Point(304, 37);
            this.laben13.Name = "laben13";
            this.laben13.Size = new System.Drawing.Size(18, 14);
            this.laben13.TabIndex = 3;
            this.laben13.Text = "Z:";
            // 
            // lblZ
            // 
            this.lblZ.AutoSize = true;
            this.lblZ.Location = new System.Drawing.Point(319, 37);
            this.lblZ.Name = "lblZ";
            this.lblZ.Size = new System.Drawing.Size(44, 14);
            this.lblZ.TabIndex = 3;
            this.lblZ.Text = "-999.9";
            // 
            // btnPolAttach
            // 
            this.btnPolAttach.Image = global::Bokka.Properties.Resources.IMAGE_SELECT;
            this.btnPolAttach.Location = new System.Drawing.Point(188, 232);
            this.btnPolAttach.Name = "btnPolAttach";
            this.btnPolAttach.Size = new System.Drawing.Size(24, 22);
            this.btnPolAttach.TabIndex = 5;
            this.tips.SetToolTip(this.btnPolAttach, "選択したPOLにアタッチ");
            this.btnPolAttach.UseVisualStyleBackColor = true;
            this.btnPolAttach.Click += new System.EventHandler(this.btnPolAttach_Click);
            // 
            // btnPolUpdate
            // 
            this.btnPolUpdate.Image = global::Bokka.Properties.Resources.IMAGE_REFRESH;
            this.btnPolUpdate.Location = new System.Drawing.Point(212, 232);
            this.btnPolUpdate.Name = "btnPolUpdate";
            this.btnPolUpdate.Size = new System.Drawing.Size(24, 22);
            this.btnPolUpdate.TabIndex = 5;
            this.tips.SetToolTip(this.btnPolUpdate, "リストを更新する");
            this.btnPolUpdate.UseVisualStyleBackColor = true;
            this.btnPolUpdate.Click += new System.EventHandler(this.btnPolUpdate_Click);
            // 
            // wkBokka
            // 
            this.wkBokka.WorkerSupportsCancellation = true;
            this.wkBokka.DoWork += new System.ComponentModel.DoWorkEventHandler(this.wkBokka_DoWork);
            this.wkBokka.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.wkBokka_RunWorkerCompleted);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Meiryo UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label12.Location = new System.Drawing.Point(242, 93);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(81, 14);
            this.label12.TabIndex = 7;
            this.label12.Text = "DialogIndex:";
            // 
            // lblDialogIndex
            // 
            this.lblDialogIndex.AutoSize = true;
            this.lblDialogIndex.Location = new System.Drawing.Point(319, 93);
            this.lblDialogIndex.Name = "lblDialogIndex";
            this.lblDialogIndex.Size = new System.Drawing.Size(21, 14);
            this.lblDialogIndex.TabIndex = 7;
            this.lblDialogIndex.Text = "99";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Meiryo UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label13.Location = new System.Drawing.Point(344, 93);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(88, 14);
            this.label13.TabIndex = 7;
            this.label13.Text = "DialogOptCnt:";
            // 
            // lblDialogOptionCount
            // 
            this.lblDialogOptionCount.AutoSize = true;
            this.lblDialogOptionCount.Location = new System.Drawing.Point(428, 93);
            this.lblDialogOptionCount.Name = "lblDialogOptionCount";
            this.lblDialogOptionCount.Size = new System.Drawing.Size(21, 14);
            this.lblDialogOptionCount.TabIndex = 7;
            this.lblDialogOptionCount.Text = "99";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Meiryo UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label20.Location = new System.Drawing.Point(242, 107);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(98, 14);
            this.label20.TabIndex = 7;
            this.label20.Text = "DialogQuestion:";
            // 
            // txtDialogQuestion
            // 
            this.txtDialogQuestion.Location = new System.Drawing.Point(245, 124);
            this.txtDialogQuestion.Name = "txtDialogQuestion";
            this.txtDialogQuestion.ReadOnly = true;
            this.txtDialogQuestion.Size = new System.Drawing.Size(197, 21);
            this.txtDialogQuestion.TabIndex = 8;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Meiryo UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label14.Location = new System.Drawing.Point(242, 9);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(48, 14);
            this.label14.TabIndex = 3;
            this.label14.Text = "Player:";
            // 
            // lblPlayerName
            // 
            this.lblPlayerName.AutoSize = true;
            this.lblPlayerName.Location = new System.Drawing.Point(286, 9);
            this.lblPlayerName.Name = "lblPlayerName";
            this.lblPlayerName.Size = new System.Drawing.Size(77, 14);
            this.lblPlayerName.TabIndex = 3;
            this.lblPlayerName.Text = "XXXXXXXXXX";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Meiryo UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label15.Location = new System.Drawing.Point(242, 51);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(84, 14);
            this.label15.TabIndex = 7;
            this.label15.Text = "IsMenuOpen:";
            // 
            // lblIsMenuOpen
            // 
            this.lblIsMenuOpen.AutoSize = true;
            this.lblIsMenuOpen.Location = new System.Drawing.Point(322, 51);
            this.lblIsMenuOpen.Name = "lblIsMenuOpen";
            this.lblIsMenuOpen.Size = new System.Drawing.Size(42, 14);
            this.lblIsMenuOpen.TabIndex = 7;
            this.lblIsMenuOpen.Text = "XXXXX";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Meiryo UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label16.Location = new System.Drawing.Point(242, 23);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(48, 14);
            this.label16.TabIndex = 3;
            this.label16.Text = "Status:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(286, 23);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(21, 14);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "XX";
            // 
            // btnCouToWaypoint
            // 
            this.btnCouToWaypoint.Location = new System.Drawing.Point(245, 231);
            this.btnCouToWaypoint.Name = "btnCouToWaypoint";
            this.btnCouToWaypoint.Size = new System.Drawing.Size(100, 23);
            this.btnCouToWaypoint.TabIndex = 9;
            this.btnCouToWaypoint.Text = "COU→Waypoint";
            this.btnCouToWaypoint.UseVisualStyleBackColor = true;
            this.btnCouToWaypoint.Click += new System.EventHandler(this.btnCouToWaypoint_Click);
            // 
            // btnWaypointToCOU
            // 
            this.btnWaypointToCOU.Location = new System.Drawing.Point(347, 231);
            this.btnWaypointToCOU.Name = "btnWaypointToCOU";
            this.btnWaypointToCOU.Size = new System.Drawing.Size(100, 23);
            this.btnWaypointToCOU.TabIndex = 9;
            this.btnWaypointToCOU.Text = "Waypoint→COU";
            this.btnWaypointToCOU.UseVisualStyleBackColor = true;
            this.btnWaypointToCOU.Click += new System.EventHandler(this.btnWaypointToCOU_Click);
            // 
            // timMonitor
            // 
            this.timMonitor.Tick += new System.EventHandler(this.timMonitor_Tick);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Meiryo UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label17.Location = new System.Drawing.Point(242, 65);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(82, 14);
            this.label17.TabIndex = 7;
            this.label17.Text = "TargetIndex:";
            // 
            // lblTargetIndex
            // 
            this.lblTargetIndex.AutoSize = true;
            this.lblTargetIndex.Location = new System.Drawing.Point(325, 65);
            this.lblTargetIndex.Name = "lblTargetIndex";
            this.lblTargetIndex.Size = new System.Drawing.Size(42, 14);
            this.lblTargetIndex.TabIndex = 7;
            this.lblTargetIndex.Text = "XXXXX";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Meiryo UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label18.Location = new System.Drawing.Point(242, 79);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(62, 14);
            this.label18.TabIndex = 7;
            this.label18.Text = "DialogID:";
            // 
            // lblDialogID
            // 
            this.lblDialogID.AutoSize = true;
            this.lblDialogID.Location = new System.Drawing.Point(301, 79);
            this.lblDialogID.Name = "lblDialogID";
            this.lblDialogID.Size = new System.Drawing.Size(21, 14);
            this.lblDialogID.TabIndex = 7;
            this.lblDialogID.Text = "99";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Meiryo UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label19.Location = new System.Drawing.Point(313, 23);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(79, 14);
            this.label19.TabIndex = 3;
            this.label19.Text = "LoginStatus:";
            // 
            // lblLoginStatus
            // 
            this.lblLoginStatus.AutoSize = true;
            this.lblLoginStatus.Location = new System.Drawing.Point(389, 23);
            this.lblLoginStatus.Name = "lblLoginStatus";
            this.lblLoginStatus.Size = new System.Drawing.Size(21, 14);
            this.lblLoginStatus.TabIndex = 3;
            this.lblLoginStatus.Text = "XX";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 282);
            this.Controls.Add(this.btnWaypointToCOU);
            this.Controls.Add(this.btnCouToWaypoint);
            this.Controls.Add(this.txtDialogQuestion);
            this.Controls.Add(this.lblDialogOptionCount);
            this.Controls.Add(this.lblDialogID);
            this.Controls.Add(this.lblDialogIndex);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.lblTargetIndex);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.lblIsMenuOpen);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cmbPol);
            this.Controls.Add(this.btnPolUpdate);
            this.Controls.Add(this.btnPolAttach);
            this.Controls.Add(this.lblZ);
            this.Controls.Add(this.laben13);
            this.Controls.Add(this.lblY);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblX);
            this.Controls.Add(this.lblLoginStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblPlayerName);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.btnExec);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblCP);
            this.Controls.Add(this.lblTicket);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Meiryo UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "歩荷";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLimitCp)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMenuIndexBivouac)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMenuIndexArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMenuIndexWorksCall)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTicketUseEach;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbLimitTicket;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnMenuIndexClear;
        private System.Windows.Forms.NumericUpDown txtMenuIndexBivouac;
        private System.Windows.Forms.NumericUpDown txtMenuIndexArea;
        private System.Windows.Forms.NumericUpDown txtMenuIndexWorksCall;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnExec;
        private System.Windows.Forms.StatusStrip toolStrip;
        private System.Windows.Forms.ComboBox cmbPol;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ToolStripStatusLabel lblMessage;
        private System.Windows.Forms.Timer timDebug;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.Label laben13;
        private System.Windows.Forms.Label lblZ;
        private System.Windows.Forms.Button btnPolAttach;
        private System.Windows.Forms.Button btnPolUpdate;
        private System.Windows.Forms.ToolTip tips;
        private System.Windows.Forms.NumericUpDown txtLimitCp;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblDialogIndex;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblDialogOptionCount;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtDialogQuestion;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblPlayerName;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblIsMenuOpen;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblStatus;
        public System.Windows.Forms.Label lblTicket;
        public System.Windows.Forms.Label lblCP;
        public System.ComponentModel.BackgroundWorker wkBokka;
        private System.Windows.Forms.Button btnCouToWaypoint;
        private System.Windows.Forms.Button btnWaypointToCOU;
        private System.Windows.Forms.Timer timMonitor;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblTargetIndex;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lblDialogID;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lblLoginStatus;
    }
}

