//----------------------------------------------------------------------------
//  Copyright (C) 2004-2015 by EMGU Corporation. All rights reserved.       
//----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System.Diagnostics;
using Emgu.CV.Util;

namespace ShapeDetection
{
    public partial class MainForm : Form
    {

        double minHue = 0.0; //0..<360
        double minSat = 0.0; //0..100
        double minVal = 0.0; // 0..100

        double maxHue = 359.9;
        double maxSat = 255.0;
        double maxVal = 255.0;
        Hsv min;
        Hsv max;

        Image<Bgr, Byte> img;
        Image<Hsv, Byte> imgHsv;
        Image<Gray, Byte> maskHsvBlack;
        Image<Gray, Byte> maskHsvBlue;
        Image<Gray, Byte> maskHsv;
        Image<Bgr, Byte> resultImg;

        public MainForm()
        {
            InitializeComponent();

            MaxHueTB.Value = Convert.ToInt32(maxHue);
            MaxSatTB.Value = Convert.ToInt32(maxSat);
            MaxValTB.Value = Convert.ToInt32(maxVal);
            MaxHueText.Text = Convert.ToString(maxHue);
            MaxSatText.Text = Convert.ToString(maxSat);
            MaxValText.Text = Convert.ToString(maxVal);

            MinHueTB.Value = Convert.ToInt32(minHue);
            MinSatTB.Value = Convert.ToInt32(minSat);
            MinValTB.Value = Convert.ToInt32(minVal);
            MinHueText.Text = Convert.ToString(maxHue);
            MinSatText.Text = Convert.ToString(maxSat);
            MinValText.Text = Convert.ToString(maxVal);

            min = new Hsv(minHue, minSat, minVal);
            max = new Hsv(maxHue, maxSat, maxVal);

            fileNameTextBox.Text = "C:\\Emgu\\emgucv-windows-universal 3.0.0.2157\\Emgu.CV.Example\\ShapeDetection\\pic3.png";
        }

