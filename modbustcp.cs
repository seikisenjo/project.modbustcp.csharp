using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Runtime.InteropServices;
// dll file for modbus
using EasyModbus;
using System.Net.Sockets;
using System.Net;
using System.Net.NetworkInformation;
using System.IO;
using System.IO.Ports;
using ModbusLib;
using ModbusLib.Protocols;
using Modbus.Common;
using ModbusClient = ModbusLib.Protocols.ModbusClient;

namespace HCR_MODBUS_example
{
    // main body
    public partial class Form : System.Windows.Forms.Form
    {
        public static string ipaddress = "";
        public static int portnum = 502;
        //ModbusProtocol receiveData;
        ModbusProtocol sendData = new ModbusProtocol();
        Byte[] bytes = new Byte[2100];
        //private int numberOfConnections = 0;
        //private byte unitIdentifier = 1;
        private int portIn;
        public InputRegisters inputRegisters;
        private IPAddress ipAddressIn;
        //private static UDPBroadcaster broadcaster;
        public EasyModbus.ModbusClient modbusClient = new EasyModbus.ModbusClient(ipaddress, portnum);
        public EasyModbus.ModbusServer modbusServer = new EasyModbus.ModbusServer();
        //public ModbusServer.server = new ModbusLib.Protocols.ModbusServer(ModbusTcpCodec());
        public DisplayFormat _displayFormat = DisplayFormat.Integer;
        public Socket _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //public bool ShowDataLength { get; set; }
        public Function _function = Function.InputRegister;
        public byte FunctionCode = ModbusCommand.FuncReadInputRegisters;
        public ICommServer _listener;
        public UInt16[] _registerData = new UInt16[65535];
        private int _transactionId;
        int txtSize = 64;
        private ModbusLib.Protocols.ModbusClient _driver;
        private ICommClient _portClient;
        //TcpListener server = null;
        IPAddress localAddr = IPAddress.Any;
        //private TCPHandler tcpHandler;
        //private byte unitIdentifier = 1;
        //private bool showProtocolInformations = true;
        //private bool preventInvokeHoldingRegisters = false;
        //public UInt16[] _registerWrite = new UInt16[65535];
        //public int[] _registerData;
        public int _displayCtrlCount;
        public int TCPPort = 502;
        public byte SlaveId = 255;
        public int SlaveDelay = 0;
        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        //public IPAddress IPAddress;

        //public int[] testjerry = new int [100];

        // instance creation initialization component
        public Form()
        {
            InitializeComponent();
            ipAddTextBox.Text = "127.0.0.1";
            ipaddress = ipAddTextBox.Text;
            txtStartAdress.Text = "100";
            //StartAddress = Convert.ToUInt16(txtStartAdress.Text, 32);
            //txtSize.Text = "64";
            portIn = portnum;
            ipAddressIn = (System.Net.IPAddress.Parse(ipaddress));
            //DataLength = Convert.ToUInt16(txtSize.Text, 32);
            _RefreshData();
            _RefreshWrite();
            //_RefreshWrite();
            //_registerData = new UInt16[65530];
            /*
            if (_registerData == null)
            {
                throw new ApplicationException("Failed to allocate 128k block");
            }*/
        }

        // execute once form is loaded
        private void Form1_Load(object sender, EventArgs e)
        {
            // create parallel thread to monitor modbus
            modbusThread = new Thread(new ThreadStart(HCRMB));
            modbusThread.IsBackground = true;
            modbusListen = new Thread(new ThreadStart(HCRSM));
            modbusListen.IsBackground = true;
            modbusWrite = new Thread(new ThreadStart(HCRSW));
            modbusWrite.IsBackground = true;

        }

        // modbus thread declaration
        Thread modbusThread;
        Thread modbusListen;
        Thread modbusWrite;

        // zhong jian ren
        delegate void hcrMBStatus(string status);

        delegate void hcrMBdo(string val);
        delegate void hcrMBdos(string val);

        delegate void hcrMBto(string val);
        delegate void hcrMBtos(string val);

        delegate void hcrMBro(string val);
        delegate void hcrMBros(string val);

        delegate void hcrMBai(string val);
        delegate void hcrMBais(string val);
        delegate void hcrMBao(string val);
        delegate void hcrMBaos(string val);

        delegate void hcrMBdi(string val);
        delegate void hcrMBdis(string val);

        delegate void hcrMBti(string val);
        delegate void hcrMBtis(string val);

        delegate void hcrMBri(string val);
        delegate void hcrMBris(string val);

        delegate void hcrMBps(string val);

        delegate void hcrMBj1c(string val);
        delegate void hcrMBj2c(string val);
        delegate void hcrMBj3c(string val);
        delegate void hcrMBj4c(string val);
        delegate void hcrMBj5c(string val);
        delegate void hcrMBj6c(string val);

        delegate void hcrMBj1t(string val);
        delegate void hcrMBj2t(string val);
        delegate void hcrMBj3t(string val);
        delegate void hcrMBj4t(string val);
        delegate void hcrMBj5t(string val);
        delegate void hcrMBj6t(string val);

        delegate void hcrMBj1bc(string val);
        delegate void hcrMBj2bc(string val);
        delegate void hcrMBj3bc(string val);
        delegate void hcrMBj4bc(string val);
        delegate void hcrMBj5bc(string val);
        delegate void hcrMBj6bc(string val);

        delegate void hcrMBpstart(string val);
        delegate void hcrMBpp(string val);
        delegate void hcrMBpstop(string val);

        //public delegate void NumberOfClientsChanged();

        //public event NumberOfClientsChanged numberOfClientsChanged;

        internal class TCPHandler
        {
            public delegate void DataChanged(object networkConnectionParameter);
            //public event DataChanged dataChanged;

            public delegate void NumberOfClientsChanged();
            //public event NumberOfClientsChanged numberOfClientsChanged;

            TcpListener server = null;


            private List<Client> tcpClientLastRequestList = new List<Client>();

            public int NumberOfConnectedClients { get; set; }

            public string ipAddress = null;

            public TCPHandler(int port)
            {
                IPAddress localAddr = IPAddress.Any;
                server = new TcpListener(localAddr, port);
                server.Start();
                server.AcceptTcpClientAsync().Start();
            }
            
            public TCPHandler(string ipAddress, int port)
            {
                this.ipAddress = ipAddress;
                IPAddress localAddr = IPAddress.Any;
                server = new TcpListener(localAddr, port);
                server.Start();
                server.AcceptTcpClientAsync().Start();
            }
            /*
            private void ReadCallback(byte[] result)
            {
                NetworkConnectionParameter networkConnectionParameter = new NetworkConnectionParameter();
                //NumberOfConnectedClients = GetAndCleanNumberOfConnectedClients(client);
                if (numberOfClientsChanged != null)
                    numberOfClientsChanged();

                //networkConnectionParameter.bytes = data;
                //networkConnectionParameter.stream = networkStream;
                if (dataChanged != null)
                    dataChanged(networkConnectionParameter);
            }
            */
            public void Disconnect()
            {
                try
                {
                    foreach (Client clientLoop in tcpClientLastRequestList)
                    {
                        clientLoop.NetworkStream.Dispose();
                    }
                }
                catch (Exception) { }
                server.Stop();

            }


            internal class Client
            {
                private readonly TcpClient tcpClient;
                private readonly byte[] buffer;
                public long Ticks { get; set; }

                public Client(TcpClient tcpClient)
                {
                    this.tcpClient = tcpClient;
                    int bufferSize = tcpClient.ReceiveBufferSize;
                    buffer = new byte[bufferSize];
                }

                public TcpClient TcpClient
                {
                    get { return tcpClient; }
                }

                public byte[] Buffer
                {
                    get { return buffer; }
                }

                public NetworkStream NetworkStream
                {
                    get
                    {

                        return tcpClient.GetStream();

                    }
                }
            }
        }

        private void setStatusLabel(string status)
        {
            if (statusLabel.InvokeRequired)
            {
                statusLabel.Invoke(new hcrMBStatus(setStatusLabel), status);
            }
            else
            {
                statusLabel.Text = status;
            }
        }

