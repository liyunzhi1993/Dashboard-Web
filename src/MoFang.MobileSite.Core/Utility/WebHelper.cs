using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MoFang.MobileSite.Core.Utility
{
    public class WebHelper
    {
        public static async Task<string> Post(string url, string strPostData)
        {
            WebClient webClient = new WebClient();
            byte[] postData = Encoding.UTF8.GetBytes(strPostData);
            webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            byte[] responseData = await webClient.UploadDataTaskAsync(url, "POST", postData);//得到返回字符流 
            return Encoding.UTF8.GetString(responseData);//解码  
        }
    }
}
