using Newtonsoft.Json;
using Qiniu.Http;
using Qiniu.IO;
using Qiniu.IO.Model;
using Qiniu.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MoFang.MobileSite.Core.Utility
{
    public class QiniuHelper
    {
        public static string UploadFile(Stream fileStream,string fileName,string AK,String SK,string bucket)
        {
            // 生成(上传)凭证时需要使用此Mac
            // 这个示例单独提供了一个Settings类，其中包含AccessKey和SecretKey
            // 实际应用中，请自行设置您的AccessKey和SecretKey
            Mac mac = new Mac(AK, SK);

            string saveKey = fileName;

            // 上传策略，参见 
            // http://developer.qiniu.com/article/developer/security/put-policy.html
            PutPolicy putPolicy = new PutPolicy();

            // 如果需要设置为"覆盖"上传(如果云端已有同名文件则覆盖)，请使用 SCOPE = "BUCKET:KEY"
            // putPolicy.Scope = bucket + ":" + saveKey;
            putPolicy.Scope = bucket;

            // 上传策略有效期(对应于生成的凭证的有效期)          
            putPolicy.SetExpires(3600);

            // 上传到云端多少天后自动删除该文件，如果不设置（即保持默认默认）则不删除
            putPolicy.DeleteAfterDays = 1;

            // 生成上传凭证，参见
            // http://developer.qiniu.com/article/developer/security/upload-token.html            

            string jstr = putPolicy.ToJsonString();            
            string token = Auth.CreateUploadToken(mac, jstr);

            FormUploader fu = new FormUploader();

            // 支持自定义参数
            //var extra = new System.Collections.Generic.Dictionary<string, string>();
            //extra.Add("FileType", "UploadFromLocal");
            //extra.Add("YourKey", "YourValue");
            //UploadFile(...,extra)

            var result = fu.UploadStreamAsync(fileStream, saveKey, token);

            return JsonConvert.DeserializeObject<ResultModel>(result.Result.Text).key;
        }
    }

    public class ResultModel
    {
        public string hash { get; set; }
        public string key { get; set; }
    }
}
