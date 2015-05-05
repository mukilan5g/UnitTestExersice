using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace FaxScheduler
{
    public class Fax:Exception
    {
        public bool SendFax(String PhoneNo, String FileName)
        {
            Regex Expression = new Regex(@"^([2-9]{1})([0-9]{2})-?[0-9]{3}-[0-9]{4}$");
            try
            {
                if (Expression.IsMatch(PhoneNo) && (PhoneNo.Substring(1, 2) != "11") && (PhoneNo.Substring(1, 1) != "9") && (PhoneNo.Substring(0, 2) != "37") && (PhoneNo.Substring(0, 2) != "96"))
                {
                    FileStream stream = File.OpenRead(FileName);
                    byte[] fileBytes = new byte[stream.Length];
                    stream.Read(fileBytes, 0, fileBytes.Length);
                    stream.Close();
                    return true;
                }
                else
                {
                    throw new FormatException();
                }
            }
            catch (FormatException e)
            {
                throw e;
            }
            catch (FileNotFoundException e)
            {
                throw e;
            }
            catch (ArgumentException e)
            {
                throw e;
            }
        }
    }
}