        public void PerformShapeDetection()
        {
            if (fileNameTextBox.Text != String.Empty)
            {
                Stopwatch watch = Stopwatch.StartNew();
                watch.Start();
                StringBuilder msgBuilder = new StringBuilder("Performance: ");

                #region get image

                img = new Image<Bgr, byte>(fileNameTextBox.Text);
                img = img.Resize(0.5, Inter.Linear).SmoothMedian(5);
                #endregion

                #region HSV magic
                //min.Hue = MinHueTB.Value; min.Satuation = MinSatTB.Value; min.Value = MinValTB.Value;
                //max.Hue = MaxHueTB.Value; max.Satuation = MaxSatTB.Value; max.Value = MaxValTB.Value;

                HsvMagic(img, maskHsvBlack, maskHsvBlue);
                
                circleImageBox.Image = maskHsvBlack;
                originalImageBox.Image = img;
                
                img.ToBitmap().Save("C:\\Emgu\\Dump\\Img.png",System.Drawing.Imaging.ImageFormat.Png);
                maskHsvBlack.ToBitmap().Save("C:\\Emgu\\Dump\\maskHsvBlack.png",  System.Drawing.Imaging.ImageFormat.Png);
                maskHsvBlue.ToBitmap().Save("C:\\Emgu\\Dump\\maskHsvBlue.png",  System.Drawing.Imaging.ImageFormat.Png);
                #endregion
                

                #region Canny and edge detection

                double cannyThreshold = 1.0;
                double cannyThresholdLinking = 500.0;

                Image<Gray, Byte> cannyBlue = maskHsvBlue.Canny(cannyThreshold, cannyThresholdLinking);
                Image<Gray, Byte> cannyBlack = maskHsvBlack.Canny(cannyThreshold, cannyThresholdLinking);

                watch.Stop();
                msgBuilder.Append(String.Format("Hsv and Canny - {0} ms; ", watch.ElapsedMilliseconds));
                #endregion
                cannyBlue.ToBitmap().Save("C:\\Emgu\\Dump\\cannyBlue.png", System.Drawing.Imaging.ImageFormat.Png);
                cannyBlack.ToBitmap().Save("C:\\Emgu\\Dump\\cannyBlack.png", System.Drawing.Imaging.ImageFormat.Png);
                
                #region Find  rectangles

                #region detect black borders
                VectorOfVectorOfPoint blackborders = new VectorOfVectorOfPoint();//list of black borders
                List<RotatedRect> Black_boxList = new List<RotatedRect>(); //a box is a rotated rectangle
                VectorOfVectorOfPoint othercontours_black = new VectorOfVectorOfPoint();
                getBlackContours(cannyBlack, blackborders, Black_boxList, othercontours_black);
                resultImg = cannyBlack.Convert<Bgr, Byte>();
                #endregion

                #region blue borders

                VectorOfVectorOfPoint blueborders = new VectorOfVectorOfPoint();//list of blue borders
                List<RotatedRect> Blue_boxList = new List<RotatedRect>(); //a box is a rotated rectangle
                VectorOfVectorOfPoint othercontours_blue = new VectorOfVectorOfPoint();
                getBlueContours(cannyBlue, blueborders, Blue_boxList, othercontours_blue);

                #endregion

              
              #region clear duplicate boxes
           
                List<RotatedRect> fltrBlue_boxList = new List<RotatedRect>();
                SizeF TMP_SizeF = new SizeF(0,0);
                PointF TMP_PointF = new PointF(0, 0);
                float TMP_Angle = 0;
                

                if (Blue_boxList.Count >= 2)
                {
                  for (int i = 1; i < Blue_boxList.Count; i++)
                  {
                    if (Blue_boxList[i - 1].Size.Width * Blue_boxList[i - 1].Size.Height > 750)
                    {
                      if (Math.Abs(Blue_boxList[i - 1].Angle - Blue_boxList[i].Angle) < 1)
                      {
                        if (Math.Abs(Blue_boxList[i - 1].Center.X - Blue_boxList[i].Center.X) < 1 && Math.Abs(Blue_boxList[i - 1].Center.Y - Blue_boxList[i].Center.Y) < 1)
                          if (Math.Abs(Blue_boxList[i - 1].Size.Width - Blue_boxList[i].Size.Width) < 1 && Math.Abs(Blue_boxList[i - 1].Size.Height - Blue_boxList[i].Size.Height) < 1)
                          {
                            TMP_PointF.X = (float)(0.5 * (Blue_boxList[i - 1].Center.X + Blue_boxList[i].Center.X));
                            TMP_PointF.Y = (float)(0.5 * (Blue_boxList[i - 1].Center.Y + Blue_boxList[i].Center.Y));
                            TMP_SizeF.Width = (float)(0.5 * (Blue_boxList[i - 1].Size.Width + Blue_boxList[i].Size.Width));
                            TMP_SizeF.Height = (float)(0.5 * (Blue_boxList[i - 1].Size.Height + Blue_boxList[i].Size.Height));
                            TMP_Angle = (float)(0.5 * (Blue_boxList[i - 1].Angle + Blue_boxList[i].Angle));
                            fltrBlue_boxList.Add(new RotatedRect(TMP_PointF, TMP_SizeF, TMP_Angle));
                            
                          }
                      }
                      else fltrBlue_boxList.Add(Blue_boxList[i]);
                    }
                  }
                }
                else { fltrBlue_boxList = Blue_boxList; } //Blue_boxList.Clear(); }

                List<RotatedRect> fltrBlack_boxList = new List<RotatedRect>();
              VectorOfVectorOfPoint fltr_blackborders = new VectorOfVectorOfPoint();
                TMP_SizeF.Width = 0;
                TMP_SizeF.Height = 0;
                TMP_PointF.X = 0;
                TMP_PointF.Y = 0;
                TMP_Angle = 0;

                if (Black_boxList.Count >= 2)
                {
                  for (int i = 1; i < Black_boxList.Count; i++)
                  {
                    if (Black_boxList[i - 1].Size.Width * Black_boxList[i - 1].Size.Height > 10)
                    {
                      if (Math.Abs(Black_boxList[i - 1].Angle - Black_boxList[i].Angle) < 1)
                      {
                        if (Math.Abs(Black_boxList[i - 1].Center.X - Black_boxList[i].Center.X) < 1 && Math.Abs(Black_boxList[i - 1].Center.Y - Black_boxList[i].Center.Y) < 1)
                          if (Math.Abs(Black_boxList[i - 1].Size.Width - Black_boxList[i].Size.Width) < 1 && Math.Abs(Black_boxList[i - 1].Size.Height - Black_boxList[i].Size.Height) < 1)
                          {
                            TMP_PointF.X = (float)(0.5 * (Black_boxList[i - 1].Center.X + Black_boxList[i].Center.X));
                            TMP_PointF.Y = (float)(0.5 * (Black_boxList[i - 1].Center.Y + Black_boxList[i].Center.Y));
                            TMP_SizeF.Width = (float)(0.5 * (Black_boxList[i - 1].Size.Width + Black_boxList[i].Size.Width));
                            TMP_SizeF.Height = (float)(0.5 * (Black_boxList[i - 1].Size.Height + Black_boxList[i].Size.Height));
                            TMP_Angle = (float)(0.5 * (Black_boxList[i - 1].Angle + Black_boxList[i].Angle));
                            fltrBlack_boxList.Add(new RotatedRect(TMP_PointF, TMP_SizeF, TMP_Angle));
                            //fltr_blackborders.Push();
                          }
                      }
                      else fltrBlack_boxList.Add(Black_boxList[i]);
                    }
                  }
                }
                else { fltrBlack_boxList = Black_boxList; }//Black_boxList.Clear(); }
                #endregion
              

              //////////
                circleImageBox.Image = maskHsvBlack;
              ////////////

                CvInvoke.DrawContours(resultImg, blackborders, -1, new Bgr(Color.Green).MCvScalar);
                CvInvoke.DrawContours(resultImg, othercontours_black, -1, new Bgr(Color.Red).MCvScalar);
                CvInvoke.DrawContours(resultImg, blueborders, -1, new Bgr(Color.Blue).MCvScalar);

                foreach (RotatedRect box in fltrBlack_boxList)
                {
                    CvInvoke.Polylines(resultImg, Array.ConvertAll(box.GetVertices(), Point.Round), true, new Bgr(Color.Aqua).MCvScalar, 1);
                }
                foreach (RotatedRect box in Black_boxList)
                {
                  CvInvoke.Polylines(img, Array.ConvertAll(box.GetVertices(), Point.Round), true, new Bgr(Color.Pink).MCvScalar, 1);
                }
                foreach (RotatedRect box in Blue_boxList)
                {
                  CvInvoke.Polylines(img, Array.ConvertAll(box.GetVertices(), Point.Round), true, new Bgr(Color.DarkViolet).MCvScalar, 1);
                }
                foreach (RotatedRect box in fltrBlue_boxList)
                {
                  CvInvoke.Polylines(resultImg, Array.ConvertAll(box.GetVertices(), Point.Round), true, new Bgr(Color.Yellow).MCvScalar, 1);
                }
                triangleRectangleImageBox.Image = resultImg;
                originalImageBox.Image = img;

                #region save to files 
                Image<Bgr, Byte> TMPImageforSaving = new Image<Bgr, byte>(maskHsvBlack.Width, maskHsvBlack.Height, new Bgr(Color.Black));
                CvInvoke.DrawContours(TMPImageforSaving, blackborders, -1, new Bgr(Color.Green).MCvScalar);
                CvInvoke.DrawContours(TMPImageforSaving, othercontours_black, -1, new Bgr(Color.Red).MCvScalar);

                foreach (RotatedRect box in Black_boxList)
                {
                  CvInvoke.Polylines(TMPImageforSaving, Array.ConvertAll(box.GetVertices(), Point.Round), true, new Bgr(Color.Pink).MCvScalar, 1);
                }
                TMPImageforSaving.ToBitmap().Save("C:\\Emgu\\Dump\\NonFltrBlack.png", System.Drawing.Imaging.ImageFormat.Png);

                TMPImageforSaving = new Image<Bgr, byte>(TMPImageforSaving.Width, TMPImageforSaving.Height, new Bgr(Color.Black));
                CvInvoke.DrawContours(TMPImageforSaving, blackborders, -1, new Bgr(Color.Green).MCvScalar);
                CvInvoke.DrawContours(TMPImageforSaving, othercontours_black, -1, new Bgr(Color.Red).MCvScalar);
                foreach (RotatedRect box in Blue_boxList)
                {
                  CvInvoke.Polylines(TMPImageforSaving, Array.ConvertAll(box.GetVertices(), Point.Round), true, new Bgr(Color.DarkViolet).MCvScalar, 1);
                }
                TMPImageforSaving.ToBitmap().Save("C:\\Emgu\\Dump\\NonFltrBlue.png", System.Drawing.Imaging.ImageFormat.Png);
                TMPImageforSaving = new Image<Bgr, byte>(maskHsvBlack.Width, maskHsvBlack.Height, new Bgr(Color.Black));
                CvInvoke.DrawContours(TMPImageforSaving, blackborders, -1, new Bgr(Color.Green).MCvScalar);
                CvInvoke.DrawContours(TMPImageforSaving, othercontours_black, -1, new Bgr(Color.Red).MCvScalar);

                foreach (RotatedRect box in fltrBlack_boxList)
                {
                  CvInvoke.Polylines(TMPImageforSaving, Array.ConvertAll(box.GetVertices(), Point.Round), true, new Bgr(Color.Aqua).MCvScalar, 1);
                }
                TMPImageforSaving.ToBitmap().Save("C:\\Emgu\\Dump\\FltrBlack.png", System.Drawing.Imaging.ImageFormat.Png);

                TMPImageforSaving = new Image<Bgr, byte>(TMPImageforSaving.Width, TMPImageforSaving.Height, new Bgr(Color.Black));
                CvInvoke.DrawContours(TMPImageforSaving, blackborders, -1, new Bgr(Color.Green).MCvScalar);
                CvInvoke.DrawContours(TMPImageforSaving, othercontours_black, -1, new Bgr(Color.Red).MCvScalar);
                foreach (RotatedRect box in fltrBlue_boxList)
                {
                  CvInvoke.Polylines(TMPImageforSaving, Array.ConvertAll(box.GetVertices(), Point.Round), true, new Bgr(Color.Yellow).MCvScalar, 1);
                }
                TMPImageforSaving.ToBitmap().Save("C:\\Emgu\\Dump\\FltrBlue.png", System.Drawing.Imaging.ImageFormat.Png);
                #endregion


              /*
                List<VectorOfPoint> contours_for_work = new List<VectorOfPoint>();
                using (VectorOfVectorOfPoint contours = blackborders)
                {
                  for (int i = 0; i < contours.Size; i++)
                  {
                    contours_for_work.Add(contours[i]);
                  }
                }
                contours_for_work.Sort((VectorOfPoint cont1, VectorOfPoint cont2) =>
                 (bool) (CvInvoke.ContourArea(cont1) > CvInvoke.ContourArea(cont1)) );
              */
              
                VectorOfVectorOfPoint Big = new VectorOfVectorOfPoint();
                bool ready = false;
                using (VectorOfVectorOfPoint contours = blackborders)
                {
                    for (int i = 0; i < contours.Size && !ready; i++)
                    {

                        VectorOfPoint contourI = contours[i];
                        for (int j = i + 1; j < contours.Size && !ready; j++)
                        {
                            if (0.38 * CvInvoke.ContourArea(contours[j]) > CvInvoke.ContourArea(contourI) && 0.26 * CvInvoke.ContourArea(contours[j]) < CvInvoke.ContourArea(contourI))
                            {
                                Big.Push(contours[j]);
                                Big.Push(contours[i]);
                                ready = !ready;
                            }
                        }
                    }
                }


                TMPImageforSaving = new Image<Bgr, Byte>(resultImg.Width, resultImg.Height, new Bgr(Color.Black));
                CvInvoke.DrawContours(TMPImageforSaving, Big, -1, new Bgr(Color.White).MCvScalar);
                TMPImageforSaving.ToBitmap().Save("C:\\Emgu\\Dump\\DetectedContours.png", System.Drawing.Imaging.ImageFormat.Png);
              imgHsv[0].ToBitmap().Save("C:\\Emgu\\Dump\\ImgHsv - Hue.png", System.Drawing.Imaging.ImageFormat.Png);
              imgHsv[1].ToBitmap().Save("C:\\Emgu\\Dump\\ImgHsv - Sat.png", System.Drawing.Imaging.ImageFormat.Png);
              imgHsv[2].ToBitmap().Save("C:\\Emgu\\Dump\\ImgHsv - Val.png", System.Drawing.Imaging.ImageFormat.Png);
              Image<Hls, byte> HlsImg = img.Convert<Hls, Byte>();


              HlsImg[0].ToBitmap().Save("C:\\Emgu\\Dump\\Img HLS - Hue.png", System.Drawing.Imaging.ImageFormat.Png);
              HlsImg[1].ToBitmap().Save("C:\\Emgu\\Dump\\Img HLS - Light.png", System.Drawing.Imaging.ImageFormat.Png);
              HlsImg[2].ToBitmap().Save("C:\\Emgu\\Dump\\Img HLS - Sat.png", System.Drawing.Imaging.ImageFormat.Png);

                lineImageBox.Image = TMPImageforSaving;
                
              
                watch.Stop();
                msgBuilder.Append(String.Format("Triangles & Rectangles - {0} ms; ", watch.ElapsedMilliseconds));
                #endregion
                /*    


                  lineImageBox.Image = resultImg;
                  originalImageBox.Image = img;
                  this.Text = msgBuilder.ToString();

                  #region draw and rectangles
                  Mat triangleRectangleImage = new Mat(img.Size, DepthType.Cv8U, 3);
                  triangleRectangleImage.SetTo(new MCvScalar(0));

                  foreach (RotatedRect box in boxList)
                  {
                      CvInvoke.Polylines(triangleRectangleImage, Array.ConvertAll(box.GetVertices(), Point.Round), true, new Bgr(Color.DarkOrange).MCvScalar, 2);
                  }

                  triangleRectangleImageBox.Image = triangleRectangleImage;
                  #endregion
                 
                  #region draw lines
                  /*Mat lineImage = new Mat(img.Size, DepthType.Cv8U, 3);
                  lineImage.SetTo(new MCvScalar(0));
                 foreach (LineSegment2D line in lines)
                   CvInvoke.Line(lineImage, line.P1, line.P2, new Bgr(Color.Green).MCvScalar, 2);

                  lineImageBox.Image = lineImage;
                  #endregion
              }
          }

          #region draw
          //foreach (LineSegment2D line in lines)
              //CvInvoke.Line(lineImage, line.P1, line.P2, new Bgr(Color.Green).MCvScalar, 2);
            

          #endregion
               * */
            }
        }