        private void setValdo(string val)
        {
            if (DO1Label.InvokeRequired)
            {
                DO1Label.Invoke(new hcrMBdo(setValdo), val);

            }
            else
            {
                DO1Label.Text = val;
                //byte[] sdi = Encoding.ASCII.GetBytes(val);
                //string value = Convert.ToString(sdi[0],2);
                //ssdi.Text = value;
                //DO1Label.Text = val;

            }

        }

        private void setValto(string val)
        {
            if (TOLabel.InvokeRequired)
            {
                TOLabel.Invoke(new hcrMBto(setValto), val);

            }
            else
            {
                TOLabel.Text = val;
                //byte[] sdi = Encoding.ASCII.GetBytes(val);
                //string value = Convert.ToString(sdi[0],2);
                //ssdi.Text = value;
                //DO1Label.Text = val;

            }

        }

        private void setValao(string val)
        {
            if (AOutput.InvokeRequired)
            {
                AOutput.Invoke(new hcrMBto(setValao), val);

            }
            else
            {
                //byte[] sdi = Encoding.ASCII.GetBytes(val);
                if (val.Length == 4)
                {
                    AOutput.Text = val.Substring(0, 1) + "." + val.Substring(1, 3);
                }
                else if (val.Length == 5)
                {
                    AOutput.Text = val.Substring(0, 2) + "." + val.Substring(2, 3);
                }
                else if (val.Length <= 3)
                {
                    AOutput.Text = "0.000";
                }
                //string value = Convert.ToString(sdi[0]);
                //ssdi.Text = value;
                //byte[] sdi = Encoding.ASCII.GetBytes(val);
                //string value = Convert.ToString(sdi[0],2);
                //ssdi.Text = value;
                //DO1Label.Text = val;

            }

        }

        private void setValdos(string val)
        {
            if (DO1Label.InvokeRequired)
            {
                DO1Label.Invoke(new hcrMBdos(setValdos), val);

            }
            else
            {
                //ssdo.Text = val;
                //val =1,10,11,100,1000 ----- convert to 0001,0010 etc.
                while (val.Length < 8)
                {
                    val = "0" + val;
                }
                while (val.Length > 8)
                {
                    val = val.Remove(0, 1);
                }

                if (val.Substring(7, 1) == "1")
                {
                    DO0.BackColor = Color.LimeGreen;
                }
                else
                {
                    DO0.BackColor = Color.Transparent;
                }

                if (val.Substring(6, 1) == "1")
                {
                    DO1.BackColor = Color.LimeGreen;
                }
                else
                {
                    DO1.BackColor = Color.Transparent;
                }

                if (val.Substring(5, 1) == "1")
                {
                    DO2.BackColor = Color.LimeGreen;
                }
                else
                {
                    DO2.BackColor = Color.Transparent;
                }

                if (val.Substring(4, 1) == "1")
                {
                    DO3.BackColor = Color.LimeGreen;
                }
                else
                {
                    DO3.BackColor = Color.Transparent;
                }

                if (val.Substring(3, 1) == "1")
                {
                    DO4.BackColor = Color.LimeGreen;
                }
                else
                {
                    DO4.BackColor = Color.Transparent;
                }

                if (val.Substring(2, 1) == "1")
                {
                    DO5.BackColor = Color.LimeGreen;
                }
                else
                {
                    DO5.BackColor = Color.Transparent;
                }

                if (val.Substring(1, 1) == "1")
                {
                    DO6.BackColor = Color.LimeGreen;
                }
                else
                {
                    DO6.BackColor = Color.Transparent;
                }

                if (val.Substring(0, 1) == "1")
                {
                    DO7.BackColor = Color.LimeGreen;
                }
                else
                {
                    DO7.BackColor = Color.Transparent;
                }

            }

        }

        // create another function to convert val to binary. for design LED
        private void setValtos(string val)
        {
            if (TOLabel.InvokeRequired)
            {
                TOLabel.Invoke(new hcrMBtos(setValtos), val);

            }
            else
            {
                //ssdo.Text = val;
                //val =1,10,11,100,1000 ----- convert to 0001,0010 etc.
                while (val.Length < 4)
                {
                    val = "0" + val;
                }

                if (val.Substring(3, 1) == "1")
                {
                    TO0.BackColor = Color.LimeGreen;
                }
                else
                {
                    TO0.BackColor = Color.Transparent;
                }

                if (val.Substring(2, 1) == "1")
                {
                    TO1.BackColor = Color.LimeGreen;
                }
                else
                {
                    TO1.BackColor = Color.Transparent;
                }

                if (val.Substring(1, 1) == "1")
                {
                    TO2.BackColor = Color.LimeGreen;
                }
                else
                {
                    TO2.BackColor = Color.Transparent;
                }

                if (val.Substring(0, 1) == "1")
                {
                    TO3.BackColor = Color.LimeGreen;
                }
                else
                {
                    TO3.BackColor = Color.Transparent;
                }

            }

        }

        private void setValro(string val)
        {
            if (RO1Label.InvokeRequired)
            {
                RO1Label.Invoke(new hcrMBro(setValro), val);

            }
            else
            {
                RO1Label.Text = val;

            }

        }
        private void setValros(string val)
        {
            if (RO1Label.InvokeRequired)
            {
                RO1Label.Invoke(new hcrMBros(setValros), val);

            }
            else
            {
                while (val.Length < 8)
                {
                    val = "0" + val;
                }
                //LRO.Text = val;
                if (val.Substring(7, 1) == "1")
                {
                    RO0.BackColor = Color.LimeGreen;
                }
                else
                {
                    RO0.BackColor = Color.Transparent;
                }

                if (val.Substring(6, 1) == "1")
                {
                    RO1.BackColor = Color.LimeGreen;
                }
                else
                {
                    RO1.BackColor = Color.Transparent;
                }

                if (val.Substring(5, 1) == "1")
                {
                    RO2.BackColor = Color.LimeGreen;
                }
                else
                {
                    RO2.BackColor = Color.Transparent;
                }

                if (val.Substring(4, 1) == "1")
                {
                    RO3.BackColor = Color.LimeGreen;
                }
                else
                {
                    RO3.BackColor = Color.Transparent;
                }

                if (val.Substring(3, 1) == "1")
                {
                    RO4.BackColor = Color.LimeGreen;
                }
                else
                {
                    RO4.BackColor = Color.Transparent;
                }

                if (val.Substring(2, 1) == "1")
                {
                    RO5.BackColor = Color.LimeGreen;
                }
                else
                {
                    RO5.BackColor = Color.Transparent;
                }

                if (val.Substring(1, 1) == "1")
                {
                    RO6.BackColor = Color.LimeGreen;
                }
                else
                {
                    RO6.BackColor = Color.Transparent;
                }

                if (val.Substring(0, 1) == "1")
                {
                    RO7.BackColor = Color.LimeGreen;
                }
                else
                {
                    RO7.BackColor = Color.Transparent;
                }
            }
        }

        private void setValdi(string val)
        {
            if (DI1Label.InvokeRequired)
            {
                DI1Label.Invoke(new hcrMBdi(setValdi), val);

            }
            else
            {
                //byte[] sdi = Encoding.ASCII.GetBytes(val);
                DI1Label.Text = val;
                //string value = Convert.ToString(sdi[0]);
                //ssdi.Text = value;
            }

        }

        private void setValti(string val)
        {
            if (TILabel.InvokeRequired)
            {
                TILabel.Invoke(new hcrMBdi(setValti), val);

            }
            else
            {
                //byte[] sdi = Encoding.ASCII.GetBytes(val);
                TILabel.Text = val;
                //string value = Convert.ToString(sdi[0]);
                //ssdi.Text = value;
            }

        }

        private void setValai(string val)
        {
            if (AInput.InvokeRequired)
            {
                AInput.Invoke(new hcrMBai(setValai), val);

            }
            else
            {
                //byte[] sdi = Encoding.ASCII.GetBytes(val);
                if (val.Length == 4)
                {
                    AInput.Text = val.Substring(0, 1) + "." + val.Substring(1, 3);
                }
                else if (val.Length == 5)
                {
                    AInput.Text = val.Substring(0, 2) + "." + val.Substring(2, 3);
                }
                else if (val.Length <= 3)
                {
                    AInput.Text = "0.000";
                }
                //string value = Convert.ToString(sdi[0]);
                //ssdi.Text = value;

            }

        }

