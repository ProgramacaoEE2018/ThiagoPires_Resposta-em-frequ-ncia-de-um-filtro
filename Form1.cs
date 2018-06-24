using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Ivi.Visa.Interop;
using System.Runtime.InteropServices;
using System.Globalization;


namespace AppFiltro
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();

            bcaptr.Enabled = false;
            bclean.Enabled = false;
            
        }

        private static VisaComInstrument myScope;


        /*
       * Initialize the oscilloscope to a known state.
       * --------------------------------------------------------------
       */
        private static void Initialize()
        {
            string strResults;
            // Get and display the device's *IDN? string.
            strResults = myScope.DoQueryString("*IDN?");
            MessageBox.Show("*IDN? result is: " + strResults, "Inicialização do Osciloscópio");
            // Clear status and load the default setup.
            myScope.DoCommand("*CLS");
            myScope.DoCommand("*RST");

        }

        //Setups iniciais
        private static void Setup()
        {
            // Use auto-scale to automatically configure oscilloscope.
            myScope.DoCommand(":AUToscale");

            // Set trigger mode (EDGE, PULSe, PATTern, etc., and input source.
            myScope.DoCommand(":TRIGger:MODE EDGE");

            // Set EDGE trigger parameters.
            myScope.DoCommand(":TRIGger:EDGE:SOURCe CHANnel1");
            myScope.DoCommand(":TRIGger:EDGE:LEVel 1.0");
            myScope.DoCommand(":TRIGger:EDGE:SLOPe POSitive");

            // Save oscilloscope configuration.
            byte[] ResultsArray; // Results array.
            int nLength; // Number of bytes returned from instrument.
            string strPath;

            // Query and read setup string.
            ResultsArray = myScope.DoQueryIEEEBlock(":SYSTem:SETup?");
            nLength = ResultsArray.Length;

            // Write setup string to file.
            strPath = "c:\\scope\\config\\setup.stp";
            FileStream fStream = File.Open(strPath, FileMode.Create);
            fStream.Write(ResultsArray, 0, nLength);
            fStream.Close();

            // Change settings with individual commands:
            // Set vertical scale and offset.

            // Set horizontal scale and position.

            // Set the acquisition type (NORMal, PEAK, AVERage, or HRESolution
            myScope.DoCommand(":ACQuire:TYPE NORMal");

            // Or, configure by loading a previously saved setup.
            byte[] DataArray;
            int nBytesWritten;

            // Read setup string from file.
            strPath = "c:\\scope\\config\\setup.stp";
            DataArray = File.ReadAllBytes(strPath);
            nBytesWritten = DataArray.Length;

            // Restore setup string.
            myScope.DoCommandIEEEBlock(":SYSTem:SETup", DataArray);
            Console.WriteLine("Setup bytes restored: {0}", nBytesWritten);



        }

       
        //Configura o setup do gerador de funções
        private static void GerarOnda()
        {
            myScope.DoCommand(":WGEN:FUNCtion SINusoid");
            myScope.DoCommand(":WGEN:VOLTage:OFFSet 0.0");
            myScope.DoCommand(":WGEN:VOLTage 9.0");
            myScope.DoCommand(":WGEN:OUTPut 1");
        }

        // Configura a frequência do gerador 
        private static void SetFreq(int f)
        {

            myScope.DoCommand(":WGEN:FREQuency?" + f.ToString());

        }

        //Variável que indica se o osciloscópio está conectado

        //LIMITE MAX E MIN DE FREQ
        static int Fmax = 10000;
        static int Fmin = 1;

        //Vetores para gráfico
        private static double[] freq = new double[Fmax + 10];
        private static double[] Amp1 = new double[Fmax + 10];
        private static double[] Amp2 = new double[Fmax + 10];
        private static double[] phase = new double[Fmax + 10];
        private static double[] modulodb = new double[Fmax + 10];

        // Mede a amplitude das ondas de entrada e saída e a fase
        private static void CapturaDados()
        {

            GerarOnda();

            //Modo do indicador para medir voltagem
            myScope.DoCommand(":MARKer:MODE WAVeform");

            //Indica o Source de cada marker(Ch1 ou Ch2)
            myScope.DoCommand(":MARKer:X1Y1source CHANnel1");
            myScope.DoCommand(":MARKer:X2Y2source CHANnel2");

            //Loop para adquirir dados de amplitude e frequência
            int i;
            for (i = Fmin; i <= Fmax; i++)
            {
                SetFreq(i);
                freq[i] = i;
                Amp1[i] = myScope.DoQueryNumber("MARKer:Y1Position?");
                Amp2[i] = myScope.DoQueryNumber("MARKer:Y2Position?");

            }

            //Adquirir dados de fase
            //Configurãção para medir fase
            myScope.DoCommand(":MEASure: SOURce CHANnel1 ,CHANnel2");

            int j;
            for (j = Fmin; j <= Fmax; j++)
            {
                SetFreq(j);
                myScope.DoCommand(":MEASure:PHASe CHANnel1 ,CHANnel2");
                phase[j] = myScope.DoQueryNumber(":MEASure:PHASe? CHANnel1 ,CHANnel2");
            }



        }

        //Botão que inicia a conexão
        private void bconect_Click(object sender, EventArgs e)
        {
            try
            {
                myScope = new
                    VisaComInstrument("USB0::0x0957::0x17A2::MY54450144::0::INSTR"
                    );
                myScope.SetTimeoutSeconds(10);
                // Initialize - start from a known state.
                Initialize();
                bconect.Enabled = false;
                bcaptr.Enabled = true;
                bclean.Enabled = true;
            }
            catch (System.ApplicationException err)
            {
                MessageBox.Show("*** VISA COM Error : " + err.Message);
            }
            catch (System.SystemException err)
            {
                MessageBox.Show("*** System Error Message : " + err.Message);
            }
            catch (System.Exception err)
            {
                System.Diagnostics.Debug.Fail("Unexpected Error");
                MessageBox.Show("*** Unexpected Error : " + err.Message);
            }
            finally
            {
               
            }
        }

        //Botão que vai iniciar a captura
        private void bcaptr_Click(object sender, EventArgs e)
        {

                CapturaDados();

                //cálculo do módulo em dB e plot nos gráficos
                int k = Fmin;
                for (k = Fmin; k <= Fmax; k++)
                {

                    double razao = Math.Pow(Amp2[k] / Amp1[k], 2);
                    double modulo = Math.Pow(razao, 0.5);
                    modulodb[k] = 20 * Math.Log10(modulo);
                    grafmod.Series[0].Points.AddY(modulodb[k]);
                    graffase.Series[0].Points.AddY(phase[k]);
                }
         
        }



        //Botão que limpa o diagrama
        private void bclean_Click(object sender, EventArgs e)
        {     
                grafmod.Series.Clear();
                graffase.Series.Clear();
        }



    }


    class VisaComInstrument
    {
        private ResourceManager m_ResourceManager;
        private FormattedIO488 m_IoObject;
        private string m_strVisaAddress;
        // Constructor
        public VisaComInstrument(string strVisaAddress)
        {
            // Save VISA address in member variable.
            m_strVisaAddress = strVisaAddress;
            // Open the default VISA COM IO object.
            OpenIo();
            // Clear the interface.
            m_IoObject.IO.Clear();
        }
        public void DoCommand(string strCommand)
        {
            // Send the command.
            m_IoObject.WriteString(strCommand, true);
            // Check for inst errors.
            CheckInstrumentErrors(strCommand);
        }
        public void DoCommandIEEEBlock(string strCommand,
        byte[] DataArray)
        {
            // Send the command to the device.
            m_IoObject.WriteIEEEBlock(strCommand, DataArray, true);
            // Check for inst errors.
            CheckInstrumentErrors(strCommand);
        }
        public string DoQueryString(string strQuery)
        { // Send the query.
            m_IoObject.WriteString(strQuery, true);
            // Get the result string.
            string strResults;
            strResults = m_IoObject.ReadString();
            // Check for inst errors.
            CheckInstrumentErrors(strQuery);
            // Return results string.
            return strResults;
        }
        public double DoQueryNumber(string strQuery)
        {
            // Send the query.
            m_IoObject.WriteString(strQuery, true);
            // Get the result number.
            double fResult;
            fResult = (double)m_IoObject.ReadNumber(
            IEEEASCIIType.ASCIIType_R8, true);
            // Check for inst errors.
            CheckInstrumentErrors(strQuery);
            // Return result number.
            return fResult;
        }
        public double[] DoQueryNumbers(string strQuery)
        {
            // Send the query.
            m_IoObject.WriteString(strQuery, true);
            // Get the result numbers.
            double[] fResultsArray;
            fResultsArray = (double[])m_IoObject.ReadList(
            IEEEASCIIType.ASCIIType_R8, ",;");
            // Check for inst errors.
            CheckInstrumentErrors(strQuery);
            // Return result numbers.
            return fResultsArray;
        }
        public byte[] DoQueryIEEEBlock(string strQuery)
        {
            // Send the query.
            m_IoObject.WriteString(strQuery, true);
            // Get the results array.
            System.Threading.Thread.Sleep(2000); // Delay before reading.
            byte[] ResultsArray;
            ResultsArray = (byte[])m_IoObject.ReadIEEEBlock(
            IEEEBinaryType.BinaryType_UI1, false, true);
            // Check for inst errors.
            CheckInstrumentErrors(strQuery);
            // Return results array.
            return ResultsArray;
        }
        private void CheckInstrumentErrors(string strCommand)
        {
            // Check for instrument errors.
            string strInstrumentError;
            bool bFirstError = true;
            do // While not "0,No error".
            {
                m_IoObject.WriteString(":SYSTem:ERRor?", true);
                strInstrumentError = m_IoObject.ReadString();
                if (!strInstrumentError.ToString().StartsWith("+0,"))
                {
                    if (bFirstError)
                    {
                        Console.WriteLine("ERROR(s) for command '{0}': ",
                        strCommand);
                        bFirstError = false;
                    }
                    Console.Write(strInstrumentError);
                }
            } while (!strInstrumentError.ToString().StartsWith("+0,"));
        }
        private void OpenIo()
        {
            m_ResourceManager = new ResourceManager();
            m_IoObject = new FormattedIO488();
            // Open the default VISA COM IO object.
            try
            {
                m_IoObject.IO =
                (IMessage)m_ResourceManager.Open(m_strVisaAddress,
                AccessMode.NO_LOCK, 0, "");
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: {0}", e.Message);
            }
        }
        public void SetTimeoutSeconds(int nSeconds)
        {
            m_IoObject.IO.Timeout = nSeconds * 1000;
        }
        public void Close()
        {
            try
            {
                m_IoObject.IO.Close();
            }
            catch { }
            try
            {
                Marshal.ReleaseComObject(m_IoObject);
            }
            catch { }
            try
            {
                Marshal.ReleaseComObject(m_ResourceManager);
            }
            catch { }
        }
    }


}


