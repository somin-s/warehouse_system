using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Configuration;
using System.Net;
using System.IO;
using System.Windows.Forms;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using Bt.SysLib;
using Bt.ScanLib;
using Bt.CommLib;
using Bt.FileLib;
using Bt;

namespace BKHandy
{
    public class Com
    {
        /********************************************************************************
         * Function ：INI file
        ********************************************************************************/
        // BT Handy Setting.
        private const string INI_FILE = @"Program Files\BKHandy\BT.ini";
        private const string LANG_FILE = @"Program Files\BKHandy\language.csv";
        public const string LOG_FILE = @"Program Files\BKHandy\backup\log.csv";
        public const string OUT_FOLDER = @"Program Files\BKHandy\outputPath\";
        public const string IN_FOLDER = @"Program Files\BKHandy\inputPath\";

        public static string ReadIniFile(string _keySet)
        {
            try
            {
                string s_ret = "";

                StringBuilder sectionSet = new StringBuilder();
                sectionSet.Append("SETTING");
                StringBuilder keySet = new StringBuilder();
                keySet.Append(_keySet);
                StringBuilder strDefSet = new StringBuilder();
                strDefSet.Append("");
                StringBuilder filenameSet = new StringBuilder();
                filenameSet.Append(INI_FILE);
                //byte[] btRetStr = new byte[LibDef.BT_INI_VALUE_MAXLEN - 1] { };
                byte[] bufaryGet = new byte[16383];

                //int ret = Ini.btIniReadString(sectionSet, keySet, strDefSet, bufaryGet, LibDef.BT_INI_VALUE_MAXLEN, filenameSet);
                int ret = Ini.btIniReadString(sectionSet, keySet, strDefSet, bufaryGet, 16382, filenameSet);
                if (0 == ret)
                {
                    MessageBox.Show("btIniReadString error ret[" + ret.ToString() + "]", "Error");
                    return "";
                }
                s_ret = Encoding.Unicode.GetString(bufaryGet, 0, (ret * 2));
                return s_ret;
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.ToString(), "Error");
                return "";
            }
        }

