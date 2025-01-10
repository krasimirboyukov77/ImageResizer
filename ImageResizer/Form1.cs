using System.Diagnostics;
using System.Drawing.Imaging;
using System.Threading;

namespace ImageResizer
{
    public partial class Form1 : Form
    {

        private CancellationTokenSource cancellationTokenSource;

        public Form1()
        {
            InitializeComponent();
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox.Image = Image.FromFile(openFileDialog.FileName);
                }
            }
        }

        private async void btnResize_Click(object sender, EventArgs e)
        {
            if (pictureBox.Image == null)
            {
                MessageBox.Show("Please select an image first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!double.TryParse(txtScalingFactor.Text, out double scalingFactor) || scalingFactor <= 0 || scalingFactor > 100)
            {
                MessageBox.Show("Please enter a valid scaling factor (1-100).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            cancellationTokenSource = new CancellationTokenSource();

            try
            {
                btnResize.Enabled = false;
                btnCancel.Enabled = true;
                progressBar.Value = 0;

                Stopwatch stopwatch = Stopwatch.StartNew();

                Bitmap originalImage = (Bitmap)pictureBox.Image;
                Bitmap resizedImage = await Task.Run(() => DownscaleImageAsynchronous(originalImage, scalingFactor / 100, cancellationTokenSource.Token));
                
                stopwatch.Stop();
                MessageBox.Show($"Asynchronous resizing completed in {(double)stopwatch.ElapsedMilliseconds / 1000} s.", "Performance", MessageBoxButtons.OK, MessageBoxIcon.Information);

                pictureBoxPreview.Image = resizedImage;

                if (resizedImage != null)
                {
                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "JPEG Image|*.jpg|PNG Image|*.png|Bitmap Image|*.bmp";
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            resizedImage.Save(saveFileDialog.FileName);
                            MessageBox.Show("Image resized and saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("Operation canceled.", "Canceled", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                btnResize.Enabled = true;
                btnCancel.Enabled = false;
                progressBar.Value = 0;
            }
        }

        private Bitmap DownscaleImageAsynchronous(Bitmap originalImage, double scalingFactor, CancellationToken cancellationToken)
        {
            int newWidth = (int)(originalImage.Width * scalingFactor);
            int newHeight = (int)(originalImage.Height * scalingFactor);

            Bitmap resizedImage = new Bitmap(newWidth, newHeight);

            using (Graphics graphics = Graphics.FromImage(resizedImage))
            {
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

                for (int y = 0; y < newHeight; y++)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    progressBar.Invoke((Action)(() => progressBar.Value = (int)((y / (double)newHeight) * 100)));

                    for (int x = 0; x < newWidth; x++)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                    }

                    graphics.DrawImage(originalImage, 0, 0, newWidth, newHeight);
                }
            }

            return resizedImage;
        }

        public Bitmap DownscaleImageSynchronous(Bitmap originalImage, double scalingFactor)
        {
            int newWidth = (int)(originalImage.Width * scalingFactor);
            int newHeight = (int)(originalImage.Height * scalingFactor);

            Bitmap resizedImage = new Bitmap(newWidth, newHeight);

          
            for (int y = 0; y < newHeight; y++)
            {
                for (int x = 0; x < newWidth; x++)
                {
                   
                    int startX = (int)(x / scalingFactor);
                    int startY = (int)(y / scalingFactor);
                    int endX = (int)((x + 1) / scalingFactor);
                    int endY = (int)((y + 1) / scalingFactor);

                    
                    Color averagedColor = GetAverageColor(originalImage, startX, startY, endX, endY);

                   
                    resizedImage.SetPixel(x, y, averagedColor);
                }

                
                progressBar.Invoke((Action)(() => progressBar.Value = (int)((y / (double)newHeight) * 100)));
            }

            return resizedImage;
        }

       
        private Color GetAverageColor(Bitmap image, int startX, int startY, int endX, int endY)
        {
            int totalR = 0, totalG = 0, totalB = 0;
            int count = 0;

            
            for (int y = startY; y < endY; y++)
            {
                for (int x = startX; x < endX; x++)
                {
                    
                    if (x < image.Width && y < image.Height)
                    {
                        Color pixelColor = image.GetPixel(x, y);
                        totalR += pixelColor.R;
                        totalG += pixelColor.G;
                        totalB += pixelColor.B;
                        count++;
                    }
                }
            }

           
            int avgR = count > 0 ? totalR / count : 0;
            int avgG = count > 0 ? totalG / count : 0;
            int avgB = count > 0 ? totalB / count : 0;

            return Color.FromArgb(avgR, avgG, avgB);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            cancellationTokenSource?.Cancel();
        }

        private void btnSelectImage_Click_1(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox.Image = Image.FromFile(openFileDialog.FileName);
                }
            }
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            cancellationTokenSource?.Cancel();
        }

        private void DownscaledPreview_Click(object sender, EventArgs e)
        {

        }

        private void btnResizeAsync_Click(object sender, EventArgs e)
        {

            if (pictureBox.Image == null)
            {
                MessageBox.Show("Please select an image first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!double.TryParse(txtScalingFactor.Text, out double scalingFactor) || scalingFactor <= 0 || scalingFactor > 100)
            {
                MessageBox.Show("Please enter a valid scaling factor (1-100).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            cancellationTokenSource = new CancellationTokenSource();

            try
            {
                btnResize.Enabled = false;
                btnCancel.Enabled = true;
                progressBar.Value = 0;

                Stopwatch stopwatch = Stopwatch.StartNew();

                Bitmap originalImage = (Bitmap)pictureBox.Image;
                Bitmap resizedImage = DownscaleImageSynchronous(originalImage, scalingFactor / 100);
                
                stopwatch.Stop();
                MessageBox.Show($"Asynchronous resizing completed in {stopwatch.ElapsedMilliseconds / 1000} s.", "Performance", MessageBoxButtons.OK, MessageBoxIcon.Information);

                pictureBoxPreview.Image = resizedImage;

                if (resizedImage != null)
                {
                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "JPEG Image|*.jpg|PNG Image|*.png|Bitmap Image|*.bmp";
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            resizedImage.Save(saveFileDialog.FileName);
                            MessageBox.Show("Image resized and saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("Operation canceled.", "Canceled", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                btnResize.Enabled = true;
                btnCancel.Enabled = false;
                progressBar.Value = 0;
            }
        }
    }
}
