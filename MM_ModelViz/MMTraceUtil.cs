using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM_ModelViz
{
    class MMTraceUtil
    {
        /// <summary>
        /// Creates a name for a log file which includes a name but also a time stamp
        /// </summary>
        /// <param name="name">the name for the log</param>
        /// <returns></returns>
        public static String LogFileName(String name)
        {
            DateTime dt = DateTime.Now;
            String logFileName = Environment.GetEnvironmentVariable("TEMP") +
                                 "\\" + name + dt.ToString("yyyyMMdd HHmm") + ".log";
            return logFileName;
        }

        /// <summary>
        /// Aligns the log file path with another path and updates the user interface
        /// </summary>
        /// <param name="logAtFilePath">alignment is only done if this is checked</param>
        /// <param name="inputFileName">the alternative path</param>
        /// <param name="selectedLogFileName">the log file path to align</param>
        public static void UpdateLogFileName(System.Windows.Forms.CheckBox logAtFilePath,
                                             System.Windows.Forms.TextBox inputFileName,
                                             System.Windows.Forms.TextBox selectedLogFileName)
        {
            if (logAtFilePath.Checked && !String.IsNullOrEmpty(inputFileName.Text))
            {
                int pos = inputFileName.Text.LastIndexOf('\\');
                if (pos > 0)
                {
                    String path = inputFileName.Text.Substring(0, pos);
                    pos = selectedLogFileName.Text.LastIndexOf('\\');
                    if (pos >= 0)
                    {
                        String name = selectedLogFileName.Text.Remove(0, pos);
                        selectedLogFileName.Text = path + name;
                    }
                }

            }
        }

    }
}
