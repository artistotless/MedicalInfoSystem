using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalTrader.helpers
{
    class ZipWrapper
    {


        public async Task<string> UnzipAsync(string ExistingZipFile, string TargetDirectory)
        {
            return await Task.Run(() => Unzip(ExistingZipFile, TargetDirectory));
        }


        private string Unzip(string ExistingZipFile, string TargetDirectory)
        {
            BackGroundEvents.ShowLoading("Распаковка архива...");
            string fileName = "";
            using (ZipFile zip = ZipFile.Read(ExistingZipFile))
            {
                foreach (ZipEntry e in zip)
                {
                    e.Extract(TargetDirectory);
                    fileName = e.FileName;

                }
                BackGroundEvents.HideLoading();
                return fileName;
            }

        }


    }
}