        private void setValaisource(string val)
        {
            if (AISource.InvokeRequired)
            {
                AISource.Invoke(new hcrMBais(setValaisource), val);

            }
            else
            {
                AISource.Text = val;
                int AISourceInt = Int32.Parse(AISource.Text);
                //byte[] sdi = Encoding.ASCII.GetBytes(val);
                if (AISourceInt != 0)
                {
                    AIV.Visible = true;
                    AIA.Visible = false;
                }
                else
                {
                    AIV.Visible = false;
                    AIA.Visible = true;
                }

            }

        }

        private void setValaosource(string val)
        {
            if (AOSource.InvokeRequired)
            {
                AOSource.Invoke(new hcrMBaos(setValaosource), val);

            }
            else
            {
                AOSource.Text = val;
                int AOSourceInt = Int32.Parse(AOSource.Text);
                //byte[] sdi = Encoding.ASCII.GetBytes(val);
                if (AOSourceInt != 0)
                {
                    AOV.Visible = true;
                    AOA.Visible = false;
                }
                else
                {
                    AOV.Visible = false;
                    AOA.Visible = true;
                }

            }

        }

        private void setValdis(string val)
        {
            if (DI1Label.InvokeRequired)
            {
                DI1Label.Invoke(new hcrMBdis(setValdis), val);

            }
            else
            {
                while (val.Length < 8)
                {
                    val = "0" + val;
                }
                while (val.Length > 8)
                {
                    val = val.Remove(0, 1);
                }
                //LDI.Text = val;
                if (val.Substring(7, 1) == "1")
                {
                    DI0.BackColor = Color.LimeGreen;
                }
                else
                {
                    DI0.BackColor = Color.Transparent;
                }

                if (val.Substring(6, 1) == "1")
                {
                    DI1.BackColor = Color.LimeGreen;
                }
                else
                {
                    DI1.BackColor = Color.Transparent;
                }

                if (val.Substring(5, 1) == "1")
                {
                    DI2.BackColor = Color.LimeGreen;
                }
                else
                {
                    DI2.BackColor = Color.Transparent;
                }

                if (val.Substring(4, 1) == "1")
                {
                    DI3.BackColor = Color.LimeGreen;
                }
                else
                {
                    DI3.BackColor = Color.Transparent;
                }

                if (val.Substring(3, 1) == "1")
                {
                    DI4.BackColor = Color.LimeGreen;
                }
                else
                {
                    DI4.BackColor = Color.Transparent;
                }

                if (val.Substring(2, 1) == "1")
                {
                    DI5.BackColor = Color.LimeGreen;
                }
                else
                {
                    DI5.BackColor = Color.Transparent;
                }

                if (val.Substring(1, 1) == "1")
                {
                    DI6.BackColor = Color.LimeGreen;
                }
                else
                {
                    DI6.BackColor = Color.Transparent;
                }

                if (val.Substring(0, 1) == "1")
                {
                    DI7.BackColor = Color.LimeGreen;
                }
                else
                {
                    DI7.BackColor = Color.Transparent;
                }

            }

        }

        private void setValtis(string val)
        {
            if (TILabel.InvokeRequired)
            {
                TILabel.Invoke(new hcrMBtis(setValtis), val);

            }
            else
            {
                while (val.Length < 4)
                {
                    val = "0" + val;
                }
                //LDI.Text = val;
                if (val.Substring(3, 1) == "1")
                {
                    TI0.BackColor = Color.LimeGreen;
                }
                else
                {
                    TI0.BackColor = Color.Transparent;
                }

                if (val.Substring(2, 1) == "1")
                {
                    TI1.BackColor = Color.LimeGreen;
                }
                else
                {
                    TI1.BackColor = Color.Transparent;
                }

                if (val.Substring(1, 1) == "1")
                {
                    TI2.BackColor = Color.LimeGreen;
                }
                else
                {
                    TI2.BackColor = Color.Transparent;
                }

                if (val.Substring(0, 1) == "1")
                {
                    TI3.BackColor = Color.LimeGreen;
                }
                else
                {
                    TI3.BackColor = Color.Transparent;
                }

            }

        }

        private void setValri(string val)
        {
            if (RI1Label.InvokeRequired)
            {
                RI1Label.Invoke(new hcrMBri(setValri), val);

            }
            else
            {
                RI1Label.Text = val;

            }

        }
        private void setValris(string val)
        {
            if (RI1Label.InvokeRequired)
            {
                RI1Label.Invoke(new hcrMBris(setValris), val);

            }
            else
            {
                while (val.Length < 8)
                {
                    val = "0" + val;
                }
                //LRI.Text = val;
                if (val.Substring(7, 1) == "1")
                {
                    RI0.BackColor = Color.LimeGreen;
                }
                else
                {
                    RI0.BackColor = Color.Transparent;
                }

                if (val.Substring(6, 1) == "1")
                {
                    RI1.BackColor = Color.LimeGreen;
                }
                else
                {
                    RI1.BackColor = Color.Transparent;
                }

                if (val.Substring(5, 1) == "1")
                {
                    RI2.BackColor = Color.LimeGreen;
                }
                else
                {
                    RI2.BackColor = Color.Transparent;
                }

                if (val.Substring(4, 1) == "1")
                {
                    RI3.BackColor = Color.LimeGreen;
                }
                else
                {
                    RI3.BackColor = Color.Transparent;
                }

                if (val.Substring(3, 1) == "1")
                {
                    RI4.BackColor = Color.LimeGreen;
                }
                else
                {
                    RI4.BackColor = Color.Transparent;
                }

                if (val.Substring(2, 1) == "1")
                {
                    RI5.BackColor = Color.LimeGreen;
                }
                else
                {
                    RI5.BackColor = Color.Transparent;
                }

                if (val.Substring(1, 1) == "1")
                {
                    RI6.BackColor = Color.LimeGreen;
                }
                else
                {
                    RI6.BackColor = Color.Transparent;
                }

                if (val.Substring(0, 1) == "1")
                {
                    RI7.BackColor = Color.LimeGreen;
                }
                else
                {
                    RI7.BackColor = Color.Transparent;
                }

            }

        }

        private void setValps(string val)
        {
            if (stps.InvokeRequired)
            {
                stps.Invoke(new hcrMBps(setValps), val);
            }
            else
            {

                stps.Text = val;
                if (val == "0")
                {
                    prgState.Text = "UNDEFINED";

                }

                else if (val == "1")
                {
                    prgState.Text = "INITIALIZED";
                }

                else if (val == "2")
                {
                    prgState.Text = "RUNNING";
                }

                else if (val == "3")
                {
                    prgState.Text = "PAUSING";
                }

                else if (val == "4")
                {
                    prgState.Text = "PAUSED";
                }

                else if (val == "5")
                {
                    prgState.Text = "STOPPING";
                }

                else if (val == "6")
                {
                    prgState.Text = "STOPPED";
                }

            }

        }

