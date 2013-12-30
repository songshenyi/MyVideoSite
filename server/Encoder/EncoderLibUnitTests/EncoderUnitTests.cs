using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyVideoSite.Server.EncoderLib;
using Microsoft.Expression.Encoder;
using System.Reflection;

namespace MyVideoSite.Server.EncoderUnitTests
{
    [TestClass]
    public class EncoderLibUnitTests
    {
        [TestMethod]
        public void EncoderJobTest()
        {
            string inputFileName = @"test.mp4";
            string outputFolder = System.IO.Directory.GetCurrentDirectory() + "\\Output";
            Encoder encoderJob = new Encoder();
            MediaItem mediaItem = encoderJob.CreateMediaItem(inputFileName);
            string actualOutputFolder = encoderJob.CreateAndExcuteEncodeJob(mediaItem, outputFolder);
        }
    }
}
