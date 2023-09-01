using InflueriAutomation.Core;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InflueriAutomation.Pages.Influencers
{
    public class UploadProposalsPage : Initializer
    {
        private By GetInputChooseFile() => By.XPath("//form//input[@id='videoInput']");

        private By GetButtonUpload() => By.XPath("//label[text()='Upload']/../..");

        public UploadProposalsPage SelectAndUploadFile(String filePath) {
            IWebElement input = FindElementCustom(GetInputChooseFile());

            // Convert the local file path to a remote file path
            string remoteFilePath = "file://" + filePath.Replace("\\", "/");

            // Execute JavaScript to make the hidden div visible
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)GetWebDriver();
            jsExecutor.ExecuteScript("document.getElementById('videoInput').removeAttribute('hidden');");

            SetValue(filePath, GetInputChooseFile());
            ClickByJavaScript(GetButtonUpload());

            return this;
        }

    }
}