        private void setValj1c(string val)
        {
            if (j1c.InvokeRequired)
            {
                j1c.Invoke(new hcrMBj1c(setValj1c), val);
            }
            else
            {
                double ssj1c = ((Convert.ToDouble(val)) / 1000);
                j1c.Text = Convert.ToString(ssj1c);
                //string sj1c = j1c.Text;
                //sssj1c.Text = Convert.ToString(ssj1c);
            }


        }
        private void setValj2c(string val)
        {
            if (j2c.InvokeRequired)
            {
                j2c.Invoke(new hcrMBj2c(setValj2c), val);
            }
            else
            {
                double ssj2c = ((Convert.ToDouble(val)) / 1000);
                j2c.Text = Convert.ToString(ssj2c);
            }

        }
        private void setValj3c(string val)
        {
            if (j3c.InvokeRequired)
            {

                j3c.Invoke(new hcrMBj3c(setValj3c), val);
            }
            else
            {
                double ssj3c = ((Convert.ToDouble(val)) / 1000);
                j3c.Text = Convert.ToString(ssj3c);
            }

        }
        private void setValj4c(string val)
        {
            if (j4c.InvokeRequired)
            {
                j4c.Invoke(new hcrMBj4c(setValj4c), val);
            }
            else
            {
                double ssj4c = ((Convert.ToDouble(val)) / 1000);
                //j3c.Text = Convert.ToString(ssj3c);
                j4c.Text = Convert.ToString(ssj4c);
            }

        }
        private void setValj5c(string val)
        {
            if (j5c.InvokeRequired)
            {
                j5c.Invoke(new hcrMBj5c(setValj5c), val);
            }
            else
            {
                double ssj5c = ((Convert.ToDouble(val)) / 1000);
                //j3c.Text = Convert.ToString(ssj3c);
                j5c.Text = Convert.ToString(ssj5c);
            }

        }
        private void setValj6c(string val)
        {
            if (j6c.InvokeRequired)
            {
                j6c.Invoke(new hcrMBj6c(setValj6c), val);
            }
            else
            {
                double ssj6c = ((Convert.ToDouble(val)) / 1000);
                //j5c.Text = Convert.ToString(ssj5c);
                j6c.Text = Convert.ToString(ssj6c);
            }

        }

        private void setValj1t(string val)
        {
            if (j1t.InvokeRequired)
            {
                j1t.Invoke(new hcrMBj1t(setValj1t), val);
            }
            else
            {
                j1t.Text = val;
            }

        }
        private void setValj2t(string val)
        {
            if (j2t.InvokeRequired)
            {
                j2t.Invoke(new hcrMBj2t(setValj2t), val);
            }
            else
            {
                j2t.Text = val;
            }

        }
        private void setValj3t(string val)
        {
            if (j3t.InvokeRequired)
            {
                j3t.Invoke(new hcrMBj3t(setValj3t), val);
            }
            else
            {
                j3t.Text = val;
            }

        }
        private void setValj4t(string val)
        {
            if (j4t.InvokeRequired)
            {
                j4t.Invoke(new hcrMBj4t(setValj4t), val);
            }
            else
            {
                j4t.Text = val;
            }

        }
        private void setValj5t(string val)
        {
            if (j5t.InvokeRequired)
            {
                j5t.Invoke(new hcrMBj5t(setValj5t), val);
            }
            else
            {
                j5t.Text = val;
            }

        }
        private void setValj6t(string val)
        {
            if (j6t.InvokeRequired)
            {
                j6t.Invoke(new hcrMBj6t(setValj6t), val);
            }
            else
            {
                j6t.Text = val;
            }

        }

        private void setValj1bc(string val)
        {
            if (j1bc.InvokeRequired)
            {
                j1bc.Invoke(new hcrMBj1bc(setValj1bc), val);
            }
            else
            {
                if (val.Substring(0, 1) == "-")
                {
                    if (val.Length == 5)
                    {
                        j1bc.Text = val.Substring(0, 4) + "." + val.Substring(4, 1);
                    }
                    else if (val.Length == 4)
                    {
                        j1bc.Text = val.Substring(0, 3) + "." + val.Substring(3, 1);
                    }
                    else if (val.Length == 3)
                    {
                        j1bc.Text = val.Substring(0, 2) + "." + val.Substring(2, 1);
                    }

                }
                else
                {
                    if (val.Length == 4)
                    {
                        j1bc.Text = val.Substring(0, 3) + "." + val.Substring(3, 1);
                    }
                    else if (val.Length == 3)
                    {
                        j1bc.Text = val.Substring(0, 2) + "." + val.Substring(2, 1);
                    }
                    else if (val.Length == 2)
                    {
                        j1bc.Text = val.Substring(0, 1) + "." + val.Substring(1, 1);
                    }
                    else if (val.Length == 1)
                    {
                        j1bc.Text = val.Substring(0, 1) + "." + val.Substring(0, 1);
                    }
                }

            }

        }
        private void setValj2bc(string val)
        {
            if (j2bc.InvokeRequired)
            {
                j2bc.Invoke(new hcrMBj2bc(setValj2bc), val);
            }
            else
            {
                if (val.Substring(0, 1) == "-")
                {
                    if (val.Length == 5)
                    {
                        j2bc.Text = val.Substring(0, 4) + "." + val.Substring(4, 1);
                    }
                    else if (val.Length == 4)
                    {
                        j2bc.Text = val.Substring(0, 3) + "." + val.Substring(3, 1);
                    }
                    else if (val.Length == 3)
                    {
                        j2bc.Text = val.Substring(0, 2) + "." + val.Substring(2, 1);
                    }

                }
                else
                {
                    if (val.Length == 4)
                    {
                        j2bc.Text = val.Substring(0, 3) + "." + val.Substring(3, 1);
                    }
                    else if (val.Length == 3)
                    {
                        j2bc.Text = val.Substring(0, 2) + "." + val.Substring(2, 1);
                    }
                    else if (val.Length == 2)
                    {
                        j2bc.Text = val.Substring(0, 1) + "." + val.Substring(1, 1);
                    }
                    else if (val.Length == 1)
                    {
                        j2bc.Text = val.Substring(0, 1) + "." + val.Substring(0, 1);
                    }
                }
            }

        }
        private void setValj3bc(string val)
        {
            if (j3bc.InvokeRequired)
            {
                j3bc.Invoke(new hcrMBj3bc(setValj3bc), val);
            }
            else
            {
                if (val.Substring(0, 1) == "-")
                {
                    if (val.Length == 5)
                    {
                        j3bc.Text = val.Substring(0, 4) + "." + val.Substring(4, 1);
                    }
                    else if (val.Length == 4)
                    {
                        j3bc.Text = val.Substring(0, 3) + "." + val.Substring(3, 1);
                    }
                    else if (val.Length == 3)
                    {
                        j3bc.Text = val.Substring(0, 2) + "." + val.Substring(2, 1);
                    }

                }
                else
                {
                    if (val.Length == 4)
                    {
                        j3bc.Text = val.Substring(0, 3) + "." + val.Substring(3, 1);
                    }
                    else if (val.Length == 3)
                    {
                        j3bc.Text = val.Substring(0, 2) + "." + val.Substring(2, 1);
                    }
                    else if (val.Length == 2)
                    {
                        j3bc.Text = val.Substring(0, 1) + "." + val.Substring(1, 1);
                    }
                    else if (val.Length == 1)
                    {
                        j3bc.Text = val.Substring(0, 1) + "." + val.Substring(0, 1);
                    }
                }
            }

        }
        private void setValj4bc(string val)
        {
            if (j4bc.InvokeRequired)
            {
                j4bc.Invoke(new hcrMBj4bc(setValj4bc), val);
            }
            else
            {
                if (val.Substring(0, 1) == "-")
                {
                    if (val.Length == 5)
                    {
                        j4bc.Text = val.Substring(0, 4) + "." + val.Substring(4, 1);
                    }
                    else if (val.Length == 4)
                    {
                        j4bc.Text = val.Substring(0, 3) + "." + val.Substring(3, 1);
                    }
                    else if (val.Length == 3)
                    {
                        j4bc.Text = val.Substring(0, 2) + "." + val.Substring(2, 1);
                    }

                }
                else
                {
                    if (val.Length == 4)
                    {
                        j4bc.Text = val.Substring(0, 3) + "." + val.Substring(3, 1);
                    }
                    else if (val.Length == 3)
                    {
                        j4bc.Text = val.Substring(0, 2) + "." + val.Substring(2, 1);
                    }
                    else if (val.Length == 2)
                    {
                        j4bc.Text = val.Substring(0, 1) + "." + val.Substring(1, 1);
                    }
                    else if (val.Length == 1)
                    {
                        j4bc.Text = val.Substring(0, 1) + "." + val.Substring(0, 1);
                    }
                }
            }

        }
        private void setValj5bc(string val)
        {
            if (j5bc.InvokeRequired)
            {
                j5bc.Invoke(new hcrMBj5bc(setValj5bc), val);
            }
            else
            {
                if (val.Substring(0, 1) == "-")
                {
                    if (val.Length == 5)
                    {
                        j5bc.Text = val.Substring(0, 4) + "." + val.Substring(4, 1);
                    }
                    else if (val.Length == 4)
                    {
                        j5bc.Text = val.Substring(0, 3) + "." + val.Substring(3, 1);
                    }
                    else if (val.Length == 3)
                    {
                        j5bc.Text = val.Substring(0, 2) + "." + val.Substring(2, 1);
                    }

                }
                else
                {
                    if (val.Length == 4)
                    {
                        j5bc.Text = val.Substring(0, 3) + "." + val.Substring(3, 1);
                    }
                    else if (val.Length == 3)
                    {
                        j5bc.Text = val.Substring(0, 2) + "." + val.Substring(2, 1);
                    }
                    else if (val.Length == 2)
                    {
                        j5bc.Text = val.Substring(0, 1) + "." + val.Substring(1, 1);
                    }
                    else if (val.Length == 1)
                    {
                        j5bc.Text = val.Substring(0, 1) + "." + val.Substring(0, 1);
                    }
                }
            }

        }
        private void setValj6bc(string val)
        {
            if (j6bc.InvokeRequired)
            {
                j6bc.Invoke(new hcrMBj6bc(setValj6bc), val);
            }
            else
            {
                if (val.Substring(0, 1) == "-")
                {
                    if (val.Length == 5)
                    {
                        j6bc.Text = val.Substring(0, 4) + "." + val.Substring(4, 1);
                    }
                    else if (val.Length == 4)
                    {
                        j6bc.Text = val.Substring(0, 3) + "." + val.Substring(3, 1);
                    }
                    else if (val.Length == 3)
                    {
                        j6bc.Text = val.Substring(0, 2) + "." + val.Substring(2, 1);
                    }


                }
                else
                {
                    if (val.Length == 4)
                    {
                        j6bc.Text = val.Substring(0, 3) + "." + val.Substring(3, 1);
                    }
                    else if (val.Length == 3)
                    {
                        j6bc.Text = val.Substring(0, 2) + "." + val.Substring(2, 1);
                    }
                    else if (val.Length == 2)
                    {
                        j6bc.Text = val.Substring(0, 1) + "." + val.Substring(1, 1);
                    }
                    else if (val.Length == 1)
                    {
                        j6bc.Text = val.Substring(0, 1) + "." + val.Substring(0, 1);
                    }

                }
            }

        }

