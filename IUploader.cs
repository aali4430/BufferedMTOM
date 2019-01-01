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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IUploader
    {

        //[OperationContract]
        //string GetData(int value);

        //[OperationContract]
        //Uploader GetDataUsingDataContract(Uploader composite);
        [OperationContract]
        void Upload(RemoteFileInfo objRemoteFile);
        // TODO: Add your service operations here
    }
    [MessageContract]
    public class RemoteFileInfo
    {
        [MessageHeader]
        public string FileName { get; set; }

        [MessageBodyMember]
        public byte[] Data { get; set; }
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    //Following code for streaaming transfer
    //[MessageContract]
    //public class RemoteFileInfo
    //{
    //    [MessageHeader]
    //    public string FileName { get; set; }

    //    [MessageBodyMember]
    //    public Stream Data { get; set; }
    //}
}
