﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using System.Threading;

namespace XOscillo
{
    enum COMMANDS
    {
        IDLE = 0,
        RESET = 175,
        PING = 63,
        READ_ADC_TRACE = 170,
        READ_BIN_TRACE = 171
    }

    class SerialArduino : OscilloSerial
    {
        protected byte m_triggerValue = 127;
        int m_baudrate;


        public SerialArduino(int baudrate, int samplerate, int numChannels)
            : base(numChannels)
        {
            // Create a new SerialPort object with default settings.
            serialPort = new SerialPort();

            m_baudrate = baudrate;
            SetSampleRate(samplerate);
        }

        override public string GetName()
        {
            return "Arduino";
        }

        override public bool Open(string portName)
        {
            string os = Environment.OSVersion.Platform.ToString();

            try
            {
                serialPort = new SerialPort(portName, m_baudrate, Parity.None, 8, StopBits.One);
                serialPort.Handshake = Handshake.None;
                serialPort.ReadBufferSize = 1024 * 10;

                DebugConsole.Instance.Add(portName + ", rts:" + serialPort.RtsEnable.ToString() + ", dtr:" + serialPort.DtrEnable.ToString() + "   trying...");
                serialPort.Open();
                //DebugConsole.Instance.Add(" rts:" + serialPort.RtsEnable.ToString() + ", dtr:" + serialPort.DtrEnable.ToString());

                if (os == "Unix")
                {
                    DebugConsole.Instance.Add("lowering RTS");
                    serialPort.RtsEnable = false;
                    for (int i = 0; i < 8; i++)
                    {
                        Thread.Sleep(250);
                        DebugConsole.Instance.Add(".");
                    }
                }
            }
            catch
            {
                DebugConsole.Instance.AddLn("Can't open!");
                return false;
            }

            try
            {
                serialPort.WriteTimeout = 1000;
                serialPort.ReadTimeout = 1000;

                DebugConsole.Instance.Add("pinging....");
                if (Ping() == true)
                {
                    DebugConsole.Instance.AddLn("Found!");
                    return true;
                }
                else
                {
                    DebugConsole.Instance.AddLn("Bad reply");
                }
            }
            catch
            {
                DebugConsole.Instance.AddLn("Timeout");
            }

            serialPort.Close();

            return false;
        }

        override public bool Reset()
        {
            if (IsOpened() == false)
            {
                return false;
            }

            try
            {
                Thread.Sleep(100);
                byte[] data = { (byte)COMMANDS.RESET };
                serialPort.Write(data, 0, 1);
                serialPort.DiscardInBuffer();

                byte[] readBuffer = new byte[2];
                Read(readBuffer, readBuffer.Length);


                return readBuffer.ToString() == "OK";
            }
            catch
            {
                return false;
            }
        }

        override public bool Ping()
        {
            if (IsOpened() == false)
            {
                return false;
            }

            Reset();

            byte[] cmd = { (byte)COMMANDS.PING };
            serialPort.Write(cmd, 0, 1);

            byte[] readBuffer = new byte[7];
            Read(readBuffer, readBuffer.Length);

            return (readBuffer[0] == 79) && (readBuffer[1] == 67);
        }
    }
}