        public static void WriteIniFile(string _keySet, string _str)
        {
            try
            {
                StringBuilder sectionSet = new StringBuilder();
                sectionSet.Append("SETTING");
                StringBuilder keySet = new StringBuilder();
                keySet.Append(_keySet);
                StringBuilder str = new StringBuilder();
                str.Append(_str);
                StringBuilder filenameSet = new StringBuilder();
                filenameSet.Append(INI_FILE);

                int ret = Ini.btIniWriteString(sectionSet, keySet, str, filenameSet);
                if (0 != ret)
                {
                    MessageBox.Show("btIniWriteString error ret[" + ret.ToString() + "]", "Error");
                }
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.ToString(), "Error");
            }
        }

        /********************************************************************************
         * Variable
        ********************************************************************************/
        public const int BYTE_SIZE = 1024;
        public static int WIFI_LENGTH = 15;
        public static int DELIVERY_SHEET_LENGTH1 = 5;
        public static int DELIVERY_SHEET_LENGTH2 = 6;

        private static int _i_Lang = 0;
        public static int i_Lang
        {
            set { _i_Lang = value; }
            get { return _i_Lang; }
        }

        private static string _s_TerminalName = "";
        public static string s_TerminalName
        {
            set { _s_TerminalName = value; }
            get { return _s_TerminalName; }
        }

        private static int _i_WorkMode = 0;
        public static int i_WorkMode
        {
            set { _i_WorkMode = value; }
            get { return _i_WorkMode; }
        }

        //======================================================Tick 
        private static string _s_ScreenType = "";
        public static string s_ScreenType
        {
            set { _s_ScreenType = value; }
            get { return _s_ScreenType; }
        }

        #region 1st Screen (Part Test)
        private static string _s_Request_No = "";
        public static string s_Request_No
        {
            set { _s_Request_No = value; }
            get { return _s_Request_No; }
        }
        private static string _s_Requester = "";
        public static string s_Requester
        {
            set { _s_Requester = value; }
            get { return _s_Requester; }
        }
        private static string _s_Requester_Name = "";
        public static string s_Requester_Name
        {
            set { _s_Requester_Name = value; }
            get { return _s_Requester_Name; }
        }
        private static string _s_Tester = "";
        public static string s_Tester
        {
            set { _s_Tester = value; }
            get { return _s_Tester; }
        }
        private static string _s_Tester_Name = "";
        public static string s_Tester_Name
        {
            set { _s_Tester_Name = value; }
            get { return _s_Tester_Name; }
        }
        private static string _s_Project = "";
        public static string s_Project
        {
            set { _s_Project = value; }
            get { return _s_Project; }
        }
        private static string _s_Project_Name = "";
        public static string s_Project_Name
        {
            set { _s_Project_Name = value; }
            get { return _s_Project_Name; }
        }
        #endregion


        #region 2nd Screen (Part Test)
        private static string _s_Plant = "";
        public static string s_Plant
        {
            set { _s_Plant = value; }
            get { return _s_Plant; }
        }
        private static string _s_Plant_Name = "";
        public static string s_Plant_Name
        {
            set { _s_Plant_Name = value; }
            get { return _s_Plant_Name; }
        }
        private static string _s_PartNo = "";
        public static string s_PartNo
        {
            set { _s_PartNo = value; }
            get { return _s_PartNo; }
        }
        private static string _s_Part_Name = "";
        public static string s_Part_Name
        {
            set { _s_Part_Name = value; }
            get { return _s_Part_Name; }
        }
        private static string _s_ColorPlat = "";
        public static string s_ColorPlat
        {
            set { _s_ColorPlat = value; }
            get { return _s_ColorPlat; }
        }

        private static string _s_TSH = "";
        public static string s_TSH
        {
            set { _s_TSH = value; }
            get { return _s_TSH; }
        }
        private static string _s_TSH_Name = "";
        public static string s_TSH_Name
        {
            set { _s_TSH_Name = value; }
            get { return _s_TSH_Name; }
        }
        #endregion


        #region 3rd Screen (Part Test)
        private static string _s_TestItem = "";
        public static string s_TestItem
        {
            set { _s_TestItem = value; }
            get { return _s_TestItem; }
        }
        private static string _s_UnitNo = "";
        public static string s_UnitNo
        {
            set { _s_UnitNo = value; }
            get { return _s_UnitNo; }
        }
        private static string _s_TotalUnit = "";
        public static string s_TotalUnit
        {
            set { _s_TotalUnit = value; }
            get { return _s_TotalUnit; }
        }
        private static string _s_Day = "";
        public static string s_Day
        {
            set { _s_Day = value; }
            get { return _s_Day; }
        }
        private static string _s_Month = "";
        public static string s_Month
        {
            set { _s_Month = value; }
            get { return _s_Month; }
        }
        private static string _s_Year = "";
        public static string s_Year
        {
            set { _s_Year = value; }
            get { return _s_Year; }
        }
        private static string _s_Remark = "";
        public static string s_Remark
        {
            set { _s_Remark = value; }
            get { return _s_Remark; }
        }


        #endregion


        #region 1st Screen (PaintMaterial)
        private static string _s_Material_Type = "";
        public static string s_Material_Type
        {
            set { _s_Material_Type = value; }
            get { return _s_Material_Type; }
        }
        private static string _s_Material_Name = "";
        public static string s_Material_Name
        {
            set { _s_Material_Name = value; }
            get { return _s_Material_Name; }
        }

        #endregion


        #region 2nd Screen (PaintMaterial)

        private static string _s_Name = "";
        public static string s_Name
        {
            set { _s_Name = value; }
            get { return _s_Name; }
        }

        private static string _s_Maker = "";
        public static string s_Maker
        {
            set { _s_Maker = value; }
            get { return _s_Maker; }
        }

        private static string _s_Maker_Name = "";
        public static string s_Maker_Name
        {
            set { _s_Maker_Name = value; }
            get { return _s_Maker_Name; }
        }
        #endregion




        //==================================================== end Tick
        private static string _s_UserID = "";
        public static string s_UserID
        {
            set { _s_UserID = value; }
            get { return _s_UserID; }
        }

        private static string _s_UserName = "";
        public static string s_UserName
        {
            set { _s_UserName = value; }
            get { return _s_UserName; }
        }

        private static string _s_Loc1_CD = "";
        public static string s_Loc1_CD
        {
            set { _s_Loc1_CD = value; }
            get { return _s_Loc1_CD; }
        }

        private static string _s_Loc1_Name = "";
        public static string s_Loc1_Name
        {
            set { _s_Loc1_Name = value; }
            get { return _s_Loc1_Name; }
        }

        private static string _s_Loc2_CD = "";
        public static string s_Loc2_CD
        {
            set { _s_Loc2_CD = value; }
            get { return _s_Loc2_CD; }
        }

        private static string _s_Loc2_Name = "";
        public static string s_Loc2_Name
        {
            set { _s_Loc2_Name = value; }
            get { return _s_Loc2_Name; }
        }

        private static string _s_ItemCD = "";
        public static string s_ItemCD
        {
            set { _s_ItemCD = value; }
            get { return _s_ItemCD; }
        }

        private static string _s_ItemName = "";
        public static string s_ItemName
        {
            set { _s_ItemName = value; }
            get { return _s_ItemName; }
        }

        private static string _s_ItemUnit = "";
        public static string s_ItemUnit
        {
            set { _s_ItemUnit = value; }
            get { return _s_ItemUnit; }
        }

        private static string _s_Lot = "";
        public static string s_Lot
        {
            set { _s_Lot = value; }
            get { return _s_Lot; }
        }

        private static string _s_Qty = "";
        public static string s_Qty
        {
            set { _s_Qty = value; }
            get { return _s_Qty; }
        }

        /********************************************************************************
         * [フォーム終了時のリリース処理]
        ********************************************************************************/
        public static void Form_ClosedCom()
        {
            Bt.ScanLib.Control.btScanEnable();

            if (MainForm._MainFormInstance != null)
            {
                MainForm._MainFormInstance.Dispose();
            }
            if (History._FormInstance != null)
            {
                History._FormInstance.Dispose();
            }
            if (InputItem._FormInstance != null)
            {
                InputItem._FormInstance.Dispose();
            }
            if (InputLocation._FormInstance != null)
            {
                InputLocation._FormInstance.Dispose();
            }
            if (InputLocation2._FormInstance != null)
            {
                InputLocation2._FormInstance.Dispose();
            }
            if (InputLot._FormInstance != null)
            {
                InputLot._FormInstance.Dispose();
            }
            if (InputQty._FormInstance != null)
            {
                InputQty._FormInstance.Dispose();
            }
            //============================================================Tick
            if (PartTest1._FormInstance != null)
            {
                PartTest1._FormInstance.Dispose();
            }
            if (PartTest2._FormInstance != null)
            {
                PartTest2._FormInstance.Dispose();
            }
            if (PartTest3._FormInstance != null)
            {
                PartTest3._FormInstance.Dispose();
            }
            if (PaintMaterial1._FormInstance != null)
            {
                PaintMaterial1._FormInstance.Dispose();
            }
            if (Paintmaterial2._FormInstance != null)
            {
                Paintmaterial2._FormInstance.Dispose();
            }
            if (Paintmaterial3._FormInstance != null)
            {
                Paintmaterial3._FormInstance.Dispose();
            }

            //============================================================
            if (Setting._FormInstance != null)
            {
                Setting._FormInstance.Dispose();
            }
            if (ErrorScreen._FormInstance != null)
            {
                ErrorScreen._FormInstance.Dispose();
            }
        }

        /********************************************************************************
         * Common Functions
        ********************************************************************************/
        public static int ConvertInt(string str)
        {
            try
            {
                int d = int.Parse(str);
                return d;
            }
            catch (System.Exception e)
            {
                return 0;
            }
        }

        public static double ConvertDouble(string str)
        {
            try
            {
                double d = double.Parse(str);
                return d;
            }
            catch (System.Exception e)
            {
                return 0;
            }
        }

        static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        public static void Buzzer1(uint cnt)
        {
            Int32 ret = 0;
            String disp = "";

            LibDef.BT_BUZZER_PARAM stBuzzerSet = new LibDef.BT_BUZZER_PARAM();			// ブザー制御構造体(Set)

            // 「500msオン、500msオフ」を繰り返す設定
            stBuzzerSet.dwOn = 500;		// 鳴動時間[ms] （1～5000）
            stBuzzerSet.dwOff = 500;		// 停止時間[ms] （0～5000）
            stBuzzerSet.dwCount = cnt;	// 鳴動回数[回] （0～100）
            stBuzzerSet.bTone = 16;		// 音階 （1～16）
            stBuzzerSet.bVolume = 1;	// ブザー音量 （1～3）

            try
            {
                // btBuzzer 鳴動
                ret = Device.btBuzzer(1, stBuzzerSet);
                if (ret != LibDef.BT_OK)
                {
                    disp = "btBuzzer error ret[" + ret + "]";
                    MessageBox.Show(disp, "Error");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        
        public static void Buzzer2()
        {
            Int32 ret = 0;
            String disp = "";

            LibDef.BT_BUZZER_PARAM stBuzzerSet = new LibDef.BT_BUZZER_PARAM();			// ブザー制御構造体(Set)

            stBuzzerSet.dwOn = 100;		// 鳴動時間[ms] （1～5000）
            stBuzzerSet.dwOff = 0;		// 停止時間[ms] （0～5000）
            stBuzzerSet.dwCount = 1;	// 鳴動回数[回] （0～100）
            stBuzzerSet.bVolume = 1;	// ブザー音量 （1～3）

            try
            {
                // btBuzzer 鳴動
                stBuzzerSet.bTone = 8;		// 音階 （1～16）
                ret = Device.btBuzzer(1, stBuzzerSet);
                System.Threading.Thread.Sleep(100);
                stBuzzerSet.bTone = 11;		// 音階 （1～16）
                ret = Device.btBuzzer(1, stBuzzerSet);
                System.Threading.Thread.Sleep(100);
                stBuzzerSet.bTone = 15;		// 音階 （1～16）
                ret = Device.btBuzzer(1, stBuzzerSet);
                System.Threading.Thread.Sleep(100);

                if (ret != LibDef.BT_OK)
                {
                    disp = "btBuzzer error ret[" + ret + "]";
                    MessageBox.Show(disp, "Error");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void getMaster()
        {
            //砂時計表示
            Cursor.Current = Cursors.WaitCursor;
            
            String disp = "";

			TcpClient client = null;

            try
            {
                // 文字コードを指定f
                System.Text.Encoding enc = Encoding.UTF8;

                // サーバへ接続
                using (client = new TcpClient())
                {
                    try
                    {
                        client.Connect(Com.ReadIniFile("HOSTIP"), int.Parse(Com.ReadIniFile("HOSTPORT")));
                    }
                    catch (FormatException)
                    {
                        return;
                    }
                    using (NetworkStream ns = client.GetStream())
                    {
                        // データ送信
                        String sendMsg = "REQUEST_MASTER";
                        Byte[] sendBytes = enc.GetBytes(sendMsg);
                        ns.Write(sendBytes, 0, sendBytes.Length);

                        // データ受信
                        MemoryStream ms = new MemoryStream();
                        Byte[] resBytes = new Byte[BYTE_SIZE];
                        int resSize;
                        String resMsg = "";
                        do
                        {
                            System.Threading.Thread.Sleep(50);

                            // データの一部を受信
                            resBytes = new Byte[BYTE_SIZE];
                            resSize = ns.Read(resBytes, 0, resBytes.Length);
                            if (resSize == 0)
                            {
                                // 受信データ無しと判断
                                break;
                            }
                            // 受信したデータを蓄積
                            //if ("" != enc.GetString(resBytes, 0, resBytes.Length))
                            //{
                            //    resMsg = resMsg + enc.GetString(resBytes, 0, resBytes.Length);
                            //}
                            ms.Write(resBytes, 0, resSize);
                        } while (ns.DataAvailable);

                        resMsg = enc.GetString(ms.ToArray(), 0, ms.ToArray().Count());

                        // MemoryStreamにキャッシュしたデータが有りなら表示
                        if ("" != resMsg)
                        {
                            GenerateMasterCSV(resMsg);
                            MessageBox.Show(Com.changeMessage("UpdateMaster"),"BKHandy Application");
                        }

                        // シャットダウンしてから切る
                        client.Client.Shutdown(SocketShutdown.Both);
                    }
                }
            }
            catch (IOException)
            {
                disp = "Invalid Connection";
                MessageBox.Show(disp);
            }
            catch (SocketException)
            {
                disp = "Connection Error";
                MessageBox.Show(disp);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                //砂時計をもとに戻す
                Cursor.Current = Cursors.Default;
            }
		}

        private static void GenerateMasterCSV(string s_str)
        {
            try
            {
                System.IO.StringReader rs = new System.IO.StringReader(s_str);

                string s_tmp = "";
                string s_FilePath = "";
                bool b_data = false;
                StreamWriter writer = null;
                //ストリームの末端まで繰り返す.
                while (rs.Peek() > -1)
                {
                    //一行読み込む.
                    s_tmp = rs.ReadLine();

                    if(null != writer && true == b_data)
                    {
                        if(s_tmp.Length > 17)
                        {
                            if("*****END_MASTER" == s_tmp.Substring(0,15))
                            {
                                writer.Close();
                                b_data = false;
                            }
                        }
                        if(true == b_data)
                        {
                            writer.WriteLine(s_tmp);
                        }
                    }

                    if(s_tmp.Length > 17)
                    {
                        if("***START_MASTER" == s_tmp.Substring(0,15))
                        {
                            s_FilePath = IN_FOLDER + 
                                            s_tmp.Substring(16) + ".csv";
                            if (true == File.Exists(s_FilePath))
                            {
                                File.Delete(s_FilePath);
                            }
                            writer = new StreamWriter(s_FilePath, true, new UTF8Encoding(false));
                            b_data = true;
                        }
                    }
                }

                rs.Close();                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    
        public static bool sendMessageLine(string Msg)
        {
            try
            {
                // 文字コードを指定
                System.Text.Encoding enc = Encoding.UTF8;

                TcpClient client = new TcpClient();
                client.Connect(Com.ReadIniFile("HOSTIP"), int.Parse(Com.ReadIniFile("HOSTPORT")));
                NetworkStream stream = client.GetStream();

                byte[] writebuf = enc.GetBytes(Msg);
                stream.Write(writebuf, 0, writebuf.Length);
                stream.Flush();
                return true;
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        public static void sendMessage(bool b_msg)
        {
            bool b_ret = false;
            //砂時計表示
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                string line = "";
                string[] files = Directory.GetFiles(OUT_FOLDER);
                foreach (string s in files)
                {
                    string s_file = Path.GetFileName(s);

                    string romFile = OUT_FOLDER +
                                    s_file;

                    string ramFile = "RamDisk\\" +
                                    s_file;

                    //ローカルファイルの有無チェック
                    if (File.Exists(romFile))
                    {
                        File.Copy(romFile, ramFile, true);

                        //ファイルが存在する場合、アップロード実行
                        line = "";
                        using (var sr = new System.IO.StreamReader(romFile))
                        {
                            // ストリームの末尾まで繰り返す
                            while (!sr.EndOfStream)
                            {
                                // ファイルから一行読み込む
                                line = sr.ReadLine();
                            }
                        }
                        b_ret = sendMessageLine(line);
                        if (true == b_ret)
                        {
                            File.Delete(romFile);
                        }
                        else
                        {
                            File.Delete(ramFile);
                            break;
                        }
                        File.Delete(ramFile);
                        System.Threading.Thread.Sleep(500);
                    }
                    else
                    {   //ファイルが存在しない場合
                        MessageBox.Show("No have file." + romFile);
                        return;
                    }
                }
                if (0 != files.Length)
                {
                    if (true == b_msg && true == b_ret)
                    {
                        MessageBox.Show(Com.changeMessage("SendLog"), "BKHandy Application");
                    }
                }
                else
                {
                    if (true == b_msg)
                    {
                        MessageBox.Show(Com.changeMessage("Nohave"), "BKHandy Application");
                    }
                }
            }
            catch (System.Exception e)
            {
                //MessageBox.Show(e.Message);
            }
            finally
            {
                //砂時計をもとに戻す
                Cursor.Current = Cursors.Default;
            }
        }

        public static string DQ(string str)
        {
            string s_ret = "";
            s_ret = str.Trim('"');
            return s_ret;
        }

        public static bool setMasterUser()
        {
            try
            {
                bool b_ret = false;

                s_UserName = "";

                // csvファイルを開く
                using (var sr = new System.IO.StreamReader(IN_FOLDER + "TB_M_USER.csv"))
                {
                    // ストリームの末尾まで繰り返す
                    while (!sr.EndOfStream)
                    {
                        // ファイルから一行読み込む
                        var line = sr.ReadLine();
                        // 読み込んだ一行をカンマ毎に分けて配列に格納する
                        string[] values = line.Split(',');
                        // 出力する

                        if (s_UserID == DQ(values[0]))
                        {
                            s_UserName = DQ(values[1]);
                            b_ret = true;
                            break;
                        }

                    }
                }
                if(false == b_ret)
                {
                    Buzzer1(1);
                }
                return b_ret;
            }
            catch (System.Exception e)
            {
                // ファイルを開くのに失敗したとき
                MessageBox.Show(e.Message);
                Buzzer1(1);
                return false;
            }
        }
        //===========================================================================================Tick
        public static bool setMasterRequester() 
        {
            try
            {
                bool b_ret = false;

                s_Requester_Name = "";

                // csvファイルを開く
                using (var sr = new System.IO.StreamReader(IN_FOLDER + "TB_M_REQUESTER.csv"))
                {
                    // ストリームの末尾まで繰り返す
                    while (!sr.EndOfStream)
                    {
                        // ファイルから一行読み込む
                        var line = sr.ReadLine();
                        // 読み込んだ一行をカンマ毎に分けて配列に格納する
                        string[] values = line.Split(',');
                        // 出力する

                        if (s_Requester == DQ(values[0]))
                        {
                            s_Requester_Name = DQ(values[1]);
                            b_ret = true;
                            break;
                        }

                    }
                }
                if (false == b_ret)
                {
                    Buzzer1(1);
                }
                return b_ret;
            }
            catch (System.Exception e)
            {
                // ファイルを開くのに失敗したとき
                MessageBox.Show(e.Message);
                Buzzer1(1);
                return false;
            }
        }

        public static bool setMasterTester()
        {
            try
            {
                bool b_ret = false;

                s_Tester_Name = "";

                // csvファイルを開く
                using (var sr = new System.IO.StreamReader(IN_FOLDER + "TB_M_TESTER.csv"))
                {
                    // ストリームの末尾まで繰り返す
                    while (!sr.EndOfStream)
                    {
                        // ファイルから一行読み込む
                        var line = sr.ReadLine();
                        // 読み込んだ一行をカンマ毎に分けて配列に格納する
                        string[] values = line.Split(',');
                        // 出力する

                        if (s_Tester == DQ(values[0]))
                        {
                            s_Tester_Name = DQ(values[1]);
                            b_ret = true;
                            break;
                        }

                    }
                }
                if (false == b_ret)
                {
                    Buzzer1(1);
                }
                return b_ret;
            }
            catch (System.Exception e)
            {
                // ファイルを開くのに失敗したとき
                MessageBox.Show(e.Message);
                Buzzer1(1);
                return false;
            }
        }

        public static bool setMasterPlant()
        {
            try
            {
                bool b_ret = false;

                s_Plant_Name = "";

                // csvファイルを開く
                using (var sr = new System.IO.StreamReader(IN_FOLDER + "TB_M_PLANT.csv"))
                {
                    // ストリームの末尾まで繰り返す
                    while (!sr.EndOfStream)
                    {
                        // ファイルから一行読み込む
                        var line = sr.ReadLine();
                        // 読み込んだ一行をカンマ毎に分けて配列に格納する
                        string[] values = line.Split(',');
                        // 出力する

                        if (s_Plant == DQ(values[0]))
                        {
                            s_Plant_Name = DQ(values[1]);
                            b_ret = true;
                            break;
                        }

                    }
                }
                if (false == b_ret)
                {
                    Buzzer1(1);
                }
                return b_ret;
            }
            catch (System.Exception e)
            {
                // ファイルを開くのに失敗したとき
                MessageBox.Show(e.Message);
                Buzzer1(1);
                return false;
            }
        }

        public static bool setMasterTSH()
        {
            try
            {
                bool b_ret = false;

                s_TSH_Name = "";

                // csvファイルを開く
                using (var sr = new System.IO.StreamReader(IN_FOLDER + "TB_M_TSH.csv"))
                {
                    // ストリームの末尾まで繰り返す
                    while (!sr.EndOfStream)
                    {
                        // ファイルから一行読み込む
                        var line = sr.ReadLine();
                        // 読み込んだ一行をカンマ毎に分けて配列に格納する
                        string[] values = line.Split(',');
                        // 出力する

                        if (s_TSH == DQ(values[0]))
                        {
                            s_TSH_Name = DQ(values[1]);
                            b_ret = true;
                            break;
                        }

                    }
                }
                if (false == b_ret)
                {
                    Buzzer1(1);
                }
                return b_ret;
            }
            catch (System.Exception e)
            {
                // ファイルを開くのに失敗したとき
                MessageBox.Show(e.Message);
                Buzzer1(1);
                return false;
            }
        }
        
        public static bool setMasterMaterialType()
        {
            try
            {
                bool b_ret = false;

                //s_Material_Type = "";

                // csvファイルを開く
                using (var sr = new System.IO.StreamReader(IN_FOLDER + "TB_M_MATERIAL_TYPE.csv"))
                {
                    // ストリームの末尾まで繰り返す
                    while (!sr.EndOfStream)
                    {
                        // ファイルから一行読み込む
                        var line = sr.ReadLine();
                        // 読み込んだ一行をカンマ毎に分けて配列に格納する
                        string[] values = line.Split(',');
                        // 出力する

                        if (s_Material_Type == DQ(values[0]))
                        {
                            //s_Material_Type = DQ(values[1]);
                            b_ret = true;
                            break;
                        }

                    }
                }
                if (false == b_ret)
                {
                    Buzzer1(1);
                }
                return b_ret;
            }
            catch (System.Exception e)
            {
                // ファイルを開くのに失敗したとき
                MessageBox.Show(e.Message);
                Buzzer1(1);
                return false;
            }
        }

        public static bool setMasterMaterialName()
        {
            try
            {
                bool b_ret = false;

                //s_Material_Type = "";

                // csvファイルを開く
                using (var sr = new System.IO.StreamReader(IN_FOLDER + "TB_M_MATERIAL_NAME.csv"))
                {
                    // ストリームの末尾まで繰り返す
                    while (!sr.EndOfStream)
                    {
                        // ファイルから一行読み込む
                        var line = sr.ReadLine();
                        // 読み込んだ一行をカンマ毎に分けて配列に格納する
                        string[] values = line.Split(',');
                        // 出力する

                        if (s_Material_Name == DQ(values[0]))
                        {
                            //s_Material_Type = DQ(values[1]);
                            b_ret = true;
                            break;
                        }

                    }
                }
                if (false == b_ret)
                {
                    Buzzer1(1);
                }
                return b_ret;
            }
            catch (System.Exception e)
            {
                // ファイルを開くのに失敗したとき
                MessageBox.Show(e.Message);
                Buzzer1(1);
                return false;
            }
        }

        public static bool setMasterMaker()
        {
            try
            {
                bool b_ret = false;

                s_Maker_Name = "";

                // csvファイルを開く
                using (var sr = new System.IO.StreamReader(IN_FOLDER + "TB_M_MAKER.csv"))
                {
                    // ストリームの末尾まで繰り返す
                    while (!sr.EndOfStream)
                    {
                        // ファイルから一行読み込む
                        var line = sr.ReadLine();
                        // 読み込んだ一行をカンマ毎に分けて配列に格納する
                        string[] values = line.Split(',');
                        // 出力する

                        if (s_Maker == DQ(values[0]))
                        {
                            s_Maker_Name = DQ(values[1]);
                            b_ret = true;
                            break;
                        }

                    }
                }
                if (false == b_ret)
                {
                    Buzzer1(1);
                }
                return b_ret;
            }
            catch (System.Exception e)
            {
                // ファイルを開くのに失敗したとき
                MessageBox.Show(e.Message);
                Buzzer1(1);
                return false;
            }
        }
        //===========================================================================================Tick
        
        public static bool setDMY(string dmy)
        {
            try
            {
                bool b_ret = false;


                if (dmy == "Day")
                {
                    if (s_Day.Trim().Length == 2)
                    {
                        int d = Int32.Parse(s_Day);
                        if (1 <= d && d <= 31)
                        {
                            b_ret = true;
                        }
                        else b_ret = false;
                    }
                    else b_ret = false; 
                    
                }
                else if (dmy == "Month")
                {
                    if (s_Month.Trim().Length == 2)
                    {
                        int d = Int32.Parse(s_Month);
                        if (1 <= d && d <= 12) b_ret = true;
                        else b_ret = false;
                    }
                    else b_ret = false; 
                }
                else if (dmy == "Year")
                {
                    if (s_Year.Trim().Length == 4)
                    {
                        int d = Int32.Parse(s_Year);
                        if (1900 <= d && d <= 3000) b_ret = true;
                        else b_ret = false;
                    }
                    else b_ret = false; 
                }

                


                if (false == b_ret)
                {
                    Buzzer1(1);
                }
                return b_ret;
            }
            catch (System.Exception e)
            {
                // ファイルを開くのに失敗したとき
                MessageBox.Show(e.Message);
                Buzzer1(1);
                return false;
            }
        }
        //===============================================================================

        public static string getUserName(string s_id)
        {
            try
            {
                string s_ret = "";
                // csvファイルを開く
                using (var sr = new System.IO.StreamReader(IN_FOLDER + "TB_M_USER.csv"))
                {
                    // ストリームの末尾まで繰り返す
                    while (!sr.EndOfStream)
                    {
                        // ファイルから一行読み込む
                        var line = sr.ReadLine();
                        // 読み込んだ一行をカンマ毎に分けて配列に格納する
                        string[] values = line.Split(',');
                        // 出力する

                        if (s_id == DQ(values[0]))
                        {
                            s_ret = DQ(values[1]);
                            break;
                        }

                    }
                }
                return s_ret;
            }
            catch (System.Exception e)
            {
                return "";
            }
        }

        public static bool setMasterLoc1()
        {
            try
            {
                bool b_ret = false;

                s_Loc1_Name = "";

                // csvファイルを開く
                using (var sr = new System.IO.StreamReader(IN_FOLDER + "TB_M_LOCATION.csv"))
                {
                    // ストリームの末尾まで繰り返す
                    while (!sr.EndOfStream)
                    {
                        // ファイルから一行読み込む
                        var line = sr.ReadLine();
                        // 読み込んだ一行をカンマ毎に分けて配列に格納する
                        string[] values = line.Split(',');
                        // 出力する

                        if (s_Loc1_CD == DQ(values[0]))
                        {
                            s_Loc1_Name = DQ(values[1]);
                            b_ret = true;
                            break;
                        }

                    }
                }
                if (false == b_ret)
                {
                    Buzzer1(1);
                }
                return b_ret;
            }
            catch (System.Exception e)
            {
                // ファイルを開くのに失敗したとき
                MessageBox.Show(e.Message);
                Buzzer1(1);
                return false;
            }
        }

        public static bool setMasterLoc2()
        {
            try
            {
                bool b_ret = false;

                s_Loc2_Name = "";

                // csvファイルを開く
                using (var sr = new System.IO.StreamReader(IN_FOLDER + "TB_M_LOCATION.csv"))
                {
                    // ストリームの末尾まで繰り返す
                    while (!sr.EndOfStream)
                    {
                        // ファイルから一行読み込む
                        var line = sr.ReadLine();
                        // 読み込んだ一行をカンマ毎に分けて配列に格納する
                        string[] values = line.Split(',');
                        // 出力する

                        if (s_Loc2_CD == DQ(values[0]))
                        {
                            s_Loc2_Name = DQ(values[1]);
                            b_ret = true;
                            break;
                        }

                    }
                }
                if (false == b_ret)
                {
                    Buzzer1(1);
                }
                return b_ret;
            }
            catch (System.Exception e)
            {
                // ファイルを開くのに失敗したとき
                MessageBox.Show(e.Message);
                Buzzer1(1);
                return false;
            }
        }

        public static string getLocName(string s_id)
        {
            try
            {
                string s_ret = "";
                // csvファイルを開く
                using (var sr = new System.IO.StreamReader(IN_FOLDER + "TB_M_LOCATION.csv"))
                {
                    // ストリームの末尾まで繰り返す
                    while (!sr.EndOfStream)
                    {
                        // ファイルから一行読み込む
                        var line = sr.ReadLine();
                        // 読み込んだ一行をカンマ毎に分けて配列に格納する
                        string[] values = line.Split(',');
                        // 出力する

                        if (s_id == DQ(values[0]))
                        {
                            s_ret = DQ(values[1]);
                            break;
                        }

                    }
                }
                return s_ret;
            }
            catch (System.Exception e)
            {
                return "";
            }
        }

        public static bool setMasterItem()
        {
            try
            {
                bool b_ret = false;

                s_ItemName = "";

                // csvファイルを開く
                using (var sr = new System.IO.StreamReader(IN_FOLDER + "TB_M_ITEM.csv"))
                {
                    // ストリームの末尾まで繰り返す
                    while (!sr.EndOfStream)
                    {
                        // ファイルから一行読み込む
                        var line = sr.ReadLine();
                        // 読み込んだ一行をカンマ毎に分けて配列に格納する
                        string[] values = line.Split(',');
                        // 出力する

                        if (s_ItemCD == DQ(values[0]))
                        {
                            s_ItemName = DQ(values[1]);
                            setMasterUnit(DQ(values[2]));
                            b_ret = true;
                            break;
                        }

                    }
                }
                if (false == b_ret)
                {
                    Buzzer1(1);
                }
                return b_ret;
            }
            catch (System.Exception e)
            {
                // ファイルを開くのに失敗したとき
                MessageBox.Show(e.Message);
                Buzzer1(1);
                return false;
            }
        }

        public static string getItemName(string s_id)
        {
            try
            {
                string s_ret = "";
                // csvファイルを開く
                using (var sr = new System.IO.StreamReader(IN_FOLDER + "TB_M_ITEM.csv"))
                {
                    // ストリームの末尾まで繰り返す
                    while (!sr.EndOfStream)
                    {
                        // ファイルから一行読み込む
                        var line = sr.ReadLine();
                        // 読み込んだ一行をカンマ毎に分けて配列に格納する
                        string[] values = line.Split(',');
                        // 出力する

                        if (s_id == DQ(values[0]))
                        {
                            s_ret = DQ(values[1]);
                            break;
                        }

                    }
                }
                return s_ret;
            }
            catch (System.Exception e)
            {
                return "";
            }
        }

        public static bool setMasterUnit(string _s_ItemUnit)
        {
            try
            {
                bool b_ret = false;

                s_ItemUnit = "";

                // csvファイルを開く
                using (var sr = new System.IO.StreamReader(IN_FOLDER + "TB_M_UNIT.csv"))
                {
                    // ストリームの末尾まで繰り返す
                    while (!sr.EndOfStream)
                    {
                        // ファイルから一行読み込む
                        var line = sr.ReadLine();
                        // 読み込んだ一行をカンマ毎に分けて配列に格納する
                        string[] values = line.Split(',');
                        // 出力する

                        if (_s_ItemUnit == DQ(values[0]))
                        {
                            s_ItemUnit = DQ(values[1]);
                            b_ret = true;
                            break;
                        }

                    }
                }
                return b_ret;
            }
            catch (System.Exception e)
            {
                // ファイルを開くのに失敗したとき
                MessageBox.Show(e.Message);
                return false;
            }
        }

        public static bool checkDeplicate(string _s_delivery)
        {
            try
            {
                // csvファイルを開く
                using (var sr = new System.IO.StreamReader(LOG_FILE))
                {
                    // ストリームの末尾まで繰り返す
                    while (!sr.EndOfStream)
                    {
                        // ファイルから一行読み込む
                        var line = sr.ReadLine();
                        // 読み込んだ一行をカンマ毎に分けて配列に格納する
                        string[] values = line.Split(',');
                        // 出力する
                        if (values[6] == getWorkMode())
                        {
                            if (values[4] == _s_delivery)
                            {
                                return true;
                            }
                        }
                    }
                    return false;
                }
            }
            catch (System.Exception ex)
            {
                // ファイルが開けない場合は、照合の必要無し
                return false;
            }
        }
        
        public static void writeLog(string str, string s_filename)
        {
            try
            {
                Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
                StreamWriter writer =
                  new StreamWriter(OUT_FOLDER + s_filename, true, sjisEnc);
                writer.WriteLine(str);
                writer.Close();
                StreamWriter writer2 =
                  new StreamWriter(LOG_FILE, true, sjisEnc);
                writer2.WriteLine(str);
                writer2.Close();

                if ("0" == Com.ReadIniFile("SENDLOG_TYPE"))
                {
                    sendMessage(false);
                }
            }
            catch (System.Exception e)
            {
                // ファイルを開くのに失敗したとき
                MessageBox.Show(e.Message);
            }
        }

        public static string getWorkMode()
        {
            string s_WorkMode = "";
            switch (i_WorkMode)
            {
                case 0:
                    s_WorkMode = "Allocate";
                    break;
                case 1:
                    s_WorkMode = "Delivery";
                    break;
                case 2:
                    s_WorkMode = "Return";
                    break;
                default:
                    break;
            }
            return s_WorkMode;
        }

        public static string changeMessage(string s_type)
        {
            try
            {
                string s_ret = "";

                // csvファイルを開く
                using (var sr = new System.IO.StreamReader(LANG_FILE))
                {
                    // ストリームの末尾まで繰り返す
                    while (!sr.EndOfStream)
                    {
                        // ファイルから一行読み込む
                        var line = sr.ReadLine();
                        // 読み込んだ一行をカンマ毎に分けて配列に格納する
                        string[] values = line.Split(',');
                        // 出力する
                        if ("Message" == values[0] &&
                            s_type == values[1])
                        {
                            s_ret = values[i_Lang + 2];
                            break;
                        }
                    }
                }
                return s_ret;
            }
            catch (System.Exception e)
            {
                // ファイルを開くのに失敗したとき
                MessageBox.Show(e.Message);
                return "";
            }
        }

        public static void changeLang(string s_page, Form obj, int i_WorkMode)
        {
            try
            {
                // csvファイルを開く
                using (var sr = new System.IO.StreamReader(LANG_FILE))
                {
                    string s_WorkMode = "";
                    if (-1 != i_WorkMode)
                    {
                        s_WorkMode = i_WorkMode.ToString();
                    }

                    // ストリームの末尾まで繰り返す
                    while (!sr.EndOfStream)
                    {
                        // ファイルから一行読み込む
                        var line = sr.ReadLine();
                        // 読み込んだ一行をカンマ毎に分けて配列に格納する
                        string[] values = line.Split(',');
                        // 出力する
                        if (s_page == values[0] &&
                            obj.Name + s_WorkMode == values[1])
                        {
                            obj.Text = values[i_Lang + 2];
                            break;
                        }
                    }
                }
            }
            catch (System.Exception e)
            {
                // ファイルを開くのに失敗したとき
                MessageBox.Show(e.Message);
            }
        }

        public static void changeLang(string s_page, Button obj)
        {
            try
            {
                // csvファイルを開く
                using (var sr = new System.IO.StreamReader(LANG_FILE))
                {
                    // ストリームの末尾まで繰り返す
                    while (!sr.EndOfStream)
                    {
                        // ファイルから一行読み込む
                        var line = sr.ReadLine();
                        // 読み込んだ一行をカンマ毎に分けて配列に格納する
                        string[] values = line.Split(',');
                        // 出力する
                        if (s_page == values[0] &&
                            obj.Name == values[1])
                        {
                            obj.Text = values[i_Lang + 2];
                            break;
                        }
                    }
                }
            }
            catch (System.Exception e)
            {
                // ファイルを開くのに失敗したとき
                MessageBox.Show(e.Message);
            }
        }

        public static void changeLang(string s_page, Label obj)
        {
            try
            {
                // csvファイルを開く
                using (var sr = new System.IO.StreamReader(LANG_FILE))
                {
                    // ストリームの末尾まで繰り返す
                    while (!sr.EndOfStream)
                    {
                        // ファイルから一行読み込む
                        var line = sr.ReadLine();
                        // 読み込んだ一行をカンマ毎に分けて配列に格納する
                        string[] values = line.Split(',');
                        // 出力する
                        if (s_page == values[0] &&
                            obj.Name == values[1])
                        {
                            obj.Text = values[i_Lang + 2];
                            break;
                        }
                    }
                }
            }
            catch (System.Exception e)
            {
                // ファイルを開くのに失敗したとき
                MessageBox.Show(e.Message);
            }
        }

        public static void changeLang(string s_page, RadioButton obj)
        {
            try
            {
                // csvファイルを開く
                using (var sr = new System.IO.StreamReader(LANG_FILE))
                {
                    // ストリームの末尾まで繰り返す
                    while (!sr.EndOfStream)
                    {
                        // ファイルから一行読み込む
                        var line = sr.ReadLine();
                        // 読み込んだ一行をカンマ毎に分けて配列に格納する
                        string[] values = line.Split(',');
                        // 出力する
                        if (s_page == values[0] &&
                            obj.Name == values[1])
                        {
                            obj.Text = values[i_Lang + 2];
                            break;
                        }
                    }
                }
            }
            catch (System.Exception e)
            {
                // ファイルを開くのに失敗したとき
                MessageBox.Show(e.Message);
            }
        }

        public static void changeLang(string s_page, CheckBox obj)
        {
            try
            {
                // csvファイルを開く
                using (var sr = new System.IO.StreamReader(LANG_FILE))
                {
                    // ストリームの末尾まで繰り返す
                    while (!sr.EndOfStream)
                    {
                        // ファイルから一行読み込む
                        var line = sr.ReadLine();
                        // 読み込んだ一行をカンマ毎に分けて配列に格納する
                        string[] values = line.Split(',');
                        // 出力する
                        if (s_page == values[0] &&
                            obj.Name == values[1])
                        {
                            obj.Text = values[i_Lang + 2];
                            break;
                        }
                    }
                }
            }
            catch (System.Exception e)
            {
                // ファイルを開くのに失敗したとき
                MessageBox.Show(e.Message);
            }
        }

        public static void changeLang(string s_page, Label obj, int i_WorkMode)
        {
            try
            {
                // csvファイルを開く
                using (var sr = new System.IO.StreamReader(LANG_FILE))
                {
                    // ストリームの末尾まで繰り返す
                    while (!sr.EndOfStream)
                    {
                        // ファイルから一行読み込む
                        var line = sr.ReadLine();
                        // 読み込んだ一行をカンマ毎に分けて配列に格納する
                        string[] values = line.Split(',');
                        // 出力する
                        if (s_page == values[0] &&
                            obj.Name + i_WorkMode.ToString() == values[1])
                        {
                            obj.Text = values[i_Lang + 2];
                            break;
                        }
                    }
                }
            }
            catch (System.Exception e)
            {
                // ファイルを開くのに失敗したとき
                MessageBox.Show(e.Message);
            }
        }

        public static void changeLang(string s_page, TextBox obj)
        {
            try
            {
                // csvファイルを開く
                using (var sr = new System.IO.StreamReader(LANG_FILE))
                {
                    // ストリームの末尾まで繰り返す
                    while (!sr.EndOfStream)
                    {
                        // ファイルから一行読み込む
                        var line = sr.ReadLine();
                        // 読み込んだ一行をカンマ毎に分けて配列に格納する
                        string[] values = line.Split(',');
                        // 出力する
                        if (s_page == values[0] &&
                            obj.Name == values[1])
                        {
                            obj.Text = values[i_Lang + 2];
                            break;
                        }
                    }
                }
            }
            catch (System.Exception e)
            {
                // ファイルを開くのに失敗したとき
                MessageBox.Show(e.Message);
            }
        }


        /********************************************************************************
         * 機能 ：サーバと接続します（キーエンス手順）
         * API  ：btCommConnect
        ********************************************************************************/
        public static Int32 KPConnect()
        {
            Int32 ret = 0;
            try
            {
                // タイムアウト5秒、キャンセル＝Cキー
                ret = KProtocol.btCommConnect(5, LibDef.BT_VK_CLR);
                return ret;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return LibDef.BT_ERR;
            }
        }

        /********************************************************************************
         * 機能 ：サーバとの接続を解除します（キーエンス手順）
         * API  ：btCommDisconnect
        ********************************************************************************/
        public static void KPDisconnect()
        {
            Int32 ret = 0;
            String disp = "";

            try
            {
                // タイムアウト5秒、キャンセル＝Cキー
                ret = KProtocol.btCommDisconnect(5, LibDef.BT_VK_CLR);
                if (ret != LibDef.BT_OK)
                {
                    disp = "btCommDisconnect error ret[" + ret + "]";
                    MessageBox.Show(disp, "エラー");
                    return;
                }
                //disp = "サーバとの接続を解除しました。\r\n";
                //MessageBox.Show(disp, "切断（キーエンス手順）");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /********************************************************************************
         * 機能 ：サーバへファイル送信します（キーエンス手順）
         * API  ：btCommPutFile
        ********************************************************************************/
        public static void KPSend()
        {
            Int32 ret = 0;
            String disp = "";
            bool overWrite = true;
            bool createFolder = true;

            try
            {
                string[] files = Directory.GetFiles(OUT_FOLDER);
                foreach (string s in files)
                {
                    string s_file = Path.GetFileName(s);

                    string romFile = OUT_FOLDER +
                                    s_file;

                    string ramFile = "RamDisk\\" +
                                    s_file;

                    //ローカルファイルの有無チェック
                    if (File.Exists(romFile))
                    {
                        File.Copy(romFile, ramFile, true);

                        //ファイルが存在する場合、アップロード実行

                        StringBuilder localFile = new StringBuilder(s);
                        StringBuilder remoteFile = new StringBuilder(s_file);

                        // タイムアウト5秒、キャンセル＝Cキー
                        ret = KProtocol.btCommPutFile(localFile, remoteFile, overWrite, createFolder, 5, LibDef.BT_VK_CLR);
                        if (ret != LibDef.BT_OK)
                        {
                            disp = "btCommPutFile error ret[" + ret + "]";
                            MessageBox.Show(disp, "エラー");
                            File.Delete(ramFile);
                            return;
                        }
                        //disp = "ファイルを送信しました。\r\n";
                        //MessageBox.Show(disp, "ファイル送信（キーエンス手順）");
                        
                        File.Delete(romFile);
                        File.Delete(ramFile);
                        System.Threading.Thread.Sleep(500);
                    }
                    else
                    {   //ファイルが存在しない場合
                        MessageBox.Show("No have file." + romFile);
                        return;
                    }
                }
                if (0 != files.Length)
                {
                    MessageBox.Show(Com.changeMessage("SendLog"), "BKHandy Application");
                }
                else
                {
                    MessageBox.Show(Com.changeMessage("Nohave"), "BKHandy Application");
                }
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        /********************************************************************************
         * 機能 ：サーバからファイルを受信します（キーエンス手順）
         * API  ：btCommGetFile
        ********************************************************************************/
        public static void KPRecv()
        {
            Int32 ret = 0;
            String disp = "";
            StringBuilder localFile = new StringBuilder("");
            StringBuilder remoteFile = new StringBuilder("");
            string s_FilePath = "";

            try
            {
                string[] Files = { "TB_M_ITEM.csv", "TB_M_LOCATION.csv", "TB_M_UNIT.csv", "TB_M_USER.csv"
                                 ,"TB_M_REQUESTER.csv","TB_M_TESTER.csv"};//Tick 

                foreach (string s_TargetFile in Files)
                {
                    s_FilePath = IN_FOLDER + s_TargetFile;
                    localFile = new StringBuilder(s_FilePath);
                    remoteFile = new StringBuilder(s_TargetFile);

                    if (true == File.Exists(s_FilePath))
                    {
                        File.Delete(s_FilePath);
                    }

                    // タイムアウト5秒、キャンセル＝Cキー
                    ret = KProtocol.btCommGetFile(remoteFile, localFile, 5, LibDef.BT_VK_CLR);
                    if (ret != LibDef.BT_OK)
                    {
                        disp = "btCommGetFile error ret[" + ret + "]";
                        MessageBox.Show(disp, "エラー");
                        break;
                    }
                }

                if (ret == LibDef.BT_OK)
                {
                    MessageBox.Show(Com.changeMessage("UpdateMaster"), "BKHandy Application");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void KPSendReceive()
        {
            try
            {
                MessageBox.Show("おき台に置いてください");

                //砂時計表示
                Cursor.Current = Cursors.WaitCursor;

                if (LibDef.BT_OK == KPConnect())
                {
                    KPSend();

                    KPRecv();

                    KPDisconnect();
                }
                else
                {
                    MessageBox.Show("コネクトエラー！！");
                    MessageBox.Show("おき台に正しく置いてください");
                }
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                //砂時計をもとに戻す
                Cursor.Current = Cursors.Default;
            }
        }
    }
}