        public void FilterBlackBorders(VectorOfVectorOfPoint blackborders, List<RotatedRect> Black_boxlist, VectorOfVectorOfPoint othercontours_black)
        {

        }
        public void getBlueContours(Image<Gray, Byte> src, VectorOfVectorOfPoint blueborders, List<RotatedRect> Blue_boxList, VectorOfVectorOfPoint othercontours_blue)
        {
          //blueborders = new VectorOfVectorOfPoint();//list of blue borders
          //Blue_boxList = new List<RotatedRect>(); //a box is a rotated rectangle
          //othercontours_blue = new VectorOfVectorOfPoint();

          using (VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint())
          {
            CvInvoke.FindContours(src, contours, null, RetrType.List, ChainApproxMethod.ChainApproxSimple);

            for (int i = 0; i < contours.Size; i++)
            {
              using (VectorOfPoint contour = contours[i])
              using (VectorOfPoint approxContour = new VectorOfPoint())
              {
                CvInvoke.ApproxPolyDP(contour, approxContour, CvInvoke.ArcLength(contour, true) * 0.05, true);
                if (CvInvoke.ContourArea(approxContour, false) > 250 && CvInvoke.BoundingRectangle(approxContour).Width * CvInvoke.BoundingRectangle(approxContour).Height > 1000) //only consider contours with area greater than 250
                {
                  if (approxContour.Size == 4)
                  {
                    Blue_boxList.Add(CvInvoke.MinAreaRect(approxContour));
                    blueborders.Push(contour);
                  }
                  else
                  {
                    othercontours_blue.Push(contour);
                    //Point[] pts = approxContour.ToArray();
                    //other.Add(PointCollection.PolyLine(pts, true));
                  }
                }
              }
            }
          }
        }

