using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JabilTest;
using JabilTestCoreLibs;
using System.Runtime.InteropServices;
using System.Threading;
using NationalInstruments.LabVIEW.Refnums;
using Z_CANFD;
namespace JTS_ZLG_CAN
{
    public class ZCAN_OpenDevice : JabilTest.Test
    {
        public ZCAN_OpenDevice(ScriptVariableSpace varSpace, object OtherParameter) : base(varSpace, null)
        {
            //
            // Add constructor logic here.

            //
        }
        public override string Version { get { return "1.01.00"; } }
        public override TestResult Execute()
        {
            VariableSpace.UpdateStatusTextFromUpdateStatus("~~~~~~~~>" + this.Name + " Start");
            // Create the test result.
            //Create the test result.
            TestResult testResult = this.testResult;
            testResult.TestName = this.testResult.TestName;
            testResult.TestDescription = this.TestDescription;
            // 声明变量

            // Get the input arguments.
            uint device_type = uint.Parse(this.GetStringVariable("Argument0", "device_type"));
            uint device_index = uint.Parse(this.GetStringVariable("Argument1", "device_index"));
            //uint reserved = uint.Parse(this.GetStringVariable("Argument2", "reserved"));
            uint DEVICE_HANDLE = 0;
            NationalInstruments.LabVIEW.Interop.ErrorCluster return_result;
            return_result.code = 0;
            return_result.source = "";
            return_result.status = false;
            string Dev_SN = "";
            string Dev_info = "";
            //~~public static void ZCAN_OpenDevice(uint device_type, uint device_index, uint reserved)
            return_result=zlgcan.ZCAN_OpenDevice(device_type, device_index, out DEVICE_HANDLE,out Dev_info,out Dev_SN);
            
            VariableSpace.UpdateStatusTextFromUpdateStatus("DEVICE_HANDLE=" + DEVICE_HANDLE);
            VariableSpace.UpdateStatusTextFromUpdateStatus("DEVICE_info=" + Dev_info);

            ScriptVariable Value0 = new ScriptVariable("ReturnValue0", VariableType.Integer, DEVICE_HANDLE);
            ScriptVariable Value1 = new ScriptVariable("ReturnValue1", VariableType.String, Dev_SN);
            ScriptVariable Value2 = new ScriptVariable("ReturnValue2", VariableType.String, Dev_info);
            this.VariableSpace.setVariable(Value0);
            this.VariableSpace.setVariable(Value1);
            this.VariableSpace.setVariable(Value2);
            
            testResult.Status = TestStatus.Pass;
            VariableSpace.UpdateStatusTextFromUpdateStatus("~~~~~~~~>" + this.Name + " END");
            return testResult;
        }

    }       // Open the Can Hub
    public class ZCAN_Start_CAN : JabilTest.Test
    {
        public ZCAN_Start_CAN(ScriptVariableSpace varSpace, object OtherParameter) : base(varSpace, null)
        {
            //
            // Add constructor logic here.

            //
        }
        public override string Version { get { return "1.01.00"; } }
        public override TestResult Execute()
        {
            VariableSpace.UpdateStatusTextFromUpdateStatus("~~~~~~~~>" + this.Name + " Start");
            // Create the test result.
            //Create the test result.
            TestResult testResult = this.testResult;
            testResult.TestName = this.testResult.TestName;
            testResult.TestDescription = this.TestDescription;
            // 声明变量

            // Get the input arguments.
            uint can_index = (uint)this.GetIntegerVariable("Argument0", "can_index");
            uint device_hande = (uint)this.GetIntegerVariable("Argument1", "device_hande");
            uint resistanceEnable = (uint)this.GetIntegerVariable("Argument2", "resistanceEnable");
            uint dbitbaud = (uint)this.GetIntegerVariable("Argument3", "dbitbaud");
            uint abitbaud = (uint)this.GetIntegerVariable("Argument4", "abitbaud");
            //uint resistanceEnable = bool.Parse(this.GetStringVariable("Argument2", "reserved"));


            uint can_index_handle = 0;
            bool startcan_success = false;

            //public static void ZCAN_Start_CAN(uint can_index, uint device_hande, uint resistanceEnable, uint dbitbaud, uint abitbaud, out uint can_index_handle, out bool startcan_success)
            zlgcan.ZCAN_Start_CAN(can_index, device_hande, resistanceEnable, dbitbaud, abitbaud, out can_index_handle, out startcan_success);

           // VariableSpace.UpdateStatusTextFromUpdateStatus("can_index_handle=" + can_index_handle);
            //VariableSpace.UpdateStatusTextFromUpdateStatus("startcan_success=" + startcan_success);

            ScriptVariable Value0 = new ScriptVariable("ReturnValue0", VariableType.Integer, can_index_handle);
            ScriptVariable Value1 = new ScriptVariable("ReturnValue1", VariableType.Boolean, startcan_success);

            base.VariableSpace.setVariable(Value0);
            base.VariableSpace.setVariable(Value1);

            // tr_.Status = TestStatus.Pass;
            testResult.Status = TestStatus.Pass;
            VariableSpace.UpdateStatusTextFromUpdateStatus("~~~~~~~~>" + this.Name + " END");
            return testResult;
        }

    }        //ZCAN_Start_CAN
    public class ZCAN_SEND : JabilTest.Test
    {
        public ZCAN_SEND(ScriptVariableSpace varSpace, object OtherParameter) : base(varSpace, null)
        {
            //
            // Add constructor logic here.

            //
        }
        public override string Version { get { return "1.01.00"; } }
        public override TestResult Execute()
        {
            VariableSpace.UpdateStatusTextFromUpdateStatus("~~~~~~~~>" + this.Name + " Start");
            // Create the test result.
            //Create the test result.
            TestResult testResult = this.testResult;
            testResult.TestName = this.testResult.TestName;
            testResult.TestDescription = this.TestDescription;
            // 声明变量
            //frame_type FrameType;
            //agreement Snedagreement;

            // Get the input arguments.
            uint can_index_handle = (uint)this.GetIntegerVariable("Argument0", "can_index_handle");
            frame_type FrameType = (frame_type)this.GetIntegerVariable("Argument1", "frame_type");
            agreement SnedAgreement = (agreement)this.GetIntegerVariable("Argument2", "agreement");
            uint CANFD_SpeedUp = (uint)this.GetIntegerVariable("Argument3", "CANFD_SpeedUp");
            uint CANID = (uint)Convert.ToInt32(this.GetStringVariable("Argument4", "CANID"), 16);
            string SendData = this.GetStringVariable("Argument5", "data");
            //Convert.ToInt32("0xaa", 16)

            //uint can_index_handle = 0;
            NationalInstruments.LabVIEW.Interop.ErrorCluster return_result;
            return_result.code = 0;
            return_result.source = "";
            return_result.status = false;

            return_result = zlgcan.ZCAN_SEND(can_index_handle, FrameType, SnedAgreement, CANID, SendData, CANFD_SpeedUp);
            VariableSpace.UpdateStatusTextFromUpdateStatus("SendID=" + CANID);
            VariableSpace.UpdateStatusTextFromUpdateStatus("Send Data=" + SendData);
     
            if (return_result.status==true)
            {
                VariableSpace.UpdateStatusTextFromUpdateStatus("ErrorCode=" + return_result.code);
                VariableSpace.UpdateStatusTextFromUpdateStatus("Error=" + return_result.source);
               
             }
            ScriptVariable Value0 = new ScriptVariable("ReturnValue0", VariableType.Boolean, !return_result.status);
            base.VariableSpace.setVariable(Value0);
            VariableSpace.UpdateStatusTextFromUpdateStatus("~~~~~~~~>" + this.Name + " END");
            testResult.Status = TestStatus.Pass;
            return testResult;
        }
    }               //ZCAN_SEND
    public class ZCAN_ClearBuffer : JabilTest.Test
    {
        public ZCAN_ClearBuffer(ScriptVariableSpace varSpace, object OtherParameter) : base(varSpace, null)
        {
            //
            // Add constructor logic here.

            //
        }
        public override string Version { get { return "1.01.00"; } }
        public override TestResult Execute()
        {
            VariableSpace.UpdateStatusTextFromUpdateStatus("~~~~~~~~>" + this.Name + " Start");
            // Create the test result.
            //Create the test result
            TestResult testResult = this.testResult;
            testResult.TestName = this.testResult.TestName;
            testResult.TestDescription = this.TestDescription;
            // 声明变量

            // Get the input arguments.
            uint can_index_handle = (uint)this.GetIntegerVariable("Argument0", "can_index_handle");

            //uint can_index_handle = 0;
            //string CANFD_DATA = "";
            //string CAN_DATA = "";
            bool clearBuffer_success = false;

            //public static bool ZCAN_Receive_Data(uint can_CH_handle, out string cAN_DATA, out string cANFD_DATA, out bool status)

            zlgcan.ZCAN_ClearBuffer(can_index_handle, out clearBuffer_success);
            //VariableSpace.UpdateStatusTextFromUpdateStatus("CAN_DATA=" + CAN_DATA);
            //VariableSpace.UpdateStatusTextFromUpdateStatus("CANFD_DATA=" + CANFD_DATA);
            //VariableSpace.UpdateStatusTextFromUpdateStatus("status=" + status);

            ScriptVariable Value0 = new ScriptVariable("ReturnValue0", VariableType.Boolean, clearBuffer_success);

            base.VariableSpace.setVariable(Value0);
            //base.VariableSpace.setVariable(Value1);
            //base.VariableSpace.setVariable(Value2);

            // tr_.Status = TestStatus.Pass;
            testResult.Status = TestStatus.Pass;
            VariableSpace.UpdateStatusTextFromUpdateStatus("~~~~~~~~>" + this.Name + " END");
            return testResult;
        }

    }
    public class ZCAN_Setfilter : JabilTest.Test
    {
        public ZCAN_Setfilter(ScriptVariableSpace varSpace, object OtherParameter) : base(varSpace, null)
        {
            // Add constructor logic here.
        }
        public override string Version { get { return "1.01.00"; } }
        public override TestResult Execute()
        {
            VariableSpace.UpdateStatusTextFromUpdateStatus("~~~~~~~~>" + this.Name + " Start");
            // Create the test result.
            //Create the test result.
            TestResult testResult = this.testResult;
            testResult.TestName = this.testResult.TestName;
            testResult.TestDescription = this.TestDescription;
            // 声明变量

            // Get the input arguments.
            uint device_handle = (uint)this.GetIntegerVariable("Argument0", "device_handle");
            uint can_index = (uint)this.GetIntegerVariable("Argument1", "can_index");
            string filter_start = this.GetStringVariable("Argument2", "filter_start");
            string filter_end = this.GetStringVariable("Argument3", "filter_end");
             frame_type  FrameType = (frame_type)this.GetIntegerVariable("Argument4", "filter_mode"); //filter_mode
            VariableSpace.UpdateStatusTextFromUpdateStatus("Step INPUT Data:");
            VariableSpace.UpdateStatusTextFromUpdateStatus("device_handle=" + device_handle);
            VariableSpace.UpdateStatusTextFromUpdateStatus("can_index=" + can_index);
            VariableSpace.UpdateStatusTextFromUpdateStatus("filter_start=" + filter_start);
            VariableSpace.UpdateStatusTextFromUpdateStatus("filter_end=" + filter_end);
            VariableSpace.UpdateStatusTextFromUpdateStatus("filter_mode=" + FrameType);
            //uint can_index_handle = 0;
            //string CANFD_DATA = "";
            //string CAN_DATA = "";
            bool setfilterResult = false;
            //ZCAN_Setfilter(uint device_handle, uint can_index, string filter_end, uint filter_mode, out bool setfilterResult)
            zlgcan.ZCAN_Setfilter(device_handle, can_index, filter_end, FrameType, filter_start,out setfilterResult);
            //VariableSpace.UpdateStatusTextFromUpdateStatus("CAN_DATA=" + CAN_DATA);
            //VariableSpace.UpdateStatusTextFromUpdateStatus("CANFD_DATA=" + CANFD_DATA);
            //VariableSpace.UpdateStatusTextFromUpdateStatus("status=" + status);
            ScriptVariable Value0 = new ScriptVariable("ReturnValue0", VariableType.Boolean, setfilterResult);
            base.VariableSpace.setVariable(Value0);
            testResult.Status = TestStatus.Pass;
            VariableSpace.UpdateStatusTextFromUpdateStatus("~~~~~~~~>" + this.Name + " END");
            return testResult;
        }

    }
    public class ZCAN_ResetCAN : JabilTest.Test
    {
        public ZCAN_ResetCAN(ScriptVariableSpace varSpace, object OtherParameter) : base(varSpace, null)
        {
            //
            // Add constructor logic here.

            //
        }
        public override string Version { get { return "1.01.00"; } }
        public override TestResult Execute()
        {
            VariableSpace.UpdateStatusTextFromUpdateStatus("~~~~~~~~>" + this.Name + " Start");
            TestResult testResult = this.testResult;
            testResult.TestName = this.testResult.TestName;
            testResult.TestDescription = this.TestDescription;
            // 声明变量

            // Get the input arguments.
            uint can_index_handle = (uint)this.GetIntegerVariable("Argument0", "can_index_handle");

            //uint can_index_handle = 0;
            //string CANFD_DATA = "";
            //string CAN_DATA = "";
            bool reset_success = false;

            //public static bool ZCAN_Receive_Data(uint can_CH_handle, out string cAN_DATA, out string cANFD_DATA, out bool status)

            zlgcan.ZCAN_ResetCAN(can_index_handle, out reset_success);
            VariableSpace.UpdateStatusTextFromUpdateStatus("reset_success=" + reset_success);
            //VariableSpace.UpdateStatusTextFromUpdateStatus("CANFD_DATA=" + CANFD_DATA);
            //VariableSpace.UpdateStatusTextFromUpdateStatus("status=" + status);

            //ScriptVariable Value0 = new ScriptVariable("ReturnValue0", VariableType.Boolean, clearBuffer_success);

            //base.VariableSpace.setVariable(Value0);
            //base.VariableSpace.setVariable(Value1);
            //base.VariableSpace.setVariable(Value2);
            testResult.Status = TestStatus.Pass;
            VariableSpace.UpdateStatusTextFromUpdateStatus("~~~~~~~~>" + this.Name + " END");
            return testResult;
        }

    }
    public class ZCAN_CloseDevice : JabilTest.Test
    {
        public ZCAN_CloseDevice(ScriptVariableSpace varSpace, object OtherParameter) : base(varSpace, null)
        {
            //
            // Add constructor logic here.

            //
        }
        public override string Version { get { return "1.01.00"; } }

