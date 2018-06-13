using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.CV.Util;
using Emgu.CV.Structure;

using System.Threading;

//http://www.emgu.com/wiki/index.php/Setting_up_EMGU_C_Sharp

namespace DigitalImageProcessing
{
    public partial class Form1 : Form
    {
        private VideoCapture _capture = null;
        private Mat _captureFrame;
        private Mat _resultFrame;
        private Image<Bgr, Byte> _resultImage;
        private Mat _sourceFrame;
        private Image<Bgr, Byte> _sourceImage = null;
        private Image<Bgr, Byte> _sourceImage2 = null;
        private Mat background;

        // RemovingBackground
        private Color colorForRemovingBackground;

        //String[] imageProcess_for_realTime_way = new String[] { "CamShift", "Gray" };
        private String imageProcess_for_realTime_way = "";

        private bool IsMouseDown = false;

        // CamShift
        private Mat map;

        private Button nowClick = null;

        public Form1()
        {
            InitializeComponent();
        }

        /*******************        Homework 1        *******************/

        //跨執行續取得物件參數 https://blog.csdn.net/_xiao/article/details/54093327
        private delegate object obj_delegate();

        /// //////////////////////////// imageBlending ///////////////////////////////////////////
        private void _blendingButton_Click(object sender, EventArgs e)
        {
            if (_sourceImage == null) return;

            ifShow_Threshold_trackBar_Scroll(true);
            if (nowClick != _blendingButton)
            {
                string fileName2 = LoadImageFile();
                if (fileName2 != "")
                {
                    _sourceImage2 = new Image<Bgr, Byte>(fileName2);
                }
                if (_sourceImage2 == null) return;

                nowClick = _blendingButton;
                setThreshold_trackBar(0, 100, 50);
            }
            _Threshold_Label.Text = (_Threshold_trackBar.Value / 100.0).ToString();

            if (_capture != null && _capture.Ptr != IntPtr.Zero && _capture.IsOpened)
            {
                imageProcess_for_realTime_way = "imageBlending";
            }
            else
            {
                _resultImage = imageProcessing.imageBlending(_sourceImage, _sourceImage2, _Threshold_trackBar.Value / 100.0);
                _resultPictureBox.Image = _resultImage.Bitmap;
            }
        }

        private void _CamshiftButton_Click(object sender, EventArgs e)
        {
            if (_capture != null && _capture.Ptr != IntPtr.Zero && _capture.IsOpened)
            {
                imageProcess_for_realTime_way = "CamShift";
            }
        }

        private void _findPedestrianButton_Click(object sender, EventArgs e)
        {
            if (_capture != null && _capture.Ptr != IntPtr.Zero && _capture.IsOpened)
            {
                imageProcess_for_realTime_way = "findPedestrian";
            }
        }

        private void _gameButton_Click(object sender, EventArgs e)
        {
            if (_capture != null && _capture.Ptr != IntPtr.Zero && _capture.IsOpened)
            {
                imageProcess_for_realTime_way = "Game";

                map = new Mat("map.png");
                _resultPictureBox.Image = map.Bitmap;
            }
        }

        /// //////////////////////////// gray ///////////////////////////////////////////
        private void _grayButton_Click(object sender, EventArgs e)
        {
            if (_sourceImage == null) return;
            ifShow_Threshold_trackBar_Scroll(false);

            if (_capture != null && _capture.Ptr != IntPtr.Zero && _capture.IsOpened)
            {
                imageProcess_for_realTime_way = "Gray";
            }
            else
            {
                _resultImage = imageProcessing.ConvertToGray(_sourceImage);
                _resultPictureBox.Image = _resultImage.Bitmap;
            }

            nowClick = _grayButton;
        }

        /// //////////////////////////// HistogramEqualization ///////////////////////////////////////////
        private void _HistogramEqualizationButton_Click(object sender, EventArgs e)
        {
            if (_sourceImage == null) return;
            ifShow_Threshold_trackBar_Scroll(false);

            if (_capture != null && _capture.Ptr != IntPtr.Zero && _capture.IsOpened)
            {
                imageProcess_for_realTime_way = "HistogramEqualization";
            }
            else
            {
                _resultImage = imageProcessing.HistogramEqualization(_sourceImage);
                _resultPictureBox.Image = _resultImage.Bitmap;
            }

            nowClick = _HistogramEqualizationButton;
        }