      public void getBlackContours(Image<Gray, Byte> src, VectorOfVectorOfPoint blackborders, List<RotatedRect> Black_boxList, VectorOfVectorOfPoint othercontours_black)
      {
         //blackborders = new VectorOfVectorOfPoint();//list of black borders
         //Black_boxList = new List<RotatedRect>(); //a box is a rotated rectangle
         //othercontours_black = new VectorOfVectorOfPoint();

        Bitmap TMPGood = new Bitmap(src.ToBitmap() , src.Width, src.Height);
        Bitmap TMPBad = new Bitmap(src.ToBitmap(), src.Width, src.Height);
        Graphics gGood = Graphics.FromImage(TMPGood);
        Graphics gBad = Graphics.FromImage(TMPBad);
        //Pen RedPen = new Pen(Color.Red);
        //Pen GreenPen = new Pen(Color.Green);
        Brush RedBrush = new SolidBrush(Color.Red);
        Brush GreenBrush = new SolidBrush(Color.Green);

                using (VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint())
                {
                  CvInvoke.FindContours(src, contours, null, RetrType.List, ChainApproxMethod.ChainApproxSimple);
                    for (int i = 0; i < contours.Size; i++)
                    {
                        using (VectorOfPoint contour = contours[i])
                        using (VectorOfPoint approxContour = new VectorOfPoint())
                        {
                          Point[] ptsContour = contour.ToArray();
                          for (int k = 0; k < ptsContour.Length; k++)
                          {
                            gBad.FillEllipse(RedBrush, ptsContour[k].X, ptsContour[k].Y, 6, 6);
                          }

                            CvInvoke.ApproxPolyDP(contour, approxContour, CvInvoke.ArcLength(contour, true) * 0.05, true);
                            if (CvInvoke.ContourArea(approxContour, false) > 250) //only consider contours with area greater than 250
                            {
                              Point[] ptsApprox = approxContour.ToArray();
                             

                              //TMP.Draw(pts, new Bgr(Color.DarkOrange), 5); //!!!!!!!!!!!!!!!
                              for (int k = 0; k < ptsApprox.Length; k++)
                              {
                                gGood.FillEllipse(GreenBrush, ptsApprox[k].X, ptsApprox[k].Y, 6, 6);
                              }
                              


                                if (CvInvoke.ContourArea(approxContour, false) > 250 && approxContour.Size == 4)
                                {
                                    Black_boxList.Add(CvInvoke.MinAreaRect(approxContour));
                                    blackborders.Push(contour);
                                }
                                else
                                {
                                    othercontours_black.Push(contour);
                                    //Point[] pts = approxContour.ToArray();
                                    //other.Add(PointCollection.PolyLine(pts, true));
                                }
                            }
                        }
                    }
                }
                TMPGood.Save("C:\\Emgu\\Dump\\Black contour corners GOOD.png", System.Drawing.Imaging.ImageFormat.Png);
                TMPBad.Save("C:\\Emgu\\Dump\\Black contour corners BAD.png", System.Drawing.Imaging.ImageFormat.Png);
      }