        private void CloseAction()
        {
            if (modbusThread.IsAlive)
            {
                modbusClient.Disconnect();
                Thread.Sleep(50);
                modbusThread.Abort();
                modbusThread.Join(50);
                setStatusLabel("Disconnected");
            }

            else
            {
                setStatusLabel("Disconnected");
            }
            if (modbusWrite.IsAlive)
            {
                modbusClient.Disconnect();
                Thread.Sleep(50);
                modbusWrite.Abort();
                modbusWrite.Join(50);
                setStatusLabel("Disconnected");
            }

            else
            {
                setStatusLabel("Disconnected");
            }
            if (modbusListen.IsAlive)
            {
                if (_listener != null)
                {
                    _listener.Abort();
                    _listener = null;
                }
                if (_socket != null)
                {
                    _socket.Dispose();
                    _socket = null;
                }
                modbusListen.Abort();
                modbusListen.Join(50);
                setStatusLabel("Disconnected");
            }

            //Thread.Sleep(5000);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!modbusThread.IsAlive)
            {
                modbusThread = new Thread(new ThreadStart(HCRMB));
                modbusThread.IsBackground = true;
                modbusThread.Start();
            }

        }

        private void Form1_Closing(object sender, FormClosingEventArgs e)
        {
            CloseAction();
        }

        private void HCRMB()
        {
            // creating an instance from Modbus client class
            //ModbusClient modbusClient = new ModbusClient(ipAddTextBox.Text, 502);    //Ip-Address and Port of Modbus-TCP-Server
            //modbusThread = new Thread(new ThreadStart(HCRMB));
            //modbusThread.IsBackground = true;
            try
            {

                /*if (!modbusClient.Connected)
                {
                    modbusClient.Connect();
                    setStatusLabel("Connecting...");
                    Thread.Sleep(2000);
                    if (!modbusClient.Connected)
                    {
                        setStatusLabel("Unavailable");
                        modbusThread.Abort();
                        modbusThread.Join(50);
                    }
                } */
                EasyModbus.ModbusClient modbusClient = new EasyModbus.ModbusClient(ipAddTextBox.Text, 502);
                modbusClient.Connect();

                //modbusClient.WriteSingleRegister(700, 1);

                while (modbusClient.Connected)
                {
                    int[] DO1 = modbusClient.ReadInputRegisters(2, 1);
                    int[] RO1 = modbusClient.ReadInputRegisters(22, 1);
                    int[] DI1 = modbusClient.ReadInputRegisters(1, 1);
                    int[] RI1 = modbusClient.ReadInputRegisters(21, 1);
                    int[] TI1 = modbusClient.ReadInputRegisters(19, 1);
                    int[] TO1 = modbusClient.ReadInputRegisters(20, 1);
                    int[] PS = modbusClient.ReadInputRegisters(600, 1);
                    int[] AI0 = modbusClient.ReadInputRegisters(5, 1);
                    int[] AO0 = modbusClient.ReadInputRegisters(13, 1);
                    int[] AISource = modbusClient.ReadInputRegisters(6, 1);
                    int[] AOSource = modbusClient.ReadInputRegisters(14, 1);

                    int[] j1c = modbusClient.ReadInputRegisters(320, 1);
                    int[] j2c = modbusClient.ReadInputRegisters(321, 1);
                    int[] j3c = modbusClient.ReadInputRegisters(322, 1);
                    int[] j4c = modbusClient.ReadInputRegisters(323, 1);
                    int[] j5c = modbusClient.ReadInputRegisters(324, 1);
                    int[] j6c = modbusClient.ReadInputRegisters(325, 1);

                    int[] j1t = modbusClient.ReadInputRegisters(330, 1);
                    int[] j2t = modbusClient.ReadInputRegisters(331, 1);
                    int[] j3t = modbusClient.ReadInputRegisters(332, 1);
                    int[] j4t = modbusClient.ReadInputRegisters(333, 1);
                    int[] j5t = modbusClient.ReadInputRegisters(334, 1);
                    int[] j6t = modbusClient.ReadInputRegisters(335, 1);

                    int[] j1bc = modbusClient.ReadInputRegisters(400, 1);
                    int[] j2bc = modbusClient.ReadInputRegisters(401, 1);
                    int[] j3bc = modbusClient.ReadInputRegisters(402, 1);
                    int[] j4bc = modbusClient.ReadInputRegisters(403, 1);
                    int[] j5bc = modbusClient.ReadInputRegisters(404, 1);
                    int[] j6bc = modbusClient.ReadInputRegisters(405, 1);

                    //modbusClient.WriteSingleRegister(700, 0);
                    //modbusClient.WriteSingleRegister(701, 0);
                    //modbusClient.WriteSingleRegister(702, 0);

                    //modbusClient.WriteSingleRegister(700, 1);

                    //int pstart = modbusClient.WriteSingleRegister(700, 1);
                    //int pp = modbusClient.WriteSingleRegister(701, 1);
                    //int pstop = modbusClient.WriteSingleRegister(702, 1);

                    setStatusLabel("Connected");

                    setValdo(Convert.ToString(DO1[0]));
                    setValdos(Convert.ToString(DO1[0], 2));

                    setValro(Convert.ToString(RO1[0]));
                    setValros(Convert.ToString(RO1[0], 2));

                    setValto(Convert.ToString(TO1[0]));
                    setValtos(Convert.ToString(TO1[0], 2));

                    setValdi(Convert.ToString(DI1[0]));
                    setValdis(Convert.ToString(DI1[0], 2));

                    setValri(Convert.ToString(RI1[0]));
                    setValris(Convert.ToString(RI1[0], 2));

                    setValti(Convert.ToString(TI1[0]));
                    setValtis(Convert.ToString(TI1[0], 2));

                    setValai(Convert.ToString(AI0[0]));
                    //setValais(Convert.ToString(AI0[0],2));
                    setValao(Convert.ToString(AO0[0]));
                    //setValaos(Convert.ToString(AO0[0],2));

                    setValaisource(Convert.ToString(AISource[0]));
                    setValaosource(Convert.ToString(AOSource[0]));

                    setValps(Convert.ToString(PS[0]));

                    setValj1c(Convert.ToString(j1c[0]));
                    setValj2c(Convert.ToString(j2c[0]));
                    setValj3c(Convert.ToString(j3c[0]));
                    setValj4c(Convert.ToString(j4c[0]));
                    setValj5c(Convert.ToString(j5c[0]));
                    setValj6c(Convert.ToString(j6c[0]));

                    setValj1t(Convert.ToString(j1t[0]));
                    setValj2t(Convert.ToString(j2t[0]));
                    setValj3t(Convert.ToString(j3t[0]));
                    setValj4t(Convert.ToString(j4t[0]));
                    setValj5t(Convert.ToString(j5t[0]));
                    setValj6t(Convert.ToString(j6t[0]));

                    setValj1bc(Convert.ToString(j1bc[0]));
                    setValj2bc(Convert.ToString(j2bc[0]));
                    setValj3bc(Convert.ToString(j3bc[0]));
                    setValj4bc(Convert.ToString(j4bc[0]));
                    setValj5bc(Convert.ToString(j5bc[0]));
                    setValj6bc(Convert.ToString(j6bc[0]));

                    Thread.Sleep(100);

                }

                if (!modbusClient.Connected)
                {
                    setStatusLabel("Disconnected");
                    Thread.Sleep(50);
                }
            }
            catch (Exception)
            {
                modbusThread.Abort();
                modbusThread.Join(50);
                setStatusLabel("Unreachable");
            }

        }
/// <summary>
/// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// </summary>
/// <param name="data"></param>
        protected void DriverIncommingData(byte[] data)
        {
            var hex = new StringBuilder(data.Length * 2);
            foreach (byte b in data)
                hex.AppendFormat("{0:x2} ", b);
        }

