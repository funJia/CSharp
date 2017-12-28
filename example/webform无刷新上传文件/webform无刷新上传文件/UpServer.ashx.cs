using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace webform无刷新上传文件
{
    /// <summary>
    /// UpServer 的摘要说明
    /// </summary>
    public class UpServer : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            int count = context.Request.Files.Count;
            string res = string.Empty;
            string error = string.Empty;
            string imgurl = string.Empty; ;
            if (count > 0)
            {
                try
                {
                    HttpPostedFile File1 = context.Request.Files[0];
                    string suffix = Path.GetExtension(File1.FileName).ToLower();
                    string path = context.Request.MapPath("UpLoadImg/HeadImage");  //用来生成文件夹  

                    if (File1.ContentLength / 4096 > 4096)
                    {
                        error = "单张头像不能超过4096K(4M)，请重新选择头像上传。";
                    }
                    else
                    {

                        if (!Directory.Exists(path))
                            Directory.CreateDirectory(path);
                        var savepath = "UpLoadImg/HeadImage/" + Guid.NewGuid() + suffix;
                        if (suffix.Equals(".jpg") || suffix.Equals(".png") || suffix.Equals(".gif") || suffix.Equals(".jpeg"))
                        {
                            File1.SaveAs(context.Request.MapPath(savepath));
                        }

                        error = "上传成功";
                        res = "{\"info\":\"" + error + "\",\"data\":\"1\",\"imgurl\":\"" + savepath + "\"}";
                    }
                }
                catch (Exception ex)
                {
                    res = "{\"info\":\"" + ex.Message + "\",\"data\":\"0\",\"imgurl\":\"\"}";
                }
                context.Response.Write(res);
                context.Response.End();
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}