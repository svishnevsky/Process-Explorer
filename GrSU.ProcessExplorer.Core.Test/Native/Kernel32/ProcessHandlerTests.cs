﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GrSU.ProcessExplorer.Core.Native.Kernel32;

namespace GrSU.ProcessExplorer.Core.Test.Native.Kernel32
{
    /// <summary>
    /// Summary description for ProcessHandlerTests
    /// </summary>
    [TestClass]
    public class ProcessHandlerTests
    {
        public ProcessHandlerTests()
        {
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void GetProcessesSmoke()
        {
            var processHandler = new ProcessHandler();
            var processList = processHandler.GetProcesses();
            Assert.IsTrue(processList.Count > 0);
        }

        [TestMethod]
        public void TerminateProcess()
        {
            var processHandler = new ProcessHandler();
            var processList = processHandler.GetProcesses();
            Assert.IsTrue(processList.Count > 0);
            if (!processList.Any(item => item.szExeFile.Contains("notepad")))
            {
                return;
            }
            
            var nodepadProcess = processList.FirstOrDefault(item => item.szExeFile.Contains("notepad"));
            processHandler.KillProcess(nodepadProcess.th32ProcessID);
        }
    }
}
