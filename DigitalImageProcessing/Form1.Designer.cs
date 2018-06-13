namespace DigitalImageProcessing
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this._loadSourceImageButton = new System.Windows.Forms.Button();
            this._grayButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this._HistogramEqualizationButton = new System.Windows.Forms.Button();
            this._OtsuButton = new System.Windows.Forms.Button();
            this._blendingButton = new System.Windows.Forms.Button();
            this._mirrorButton = new System.Windows.Forms.Button();
            this._RotatingButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.RemovingBackgrounds_Button = new System.Windows.Forms.Button();
            this._gameButton = new System.Windows.Forms.Button();
            this._findPedestrianButton = new System.Windows.Forms.Button();
            this._CamshiftButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this._openCameraButton = new System.Windows.Forms.Button();
            this.foregroundLabel = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.saveResultImageButton = new System.Windows.Forms.Button();
            this.resultLabel = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this._Threshold_Label = new System.Windows.Forms.Label();
            this._Threshold_trackBar = new System.Windows.Forms.TrackBar();
            this._Threshold_max_Label = new System.Windows.Forms.Label();
            this._Threshold_min_Label = new System.Windows.Forms.Label();
            this._sourcePictureBox = new System.Windows.Forms.PictureBox();
            this._resultPictureBox = new System.Windows.Forms.PictureBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Threshold_trackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._sourcePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._resultPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // _loadSourceImageButton
            // 
            this._loadSourceImageButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this._loadSourceImageButton.Font = new System.Drawing.Font("微軟正黑體", 14.25F);
            this._loadSourceImageButton.Location = new System.Drawing.Point(385, 9);
            this._loadSourceImageButton.Name = "_loadSourceImageButton";
            this._loadSourceImageButton.Size = new System.Drawing.Size(135, 40);
            this._loadSourceImageButton.TabIndex = 1;
            this._loadSourceImageButton.Text = "Load Image";
            this._loadSourceImageButton.UseVisualStyleBackColor = true;
            this._loadSourceImageButton.Click += new System.EventHandler(this._loadSourceImageButton_Click);
            // 
            // _grayButton
            // 
            this._grayButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._grayButton.Font = new System.Drawing.Font("微軟正黑體", 14.25F);
            this._grayButton.Location = new System.Drawing.Point(359, 3);
            this._grayButton.Name = "_grayButton";
            this._grayButton.Size = new System.Drawing.Size(76, 60);
            this._grayButton.TabIndex = 1;
            this._grayButton.Text = "灰階";
            this._grayButton.UseVisualStyleBackColor = true;
            this._grayButton.Click += new System.EventHandler(this._grayButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.03524F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.96476F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel6, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this._sourcePictureBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this._resultPictureBox, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83.88889F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 73F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1065, 568);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this._HistogramEqualizationButton);
            this.panel1.Controls.Add(this._OtsuButton);
            this.panel1.Controls.Add(this._blendingButton);
            this.panel1.Controls.Add(this._mirrorButton);
            this.panel1.Controls.Add(this._RotatingButton);
            this.panel1.Controls.Add(this._grayButton);
            this.panel1.Location = new System.Drawing.Point(536, 496);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(525, 68);
            this.panel1.TabIndex = 4;
            // 
            // _HistogramEqualizationButton
            // 
            this._HistogramEqualizationButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._HistogramEqualizationButton.Font = new System.Drawing.Font("微軟正黑體", 14.25F);
            this._HistogramEqualizationButton.Location = new System.Drawing.Point(3, 3);
            this._HistogramEqualizationButton.Name = "_HistogramEqualizationButton";
            this._HistogramEqualizationButton.Size = new System.Drawing.Size(84, 60);
            this._HistogramEqualizationButton.TabIndex = 1;
            this._HistogramEqualizationButton.Text = "值方圖均等化";
            this._HistogramEqualizationButton.UseVisualStyleBackColor = true;
            this._HistogramEqualizationButton.Click += new System.EventHandler(this._HistogramEqualizationButton_Click);
            // 
            // _OtsuButton
            // 
            this._OtsuButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._OtsuButton.Font = new System.Drawing.Font("微軟正黑體", 14.25F);
            this._OtsuButton.Location = new System.Drawing.Point(93, 3);
            this._OtsuButton.Name = "_OtsuButton";
            this._OtsuButton.Size = new System.Drawing.Size(77, 60);
            this._OtsuButton.TabIndex = 1;
            this._OtsuButton.Text = "二值化";
            this._OtsuButton.UseVisualStyleBackColor = true;
            this._OtsuButton.Click += new System.EventHandler(this._OtsuButton_Click);
            // 
            // _blendingButton
            // 
            this._blendingButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._blendingButton.Font = new System.Drawing.Font("微軟正黑體", 14.25F);
            this._blendingButton.Location = new System.Drawing.Point(174, 3);
            this._blendingButton.Name = "_blendingButton";
            this._blendingButton.Size = new System.Drawing.Size(99, 60);
            this._blendingButton.TabIndex = 1;
            this._blendingButton.Text = "透明度影像合成";
            this._blendingButton.UseVisualStyleBackColor = true;
            this._blendingButton.Click += new System.EventHandler(this._blendingButton_Click);
            // 
            // _mirrorButton
            // 
            this._mirrorButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._mirrorButton.Font = new System.Drawing.Font("微軟正黑體", 14.25F);
            this._mirrorButton.Location = new System.Drawing.Point(441, 3);
            this._mirrorButton.Name = "_mirrorButton";
            this._mirrorButton.Size = new System.Drawing.Size(79, 60);
            this._mirrorButton.TabIndex = 1;
            this._mirrorButton.Text = "鏡像";
            this._mirrorButton.UseVisualStyleBackColor = true;
            this._mirrorButton.Click += new System.EventHandler(this._mirrorButton_Click);
            // 
            // _RotatingButton
            // 
            this._RotatingButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._RotatingButton.Font = new System.Drawing.Font("微軟正黑體", 14.25F);
            this._RotatingButton.Location = new System.Drawing.Point(279, 3);
            this._RotatingButton.Name = "_RotatingButton";
            this._RotatingButton.Size = new System.Drawing.Size(74, 60);
            this._RotatingButton.TabIndex = 1;
            this._RotatingButton.Text = "旋轉";
            this._RotatingButton.UseVisualStyleBackColor = true;
            this._RotatingButton.Click += new System.EventHandler(this._RotatingButton_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.RemovingBackgrounds_Button);
            this.panel2.Controls.Add(this._gameButton);
            this.panel2.Controls.Add(this._findPedestrianButton);
            this.panel2.Controls.Add(this._CamshiftButton);
            this.panel2.Location = new System.Drawing.Point(4, 496);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(525, 68);
            this.panel2.TabIndex = 5;
            // 
            // RemovingBackgrounds_Button
            // 
            this.RemovingBackgrounds_Button.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.RemovingBackgrounds_Button.Font = new System.Drawing.Font("微軟正黑體", 14.25F);
            this.RemovingBackgrounds_Button.Location = new System.Drawing.Point(253, 3);
            this.RemovingBackgrounds_Button.Name = "RemovingBackgrounds_Button";
            this.RemovingBackgrounds_Button.Size = new System.Drawing.Size(109, 60);
            this.RemovingBackgrounds_Button.TabIndex = 1;
            this.RemovingBackgrounds_Button.Text = "藍幕去背";
            this.RemovingBackgrounds_Button.UseVisualStyleBackColor = true;
            this.RemovingBackgrounds_Button.Click += new System.EventHandler(this.RemovingBackgrounds_Button_Click);
            // 
            // _gameButton
            // 
            this._gameButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._gameButton.Font = new System.Drawing.Font("微軟正黑體", 14.25F);
            this._gameButton.Location = new System.Drawing.Point(385, 3);
            this._gameButton.Name = "_gameButton";
            this._gameButton.Size = new System.Drawing.Size(116, 60);
            this._gameButton.TabIndex = 1;
            this._gameButton.Text = "電流急急棒";
            this._gameButton.UseVisualStyleBackColor = true;
            this._gameButton.Click += new System.EventHandler(this._gameButton_Click);
            // 
            // _findPedestrianButton
            // 
            this._findPedestrianButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._findPedestrianButton.Cursor = System.Windows.Forms.Cursors.Default;
            this._findPedestrianButton.Font = new System.Drawing.Font("微軟正黑體", 14.25F);
            this._findPedestrianButton.Location = new System.Drawing.Point(125, 3);
            this._findPedestrianButton.Name = "_findPedestrianButton";
            this._findPedestrianButton.Size = new System.Drawing.Size(112, 60);
            this._findPedestrianButton.TabIndex = 1;
            this._findPedestrianButton.Text = "行人偵測";
            this._findPedestrianButton.UseVisualStyleBackColor = true;
            this._findPedestrianButton.Click += new System.EventHandler(this._findPedestrianButton_Click);
            // 
            // _CamshiftButton
            // 
            this._CamshiftButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._CamshiftButton.Font = new System.Drawing.Font("微軟正黑體", 14.25F);
            this._CamshiftButton.Location = new System.Drawing.Point(9, 3);
            this._CamshiftButton.Name = "_CamshiftButton";
            this._CamshiftButton.Size = new System.Drawing.Size(99, 60);
            this._CamshiftButton.TabIndex = 1;
            this._CamshiftButton.Text = "Camshift";
            this._CamshiftButton.UseVisualStyleBackColor = true;
            this._CamshiftButton.Click += new System.EventHandler(this._CamshiftButton_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this._openCameraButton);
            this.panel3.Controls.Add(this._loadSourceImageButton);
            this.panel3.Controls.Add(this.foregroundLabel);
            this.panel3.Location = new System.Drawing.Point(4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(525, 63);
            this.panel3.TabIndex = 0;
            // 
            // _openCameraButton
            // 
            this._openCameraButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._openCameraButton.Font = new System.Drawing.Font("微軟正黑體", 14.25F);
            this._openCameraButton.Location = new System.Drawing.Point(253, 10);
            this._openCameraButton.Name = "_openCameraButton";
            this._openCameraButton.Size = new System.Drawing.Size(126, 40);
            this._openCameraButton.TabIndex = 1;
            this._openCameraButton.Text = "開啟攝影機";
            this._openCameraButton.UseVisualStyleBackColor = true;
            this._openCameraButton.Click += new System.EventHandler(this._openCameraButton_Click);
            // 
            // foregroundLabel
            // 
            this.foregroundLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.foregroundLabel.AutoSize = true;
            this.foregroundLabel.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.foregroundLabel.Location = new System.Drawing.Point(13, 15);
            this.foregroundLabel.Name = "foregroundLabel";
            this.foregroundLabel.Size = new System.Drawing.Size(80, 27);
            this.foregroundLabel.TabIndex = 2;
            this.foregroundLabel.Text = "Source";
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.saveResultImageButton);
            this.panel4.Controls.Add(this.resultLabel);
            this.panel4.Location = new System.Drawing.Point(536, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(525, 63);
            this.panel4.TabIndex = 6;
            // 
            // saveResultImageButton
            // 
            this.saveResultImageButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.saveResultImageButton.Font = new System.Drawing.Font("微軟正黑體", 14.25F);
            this.saveResultImageButton.Location = new System.Drawing.Point(376, 9);
            this.saveResultImageButton.Name = "saveResultImageButton";
            this.saveResultImageButton.Size = new System.Drawing.Size(135, 40);
            this.saveResultImageButton.TabIndex = 1;
            this.saveResultImageButton.Text = "Save Image";
            this.saveResultImageButton.UseVisualStyleBackColor = true;
            this.saveResultImageButton.Click += new System.EventHandler(this.saveResultImageButton_Click);
            // 
            // resultLabel
            // 
            this.resultLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.resultLabel.AutoSize = true;
            this.resultLabel.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.resultLabel.Location = new System.Drawing.Point(14, 16);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(73, 27);
            this.resultLabel.TabIndex = 3;
            this.resultLabel.Text = "Result";
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Location = new System.Drawing.Point(4, 438);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(525, 51);
            this.panel5.TabIndex = 7;
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this._Threshold_Label);
            this.panel6.Controls.Add(this._Threshold_trackBar);
            this.panel6.Controls.Add(this._Threshold_max_Label);
            this.panel6.Controls.Add(this._Threshold_min_Label);
            this.panel6.Location = new System.Drawing.Point(536, 438);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(525, 51);
            this.panel6.TabIndex = 8;
            // 
            // _Threshold_Label
            // 
            this._Threshold_Label.AutoSize = true;
            this._Threshold_Label.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._Threshold_Label.Location = new System.Drawing.Point(215, 31);
            this._Threshold_Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this._Threshold_Label.Name = "_Threshold_Label";
            this._Threshold_Label.Size = new System.Drawing.Size(46, 16);
            this._Threshold_Label.TabIndex = 1;
            this._Threshold_Label.Text = "label1";
            this._Threshold_Label.Visible = false;
            // 
            // _Threshold_trackBar
            // 
            this._Threshold_trackBar.Location = new System.Drawing.Point(56, 2);
            this._Threshold_trackBar.Margin = new System.Windows.Forms.Padding(2);
            this._Threshold_trackBar.Maximum = 300;
            this._Threshold_trackBar.Name = "_Threshold_trackBar";
            this._Threshold_trackBar.Size = new System.Drawing.Size(373, 45);
            this._Threshold_trackBar.TabIndex = 0;
            this._Threshold_trackBar.Value = 100;
            this._Threshold_trackBar.Visible = false;
            this._Threshold_trackBar.Scroll += new System.EventHandler(this._Threshold_trackBar_Scroll);
            // 
            // _Threshold_max_Label
            // 
            this._Threshold_max_Label.AutoSize = true;
            this._Threshold_max_Label.Font = new System.Drawing.Font("新細明體", 12F);
            this._Threshold_max_Label.Location = new System.Drawing.Point(455, 9);
            this._Threshold_max_Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this._Threshold_max_Label.Name = "_Threshold_max_Label";
            this._Threshold_max_Label.Size = new System.Drawing.Size(46, 16);
            this._Threshold_max_Label.TabIndex = 1;
            this._Threshold_max_Label.Text = "label1";
            this._Threshold_max_Label.Visible = false;
            // 
            // _Threshold_min_Label
            // 
            this._Threshold_min_Label.AutoSize = true;
            this._Threshold_min_Label.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._Threshold_min_Label.Location = new System.Drawing.Point(12, 9);
            this._Threshold_min_Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this._Threshold_min_Label.Name = "_Threshold_min_Label";
            this._Threshold_min_Label.Size = new System.Drawing.Size(46, 16);
            this._Threshold_min_Label.TabIndex = 1;
            this._Threshold_min_Label.Text = "label1";
            this._Threshold_min_Label.Visible = false;
            // 
            // _sourcePictureBox
            // 
            this._sourcePictureBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._sourcePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._sourcePictureBox.Location = new System.Drawing.Point(106, 132);
            this._sourcePictureBox.Name = "_sourcePictureBox";
            this._sourcePictureBox.Size = new System.Drawing.Size(320, 240);
            this._sourcePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this._sourcePictureBox.TabIndex = 1;
            this._sourcePictureBox.TabStop = false;
            this._sourcePictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this._sourcePictureBox_mouseClick);
            this._sourcePictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this._sourcePictureBox_mouseDown);
            this._sourcePictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this._sourcePictureBox_mouseMove);
            this._sourcePictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this._sourcePictureBox_mouseUp);
            // 
            // _resultPictureBox
            // 
            this._resultPictureBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._resultPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._resultPictureBox.Location = new System.Drawing.Point(638, 132);
            this._resultPictureBox.Name = "_resultPictureBox";
            this._resultPictureBox.Size = new System.Drawing.Size(320, 240);
            this._resultPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this._resultPictureBox.TabIndex = 1;
            this._resultPictureBox.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 590);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Threshold_trackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._sourcePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._resultPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button _loadSourceImageButton;
        private System.Windows.Forms.Button _grayButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.Label foregroundLabel;
        private System.Windows.Forms.Button saveResultImageButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button _blendingButton;
        private System.Windows.Forms.Button _RotatingButton;
        private System.Windows.Forms.TrackBar _Threshold_trackBar;
        private System.Windows.Forms.Label _Threshold_min_Label;
        private System.Windows.Forms.Label _Threshold_max_Label;
        private System.Windows.Forms.Label _Threshold_Label;
        private System.Windows.Forms.Button _OtsuButton;
        private System.Windows.Forms.Button _HistogramEqualizationButton;
        private System.Windows.Forms.Button _mirrorButton;
        private System.Windows.Forms.Button _openCameraButton;
        private System.Windows.Forms.PictureBox _sourcePictureBox;
        private System.Windows.Forms.PictureBox _resultPictureBox;
        private System.Windows.Forms.Button _CamshiftButton;
        private System.Windows.Forms.Button RemovingBackgrounds_Button;
        private System.Windows.Forms.Button _gameButton;
        private System.Windows.Forms.Button _findPedestrianButton;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}