        protected void DriverOutgoingData(byte[] data)
        {
            var hex = new StringBuilder(data.Length * 2);
            foreach (byte b in data)
                hex.AppendFormat("{0:x2} ", b);
        }

        private void DoRead(ModbusCommand command)
        {
            for (int i = 0; i < command.Count; i++)
                command.Data[i] = Convert.ToUInt16(_registerData[command.Offset + i]);

        }

        private void DoWrite(ModbusCommand command)
        {
            var dataAddress = command.Offset;
            command.Data.CopyTo(_registerData, dataAddress);
            _UpdateDataTable();
        }
 
        private void IllegalFunction(ModbusCommand command)
        {
            command.ExceptionCode = ModbusCommand.ErrorIllegalFunction;
        }

        void listener_ServeCommand(object sender, ServeCommandEventArgs e)
        {
            var command = (ModbusCommand)e.Data.UserData;

            //Thread.Sleep(1);

            //take the proper function command handler

                    if (_function == Function.InputRegister)
                        DoRead(command);
                    //else
                        //IllegalFunction(command);
        }

        private void tabPage1_Selected(object sender, TabControlEventArgs e)
        {
            //CurrentTab.RegisterData = _registerData;   
            //CurrentTab.DisplayFormat = _displayFormat;
            var tab = tabControl1.SelectedTab;
            if (tab.Text.Equals("...") && tabControl1.TabPages.Count < 5)
            {
                DataTab Form = new DataTab();
                Form.DataLength = ((ushort)(256));
                Form.DisplayFormat = DisplayFormat.Integer;
                Form.Location = new Point(3, 3);
                Form.Name = "dataTab" + (tabControl1.TabPages.Count + 1);
                Form.RegisterData = _registerData;
                //Form.ShowDataLength = ShowDataLength;
                Form.Size = new Size(688, 538);
                Form.StartAddress = ((ushort)(0));
                Form.TabIndex = 0;
                Form.OnApply += dataTab_OnApply;
                TabPage tabPage = new TabPage();
                tabPage.Controls.Add(Form);
                tabPage.Location = new Point(4, 22);
                //tabPage.Name = "tabPage" + (tabControl1.TabPages.Count + 1);
                tabPage.Padding = new Padding(3);
                tabPage.Size = new Size(851, 411);
                tabPage.TabIndex = tabControl1.TabPages.Count;
                //tabPage.Text = "...";
                tabPage.UseVisualStyleBackColor = true;
                tabControl1.Controls.Add(tabPage);
            }
            var address = StartAddress;
            //tab.Text = address.ToString();
            _startAddress = address;
            _dataLength = DataLength;
        }

        private void tabPage2_Selected(object sender, TabControlEventArgs e)
        {
            //CurrentTab.RegisterData = _registerData;
            //CurrentTab.DisplayFormat = _displayFormat;
            var tab = tabControl1.SelectedTab;
            if (tab.Text.Equals("...") && tabControl1.TabPages.Count < 5)
            {
                DataTab Form = new DataTab();
                Form.DataLength = ((ushort)(256));
                Form.DisplayFormat = DisplayFormat.Integer;
                Form.Location = new Point(3, 3);
                Form.Name = "dataTab" + (tabControl1.TabPages.Count + 1);
                Form.RegisterData = _registerData;
                //Form.ShowDataLength = ShowDataLength;
                Form.Size = new Size(688, 538);
                Form.StartAddress = ((ushort)(0));
                Form.TabIndex = 0;
                Form.OnApply += writeTab_OnApply;
                TabPage tabPage = new TabPage();
                tabPage.Controls.Add(Form);
                tabPage.Location = new Point(4, 22);
                //tabPage.Name = "tabPage" + (tabControl1.TabPages.Count + 1);
                tabPage.Padding = new Padding(3);
                tabPage.Size = new Size(851, 411);
                tabPage.TabIndex = tabControl1.TabPages.Count;
                //tabPage.Text = "...";
                tabPage.UseVisualStyleBackColor = true;
                tabControl1.Controls.Add(tabPage);
            }
            var address = StartAddress;
            //tab.Text = address.ToString();
            _startAddress = address;
            _dataLength = DataLength;
        }

        void dataTab_OnApply(object sender, EventArgs e)
        {
            var tab = tabControl1.SelectedTab;
            var address = StartAddress;
            //tab.Text = address.ToString();
            _startAddress = address;
            _dataLength = DataLength;
            //groupBoxData.Controls.Clear();
            _RefreshData();
        }

        void writeTab_OnApply(object sender, EventArgs e)
        {
            var tab = tabControl1.SelectedTab;
            var address = StartAddress;
            //tab.Text = address.ToString();
            _startAddress = address;
            _dataLength = DataLength;
            //groupBoxData.Controls.Clear();
            _RefreshWrite();
        }

        private ushort _startAddress;
        private ushort _dataLength;

        public ushort StartAddress
        {
            get
            {
                ushort rVal = 0;
                try
                {
                    if (txtStartAdress.Text.IndexOf("0x", 0, txtStartAdress.Text.Length) == 0)
                    {
                        string str = txtStartAdress.Text.Replace("0x", "");
                        rVal = Convert.ToUInt16(str, 16);
                    }
                    rVal = Convert.ToUInt16(txtStartAdress.Text);
                }
                catch (Exception)
                {
                    txtStartAdress.Text = "0";
                }
                return rVal;
            }
            set
            {
                txtStartAdress.Text = Convert.ToString(value);
            }
        }

        public ushort DataLength
        {
            get
            {
                ushort rVal = 64;
                try
                {
                    if (txtSize ==0)
                    //if (txtSize.Text.IndexOf("0x", 0, txtSize.Text.Length) == 0)
                    {
                        //string str = txtSize.Text.Replace("0x", "");
                        //rVal = Convert.ToUInt16(str, 16);
                        rVal = Convert.ToUInt16(txtSize);
                    }
                    rVal = Convert.ToUInt16(txtSize);
                }
                catch (Exception)
                {
                    txtSize = 64;
                    //txtSize.Text = "64";
                }
                return rVal;
            }
            set
            {
                txtSize = value;
                //txtSize.Text = Convert.ToString(value);
            }
        }