        private void _loadSourceImageButton_Click(object sender, EventArgs e)
        {
            string fileName = LoadImageFile();
            if (fileName != "")
            {
                _sourceImage = new Image<Bgr, Byte>(fileName);
                _sourcePictureBox.Image = _sourceImage.Bitmap;
            }
        }

        /// //////////////////////////// mirror ///////////////////////////////////////////
        private void _mirrorButton_Click(object sender, EventArgs e)
        {
            if (_sourceImage == null) return;
            ifShow_Threshold_trackBar_Scroll(false);

            if (_capture != null && _capture.Ptr != IntPtr.Zero && _capture.IsOpened)
            {
                imageProcess_for_realTime_way = "Mirror";
            }
            else
            {
                _resultImage = imageProcessing.ConvertToMirror(_sourceImage);
                _resultPictureBox.Image = _resultImage.Bitmap;
            }

            nowClick = _mirrorButton;
        }

        private void _openCameraButton_Click(object sender, EventArgs e)
        {
            if (_capture != null && _capture.Ptr != IntPtr.Zero && _capture.IsOpened)
            {
                _openCameraButton.Text = "開啟攝影機";

                _capture.Stop();//摄像头关闭
                _capture.ImageGrabbed -= ProcessFrame;
                _capture.Dispose();
                _resultFrame = null;

                imageProcess_for_realTime_way = "";
            }
            else
            {
                _openCameraButton.Enabled = false;
                _openCameraButton.Text = "停止攝影機";

                _capture = new VideoCapture(0);//0為相機編號，如果電腦只有一台相機就設置0，超過一台就測試看看要用幾號
                _capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.AutoExposure, 0);
                _capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameWidth, 320);//_sourcePictureBox.Width
                _capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameHeight, 240);// _sourcePictureBox.Height

                _capture.ImageGrabbed += ProcessFrame;
                _captureFrame = new Mat();

                if (_capture != null)
                    _capture.Start();