        public void HsvMagic(Image<Bgr, Byte> src, Image<Gray, Byte> black_dst, Image<Gray, Byte> blue_dst)
        {
          Hsv blueVal_min = new Hsv(0, 50, 125); Hsv blueVal_max = new Hsv(359.9, 255, 255);
          Hsv blackVal_min = new Hsv(0, 0, 100); Hsv blackVal_max = new Hsv(360, 255, 255);
          imgHsv = src.Convert<Hsv, Byte>();

          // borders
          maskHsvBlack = getBlackHsvMack(imgHsv, blackVal_min, blackVal_max);
          //blue
          maskHsvBlue = getBlueHsvMask(imgHsv, blueVal_min, blueVal_max);
          //other 
          //maskHsv = new Image<Gray, Byte>(imgHsv.Width, imgHsv.Height);
          //CvInvoke.BitwiseXor(maskHsvBlue, maskHsvBlack, maskHsv);
        }

        public Image<Gray, Byte> getBlueHsvMask(Image<Hsv, Byte> src, Hsv blue_min, Hsv blue_max)
        {
          Image<Gray, Byte> TMP = new Image<Gray, byte>(src.Width, src.Height);
          TMP = src.InRange(blue_min, blue_max);
          return TMP;
        }

        public Image<Gray, Byte> getBlackHsvMack(Image<Hsv, Byte> src, Hsv black_min, Hsv black_max)
        {
          //maskHsvBlack = new Image<Gray, byte>(img.Size.Width, img.Size.Height, new Gray(0));
          src.Convert<Bgr, Byte>();
          byte[, ,] data = src.Data;

          Image<Bgr, Byte> TMP = new Image<Bgr, byte>(src.Width, src.Height);
          byte[, ,] dst = TMP.Data;
          /*
          bool IsBlack;
          const int grayMax = 120;
          const double blueProp = 1.8;
          const double greeProp = 2.5;
          const double redProp = 2.5;
          const byte zeroLevel = 50;
          const byte treshhold = 35;
          for (int i = img.Rows - 1; i >= 0; i--)
          {
            for (int j = img.Cols - 1; j >= 0; j--)
            {
              IsBlack = true;
              // 0 - blue
              // 1 - green
              // 2 - red
              //new great, god like code
              //debug

              byte b = data[i, j, 0];
              byte g = data[i, j, 1];
              byte r = data[i, j, 2];
              if (b > grayMax)
                IsBlack = false;
              if (g > grayMax)
                IsBlack = false;
              if (r > grayMax)
                IsBlack = false;
              /*if (IsBlack)
              {
                  int debug = 0;
              }*/
            /*if (b >= zeroLevel && g >= zeroLevel && r >= zeroLevel)
              {
                IsBlack = false;
              /*
                //too many blue
                if (b * blueProp >= g || b * blueProp >= r)
                  if (b > r + treshhold || b > g + treshhold)
                    IsBlack = false;
                //too many green
                if (g * greeProp >= r || g * greeProp >= b)
                  if (g > r + treshhold || g > b + treshhold)
                    IsBlack = false;
                //too many red
                if (r * redProp >= g || r * redProp <= b)
                  if (r > b + treshhold || r > g + treshhold)
                    IsBlack = false;
               * */
            //  }
            /*if (IsBlack)
            {
              dst[i, j, 0] = dst[i, j, 1] = dst[i, j, 2] = 0;
            }
            else { dst[i, j, 0] = dst[i, j, 1] = dst[i, j, 2] = 255; }
            }
          }
          
          */
          
          TMP = img.InRange(new Bgr(0, 0, 0), new Bgr(90, 90, 90)).Convert<Bgr,Byte>();
          return TMP.Convert<Gray, byte>();
        }


