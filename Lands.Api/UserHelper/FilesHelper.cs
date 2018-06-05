using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Lands.Api.UserHelper
{
    public class FilesHelper
    {
        public static bool UploadPhoto(MemoryStream stream, string folder, string file)
        {
            try
            {
                stream.Position = 0;
                var path = Path.Combine(HttpContext.Current.Server.MapPath(folder), file);
                File.WriteAllBytes(path, stream.ToArray());
            }
            catch 
            {

                return false;
            }

            return true;
        }
    }
}