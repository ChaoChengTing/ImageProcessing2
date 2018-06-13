using System;

using System.Runtime.InteropServices;
using Emgu.CV;
using Emgu.CV.Structure;

namespace DigitalImageProcessing
{
    public static class imageProcessing
    {
        public static Image<Bgr, Byte> MatToImage(Mat source)
        {
            Image<Bgr, Byte> result = new Image<Bgr, Byte>(source.Width, source.Height);
            int rows = source.Height;
            int cols = source.Width;

            byte[] source_byte = source.GetData();

            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < cols; x++)
                {
                    int index = (y * cols + x) * 3;
                    result.Data[y, x, 0] = source_byte[index + 0];
                    result.Data[y, x, 1] = source_byte[index + 1];
                    result.Data[y, x, 2] = source_byte[index + 2];
                }
            }

            return result;
        }

        public static Mat ConvertToGray_MatToImageWay(Mat source)  //灰階 function //Gray = R*0.299 + G*0.587 + B*0.114
        {
            Image<Bgr, Byte> source_image = source.ToImage<Bgr, Byte>();
            Image<Gray, Byte> result_image = new Image<Gray, Byte>(source_image.Width, source_image.Height);

            int rows = source.Height;
            int cols = source.Width;

            byte r, g, b;
            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < cols; x++)
                {
                    int index = y * cols * 3 + x * 3;
                    int index2 = y * cols * 3 + (cols - x - 1) * 3;
                    b = (byte)source_image.Data[y, x, 0];  //B
                    g = (byte)source_image.Data[y, x, 1];  //G
                    r = (byte)source_image.Data[y, x, 2];  //R

                    byte grayColor = (byte)(b * 0.114 + g * 0.587 + r * 0.299);
                    result_image.Data[y, x, 0] = grayColor;
                }
            }
            Mat result = result_image.Mat;

            return result;
        }

        public static Image<Bgr, Byte> ConvertToGray(Image<Bgr, Byte> source)  //灰階 function //Gray = R*0.299 + G*0.587 + B*0.114
        {
            Image<Bgr, Byte> result = new Image<Bgr, Byte>(source.Width, source.Height);

            int rows = source.Height;
            int cols = source.Width;

            byte r, g, b;
            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < cols; x++)
                {
                    b = (byte)source.Data[y, x, 0];  //B
                    g = (byte)source.Data[y, x, 1];  //G
                    r = (byte)source.Data[y, x, 2];  //R

                    byte grayColor = (byte)(b * 0.114 + g * 0.587 + r * 0.299);
                    result.Data[y, x, 0] = grayColor;
                    result.Data[y, x, 1] = grayColor;
                    result.Data[y, x, 2] = grayColor;
                }
            }

            return result;
        }

        public static Image<Bgr, Byte> ConvertToMirror(Image<Bgr, Byte> source)
        {
            Image<Bgr, Byte> result = new Image<Bgr, Byte>(source.Width, source.Height);

            int rows = source.Height;
            int cols = source.Width;

            byte r, g, b;
            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < cols; x++)
                {
                    b = (byte)source.Data[y, x, 0];  //B
                    g = (byte)source.Data[y, x, 1];  //G
                    r = (byte)source.Data[y, x, 2];  //R

                    result.Data[y, (cols - x - 1), 0] = b;
                    result.Data[y, (cols - x - 1), 1] = g;
                    result.Data[y, (cols - x - 1), 2] = r;
                }
            }
            return result;
        }

        public static Image<Bgr, Byte> Rotating(Image<Bgr, Byte> source, double theta)
        {
            int way = 1;
            Image<Bgr, Byte> result = new Image<Bgr, Byte>(source.Width, source.Height);
            int rows = source.Height;
            int cols = source.Width;

            double theta2 = Math.PI * theta / 180.0;

            if (way == 1)
            {
                //將旋轉公式反著用：從選轉後的座標推回source的座標拿顏色 -> 沒破洞
                for (int dist_y = 0; dist_y < rows; dist_y++)
                {
                    for (int dist_x = 0; dist_x < cols; dist_x++)
                    {
                        int ox = (int)(Math.Cos(theta2) * (dist_x - (cols - 1) / 2) + Math.Sin(theta2) * (dist_y - (rows - 1) / 2));
                        int oy = (int)(-Math.Sin(theta2) * (dist_x - (cols - 1) / 2) + Math.Cos(theta2) * (dist_y - (rows - 1) / 2));
                        int source_x = (ox + (cols - 1) / 2);
                        int source_y = (oy + (rows - 1) / 2);

                        if (source_y >= 0 && source_y < rows && source_x >= 0 && source_x < cols)
                        {
                            result.Data[dist_y, dist_x, 0] = (byte)source.Data[source_y, source_x, 0];  //B
                            result.Data[dist_y, dist_x, 1] = (byte)source.Data[source_y, source_x, 1];  //G
                            result.Data[dist_y, dist_x, 2] = (byte)source.Data[source_y, source_x, 2]; //R
                        }
                    }
                }
            }
            else if (way == 2)
            {
#if use_Rotation_Matrix
                Matrix<double> Rotation_Matrix = new Matrix<double>(2, 2);
                Rotation_Matrix.Data[0, 0] = Math.Cos(theta);
                Rotation_Matrix.Data[0, 1] = -Math.Sin(theta);
                Rotation_Matrix.Data[1, 0] = Math.Sin(theta);
                Rotation_Matrix.Data[1, 1] = Math.Cos(theta);

                Matrix<double> source_pixel_position = new Matrix<double>(2, 1);
                Matrix<double> result_pixel_position = new Matrix<double>(2, 1);
#endif
                //依照一般的旋轉公式 -> 會有破洞
                for (int source_y = 0; source_y < rows; source_y++)
                {
                    for (int source_x = 0; source_x < cols; source_x++)
                    {
#if use_Rotation_Matrix
                        //旋轉座標用矩陣運算 -> 效能較差、計算比較慢
                        source_pixel_position.Data[0, 0] = source_x;
                        source_pixel_position.Data[1, 0] = source_y;
                        result_pixel_position = Rotation_Matrix * source_pixel_position;
                        int dist_x = (int)(result_pixel_position.Data[0, 0] + 0.5);
                        int dist_y = (int)(result_pixel_position.Data[1, 0] + 0.5);
                        if (dist_y >= rows || dist_x >= cols || dist_y < 0 || dist_x < 0)
                            continue;
                        int index = source_y * cols * 3 + source_x * 3;
                        int index2 = dist_y * cols * 3 + dist_x * 3;
                        pResult[index2] = pSource[index];  //B
                        pResult[index2 + 1] = pSource[index + 1];  //G
                        pResult[index2 + 2] = pSource[index + 2]; //R
#else
                        int ox = (int)(Math.Cos(theta) * (source_x - (cols - 1) / 2) - Math.Sin(theta) * (source_y - (rows - 1) / 2));
                        int oy = (int)(Math.Sin(theta) * (source_x - (cols - 1) / 2) + Math.Cos(theta) * (source_y - (rows - 1) / 2));
                        int dist_x = (ox + (cols - 1) / 2);
                        int dist_y = (oy + (rows - 1) / 2);

                        if (dist_y >= 0 && dist_y < rows && dist_x >= 0 && dist_x < cols)
                        {
                            result.Data[dist_y, dist_x, 0] = (byte)source.Data[source_y, source_x, 0];  //B
                            result.Data[dist_y, dist_x, 1] = (byte)source.Data[source_y, source_x, 1];  //G
                            result.Data[dist_y, dist_x, 2] = (byte)source.Data[source_y, source_x, 2]; //R
                        }
#endif
                    }
                }
            }

            return result;
        }

        public static Image<Bgr, Byte> imageBlending(Image<Bgr, Byte> source, Image<Bgr, Byte> source2, double Threshold)
        {
            Image<Bgr, Byte> result = new Image<Bgr, Byte>(source.Width, source.Height);
            int rows = source.Height;
            int cols = source.Width;

            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < cols; x++)
                {
                    result.Data[y, x, 0] = (byte)(source.Data[y, x, 0] * Threshold + source2.Data[y, x, 0] * (1 - Threshold));  //B
                    result.Data[y, x, 1] = (byte)(source.Data[y, x, 1] * Threshold + source2.Data[y, x, 1] * (1 - Threshold));  //G
                    result.Data[y, x, 2] = (byte)(source.Data[y, x, 2] * Threshold + source2.Data[y, x, 2] * (1 - Threshold)); //R
                }
            }
            return result;
        }

        public static Image<Bgr, Byte> ConvertToOtsu(Image<Bgr, Byte> source)
        {
            source = ConvertToGray(source);
            //source = source<Gray, Mat>();
            //source.ConvertTo(source, 0);
            //return source;
            Image<Bgr, Byte> result = new Image<Bgr, Byte>(source.Width, source.Height);
            int rows = source.Height;
            int cols = source.Width;
            int threshold = 0;

            int[] hist = new int[256];
            Array.Clear(hist, 0, hist.Length);
            //值方圖計算
            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < cols; x++)
                {
                    int index = y * cols * 3 + x * 3;
                    hist[source.Data[y, x, 0]]++;
                }
            }

            int n = 255;
            double minVariance = double.MaxValue;

            for (int i = 0; i < n; i++)
            {
                double ua = 0, ub = 0;
                int ua_numerator = 0, ua_denominator = 0;
                int ub_numerator = 0, ub_denominator = 0;
                double sigma1 = 0, sigma2 = 0, sigma = 0;
                //conpute u1
                for (int j = 0; j < i; j++)
                {
                    ua_numerator += (hist[j] * j);
                    ua_denominator += hist[j];
                }
                //conpute u2
                for (int j = i; j < n; j++)
                {
                    ub_numerator += (hist[j] * j);
                    ub_denominator += hist[j];
                }
                if (ua_denominator != 0)
                    ua = ((double)ua_numerator / (double)ua_denominator);

                if (ub_denominator != 0)
                    ub = ((double)ub_numerator / (double)ub_denominator);
                //conpute Sigma1
                for (int j = 0; j < i; j++)
                {
                    sigma1 += ((ua - j) * (ua - j) * hist[j]);
                }
                //conpute Sigma2
                for (int j = i; j < n; j++)
                {
                    sigma2 += ((ub - j) * (ub - j) * hist[j]);
                }
                sigma = Math.Sqrt(sigma1 + sigma2);
                if (minVariance > sigma)
                {
                    minVariance = sigma;
                    threshold = i;
                }
            }

            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < cols; x++)
                {
                    int index = y * cols * 3 + x * 3;
                    if ((int)threshold < source.Data[y, x, 0])
                    {
                        result.Data[y, x, 0] = 255;
                        result.Data[y, x, 1] = 255;
                        result.Data[y, x, 2] = 255;
                    }
                    else
                    {
                        result.Data[y, x, 0] = 0;
                        result.Data[y, x, 1] = 0;
                        result.Data[y, x, 2] = 0;
                    }
                }
            }
            return result;
        }

        private static byte[] HistogramEqualization_for_oneChannel(byte[] source, int width, int height)
        {
            byte[] resultImage = new byte[width * height];

            float[] gray_level = new float[256]; //宣告要排放gray等級個數的陣列
            Array.Clear(gray_level, 0, gray_level.Length);

            for (int y = 0; y < height; y++) //把值放入gray_level[]內
            {
                for (int x = 0; x < width; x++)
                {
                    int index = y * width + x;
                    int gray = source[index];
                    gray_level[gray]++;
                }
            }

            for (int i = 0; i < 256; i++)
            {
                gray_level[i] = gray_level[i] / ((width) * (height));
            }

            for (int i = 1; i < 256; i++)
            {
                gray_level[i] = gray_level[i] + gray_level[i - 1];
            }

            for (int i = 0; i < 256; i++)
            {
                gray_level[i] = gray_level[i] * 255;
            }

            for (int y = 0; y < height; y++) //做histogram均化
            {
                for (int x = 0; x < width; x++)
                {
                    int index = y * width + x;
                    int gray = source[index];

                    resultImage[index] = (byte)gray_level[gray];
                    resultImage[index] = (byte)gray_level[gray];
                    resultImage[index] = (byte)gray_level[gray];
                }
            }
            return resultImage;
        }

        public static Image<Bgr, Byte> HistogramEqualization(Image<Bgr, Byte> source)
        {
            Image<Bgr, Byte> result = new Image<Bgr, Byte>(source.Width, source.Height);
            int rows = source.Height;
            int cols = source.Width;
            byte[] b_array = new byte[rows * cols];
            byte[] g_array = new byte[rows * cols];
            byte[] r_array = new byte[rows * cols];

            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < cols; x++)
                {
                    int index = y * cols * 3 + x * 3;
                    int index2 = y * cols + x;

                    b_array[index2] = (byte)(source.Data[y, x, 0]);  //B
                    g_array[index2] = (byte)(source.Data[y, x, 1]);  //G
                    r_array[index2] = (byte)(source.Data[y, x, 2]); //R
                }
            }

            b_array = HistogramEqualization_for_oneChannel(b_array, cols, rows);
            g_array = HistogramEqualization_for_oneChannel(g_array, cols, rows);
            r_array = HistogramEqualization_for_oneChannel(r_array, cols, rows);

            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < cols; x++)
                {
                    int index = y * cols * 3 + x * 3;
                    int index2 = y * cols + x;

                    result.Data[y, x, 0] = b_array[index2];  //B
                    result.Data[y, x, 1] = g_array[index2];  //G
                    result.Data[y, x, 2] = r_array[index2];  //R
                }
            }

            return result;
        }
    }
}