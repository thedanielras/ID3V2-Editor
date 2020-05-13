using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ID3V2_ClassLibrary
{
    class ID3V2Editor
    {
        private Stream fileStream;
        private ID3V2Header header;
        
        public ID3V2Editor(IFileManager fileManager)
        {
            fileStream = fileManager.Open();
        }
    }
}