                _openCameraButton.Enabled = true;
            }
        }

        /// //////////////////////////// ConvertToOtsu ///////////////////////////////////////////
        private void _OtsuButton_Click(object sender, EventArgs e)
        {
            if (_sourceImage == null) return;
            ifShow_Threshold_trackBar_Scroll(false);

            if (_capture != null && _capture.Ptr != IntPtr.Zero && _capture.IsOpened)
            {
                imageProcess_for_realTime_way = "Otsu";
            }
            else
            {
                _resultImage = imageProcessing.ConvertToOtsu(_sourceImage);
                _resultPictureBox.Image = _resultImage.Bitmap;
            }

            nowClick = _OtsuButton;
        }

        /// //////////////////////////// Rotating ///////////////////////////////////////////
        private void _RotatingButton_Click(object sender, EventArgs e)
        {
            if (_sourceImage == null) return;

            ifShow_Threshold_trackBar_Scroll(true);
            if (nowClick != _RotatingButton)
            {
                nowClick = _RotatingButton;
                setThreshold_trackBar(0, 36000, 7595);
            }
            _Threshold_Label.Text = (_Threshold_trackBar.Value / 100.0).ToString();

            if (_capture != null && _capture.Ptr != IntPtr.Zero && _capture.IsOpened)
            {
                imageProcess_for_realTime_way = "Rotating";
            }
            else
            {
                _resultImage = imageProcessing.Rotating(_sourceImage, _Threshold_trackBar.Value / 100.0);
                _resultPictureBox.Image = _resultImage.Bitmap;
            }
        }

        private void _sourcePictureBox_mouseClick(object sender, MouseEventArgs e)
        {
        }

        private void _sourcePictureBox_mouseDown(object sender, MouseEventArgs e)
        {
        }

        private void _sourcePictureBox_mouseMove(object sender, MouseEventArgs e)
        {
        }

        private void _sourcePictureBox_mouseUp(object sender, MouseEventArgs e)
        {
        }

        /// //////////////////////////// _Threshold_trackBar_Scroll ///////////////////////////////////////////
        private void _Threshold_trackBar_Scroll(object sender, EventArgs e)
        {
            if (_sourceImage == null) return;
            nowClick.PerformClick();
        }

        private void ifShow_Threshold_trackBar_Scroll(bool s)
        {
            if (s)
            {
                _Threshold_trackBar.Show();
                _Threshold_min_Label.Show();
                _Threshold_max_Label.Show();
                _Threshold_Label.Show();
            }
            else
            {
                _Threshold_trackBar.Hide();
                _Threshold_min_Label.Hide();
                _Threshold_max_Label.Hide();
                _Threshold_Label.Hide();
            }
        }

        private string LoadImageFile()
        {
            string fileName = "";
            OpenFileDialog dialog = new OpenFileDialog();
            DirectoryInfo dir = new DirectoryInfo(System.Windows.Forms.Application.StartupPath);
            dialog.Title = "Open an Image File";
            dialog.RestoreDirectory = true;
            dialog.InitialDirectory = dir.Parent.Parent.FullName;
            dialog.Filter = "PNG (*.png)|*.png|JPEG (*.jpeg;*.jpg)|*.jpg;*.jpeg|Bmp (*.bmp)|*.bmp";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK && dialog.FileName != null)
            {
                fileName = dialog.FileName;
            }
            return fileName;
        }

        private void ProcessFrame(object sender, EventArgs e)
        {
            if (_capture != null && _capture.Ptr != IntPtr.Zero && _capture.IsOpened)
            {
                //取得網路攝影機的影像
                _capture.Retrieve(_captureFrame);
                if (_captureFrame == null || _captureFrame.IsEmpty)
                    return;
                _resultFrame = _captureFrame.Clone();
                _sourceFrame = _captureFrame.Clone();
                _sourceImage = imageProcessing.MatToImage(_captureFrame);
                //CvInvoke.Resize(_captureFrame, _captureFrame, new Size(_sourcePictureBox.Width, _sourcePictureBox.Height), 0, 0, Emgu.CV.CvEnum.Inter.Linear);//, Emgu.CV.CvEnum.Inter.Linear

                //顯示影像到PictureBox上
                if (imageProcess_for_realTime_way == "Gray")
                {
                    _resultImage = imageProcessing.ConvertToGray(_sourceImage);
                    _resultPictureBox.Image = _resultImage.Bitmap;
                }
                else if (imageProcess_for_realTime_way == "Mirror")
                {
                    _resultImage = imageProcessing.ConvertToMirror(_sourceImage);
                    _resultPictureBox.Image = _resultImage.Bitmap;
                }
                else if (imageProcess_for_realTime_way == "Rotating")
                {
                    int _Threshold_trackBar_value = 0;
                    if (_Threshold_trackBar.InvokeRequired)
                    {
                        _Threshold_trackBar_value = (int)_Threshold_trackBar.Invoke(new obj_delegate(() => { return _Threshold_trackBar.Value; }));
                    }
                    else
                    {
                        _Threshold_trackBar_value = _Threshold_trackBar.Value;
                    }
                    _resultImage = imageProcessing.Rotating(_sourceImage, _Threshold_trackBar_value / 100.0);
                    _resultPictureBox.Image = _resultImage.Bitmap;
                }
                else if (imageProcess_for_realTime_way == "Otsu")
                {
                    _resultImage = imageProcessing.ConvertToOtsu(_sourceImage);
                    _resultPictureBox.Image = _resultImage.Bitmap;
                }
                else if (imageProcess_for_realTime_way == "HistogramEqualization")
                {
                    _resultImage = imageProcessing.HistogramEqualization(_sourceImage);
                    _resultPictureBox.Image = _resultImage.Bitmap;
                }
                else if (imageProcess_for_realTime_way == "imageBlending")
                {
                    int _Threshold_trackBar_value = 0;
                    if (_Threshold_trackBar.InvokeRequired)
                    {
                        _Threshold_trackBar_value = (int)_Threshold_trackBar.Invoke(new obj_delegate(() => { return _Threshold_trackBar.Value; }));
                    }
                    else
                    {
                        _Threshold_trackBar_value = _Threshold_trackBar.Value;
                    }
                    _resultImage = imageProcessing.imageBlending(_sourceImage, _sourceImage2, _Threshold_trackBar_value / 100.0);
                    _resultPictureBox.Image = _resultImage.Bitmap;
                }
                else if (imageProcess_for_realTime_way == "RemovingBackgrounds" && background != null && !background.IsEmpty)
                {
                    int _Threshold_trackBar_value = 30;
                    if (_Threshold_trackBar.InvokeRequired)
                    {
                        _Threshold_trackBar_value = (int)_Threshold_trackBar.Invoke(new obj_delegate(() => { return (int)((double)_Threshold_trackBar.Value / 100.0); }));
                    }
                    else
                    {
                        _Threshold_trackBar_value = (int)((double)_Threshold_trackBar.Value / 100.0);
                    }

                    /* 在這裡實作 */

                    _resultPictureBox.Image = _resultFrame.Bitmap;
                    CvInvoke.PutText(_sourceFrame, "now keyColor is R: " + colorForRemovingBackground.R + " G: " + colorForRemovingBackground.G + " B: " + colorForRemovingBackground.B, new Point(10, 20), Emgu.CV.CvEnum.FontFace.HersheySimplex, 0.4, new MCvScalar(0, 0, 255));
                }
                else if (imageProcess_for_realTime_way == "CamShift")
                {
                    _resultPictureBox.Image = _resultFrame.Bitmap;
                }
                else if (imageProcess_for_realTime_way == "Game")
                {
                    _resultPictureBox.Image = _resultFrame.Bitmap;
                }
                else if (imageProcess_for_realTime_way == "findPedestrian")
                {
                    _resultPictureBox.Image = _resultFrame.Bitmap;
                }
                else
                {
                    _resultPictureBox.Image = _resultFrame.Bitmap;
                }
                _sourcePictureBox.Image = _sourceFrame.Bitmap;
            }

            //釋放繪圖資源->避免System.AccessViolationException
            GC.Collect();
        }

        private void RemovingBackgrounds_Button_Click(object sender, EventArgs e)
        {
            if (_capture != null && _capture.Ptr != IntPtr.Zero && _capture.IsOpened)
            {
                ifShow_Threshold_trackBar_Scroll(true);
                if (nowClick != RemovingBackgrounds_Button)
                {
                    nowClick = RemovingBackgrounds_Button;
                    setThreshold_trackBar(0, 25600, 3000);
                }
                _Threshold_Label.Text = (_Threshold_trackBar.Value / 100.0).ToString();

                imageProcess_for_realTime_way = "RemovingBackgrounds";
                if (colorForRemovingBackground.IsEmpty)
                    colorForRemovingBackground = Color.White;
                //MessageBox.Show("請點擊畫面中的一種顏色，以該顏色為key color做藍幕去背！");
                // 於 TextBox MouseClick事件中，顯示 ColorDialog
                //if (colorDialog1.ShowDialog() != DialogResult.Cancel)
                //{
                //    colorForRemovingBackground = colorDialog1.Color;  // 回傳選擇顏色，並且設定 Textbox 的背景顏色
                //}

                /* 在這裡實作 */
                background = new Mat("back5.jpg");
                CvInvoke.Resize(background, background, new Size(320, 240));
            }
            else
            {
            }
        }

        private void saveResultImageButton_Click(object sender, EventArgs e)
        {
            if (_resultFrame == null || _resultFrame.IsEmpty)
            {
                if (_resultImage == null)
                    return;
                else
                {
                    SaveFileDialog dialog = new SaveFileDialog();
                    dialog.Filter = "PNG (*.png)|*.png|JPEG (*.jpeg;*.jpg)|*.jpg;*.jpeg|Bmp (*.bmp)|*.bmp";
                    dialog.Title = "Save an Image File";
                    if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK && dialog.FileName != null)
                    {
                        string fileName = dialog.FileName;
                        _resultImage.Save(fileName);
                    }
                }
            }
            else
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "PNG (*.png)|*.png|JPEG (*.jpeg;*.jpg)|*.jpg;*.jpeg|Bmp (*.bmp)|*.bmp";
                dialog.Title = "Save an Image File";
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK && dialog.FileName != null)
                {
                    string fileName = dialog.FileName;
                    CvInvoke.Imwrite(fileName, _resultFrame);
                }
            }
        }

        private void setThreshold_trackBar(int min, int max, int initialValue)
        {
            _Threshold_trackBar.Minimum = min;
            _Threshold_trackBar.Maximum = max;
            _Threshold_trackBar.Value = initialValue;
            _Threshold_min_Label.Text = (_Threshold_trackBar.Minimum / 100.0).ToString();
            _Threshold_max_Label.Text = (_Threshold_trackBar.Maximum / 100.0).ToString();
            _Threshold_Label.Text = (_Threshold_trackBar.Value / 100.0).ToString();
        }

        /*******************        Homework 2        *******************/
        /**********************************/
    }
}