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
            ReadHeader();
        }

        private void ReadHeader()
        {
            byte[] rawHeader = new byte[10];
            fileStream.Read(rawHeader, 0, 10);

            header = new ID3V2Header(rawHeader);
            if (!header.isValid) throw new InvalidID3V2Exception();
        }
    }
}