        #region Menu stuff
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            PerformShapeDetection();
        }

        private void loadImageButton_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK || result == DialogResult.Yes)
            {
                fileNameTextBox.Text = openFileDialog1.FileName;
            }
        }

        private void MinHueTB_Scroll(object sender, EventArgs e)
        {
            if (MinHueTB.Value >= MaxHueTB.Value)
            {
                MinHueTB.Value = MaxHueTB.Value - 1;
                minHue = Convert.ToDouble(MinHueTB.Value);
                MinHueText.Text = Convert.ToString(minHue);
            }
            else
            {
                minHue = Convert.ToDouble(MinHueTB.Value);
                MinHueText.Text = Convert.ToString(minHue);
            }
            PerformShapeDetection();
        }

        private void MinSatTB_Scroll(object sender, EventArgs e)
        {

            if (MinSatTB.Value >= MaxSatTB.Value)
            {
                MinSatTB.Value = MaxSatTB.Value - 1;
                minSat = Convert.ToDouble(MinSatTB.Value);
                MinSatTB.Text = Convert.ToString(minSat);
            }
            else
            {
                minSat = Convert.ToDouble(MinSatTB.Value);
                MinSatText.Text = Convert.ToString(minSat);
            }
            PerformShapeDetection();
        }

        private void MinValTB_Scroll(object sender, EventArgs e)
        {
          
            if (MinValTB.Value >= MaxValTB.Value)
            {
                MinValTB.Value = MaxValTB.Value - 1;
                minVal = Convert.ToDouble(MinValTB.Value);
                MinValText.Text = Convert.ToString(minVal);
            }
            else
            {
                minVal = Convert.ToDouble(MinValTB.Value);
                MinValText.Text = Convert.ToString(minVal);
            }
            PerformShapeDetection();
        }

        private void MaxHueTB_Scroll(object sender, EventArgs e)
        {
            if (MaxHueTB.Value <= MinHueTB.Value)
            {
                MaxHueTB.Value = MinHueTB.Value + 1;
                maxHue = Convert.ToDouble(MaxHueTB.Value);
                MaxHueText.Text = Convert.ToString(maxHue);

            }
            else
            {
                maxHue = Convert.ToDouble(MaxHueTB.Value);
                MaxHueText.Text = Convert.ToString(maxHue);
            }
            PerformShapeDetection();
        }

        private void MaxSatTB_Scroll(object sender, EventArgs e)
        {


            if (MaxSatTB.Value <= MinSatTB.Value)
            {
                MaxSatTB.Value = MinSatTB.Value + 1;
                maxSat = Convert.ToDouble(MaxSatTB.Value);
                MaxSatText.Text = Convert.ToString(maxSat);
            }
            else
            {
                maxSat = Convert.ToDouble(MaxSatTB.Value);
                MaxSatText.Text = Convert.ToString(maxSat);
            }
            PerformShapeDetection();
        }

        private void MaxValTB_Scroll(object sender, EventArgs e)
        {

            if (MaxValTB.Value <= MinValTB.Value)
            {
                MaxValTB.Value = MinValTB.Value + 1;
                maxVal = Convert.ToDouble(MaxValTB.Value);
                MaxValText.Text = Convert.ToString(maxVal);
            }
            else
            {
                maxVal = Convert.ToDouble(MaxValTB.Value);
                MaxValText.Text = Convert.ToString(maxVal);
            }
            PerformShapeDetection();
        }

        private void CaptureBtn_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}


