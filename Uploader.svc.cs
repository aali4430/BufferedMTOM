using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.IO;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Uploader : IUploader
    {
        public void Upload(RemoteFileInfo objRemoteFile)
        {

            string filePath = @"C:\NewFile\" + objRemoteFile.FileName;
            string filePath2 = @"C:\NewFile\log.txt";
            int counter = 0;
            List<string> str = new List<string>();
            Stream stream = new MemoryStream(objRemoteFile.Data);
            using (stream) // data is the Stream value.
            {
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    using (FileStream fs = new FileStream(filePath, FileMode.Append))
                    {
                        using (BinaryWriter writer = new BinaryWriter(fs))
                        {
                                
                                byte[] buffer = reader.ReadBytes(4096);
                                writer.Write(buffer);
                        }
                    }
                }
            }
            str.Add(counter.ToString());
            File.AppendAllLines(filePath2, str);
            //filewriter.WriteLine(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")+"---Counter="+counter.ToString());
        }
        [Obsolete]
        public void Upload2(RemoteFileInfo objRemoteFile)
        {
           
            string filePath = @"C:\NewFile\"+objRemoteFile.FileName;
            string filePath2 = @"C:\NewFile\log.txt";
            int counter = 0;
            List<string> str = new List<string>();
            Stream stream = new MemoryStream(objRemoteFile.Data);
            using (stream) // data is the Stream value.
            {
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    using (FileStream fs = new FileStream(filePath, FileMode.Create))
                    {
                        using (BinaryWriter writer = new BinaryWriter(fs))
                        {
                            byte[] buffer;
                            do
                            {
                                
                                str.Add(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff"));
                                buffer = reader.ReadBytes(4096);
                                writer.Write(buffer);
                                counter += 1;
                            } while (buffer.Length > 0);
                        }
                    }
                }
            }
            str.Add(counter.ToString());
            File.AppendAllLines(filePath2, str);
            //filewriter.WriteLine(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")+"---Counter="+counter.ToString());
        }
    }
}
