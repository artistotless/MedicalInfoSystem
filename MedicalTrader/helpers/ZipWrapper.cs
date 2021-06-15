using Ionic.Zip;

using System.IO;

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
                    if (File.Exists(TargetDirectory + e.FileName))
                    {
                        File.Delete(TargetDirectory + e.FileName);
                    }
                    e.Extract(TargetDirectory);
                    fileName = e.FileName;

                }
                BackGroundEvents.HideLoading();
                return TargetDirectory + fileName;
            }

        }


    }
}
