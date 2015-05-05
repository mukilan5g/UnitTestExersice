using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VCR;
namespace VcrTest
{
    [TestClass]
    public class VcrTest1
    {
        AVTransport av = new AVTransport();
        [TestMethod]
        public void AtStart()
        {
            Assert.IsTrue(av.CurrentTimePosition()==00.00);
        }

        [TestMethod]
        public void CheckRewindExceedBOT()
        {
            av.Rewind(00.50);
            Assert.IsTrue(av.CurrentTimePosition() == 00.00);
        }

        [TestMethod]
        public void PositionAfterRewind()
        {
            av.FastForward(00.50);
            av.FastForward(00.50);
            av.FastForward(00.50);
            av.Rewind(00.50);
            av.Rewind(00.50);
            av.Rewind(00.50);
            Assert.IsTrue(av.CurrentTimePosition() == av.BOT);
        }

        [TestMethod]
        public void labelCheck()
        {
            //forwarding ...
            av.FastForward(00.50);
            av.FastForward(00.50);
            av.FastForward(00.50);
            av.FastForward(00.50);
            av.FastForward(00.50);
            //mariking the position
            //current position 5*(00.50)
            av.MarkTimePosition("mark1");
            //rewinding...
            av.Rewind(00.30);
            av.Rewind(00.30);
            av.Rewind(00.30);
            av.Rewind(00.30);
            //current position 5*(00.50)-4*(00.30)
            //mariking the position
            av.MarkTimePosition("mark2");
            Assert.IsTrue(av.CurrentTimePosition() == 01.30);
            //jumping to specific position....
            av.GotoMark("mark1");
            Assert.IsTrue(av.CurrentTimePosition() == 02.50);
        }        
    }
}
