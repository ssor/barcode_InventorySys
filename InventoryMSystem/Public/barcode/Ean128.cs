using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Data;
using System.Drawing.Imaging;

namespace InventoryMSystemBarcode
{
    enum Code128Subset
    {
        SubsetA,
        SubsetB,
        SubsetC
    }
    public enum SaveTypes : int { JPG, BMP, PNG, GIF, TIFF, UNSPECIFIED };

    public class Ean128
    {
        private DataTable C128_Code = new DataTable("C128");
        List<string> encodedValueList = new List<string>();
        int Width = 400;
        int Height = 100;
        Color BackColor = Color.White;
        Color ForeColor = Color.Black;
        string encodedValue = string.Empty;
        string printData = string.Empty;
        Image _Encoded_Image = null;

        public Image Encoded_Image
        {
            get { return _Encoded_Image; }
            set { _Encoded_Image = value; }
        }

        public string EncodedValue
        {
            get { return encodedValue; }
            set { encodedValue = value; }
        }

        public string calculateChecksum(string data)
        {

            int initialChecksum = 105;
            int reminder = 0;
            int multiplier = 1;
            //char[] chars = value.ToCharArray();
            //for (multiplier = 1; multiplier <= chars.Length; multiplier++)
            //{
            //    initialChecksum = initialChecksum + multiplier * ((int)chars[multiplier - 1] - 32);
            //}
            for (int i = 0; i < data.Length; i += 2)
            {
                int defaultLength = 2;
                if ((data.Length - i) < 2)
                {
                    defaultLength = data.Length - i;
                }
                string strNumber = data.Substring(i, defaultLength);
                int num = int.Parse(strNumber);
                initialChecksum = initialChecksum + multiplier * num;
                multiplier++;
            }

            reminder = initialChecksum % 103;

            DataRow[] rows = null;
            rows = C128_Code.Select(string.Format("Value = '{0}'", reminder.ToString()));
            if (rows.Length > 0)
            {
                return rows[0]["Encoding"].ToString();
            }

            return null;
        }
        public Bitmap getEncodeImage(List<AIData> dataList, int width, int height)
        {
            this.init_Code128();
            encodedValue = getEncodedValue(dataList);

            this.Width = width;
            this.Height = height - 20;

            int iBarWidthModifier = 1;
            int shiftAdjustment = 0;
            int totalBarWidth = Width - Width % encodedValue.Length;
            shiftAdjustment = (Width % encodedValue.Length) / 2;

            Bitmap b = new Bitmap(Width, height);
            int iBarWidth = Width / encodedValue.Length;

            //draw image
            int pos = 0;

            using (Graphics g = Graphics.FromImage(b))
            {
                //clears the image and colors the entire background
                g.Clear(BackColor);

                //lines are fBarWidth wide so draw the appropriate color line vertically
                using (Pen backpen = new Pen(BackColor, iBarWidth / iBarWidthModifier))
                {
                    using (Pen pen = new Pen(ForeColor, iBarWidth / iBarWidthModifier))
                    {
                        while (pos < encodedValue.Length)
                        {
                            if (encodedValue[pos] == '1')
                                g.DrawLine(pen, new Point(pos * iBarWidth + shiftAdjustment + 1, 0), new Point(pos * iBarWidth + shiftAdjustment + 1, Height));

                            pos++;
                        }//while
                    }//using
                }//using
                int left = 0;
                int ifontsize = 15;
                SizeF stringSize = new SizeF();
                bool bSizeOK = false;
                Font drawFont = null;
                while (!bSizeOK)
                {
                    drawFont = new Font("Arial", ifontsize);
                    stringSize = g.MeasureString(printData, drawFont);
                    if (stringSize.Width < (totalBarWidth - 20))
                    {
                        bSizeOK = true;
                    }
                    else
                    {
                        ifontsize--;
                    }
                }

                left = (int)(width - stringSize.Width) / 2;
                // Create point for upper-left corner of drawing.
                PointF drawPoint = new PointF(left, Height);

                SolidBrush drawBrush = new SolidBrush(Color.Black);
                // Draw string to screen.
                g.DrawString(printData, drawFont, drawBrush, drawPoint);

            }//using
            _Encoded_Image = (Image)b;
            return b;
        }
                /// <summary>
        /// Saves an encoded image to a specified file and type.
        /// </summary>
        /// <param name="Filename">Filename to save to.</param>
        /// <param name="FileType">Format to use.</param>
        public void SaveImage(string Filename, SaveTypes FileType)
        {
            try
            {
                if (_Encoded_Image != null)
                {
                    System.Drawing.Imaging.ImageFormat imageformat;
                    switch (FileType)
                    {
                        case SaveTypes.GIF: imageformat = System.Drawing.Imaging.ImageFormat.Gif; break;
                        case SaveTypes.JPG: imageformat = System.Drawing.Imaging.ImageFormat.Jpeg; break;
                        case SaveTypes.PNG: imageformat = System.Drawing.Imaging.ImageFormat.Png; break;
                        case SaveTypes.TIFF: imageformat = System.Drawing.Imaging.ImageFormat.Tiff; break;
                        default: imageformat = System.Drawing.Imaging.ImageFormat.Bmp; break;
                    }//switch
                    ((Bitmap)_Encoded_Image).Save(Filename, imageformat);
                }//if
            }//try
            catch (Exception ex)
            {
                throw new Exception("无法保存条码：\n\n=======================\n\n" + ex.Message);
            }//catch
        }
        public Bitmap getEncodeImage(string data, int width, int height)
        {

            this.init_Code128();
            // 42090210
            encodedValue = getEncodedValue(data);

            this.Width = width;
            this.Height = height;

            int iBarWidthModifier = 1;
            int shiftAdjustment = 0;

            // 42 + 9*2+2*3+10*4 = 106
            // 106+105=211
            // 211%103 = 5 

            shiftAdjustment = (Width % encodedValue.Length) / 2;

            Bitmap b = new Bitmap(Width, Height);
            int iBarWidth = Width / encodedValue.Length;

            //draw image
            int pos = 0;

            using (Graphics g = Graphics.FromImage(b))
            {
                //clears the image and colors the entire background
                g.Clear(BackColor);

                //lines are fBarWidth wide so draw the appropriate color line vertically
                using (Pen backpen = new Pen(BackColor, iBarWidth / iBarWidthModifier))
                {
                    using (Pen pen = new Pen(ForeColor, iBarWidth / iBarWidthModifier))
                    {
                        while (pos < encodedValue.Length)
                        {
                            if (encodedValue[pos] == '1')
                                g.DrawLine(pen, new Point(pos * iBarWidth + shiftAdjustment + 1, 0), new Point(pos * iBarWidth + shiftAdjustment + 1, Height));

                            pos++;
                        }//while
                    }//using
                }//using
            }//using

            return b;
        }
        private string getEncodedValue(List<AIData> dataList)
        {
            string strReturn = string.Empty;
            if (dataList.Count <= 0)
            {
                return null;
            }
            string fnc1 = null;
            fnc1 = this.getEncodedValueByChar(Convert.ToChar(200).ToString(), Code128Subset.SubsetC);

            //设计每一组数据的编码值
            for (int i = 0; i < dataList.Count; i++)
            {
                string temp = dataList[i].ToString();
                this.printData = this.printData + string.Format("({0}){1}", dataList[i].AI, dataList[i].Data);
                string TempData = string.Empty;
                for (int j = 0; j < temp.Length; j += 2)
                {
                    string strNumber = temp.Substring(j, 2);
                    TempData += this.getEncodedValueByChar(strNumber, Code128Subset.SubsetC);
                }
                dataList[i].EncodedData = fnc1 + TempData;
                TempData = null;
            }
            string Start_C = this.getEncodedValueByChar("START_C", Code128Subset.SubsetC);
            strReturn += Start_C;
            string chksumdata = string.Empty;
            for (int i = 0; i < dataList.Count; i++)
            {
                strReturn += dataList[i].EncodedData;
                chksumdata += dataList[i].ToString();
            }
            string checkSerial = this.calculateChecksum(chksumdata);
            strReturn += checkSerial;
            string StopEncoding = null;
            StopEncoding = this.getEncodedValueByChar("STOP", Code128Subset.SubsetC);
            strReturn += StopEncoding;
            return strReturn;
        }
        private string getEncodedValue(string data)
        {

            //data = "01194211234500111599123110101234";
            string Start_C = null;
            DataRow[] rows = null;
            rows = C128_Code.Select("C = 'START_C'");
            if (rows.Length > 0)
            {
                Start_C = rows[0]["Encoding"].ToString();
            }
            string StopEncoding = null;
            StopEncoding = this.getEncodedValueByChar("STOP", Code128Subset.SubsetC);
            //rows = null;
            //rows = C128_Code.Select("C = 'STOP'");
            //if (rows.Length > 0)
            //{
            //    StopEncoding = rows[0]["Encoding"].ToString();
            //}

            string fnc1 = null;
            fnc1 = this.getEncodedValueByChar(Convert.ToChar(200).ToString(), Code128Subset.SubsetC);
            //rows = null;
            //rows = C128_Code.Select("Value = '102'");
            //if (rows.Length > 0)
            //{
            //    fnc1 = rows[0]["Encoding"].ToString();
            //}

            string EncodedDataValue = string.Empty;
            string TempData = string.Empty;
            for (int i = 0; i < data.Length; i += 2)
            {
                string strNumber = data.Substring(i, 2);
                TempData += this.getEncodedValueByChar(strNumber, Code128Subset.SubsetC);
                //DataRow[] rowsTemp = null;
                //rowsTemp = C128_Code.Select("C = '" + strNumber + "'");
                //if (rowsTemp.Length > 0)
                //{
                //    TempData += rowsTemp[0]["Encoding"].ToString();
                //}
                //else
                //{
                //    throw new Exception("输入数据的编码不存在");
                //}
                //TempData = null;
            }
            //42090210
            // 42 + 9*2+2*3+10*4 = 106
            // 106+105=211
            // 211%103 = 5 
            //string str42 = "10110111000";
            //string str9 = "11001001000";
            //string str2 = "11001100110";
            //string str5 = "10001001100";
            //Start_C = "11010011100";
            //StopEncoding = "1100011101011";
            // (10)45566(17)040301
            // (10 + 45 * 2 + 56 * 3 + 6 * 4 + 17 * 5 + 4*6 + 3 * 7 + 8 + 105)%103=20

            //fnc1 = "11110101110";
            //data = "104556617040301";
            //string str10 = "11001000100";
            //string str45 = this.getEncodedValueByChar("45", Code128Subset.SubsetC);
            //string str56 = this.getEncodedValueByChar("56", Code128Subset.SubsetC);
            //string str61 = this.getEncodedValueByChar("61", Code128Subset.SubsetC);
            //string str70 = this.getEncodedValueByChar("70", Code128Subset.SubsetC);
            //string str40 = this.getEncodedValueByChar("40", Code128Subset.SubsetC);
            //string str30 = this.getEncodedValueByChar("30", Code128Subset.SubsetC);
            //string str20 = this.getEncodedValueByChar("20", Code128Subset.SubsetC);
            //string str1 = this.getEncodedValueByChar("01", Code128Subset.SubsetC);
            //string str17 = this.getEncodedValueByChar("17", Code128Subset.SubsetC);
            //string str6 = this.getEncodedValueByChar("06", Code128Subset.SubsetC);
            //string str4 = this.getEncodedValueByChar("04", Code128Subset.SubsetC);
            //string str3 = this.getEncodedValueByChar("03", Code128Subset.SubsetC);
            //string strCodeB = this.getEncodedValueByChar("CODE_B", Code128Subset.SubsetC);
            //string strCodeC = this.getEncodedValueByChar("99", Code128Subset.SubsetC);
            string checkStartA = this.calculateChecksum(data);
            string Encoded_Value =
                //Start_C + fnc1 + str10 + str45 + str56 + str6 + fnc1 + str17 + str4 + str3 + str1 + checkStartA + StopEncoding;
                //Start_C + fnc1 + str10 + str45 + str56 + strCodeB + str6 + strCodeC + fnc1 + str17 + str4 + str3 + str1 + checkStartA + StopEncoding;
            Start_C + fnc1 + TempData + checkStartA + StopEncoding;
            //Start_C + fnc1 + TempData + checkStartA + StopEncoding;//只有一个AI时可以

            return Encoded_Value;
        }
        private string getEncodedValueByChar(string data, Code128Subset subset)
        {
            DataRow[] rows = null;

            if (subset == Code128Subset.SubsetA)
            {
                rows = C128_Code.Select("A = '" + data + "'");
                if (rows.Length > 0)
                {
                    return rows[0]["Encoding"].ToString();
                }
            }
            if (subset == Code128Subset.SubsetB)
            {
                rows = C128_Code.Select("B = '" + data + "'");
                if (rows.Length > 0)
                {
                    return rows[0]["Encoding"].ToString();
                }
            }
            if (subset == Code128Subset.SubsetC)
            {
                rows = C128_Code.Select("C = '" + data + "'");
                if (rows.Length > 0)
                {
                    return rows[0]["Encoding"].ToString();
                }
            }

            return null;

            return null;
        }
        private void init_Code128()
        {
            if (this.C128_Code.Rows.Count > 0)
            {
                return;
            }
            //set the table to case sensitive since there are upper and lower case values
            this.C128_Code.CaseSensitive = true;

            //set up columns
            this.C128_Code.Columns.Add("Value", typeof(string));
            this.C128_Code.Columns.Add("A", typeof(string));
            this.C128_Code.Columns.Add("B", typeof(string));
            this.C128_Code.Columns.Add("C", typeof(string));
            this.C128_Code.Columns.Add("Encoding", typeof(string));

            //populate data
            this.C128_Code.Rows.Add(new object[] { "0", " ", " ", "00", "11011001100" });
            this.C128_Code.Rows.Add(new object[] { "1", "!", "!", "01", "11001101100" });
            this.C128_Code.Rows.Add(new object[] { "2", "\"", "\"", "02", "11001100110" });
            this.C128_Code.Rows.Add(new object[] { "3", "#", "#", "03", "10010011000" });
            this.C128_Code.Rows.Add(new object[] { "4", "$", "$", "04", "10010001100" });
            this.C128_Code.Rows.Add(new object[] { "5", "%", "%", "05", "10001001100" });
            this.C128_Code.Rows.Add(new object[] { "6", "&", "&", "06", "10011001000" });
            this.C128_Code.Rows.Add(new object[] { "7", "'", "'", "07", "10011000100" });
            this.C128_Code.Rows.Add(new object[] { "8", "(", "(", "08", "10001100100" });
            this.C128_Code.Rows.Add(new object[] { "9", ")", ")", "09", "11001001000" });
            this.C128_Code.Rows.Add(new object[] { "10", "*", "*", "10", "11001000100" });
            this.C128_Code.Rows.Add(new object[] { "11", "+", "+", "11", "11000100100" });
            this.C128_Code.Rows.Add(new object[] { "12", ",", ",", "12", "10110011100" });
            this.C128_Code.Rows.Add(new object[] { "13", "-", "-", "13", "10011011100" });
            this.C128_Code.Rows.Add(new object[] { "14", ".", ".", "14", "10011001110" });
            this.C128_Code.Rows.Add(new object[] { "15", "/", "/", "15", "10111001100" });
            this.C128_Code.Rows.Add(new object[] { "16", "0", "0", "16", "10011101100" });
            this.C128_Code.Rows.Add(new object[] { "17", "1", "1", "17", "10011100110" });
            this.C128_Code.Rows.Add(new object[] { "18", "2", "2", "18", "11001110010" });
            this.C128_Code.Rows.Add(new object[] { "19", "3", "3", "19", "11001011100" });
            this.C128_Code.Rows.Add(new object[] { "20", "4", "4", "20", "11001001110" });
            this.C128_Code.Rows.Add(new object[] { "21", "5", "5", "21", "11011100100" });
            this.C128_Code.Rows.Add(new object[] { "22", "6", "6", "22", "11001110100" });
            this.C128_Code.Rows.Add(new object[] { "23", "7", "7", "23", "11101101110" });
            this.C128_Code.Rows.Add(new object[] { "24", "8", "8", "24", "11101001100" });
            this.C128_Code.Rows.Add(new object[] { "25", "9", "9", "25", "11100101100" });
            this.C128_Code.Rows.Add(new object[] { "26", ":", ":", "26", "11100100110" });
            this.C128_Code.Rows.Add(new object[] { "27", ";", ";", "27", "11101100100" });
            this.C128_Code.Rows.Add(new object[] { "28", "<", "<", "28", "11100110100" });
            this.C128_Code.Rows.Add(new object[] { "29", "=", "=", "29", "11100110010" });
            this.C128_Code.Rows.Add(new object[] { "30", ">", ">", "30", "11011011000" });
            this.C128_Code.Rows.Add(new object[] { "31", "?", "?", "31", "11011000110" });
            this.C128_Code.Rows.Add(new object[] { "32", "@", "@", "32", "11000110110" });
            this.C128_Code.Rows.Add(new object[] { "33", "A", "A", "33", "10100011000" });
            this.C128_Code.Rows.Add(new object[] { "34", "B", "B", "34", "10001011000" });
            this.C128_Code.Rows.Add(new object[] { "35", "C", "C", "35", "10001000110" });
            this.C128_Code.Rows.Add(new object[] { "36", "D", "D", "36", "10110001000" });
            this.C128_Code.Rows.Add(new object[] { "37", "E", "E", "37", "10001101000" });
            this.C128_Code.Rows.Add(new object[] { "38", "F", "F", "38", "10001100010" });
            this.C128_Code.Rows.Add(new object[] { "39", "G", "G", "39", "11010001000" });
            this.C128_Code.Rows.Add(new object[] { "40", "H", "H", "40", "11000101000" });
            this.C128_Code.Rows.Add(new object[] { "41", "I", "I", "41", "11000100010" });
            this.C128_Code.Rows.Add(new object[] { "42", "J", "J", "42", "10110111000" });
            this.C128_Code.Rows.Add(new object[] { "43", "K", "K", "43", "10110001110" });
            this.C128_Code.Rows.Add(new object[] { "44", "L", "L", "44", "10001101110" });
            this.C128_Code.Rows.Add(new object[] { "45", "M", "M", "45", "10111011000" });
            this.C128_Code.Rows.Add(new object[] { "46", "N", "N", "46", "10111000110" });
            this.C128_Code.Rows.Add(new object[] { "47", "O", "O", "47", "10001110110" });
            this.C128_Code.Rows.Add(new object[] { "48", "P", "P", "48", "11101110110" });
            this.C128_Code.Rows.Add(new object[] { "49", "Q", "Q", "49", "11010001110" });
            this.C128_Code.Rows.Add(new object[] { "50", "R", "R", "50", "11000101110" });
            this.C128_Code.Rows.Add(new object[] { "51", "S", "S", "51", "11011101000" });
            this.C128_Code.Rows.Add(new object[] { "52", "T", "T", "52", "11011100010" });
            this.C128_Code.Rows.Add(new object[] { "53", "U", "U", "53", "11011101110" });
            this.C128_Code.Rows.Add(new object[] { "54", "V", "V", "54", "11101011000" });
            this.C128_Code.Rows.Add(new object[] { "55", "W", "W", "55", "11101000110" });
            this.C128_Code.Rows.Add(new object[] { "56", "X", "X", "56", "11100010110" });
            this.C128_Code.Rows.Add(new object[] { "57", "Y", "Y", "57", "11101101000" });
            this.C128_Code.Rows.Add(new object[] { "58", "Z", "Z", "58", "11101100010" });
            this.C128_Code.Rows.Add(new object[] { "59", "[", "[", "59", "11100011010" });
            this.C128_Code.Rows.Add(new object[] { "60", @"\", @"\", "60", "11101111010" });
            this.C128_Code.Rows.Add(new object[] { "61", "]", "]", "61", "11001000010" });
            this.C128_Code.Rows.Add(new object[] { "62", "^", "^", "62", "11110001010" });
            this.C128_Code.Rows.Add(new object[] { "63", "_", "_", "63", "10100110000" });
            this.C128_Code.Rows.Add(new object[] { "64", "\0", "`", "64", "10100001100" });
            this.C128_Code.Rows.Add(new object[] { "65", Convert.ToChar(1).ToString(), "a", "65", "10010110000" });
            this.C128_Code.Rows.Add(new object[] { "66", Convert.ToChar(2).ToString(), "b", "66", "10010000110" });
            this.C128_Code.Rows.Add(new object[] { "67", Convert.ToChar(3).ToString(), "c", "67", "10000101100" });
            this.C128_Code.Rows.Add(new object[] { "68", Convert.ToChar(4).ToString(), "d", "68", "10000100110" });
            this.C128_Code.Rows.Add(new object[] { "69", Convert.ToChar(5).ToString(), "e", "69", "10110010000" });
            this.C128_Code.Rows.Add(new object[] { "70", Convert.ToChar(6).ToString(), "f", "70", "10110000100" });
            this.C128_Code.Rows.Add(new object[] { "71", Convert.ToChar(7).ToString(), "g", "71", "10011010000" });
            this.C128_Code.Rows.Add(new object[] { "72", Convert.ToChar(8).ToString(), "h", "72", "10011000010" });
            this.C128_Code.Rows.Add(new object[] { "73", Convert.ToChar(9).ToString(), "i", "73", "10000110100" });
            this.C128_Code.Rows.Add(new object[] { "74", Convert.ToChar(10).ToString(), "j", "74", "10000110010" });
            this.C128_Code.Rows.Add(new object[] { "75", Convert.ToChar(11).ToString(), "k", "75", "11000010010" });
            this.C128_Code.Rows.Add(new object[] { "76", Convert.ToChar(12).ToString(), "l", "76", "11001010000" });
            this.C128_Code.Rows.Add(new object[] { "77", Convert.ToChar(13).ToString(), "m", "77", "11110111010" });
            this.C128_Code.Rows.Add(new object[] { "78", Convert.ToChar(14).ToString(), "n", "78", "11000010100" });
            this.C128_Code.Rows.Add(new object[] { "79", Convert.ToChar(15).ToString(), "o", "79", "10001111010" });
            this.C128_Code.Rows.Add(new object[] { "80", Convert.ToChar(16).ToString(), "p", "80", "10100111100" });
            this.C128_Code.Rows.Add(new object[] { "81", Convert.ToChar(17).ToString(), "q", "81", "10010111100" });
            this.C128_Code.Rows.Add(new object[] { "82", Convert.ToChar(18).ToString(), "r", "82", "10010011110" });
            this.C128_Code.Rows.Add(new object[] { "83", Convert.ToChar(19).ToString(), "s", "83", "10111100100" });
            this.C128_Code.Rows.Add(new object[] { "84", Convert.ToChar(20).ToString(), "t", "84", "10011110100" });
            this.C128_Code.Rows.Add(new object[] { "85", Convert.ToChar(21).ToString(), "u", "85", "10011110010" });
            this.C128_Code.Rows.Add(new object[] { "86", Convert.ToChar(22).ToString(), "v", "86", "11110100100" });
            this.C128_Code.Rows.Add(new object[] { "87", Convert.ToChar(23).ToString(), "w", "87", "11110010100" });
            this.C128_Code.Rows.Add(new object[] { "88", Convert.ToChar(24).ToString(), "x", "88", "11110010010" });
            this.C128_Code.Rows.Add(new object[] { "89", Convert.ToChar(25).ToString(), "y", "89", "11011011110" });
            this.C128_Code.Rows.Add(new object[] { "90", Convert.ToChar(26).ToString(), "z", "90", "11011110110" });
            this.C128_Code.Rows.Add(new object[] { "91", Convert.ToChar(27).ToString(), "{", "91", "11110110110" });
            this.C128_Code.Rows.Add(new object[] { "92", Convert.ToChar(28).ToString(), "|", "92", "10101111000" });
            this.C128_Code.Rows.Add(new object[] { "93", Convert.ToChar(29).ToString(), "}", "93", "10100011110" });
            this.C128_Code.Rows.Add(new object[] { "94", Convert.ToChar(30).ToString(), "~", "94", "10001011110" });

            this.C128_Code.Rows.Add(new object[] { "95", Convert.ToChar(31).ToString(), Convert.ToChar(127).ToString(), "95", "10111101000" });
            this.C128_Code.Rows.Add(new object[] { "96", Convert.ToChar(202).ToString()/*FNC3*/, Convert.ToChar(202).ToString()/*FNC3*/, "96", "10111100010" });
            this.C128_Code.Rows.Add(new object[] { "97", Convert.ToChar(201).ToString()/*FNC2*/, Convert.ToChar(201).ToString()/*FNC2*/, "97", "11110101000" });
            this.C128_Code.Rows.Add(new object[] { "98", "SHIFT", "SHIFT", "98", "11110100010" });
            this.C128_Code.Rows.Add(new object[] { "99", "CODE_C", "CODE_C", "99", "10111011110" });
            this.C128_Code.Rows.Add(new object[] { "100", "CODE_B", Convert.ToChar(203).ToString()/*FNC4*/, "CODE_B", "10111101110" });
            this.C128_Code.Rows.Add(new object[] { "101", Convert.ToChar(203).ToString()/*FNC4*/, "CODE_A", "CODE_A", "11101011110" });
            this.C128_Code.Rows.Add(new object[] { "102", Convert.ToChar(200).ToString()/*FNC1*/, Convert.ToChar(200).ToString()/*FNC1*/, Convert.ToChar(200).ToString()/*FNC1*/, "11110101110" });//411131
            this.C128_Code.Rows.Add(new object[] { "103", "START_A", "START_A", "START_A", "11010000100" });//211412
            this.C128_Code.Rows.Add(new object[] { "104", "START_B", "START_B", "START_B", "11010010000" });//211214
            this.C128_Code.Rows.Add(new object[] { "105", "START_C", "START_C", "START_C", "11010011100" });//211232
            this.C128_Code.Rows.Add(new object[] { "", "STOP", "STOP", "STOP", "1100011101011" });//2331112
        }
    }
}
