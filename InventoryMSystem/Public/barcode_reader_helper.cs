using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using System.Timers;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace barcode_helper
{
    public interface Ibarcode_reader_listener
    {
        void new_message(string barcode);
    }
    public class barcode_reader_helper
    {
         static Ibarcode_reader_listener _listener = null;
        static Timer _timer = new Timer();
        static SerialPort _serial_port = null;
        static string barcodeCommand = "ff5555af1111111111";
        static string buffer = string.Empty;
        static byte[] bytesCommandToWrite;
        public static void start(SerialPort serial_port, Ibarcode_reader_listener listener)
        {
            _serial_port = serial_port;
            _listener = listener;
            _serial_port.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(comport_DataReceived);
            _timer.Interval = 500;
            _timer.Elapsed += new ElapsedEventHandler(_timer_Elapsed);

            MatchCollection mc = Regex.Matches(barcodeCommand, @"(?i)[\da-f]{2}");
            //MatchCollection mc = Regex.Matches(txt_Send.Text, @"(?i)[\da-f]{2}");
            List<byte> buf = new List<byte>();//填充到这个临时列表中
            //依次添加到列表中
            foreach (Match m in mc)
            {
                buf.Add(Byte.Parse(m.ToString(), System.Globalization.NumberStyles.HexNumber));
            }
            bytesCommandToWrite = buf.ToArray();


            _timer.Start();
        }
        public static void stop()
        {
            _timer.Stop();
        }
        static void comport_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                string temp = _serial_port.ReadExisting();
                buffer += temp;
                Debug.WriteLine(
                    string.Format("frmReadBar.comport_DataReceived  ->  = {0}"
                    , buffer));
                if (buffer.IndexOf("\r\n") != -1)
                {
                    if (_listener != null)
                    {
                        _listener.new_message(buffer);
                    }
                    buffer = string.Empty;
                }

            }
            catch (System.Exception ex)
            {
                Debug.WriteLine("frmReadBar -> comport_DataReceived  " + ex.Message);
            }
        }
        static void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                //转换列表为数组后发送
                _serial_port.Write(bytesCommandToWrite, 0, bytesCommandToWrite.Length);
                //this.comport.Write(barcodeCommand);
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(
                    string.Format("frmReadBar._timer_Tick  ->  = {0}"
                    , ex.Message));
            }
        }
    }
}