/*
//----------------------------------------------------------------------------
//  Copyright (C) 2004-2015 by EMGU Corporation. All rights reserved.       
//----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System.Diagnostics;
using Emgu.CV.Util;

namespace ShapeDetection
{
   public partial class MainForm : Form
   {

      public MainForm()
      {
         InitializeComponent();

         fileNameTextBox.Text = "pic3.png";
      }

      public void PerformShapeDetection()
      {
         if (fileNameTextBox.Text != String.Empty)
         {
            StringBuilder msgBuilder = new StringBuilder("Performance: ");

            //Load the image from file and resize it for display
            Image<Bgr, Byte> img = 
               new Image<Bgr, byte>(fileNameTextBox.Text)
               .Resize(400, 400, Emgu.CV.CvEnum.Inter.Linear, true);

            //Convert the image to grayscale and filter out the noise
            UMat uimage = new UMat();
            CvInvoke.CvtColor(img, uimage, ColorConversion.Bgr2Gray);

            //use image pyr to remove noise
            UMat pyrDown = new UMat();
            CvInvoke.PyrDown(uimage, pyrDown);
            CvInvoke.PyrUp(pyrDown, uimage);
            
            //Image<Gray, Byte> gray = img.Convert<Gray, Byte>().PyrDown().PyrUp();

            #region circle detection
            Stopwatch watch = Stopwatch.StartNew();
            double cannyThreshold = 180.0;
            double circleAccumulatorThreshold = 120;
            CircleF[] circles = CvInvoke.HoughCircles(uimage, HoughType.Gradient, 2.0, 20.0, cannyThreshold, circleAccumulatorThreshold, 5);

            watch.Stop();
            msgBuilder.Append(String.Format("Hough circles - {0} ms; ", watch.ElapsedMilliseconds));
            #endregion

            #region Canny and edge detection
            watch.Reset(); watch.Start();
            double cannyThresholdLinking = 120.0;
            UMat cannyEdges = new UMat();
            CvInvoke.Canny(uimage, cannyEdges, cannyThreshold, cannyThresholdLinking);

            LineSegment2D[] lines = CvInvoke.HoughLinesP(
               cannyEdges, 
               1, //Distance resolution in pixel-related units
               Math.PI/45.0, //Angle resolution measured in radians.
               20, //threshold
               30, //min Line width
               10); //gap between lines

            watch.Stop();
            msgBuilder.Append(String.Format("Canny & Hough lines - {0} ms; ", watch.ElapsedMilliseconds));
            #endregion

            #region Find triangles and rectangles
            watch.Reset(); watch.Start();
            List<Triangle2DF> triangleList = new List<Triangle2DF>();
            List<RotatedRect> boxList = new List<RotatedRect>(); //a box is a rotated rectangle

            using (VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint())
            {
               CvInvoke.FindContours(cannyEdges, contours, null, RetrType.List, ChainApproxMethod.ChainApproxSimple );
               int count = contours.Size;
               for (int i = 0; i < count; i++)
               {
                  using (VectorOfPoint contour = contours[i])
                  using (VectorOfPoint approxContour = new VectorOfPoint())
                  {
                     CvInvoke.ApproxPolyDP(contour, approxContour, CvInvoke.ArcLength(contour, true) * 0.05, true);
                     if (CvInvoke.ContourArea(approxContour, false) > 250) //only consider contours with area greater than 250
                     {
                        if (approxContour.Size == 3) //The contour has 3 vertices, it is a triangle
                        {
                           Point[] pts = approxContour.ToArray();
                           triangleList.Add(new Triangle2DF(
                              pts[0],
                              pts[1],
                              pts[2]
                              ));
                        } else if (approxContour.Size == 4) //The contour has 4 vertices.
                        {
                           #region determine if all the angles in the contour are within [80, 100] degree
                           bool isRectangle = true;
                           Point[] pts = approxContour.ToArray();
                           LineSegment2D[] edges = PointCollection.PolyLine(pts, true);

                           for (int j = 0; j < edges.Length; j++)
                           {
                              double angle = Math.Abs(
                                 edges[(j + 1) % edges.Length].GetExteriorAngleDegree(edges[j]));
                              if (angle < 80 || angle > 100)
                              {
                                 isRectangle = false;
                                 break;
                              }
                           }
                           #endregion

                           if (isRectangle) boxList.Add(CvInvoke.MinAreaRect(approxContour));
                        }
                     }
                  }
               }
            }

            watch.Stop();
            msgBuilder.Append(String.Format("Triangles & Rectangles - {0} ms; ", watch.ElapsedMilliseconds));
            #endregion

            originalImageBox.Image = img;
            this.Text = msgBuilder.ToString();

            #region draw triangles and rectangles
            Mat triangleRectangleImage = new Mat(img.Size, DepthType.Cv8U, 3);
            triangleRectangleImage.SetTo(new MCvScalar(0));
            foreach (Triangle2DF triangle in triangleList)
            {
               CvInvoke.Polylines(triangleRectangleImage, Array.ConvertAll(triangle.GetVertices(), Point.Round), true, new Bgr(Color.DarkBlue).MCvScalar, 2);
            }
            foreach (RotatedRect box in boxList)
            {
               CvInvoke.Polylines(triangleRectangleImage, Array.ConvertAll(box.GetVertices(), Point.Round), true, new Bgr(Color.DarkOrange).MCvScalar, 2);
            }
               
            triangleRectangleImageBox.Image = triangleRectangleImage;
            #endregion

            #region draw circles
            Mat circleImage = new Mat(img.Size, DepthType.Cv8U, 3);
            circleImage.SetTo(new MCvScalar(0));
            foreach (CircleF circle in circles)
               CvInvoke.Circle(circleImage, Point.Round(circle.Center), (int) circle.Radius, new Bgr(Color.Brown).MCvScalar, 2);
               
            circleImageBox.Image = circleImage;
            #endregion

            #region draw lines
            Mat lineImage = new Mat(img.Size, DepthType.Cv8U, 3);
            lineImage.SetTo(new MCvScalar(0));
            foreach (LineSegment2D line in lines)
               CvInvoke.Line(lineImage, line.P1, line.P2, new Bgr(Color.Green).MCvScalar, 2);
               
            lineImageBox.Image = lineImage;
            #endregion
         }
      }

      private void textBox1_TextChanged(object sender, EventArgs e)
      {
         PerformShapeDetection();
      }

      private void loadImageButton_Click(object sender, EventArgs e)
      {
         DialogResult result = openFileDialog1.ShowDialog();
         if (result == DialogResult.OK || result == DialogResult.Yes)
         {
            fileNameTextBox.Text = openFileDialog1.FileName;
         }
      }
   }
}



*/