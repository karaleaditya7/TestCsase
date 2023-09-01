using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InflueriAutomation.Core;
using MongoDB.Driver;

namespace InflueriAutomation.Utils
{
    public class FileUtils
    {

        public static String GetProjectRootPath()
        {
            var enviroment = Environment.CurrentDirectory;
            return Directory.GetParent(enviroment).Parent.FullName;
        }

        public void CreateDir(String path)
        {
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
            }
            catch (Exception ex)
            {
                BaseTestPage.Logger.Error(ex.Message);
            }
        }

        public void DeleteDir(String path)
        {
            try
            {
                if (Directory.Exists(path))
                {
                    Directory.Delete(path);
                } 
                else
                {
                    BaseTestPage.Logger.Warn("Directory does not exists");
                }
            }
            catch (Exception ex)
            {
                BaseTestPage.Logger.Error(ex.Message);
            }
        }

        public String[] GetFilesFromDir(String path)
        {
            try
            {
                if (Directory.Exists(path))
                {
                    return Directory.GetFiles(path);
                }
                else
                {
                    BaseTestPage.Logger.Warn("Directory does not exists");
                    return null;
                }
            }
            catch (Exception ex)
            {
                BaseTestPage.Logger.Error(ex.Message);
                return null;
            }
        }

        public void DeleteFilesFromDir(String dirPath)
        {
            try
            {
                if (Directory.Exists(dirPath))
                {
                    String[] files = Directory.GetFiles(dirPath);
                    foreach(String file in files)
                    {
                        File.Delete(file);
                    }
                }
                else
                {
                    BaseTestPage.Logger.Warn("Directory does not exists");
                }
            }
            catch (Exception ex)
            {
                BaseTestPage.Logger.Error(ex.Message);
            }
        }



    }
}
