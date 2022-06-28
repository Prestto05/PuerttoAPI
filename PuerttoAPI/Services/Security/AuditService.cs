using Core.Puertto.DTOs.Security;
using PuerttoAPI.Interfaces;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;

namespace PuerttoAPI.Services.Security
{
    public class AuditService : IAuditServices
    {
        public async Task<Audit> GetFieldsAuditory(HttpContext httpContext)
        {
            var audit = new Audit();
            //audit.IdUserAudit = int.Parse(httpContext.User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
            audit.IpPublicAudit = (string.IsNullOrEmpty(httpContext.Connection.RemoteIpAddress.ToString())) ? string.Empty: httpContext.Connection.RemoteIpAddress.ToString();


            string addr = "";
            foreach (NetworkInterface n in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (n.OperationalStatus == OperationalStatus.Up)
                {
                    addr += n.GetPhysicalAddress().ToString();
                    break;
                }
            }
            

            audit.MacAddressAudit = addr;



            return audit;
        
        }

        [DllImport("Iphlpapi.dll")]
        private static extern int SendARP(Int32 dest, Int32 host, ref Int64 mac, ref Int32 length);
        [DllImport("Ws2_32.dll")]
        private static extern Int32 inet_addr(string ip);


        private static string GetClientMAC(string strClientIP)
        {
            string mac_dest = "";
            try
            {
                Int32 ldest = inet_addr(strClientIP);
                Int32 lhost = inet_addr("");
                Int64 macinfo = new Int64();
                Int32 len = 6;
                int res = SendARP(ldest, 0, ref macinfo, ref len);
                string mac_src = macinfo.ToString("X");

                while (mac_src.Length < 12)
                {
                    mac_src = mac_src.Insert(0, "0");
                }

                for (int i = 0; i < 11; i++)
                {
                    if (0 == (i % 2))
                    {
                        if (i == 10)
                        {
                            mac_dest = mac_dest.Insert(0, mac_src.Substring(i, 2));
                        }
                        else
                        {
                            mac_dest = "-" + mac_dest.Insert(0, mac_src.Substring(i, 2));
                        }
                    }
                }
            }
            catch (Exception err)
            {
                throw new Exception("L?i " + err.Message);
            }
            return mac_dest;
        }
    }
}
