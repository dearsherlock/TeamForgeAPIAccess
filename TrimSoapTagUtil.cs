using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFClient
{
    public class TrimSoapTagUtil
    {
        public static string TrimSoapTagUtilFunc(string data) {
            data=data.Replace(" xmlns:ns2=\"http://schema.open.collab.net/sfee50/soap60/type\"","");            
            data=data.Replace(" xmlns:soapenc=\"http://schemas.xmlsoap.org/soap/encoding/\"","");
            data = data.Replace(" soapenv:encodingStyle=\"http://schemas.xmlsoap.org/soap/encoding/\"", "");

            data = data.Replace(" xmlns:ns3=\"http://schema.open.collab.net/sfee50/soap60/type\"", "");
            
            data=data.Replace(" xsi:type=\"ns4:ProjectSoapRow\"","");
            data=data.Replace(" xmlns:ns4=\"http://schema.open.collab.net/sfee50/soap60/type\"","");


            data = data.Replace(" xsi:type=\"ns3:ProjectSoapRow\"", "");
            data = data.Replace(" xsi:type=\"ns2:ProjectSoapList\"", "");
            data = data.Replace("soapenc:root=\"0\"", "");
            data = data.Replace(" xsi:type=\"xsd:boolean\"", "");
            data = data.Replace(" xsi:nil=\"true\"", "");
            data = data.Replace(" xsi:type=\"xsd:string\"", "");
            data = data.Replace(" xsi:type=\"xsd:dateTime\"", "");

            
            return data;
        
        }
    }
}
