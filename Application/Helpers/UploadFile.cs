using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Helpers
{
    public class UploadFile
    {
        public static IEnumerable<string> AllowedExtensions => new List<string> { ".jpeg", ".jpg", ".png" };

        
    }
}