        /// <summary>
        /// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// 

        public event EventHandler OnApply;

        //public UInt16[] RegisterData { get; set; }
        //public DisplayFormat DisplayFormat { get; set; }
        
        #region Data Table
        
        public void _RefreshData()
        {
            // Create as many textboxes as fit into window
            //groupBoxData.Controls.Clear();
            var x = 0;
            var y = 10;
            var z = 20;
            while (y < groupBoxData.Size.Width - 100)
            {
                var labData = new Label();
                groupBoxData.Controls.Add(labData);
                labData.Size = new Size(30, 25);
                labData.Location = new Point(y, z);
                //labData.Font = new Font("Calibri", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
                
                        var txtData = new TextBox();
                        groupBoxData.Controls.Add(txtData);
                        txtData.Size = new Size(55, 25);
                        txtData.Location = new Point(y + 30, z - 2);
                        txtData.TextAlign = HorizontalAlignment.Right;
                        txtData.Tag = x;
                        txtData.MaxLength = 5;
                        txtData.Leave += TxtDataLeave;
                        txtData.Enter += txtData_Enter;
                        txtData.KeyPress += txtDataIntegerKeyPress;
                        z = z + txtData.Size.Height + 15;
                        labData.Text = Convert.ToString(StartAddress + x);

                x++;
                
                if (z > groupBoxData.Size.Height - 30)
                {
                    var inc = _displayFormat == DisplayFormat.Binary ? 200 : 100;
                    y = y + inc;
                    z = 20;
                }
            }
            _displayCtrlCount = x;
            _UpdateDataTable();
        }

        public void _RefreshWrite()
        {
            // Create as many textboxes as fit into window
            //groupBoxData.Controls.Clear();
            var x = 0;
            var y = 10;
            var z = 20;
            while (y < groupBoxWrite.Size.Width - 100)
            {
                var labWrite = new Label();
                groupBoxWrite.Controls.Add(labWrite);
                labWrite.Size = new Size(30, 25);
                labWrite.Location = new Point(y, z);
                //labWrite.Font = new Font("Calibri", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);

                var txtWrite = new TextBox();
                groupBoxWrite.Controls.Add(txtWrite);
                txtWrite.Size = new Size(55, 25);
                txtWrite.Location = new Point(y + 30, z - 2);
                txtWrite.TextAlign = HorizontalAlignment.Right;
                txtWrite.Tag = x;
                txtWrite.MaxLength = 5;
                txtWrite.Leave += TxtDataLeave;
                txtWrite.Enter += txtData_Enter;
                txtWrite.KeyPress += txtDataIntegerKeyPress;
                z = z + txtWrite.Size.Height + 15;
                labWrite.Text = Convert.ToString(StartAddress + x);

                x++;

                if (z > groupBoxWrite.Size.Height - 30)
                {
                    var inc = _displayFormat == DisplayFormat.Binary ? 200 : 100;
                    y = y + inc;
                    z = 20;
                }
            }
            _displayCtrlCount = x;
            _UpdateDataWrite();
        }

        void txtDataIntegerKeyPress(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        void txtData_Enter(object sender, EventArgs e)
        {
            var textBox = (TextBox)sender;
            if (!String.IsNullOrEmpty(textBox.Text))
            {
                textBox.Clear();
            }
        }

        void TxtDataLeave(object sender, EventArgs e)
        {
            var textBox = (TextBox)sender;
            var textBoxNumber = Int32.Parse(textBox.Tag.ToString());
            UInt16 res;
            if (UInt16.TryParse(textBox.Text, out res))
            {
                _registerData[StartAddress + textBoxNumber] = res;
            }
            else
            {
                textBox.Text = "0";
            }
        }
        
        public void _UpdateDataTable()
        {
            //_registerData =
            //_displayCtrlCount = Convert.ToInt32("120");
            var data = new ushort[_displayCtrlCount];
            //int[] dataC = new int[_displayCtrlCount];
            for (int i = 0; i < _displayCtrlCount; i++)
            {
                var index = StartAddress + i;
                /*
                if (index >= testjerry.Length)
                {
                    break;
                }
                */
                data[i] = _registerData[index];
                //dataC[i] = Convert.ToInt32(data[i]);
               
            }
            // ------------------------------------------------------------------------
            // Put new data into text boxes
            //ushort _registerData = Convert.ToUInt16("1");

            foreach (Control ctrl in groupBoxData.Controls)
            {
                if (ctrl is TextBox)
                {
                    int x = Convert.ToUInt16(ctrl.Tag);
                    if (x <= data.GetUpperBound(0))
                    {
                        ctrl.Text = data[x].ToString(CultureInfo.InvariantCulture);
                        ctrl.Visible = true;
                    }
                    else ctrl.Text = "0";
                }
            }
            
        }

        public void _UpdateDataWrite()
        {
            var data = new ushort[_displayCtrlCount];
            for (int i = 0; i < _displayCtrlCount; i++)
            {
                var index = StartAddress + i;
                if (index >= _registerData.Length)
                {
                    break;
                }
                data[i] = _registerData[index];
                //data[i] = 0;

            }
            // ------------------------------------------------------------------------
            // Put new data into text boxes
            foreach (Control ctrl in groupBoxWrite.Controls)
            {

                int x = Convert.ToUInt16(ctrl.Tag);
                if (x <= data.GetUpperBound(0))
                {
                    if (ctrl is TextBox)
                    {
                        ctrl.Text = data[x].ToString(CultureInfo.InvariantCulture);
                        //ctrl.Text = data[x].ToString();
                        ctrl.Visible = true;
                    }
                }
                else ctrl.Text = "0";

            }
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
                    //var address = StartAddress;
                    //var tab = tabControl1.SelectedTab;
                    groupBoxData.Controls.Clear();
                    
                    //tab.Text = address.ToString();
                    //_startAddress = address;
                    //_dataLength = DataLength;
                    if (OnApply != null) OnApply(this, new EventArgs());
                    _RefreshData();
 
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            if (_registerData != null)
            {
                var count = DataLength;
                
                /*
                if (modbusListen.IsAlive)
                { 
                    modbusListen.Abort();
                    modbusListen.Join(50);
                    setStatusLabel("Disconnected");
                }
                */
                for (int i = StartAddress; i < _registerData.Length && count-- != 0; i++)
                {
                    _registerData[i] = 0;
                }
                _RefreshData();
            }
        }

        #endregion

        /// <summary>
        /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>

        private void HCRSM()
        {
            //creating an instance from Modbus client class
            //ModbusClient modbusClient = new ModbusClient(ipAddTextBox.Text, 502);    //Ip-Address and Port of Modbus-TCP-Server
            //modbusThread = new Thread(new ThreadStart(HCRMB));
            //modbusThread.IsBackground = true;

            try
            {

                _socket.Bind(new IPEndPoint(IPAddress.Any, 502));
                _socket.Listen(10);
                //public EasyModbus.ModbusServer modbusServer = new EasyModbus.ModbusServer();
                var server = new ModbusLib.Protocols.ModbusServer(new ModbusTcpCodec()) { Address = SlaveId };
                //broadcasrter = new UDPBroadcaster();
                //var server = new TcpListener(IPAddress.Any, 502);
                //server.Start();
                //server.BeginAcceptTcpClient(AcceptTcpClientCallback, null);
                //server.BeginAcceptTcpClient(null);

                //var tcpHandler = new TCPHandler(portnum);
                //tcpHandler.dataChanged += new TCPHandler.DataChanged(ProcessReceivedData);
                //tcpHandler.numberOfClientsChanged += new TCPHandler.NumberOfClientsChanged(numberOfClientsChanged);

                server.IncommingData += DriverIncommingData;
                server.OutgoingData += DriverOutgoingData;

                while (true)
                {
                    //modbusServer.Listen();
                    
                    _listener = _socket.GetTcpListener(server);
                    _listener.ServeCommand += listener_ServeCommand;
                    _listener.Start();
                    
                    Thread.Sleep(1);
                    //_UpdateDataTable();
                    //Thread.Sleep(10);
                    //modbusServer.inputRegisters[]
                    //modbusServer.StopListening();
                }

                //modbusServer.StopListening();

            }
            catch (Exception)
            {
                modbusListen.Abort();
                modbusListen.Join(50);
                setStatusLabel("Modbus Server failed!");
            }

        }

        private void HCRSW()
        {
            //creating an instance from Modbus client class
            //ModbusClient modbusClient = new ModbusClient(ipAddTextBox.Text, 502);    //Ip-Address and Port of Modbus-TCP-Server
            //modbusThread = new Thread(new ThreadStart(HCRMB));
            //modbusThread.IsBackground = true;

            try
            {
                _socket.SetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.NoDelay, true);
                _socket.SendTimeout = 2500;
                _socket.ReceiveTimeout = 2500;
                _socket.Connect(new IPEndPoint((IPAddress.Parse(ipaddress)), TCPPort));
                _portClient = _socket.GetClient();
                _driver = new ModbusClient(new ModbusTcpCodec()) { Address = SlaveId };
                _driver.OutgoingData += DriverOutgoingData;
                _driver.IncommingData += DriverIncommingData;
                /*if (!modbusClient.Connected)
                {
                    modbusClient.Connect();
                    setStatusLabel("Connecting...");
                    Thread.Sleep(2000);
                    if (!modbusClient.Connected)
                    {
                        setStatusLabel("Unavailable");
                        modbusThread.Abort();
                        modbusThread.Join(50);
                    }
                }*/
                //private Socket _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //_socket.Bind(new IPEndPoint(IPAddress.Any, TCPPort));
                //_socket.Listen(10);
                //create a server driver

                //modbusServer.StopListening();

            }
            catch (Exception)
            {
                modbusWrite.Abort();
                modbusWrite.Join(50);
                setStatusLabel("Modbus client failed!");
            }

        }

