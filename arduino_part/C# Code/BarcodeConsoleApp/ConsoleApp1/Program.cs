using System;
using System.IO.Ports;
using System.Threading;
namespace ConsoleApp1
{
    public class Program
    {
        static SerialPort _serialPort = new SerialPort();
        public static void Main()
        {
            
            _serialPort.PortName = "COM3";//Set your board COM
            _serialPort.BaudRate = 9600;
            _serialPort.Open();
            while (true)
            {
                string a = _serialPort.ReadExisting();
                //Console.WriteLine(1);
                string s = Console.ReadLine();
                _serialPort.WriteLine(s);
                Thread.Sleep(200);
            }
        }
    }
}