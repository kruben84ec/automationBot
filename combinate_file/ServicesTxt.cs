using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace combinate_file
{
    class ServicesTxt
    {
        public List<string> accountBoletinadas = new List<string>();
        public List<string> accountYobsidiam = new List<string>();


        public List<string> getDataFile(string pathReport,List<string> dataExcel)
        {
            String line;
            if (File.Exists(pathReport))
            {
                try
                {
                    //Pass the file path and file name to the StreamReader constructor
                    StreamReader sr = new StreamReader(pathReport);
                    //Read the first line of text
                    line = sr.ReadLine();
                    //Continue to read until you reach end of file
                    while (line != null)
                    {
                        //write the line to console window
                        dataExcel.Add(line);
                        //Read the next line
                        line = sr.ReadLine();
                    }
                    //close the file
                    sr.Close();

                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }


            }
            return dataExcel;
        }

        public void getDataToExcel(List<string> codeBrandList, String pathReport) {
            String pathReportCx91 = "";
            String pathReportYobsidim = "";
            String codeBrand = "";

            

            for (int codeBrandItem = 1; codeBrandItem < codeBrandList.Count; codeBrandItem++)
            {
                codeBrand = codeBrandList[codeBrandItem];
                pathReportCx91 = pathReport + @"\" + codeBrand + ".txt";
                pathReportYobsidim = pathReport + @"\" + codeBrand + "_yosidian.txt";

                this.accountBoletinadas = getDataFile(pathReportCx91, this.accountBoletinadas);
                this.accountYobsidiam = getDataFile(pathReportYobsidim, this.accountYobsidiam);


                if (File.Exists(pathReportCx91))
                {
                    File.Delete(pathReportCx91);
                }

                if (File.Exists(pathReportYobsidim))
                {
                    File.Delete(pathReportYobsidim);
                }
            }

        }
    }
}