        private void ExecuteReadCommand(byte function)
        {
            try
            {
                var command = new ModbusCommand(function) { Offset = StartAddress, Count = DataLength, TransId = _transactionId++ };
                var result = _driver.ExecuteGeneric(_portClient, command);
                if (result.Status == CommResponse.Ack)
                {
                    command.Data.CopyTo(_registerData, StartAddress);
                    _UpdateDataTable();
                }
                else
                {
                }
            }
            catch (Exception)
            {
                //AppendLog(ex.Message);
            }
        }

        private void closebtt_Click(object sender, EventArgs e)
        {
            if (modbusThread.IsAlive)
            {
                modbusClient.Disconnect();
                Thread.Sleep(50);
                modbusThread.Abort();
                modbusThread.Join(50);
                setStatusLabel("Disconnected");
            }

            else
            {
                setStatusLabel("Disconnected");
            }
        }

        private void startBtt_Click(object sender, EventArgs e)
        {
            int trial_count = 0;
            EasyModbus.ModbusClient modbusClient = new EasyModbus.ModbusClient(ipAddTextBox.Text, 502);
            try
            {
                if (!modbusClient.Connected)
                {
                    while (trial_count <= 3)
                    {
                        modbusClient.Connect();
                        Thread.Sleep(150);
                        if (modbusClient.Connected)
                        {
                            break;
                        }
                        trial_count++;
                    }
                }
                if (modbusClient.Connected)
                {
                    modbusClient.WriteSingleRegister(702, 1);
                    modbusClient.WriteSingleRegister(701, 0);
                    modbusClient.WriteSingleRegister(700, 0);
                    /*if (modbusClient.Connected)
                    {
                        modbusClient.WriteSingleRegister(700, 1);
                        modbusClient.WriteSingleRegister(701, 0);
                        modbusClient.WriteSingleRegister(702, 0);
                        Thread.Sleep(50);
                        modbusClient.WriteSingleRegister(700, 0);
                        modbusClient.WriteSingleRegister(700, 1);
                    }*/
                }
            }
            catch
            {
                setStatusLabel("Not connected!");
            }

        }

        private void pauseBtt_Click(object sender, EventArgs e)
        {
            int trial_count = 0;
            EasyModbus.ModbusClient modbusClient = new EasyModbus.ModbusClient(ipAddTextBox.Text, 502);
            try
            {
                if (!modbusClient.Connected)
                {
                    while (trial_count <= 3)
                    {
                        modbusClient.Connect();
                        Thread.Sleep(150);
                        if (modbusClient.Connected)
                        {
                            break;
                        }
                        trial_count++;
                    }
                }
                if (modbusClient.Connected)
                {
                    modbusClient.WriteSingleRegister(701, 1);
                    modbusClient.WriteSingleRegister(700, 0);
                    modbusClient.WriteSingleRegister(702, 0);
                    /*if (modbusClient.Connected)
                    {
                        modbusClient.WriteSingleRegister(700, 1);
                        modbusClient.WriteSingleRegister(701, 0);
                        modbusClient.WriteSingleRegister(702, 0);
                        Thread.Sleep(50);
                        modbusClient.WriteSingleRegister(700, 0);
                        modbusClient.WriteSingleRegister(700, 1);
                    }*/
                }
            }
            catch
            {
                setStatusLabel("Not connected!");
            }

        }

        private void stopBtt_Click(object sender, EventArgs e)
        {
            int trial_count = 0;
            EasyModbus.ModbusClient modbusClient = new EasyModbus.ModbusClient(ipAddTextBox.Text, 502);
            try
            {
                if (!modbusClient.Connected)
                {
                    while (trial_count <= 3)
                    {
                        modbusClient.Connect();
                        Thread.Sleep(150);
                        if (modbusClient.Connected)
                        {
                            break;
                        }
                        trial_count++;
                    }
                }
                if (modbusClient.Connected)
                {
                    modbusClient.WriteSingleRegister(700, 1);
                    modbusClient.WriteSingleRegister(701, 0);
                    modbusClient.WriteSingleRegister(702, 0);
                    /*if (modbusClient.Connected)
                    {
                        modbusClient.WriteSingleRegister(700, 1);
                        modbusClient.WriteSingleRegister(701, 0);
                        modbusClient.WriteSingleRegister(702, 0);
                        Thread.Sleep(50);
                        modbusClient.WriteSingleRegister(700, 0);
                        modbusClient.WriteSingleRegister(700, 1);
                    }*/
                }
            }
            catch
            {
                setStatusLabel("Not connected!");
            }

        }

        private void buttonWriteApply_Click(object sender, EventArgs e)
        {
            if (!modbusWrite.IsAlive)
            {
                modbusWrite = new Thread(new ThreadStart(HCRSW));
                modbusWrite.IsBackground = true;
                modbusWrite.Start();
            }
        }

        private void buttonWriteClear_Click(object sender, EventArgs e)
        {
            if (modbusWrite.IsAlive)
            {
                modbusClient.Disconnect();
                Thread.Sleep(50);
                modbusWrite.Abort();
                modbusWrite.Join(50);
                setStatusLabel("Modbus Server failed!");
            }
        }

        private void buttonListen_Click(object sender, EventArgs e)
        {
            if (!modbusListen.IsAlive)
            {
                modbusListen = new Thread(new ThreadStart(HCRSM));
                modbusListen.IsBackground = true;
                modbusListen.Start();
            }
        }

        private void buttonDisconnect_Click(object sender, EventArgs e)
        {
            if (_listener != null)
            {
                _listener.Abort();
                _listener = null;
            }
            if (_socket != null)
            {
                _socket.Dispose();
                _socket = null;
            }
            if (modbusListen != null && modbusListen.IsAlive)
            {
                modbusServer.StopListening();
                if (modbusListen.Join(2000) == false)
                {
                    modbusListen.Abort();
                    modbusListen = null;
                }
            }
        }

        private void buttonWrite_Click(object sender, EventArgs e)
        {
            ExecuteReadCommand(ModbusCommand.FuncReadInputRegisters);
        }

    }
    
}
