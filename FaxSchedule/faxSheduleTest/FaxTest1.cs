using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FaxScheduler;
using System.IO;
using System.Diagnostics;


namespace FaxSheduleTest
{
    [TestClass]
    public class FaxTest1
    {
        /// <summary>
        /// <!--Send fax to the valid phone number and check whether it return true-->
        /// </summary>
        [TestMethod]
        public void ValidFormatCheck()
        {
            Fax c = new Fax();
            Assert.IsTrue(c.SendFax("221-190-2346", @"C:\Users\mukilan\Desktop\new1.txt"));
        }

        /// <summary>
        /// <!--Send fax to the invalid phone_number that contains the format(x11-nnn-nnnn)  and check whether it throws the format Exception-->
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void InvalidAreaCodeCheck_1()
        {
            Fax c = new Fax();
            c.SendFax("211-190-2346", @"C:\Users\mukilan\Desktop\new1.txt");
        }

        /// <summary>
        /// <!--Send fax to the invalid phone_number that contains the format(x9n-nnn-nnnn)  and check whether it throws the format Exception-->
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void InvalidAreaCodeCheck_2()
        {
            Fax c = new Fax();
            c.SendFax("291-190-2346", @"C:\Users\mukilan\Desktop\new1.txt");
        }

        /// <summary>
        /// <!--Send fax to the invalid phone_number that contains the format(37n-nnn-nnnn)  and check whether it throws the format Exception-->
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void InvalidAreaCodeCheck_3()
        {
            Fax c = new Fax();
            c.SendFax("371-190-2346", @"C:\Users\mukilan\Desktop\new1.txt");
        }

        /// <summary>
        /// <!--Send fax to the invalid phone_number that contains the format(96x-nnn-nnnn)  and check whether it throws the format Exception-->
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void InvalidAreaCodeCheck_4()
        {
            Fax c = new Fax();
            c.SendFax("961-190-2346", @"C:\Users\mukilan\Desktop\new1.txt");
        }

        /// <summary>
        /// <!--Send fax to the invalid phone_number that contains the format(xnn-nnn-nnnnn)  and check whether it throws the format Exception-->
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TooManyDigitsCheck()
        {
            Fax c = new Fax();
            //
            c.SendFax("211-190-23467", @"C:\Users\mukilan\Desktop\new1.txt");
        }

        /// <summary>
        /// <!--Send fax to the invalid phone_number that contains the format(xnn-nnn-nnn)  and check whether it throws the format Exception-->
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void NotEnoughDigitCheck()
        {
            Fax c = new Fax();
            c.SendFax("211-190-234", @"C:\Users\mukilan\Desktop\new1.txt");
        }

        /// <summary>
        /// <!--Send fax to the invalid phone_number that contains the format(x n-nnn-nnn)  and check whether it throws the format Exception-->
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void IllegalCharactersCheck_1()
        {
            Fax c = new Fax();
            c.SendFax("2 1-190-234", @"C:\Users\mukilan\Desktop\new1.txt");
        }

        /// <summary>
        /// <!--Send fax to the invalid phone_number that contains the format(x<char>n-nnn-nnn)  and check whether it throws the format Exception-->
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void IllegalCharactersCheck_2()
        {
            Fax c = new Fax();
            c.SendFax("2X1-190-234", @"C:\Users\mukilan\Desktop\new1.txt");
        }

        /// <summary>
        /// <!--Send fax to the invalid phone_number that contains the format(xnn-nnnnnnn)  and check whether it throws the format Exception-->
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void MissingDashesCheck()
        {
            Fax c = new Fax();
            //
            c.SendFax("211-1902345", @"C:\Users\mukilan\Desktop\new1.txt");
        }

        /// <summary>
        /// <!--Send fax to the invalid phone_number that contains the format(xnn-nnn-nnn-n)  and check whether it throws the format Exception-->
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void MultipleDashesCheck()
        {
            Fax c = new Fax();
            c.SendFax("211-190-234-5", @"C:\Users\mukilan\Desktop\new1.txt");
        }

        /// <summary>
        /// <!--Send fax without phone_No and check whether it throws the format Exception-->
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void NullValueCheck()
        {
            Fax c = new Fax();
            c.SendFax(" ", @"C:\Users\mukilan\Desktop\new.txt");
        }

        /// <summary>
        /// <!--send fax with existing file and check it return true-->
        /// </summary>
        [TestMethod]
        public void FileExistsCheck()
        {
            Fax c = new Fax();
            Assert.IsTrue(c.SendFax("224-190-2346", @"C:\Users\mukilan\Desktop\new1.txt"));
        }

        /// <summary>
        /// <!--send fax with file that does not exists  and check it throws FileNotFoundException-->
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void FileNotFoundCheck()
        {
            Fax c = new Fax();
            c.SendFax("201-190-2346", @"C:\Users\mukilan\Desktop\new.txt");
        }

        /// <summary>
        /// <!--send fax without file and check it throws ArgumentException-->
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NullFilenameCheck()
        {
            Fax c = new Fax();
            c.SendFax("201-190-2346","");
        }

        /// <summary>
        /// <!--send fax with invalid extension of that file and check it throws FileNotFoundException-->
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void InvalidExtensionCheck()
        {
            Fax c = new Fax();
            c.SendFax("201-190-2346", @"C:\Users\mukilan\Desktop\new1.text");
        }
    }
}