        public override TestResult Execute()
        {
            VariableSpace.UpdateStatusTextFromUpdateStatus("~~~~~~~~>" + this.Name + " Start");
            // Create the test result.
            //Create the test result.
            TestResult testResult = this.testResult;
            testResult.TestName = this.testResult.TestName;
            testResult.TestDescription = this.TestDescription;
            // 声明变量

            // Get the input arguments.
            uint DEVICE_HANDLE = (uint)(this.GetIntegerVariable("Argument0", "DEVICE_HANDLE"));
            bool close_result = false;
            //~~public static void ZCAN_OpenDevice(uint device_type, uint device_index, uint reserved, out uint dEVICE_HANDLE)
            zlgcan.ZCAN_CloseDevice(DEVICE_HANDLE,out close_result);
            //VariableSpace.UpdateStatusTextFromUpdateStatus("inStr=" + DEVICE_HANDLE);
            ScriptVariable Value0 = new ScriptVariable("ReturnValue0", VariableType.Boolean, close_result);
            base.VariableSpace.setVariable(Value0);
            VariableSpace.UpdateStatusTextFromUpdateStatus(close_result.ToString());
            VariableSpace.UpdateStatusTextFromUpdateStatus("~~~~~~~~>" + this.Name + " END");
            // tr_.Status = TestStatus.Pass;
            testResult.Status = TestStatus.Pass;
            return testResult;
        }

    }       // 关闭CAN
    public class ZCAN_Send_Receive : JabilTest.Test
    {
        public ZCAN_Send_Receive(ScriptVariableSpace varSpace, object OtherParameter) : base(varSpace, null)
        {
            // Add constructor logic here.
        }
        public override string Version { get { return "1.01.00"; } }
        public override TestResult Execute()
        {
            VariableSpace.UpdateStatusTextFromUpdateStatus("~~~~~~~~>" + this.Name + " Start");
            // Create the test result.
            //Create the test result.
            TestResult testResult = this.testResult;
            testResult.TestName = this.testResult.TestName;
            testResult.TestDescription = this.TestDescription;
            // 声明变量
            // Get the input arguments.
            uint can_index_handle = (uint)this.GetIntegerVariable("Argument0", "can_index_handle");
            frame_type Frametype = (frame_type)this.GetIntegerVariable("Argument1", "frame_type");
            agreement agreement = (agreement)this.GetIntegerVariable("Argument2", "agreement");
            uint CANFD_SpeedUp = (uint)this.GetIntegerVariable("Argument3", "CANFD_SpeedUp");
            uint CANID = (uint)Convert.ToInt32(this.GetStringVariable("Argument4", "CANID"), 16);
            string SendData = this.GetStringVariable("Argument5", "data");
            uint ms_wait = (uint)this.GetIntegerVariable("Argument6", "ms_wait");
            //Convert.ToInt32("0xaa", 16)
            //uint can_index_handle = 0;
            uint receive_Num = 0;
            string receive_Data = "";

            NationalInstruments.LabVIEW.Interop.ErrorCluster return_result;
            return_result.code = 0;
            return_result.source = "";
            return_result.status = false;

            return_result = zlgcan.ZCAN_Send_Receive(can_index_handle, Frametype, agreement, CANFD_SpeedUp,  CANID, ms_wait, SendData, out receive_Num,out receive_Data);
            VariableSpace.UpdateStatusTextFromUpdateStatus("SendID=" + CANID.ToString("x"));
            VariableSpace.UpdateStatusTextFromUpdateStatus("Send Data=" + SendData);
            VariableSpace.UpdateStatusTextFromUpdateStatus("receive_Data=" + receive_Data);
            VariableSpace.UpdateStatusTextFromUpdateStatus("receive_Num=" + receive_Num);
  
            ScriptVariable Value0 = new ScriptVariable("ReturnValue0", VariableType.Boolean, !return_result.status);  //返回是否右错误，没错误为true 和labview 相反
            ScriptVariable Value1 = new ScriptVariable("ReturnValue1", VariableType.String, receive_Data);
            ScriptVariable Value2 = new ScriptVariable("ReturnValue2", VariableType.String, receive_Num);
            base.VariableSpace.setVariable(Value0);
            base.VariableSpace.setVariable(Value1);
            base.VariableSpace.setVariable(Value2);

            testResult.Status = TestStatus.Pass;
            VariableSpace.UpdateStatusTextFromUpdateStatus("~~~~~~~~>" + this.Name + " END");
            return testResult;
        }

    }
    public class ZCAN_ReceiveByType : JabilTest.Test
    {
        public ZCAN_ReceiveByType(ScriptVariableSpace varSpace, object OtherParameter) : base(varSpace, null)
        {
            // Add constructor logic here.
        }
        public override string Version { get { return "1.01.00"; } }
        public override TestResult Execute()
        {
            //Create the test result.
            TestResult testResult = this.testResult;
            testResult.TestName = this.testResult.TestName;
            testResult.TestDescription = this.TestDescription;
            VariableSpace.UpdateStatusTextFromUpdateStatus("~~~~~~~~>" + this.Name + " Start");
            // 声明变量
            // Get the input arguments.
            uint can_index_handle = (uint)this.GetIntegerVariable("Argument0", "can_index_handle");
            uint agreement = (uint)this.GetIntegerVariable("Argument1", "agreement");
            //string data = this.GetStringVariable("Argument2", "data");
            NationalInstruments.LabVIEW.Interop.ErrorCluster return_result;
            return_result.code = 0;
            return_result.source = "";
            return_result.status = false;
            string data = "";
            uint receive_Num = 0;
            try
            {
                return_result = zlgcan.ZCAN_ReceiveByType(can_index_handle, agreement, out data, out receive_Num);
                if (return_result.status == false)
                {
                    testResult.Status = TestStatus.Pass;
                }
                else
                {
                    testResult.Status = TestStatus.Fail;
                    VariableSpace.UpdateStatusTextFromUpdateStatus(this.Name + "Error'" + return_result.Source);
                    VariableSpace.UpdateStatusTextFromUpdateStatus(this.Name + "ErrorCode'" + return_result.code);
                }
                VariableSpace.UpdateStatusTextFromUpdateStatus("CAN_data=" + data);
                ScriptVariable Value0 = new ScriptVariable("ReturnValue0", VariableType.String, data);
                base.VariableSpace.setVariable(Value0);
            }
            catch(Exception e)
            {
                base.FailTest(e.Message);
            }
            VariableSpace.UpdateStatusTextFromUpdateStatus("~~~~~~~~>" + this.Name + " END");
            return testResult;
        }
    } 
    public class ZCAN_GetDeviceInfo : JabilTest.Test
    {
        public ZCAN_GetDeviceInfo(ScriptVariableSpace varSpace, object OtherParameter) : base(varSpace, null)
        {
            // Add constructor logic here.
        }
        public override string Version { get { return "1.01.00"; } }
        public override TestResult Execute()
        {
            //Create the test result.
            TestResult testResult = this.testResult;
            testResult.TestName = this.testResult.TestName;
            testResult.TestDescription = this.TestDescription;
            // 声明变量
            // Get the input arguments.
            uint DEVICE_HANDLE = (uint)this.GetIntegerVariable("Argument0", "DEVICE_HANDLE");
            //uint agreement = (uint)this.GetIntegerVariable("Argument1", "agreement");
            //string data = this.GetStringVariable("Argument2", "data");
            VariableSpace.UpdateStatusTextFromUpdateStatus("~~~~~~~~>" + this.Name + " Start");
            NationalInstruments.LabVIEW.Interop.ErrorCluster return_result;
            return_result.code = 0;
            return_result.source = "";
            return_result.status = false;
            string DEVICE_INFO = "";
            string _serialNumber = "";
            //uint receive_Num = 0;
            //public static NationalInstruments.LabVIEW.Interop.ErrorCluster ZCAN_GetDeviceInfo(uint dEVICE_HANDLE, out string dEVICE_INFO, out string serialNumber)
            return_result = zlgcan.ZCAN_GetDeviceInfo(DEVICE_HANDLE, out DEVICE_INFO, out _serialNumber);
    
            VariableSpace.UpdateStatusTextFromUpdateStatus(this.Name + "Errorinfo=" + return_result.Source);
            VariableSpace.UpdateStatusTextFromUpdateStatus(this.Name + "ErrorCode=" + return_result.code);
            VariableSpace.UpdateStatusTextFromUpdateStatus("DEVICE_INFO=" + DEVICE_INFO);
            VariableSpace.UpdateStatusTextFromUpdateStatus("serialNumber=" + _serialNumber);
            VariableSpace.UpdateStatusTextFromUpdateStatus("~~~~~~~~>" + this.Name + " END");
            ScriptVariable Value0 = new ScriptVariable("ReturnValue0", VariableType.String, _serialNumber);
            base.VariableSpace.setVariable(Value0);
            testResult.Status = TestStatus.Pass;
            return testResult;
        }
    }



}
