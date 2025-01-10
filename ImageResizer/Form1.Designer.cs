namespace ImageResizer
{
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox = new PictureBox();
            txtScalingFactor = new TextBox();
            btnSelectImage = new Button();
            btnResize = new Button();
            progressBar = new ProgressBar();
            btnCancel = new Button();
            pictureBoxPreview = new PictureBox();
            ScalingFactor = new Label();
            DownscaledPreview = new Label();
            btnResizeAsync = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPreview).BeginInit();
            SuspendLayout();
            // 
            // pictureBox
            // 
            pictureBox.Location = new Point(41, 31);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(295, 281);
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            // 
            // txtScalingFactor
            // 
            txtScalingFactor.Location = new Point(41, 318);
            txtScalingFactor.Name = "txtScalingFactor";
            txtScalingFactor.Size = new Size(125, 27);
            txtScalingFactor.TabIndex = 1;
            // 
            // btnSelectImage
            // 
            btnSelectImage.Location = new Point(653, 41);
            btnSelectImage.Name = "btnSelectImage";
            btnSelectImage.Size = new Size(114, 29);
            btnSelectImage.TabIndex = 2;
            btnSelectImage.Text = "Load Image";
            btnSelectImage.UseVisualStyleBackColor = true;
            btnSelectImage.Click += btnSelectImage_Click_1;
            // 
            // btnResize
            // 
            btnResize.Location = new Point(172, 317);
            btnResize.Name = "btnResize";
            btnResize.Size = new Size(105, 29);
            btnResize.TabIndex = 3;
            btnResize.Text = "Resize Async";
            btnResize.UseVisualStyleBackColor = true;
            btnResize.Click += btnResize_Click;
            // 
            // progressBar
            // 
            progressBar.Location = new Point(41, 387);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(295, 29);
            progressBar.TabIndex = 4;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(352, 387);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click_1;
            // 
            // pictureBoxPreview
            // 
            pictureBoxPreview.Location = new Point(352, 31);
            pictureBoxPreview.Name = "pictureBoxPreview";
            pictureBoxPreview.Size = new Size(295, 281);
            pictureBoxPreview.TabIndex = 6;
            pictureBoxPreview.TabStop = false;
            // 
            // ScalingFactor
            // 
            ScalingFactor.AutoSize = true;
            ScalingFactor.Location = new Point(51, 348);
            ScalingFactor.Name = "ScalingFactor";
            ScalingFactor.Size = new Size(101, 20);
            ScalingFactor.TabIndex = 7;
            ScalingFactor.Text = "Scaling Factor";
            // 
            // DownscaledPreview
            // 
            DownscaledPreview.AutoSize = true;
            DownscaledPreview.Location = new Point(398, 322);
            DownscaledPreview.Name = "DownscaledPreview";
            DownscaledPreview.Size = new Size(191, 20);
            DownscaledPreview.TabIndex = 8;
            DownscaledPreview.Text = "Downscaled Image Preview";
            DownscaledPreview.Click += DownscaledPreview_Click;
            // 
            // btnResizeAsync
            // 
            btnResizeAsync.Location = new Point(172, 348);
            btnResizeAsync.Name = "btnResizeAsync";
            btnResizeAsync.Size = new Size(105, 29);
            btnResizeAsync.TabIndex = 10;
            btnResizeAsync.Text = "Resize Sync";
            btnResizeAsync.UseVisualStyleBackColor = true;
            btnResizeAsync.Click += btnResizeAsync_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(808, 474);
            Controls.Add(btnResizeAsync);
            Controls.Add(DownscaledPreview);
            Controls.Add(ScalingFactor);
            Controls.Add(pictureBoxPreview);
            Controls.Add(btnCancel);
            Controls.Add(progressBar);
            Controls.Add(btnResize);
            Controls.Add(btnSelectImage);
            Controls.Add(txtScalingFactor);
            Controls.Add(pictureBox);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPreview).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox;
        private TextBox txtScalingFactor;
        private Button btnSelectImage;
        private Button btnResize;
        private ProgressBar progressBar;
        private Button btnCancel;
        private PictureBox pictureBoxPreview;
        private Label ScalingFactor;
        private Label DownscaledPreview;
        private Button btnResizeAsync;
    }
}
