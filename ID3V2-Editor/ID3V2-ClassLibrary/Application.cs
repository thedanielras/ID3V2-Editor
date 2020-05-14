using System;
using System.Collections.Generic;
using System.Text;

namespace ID3V2_ClassLibrary
{
    public class Application
    {
        private ID3V2Editor editor;

        public Application(string path)
        {
            IFileManager fileManager = new FileManager(path);
            editor = new ID3V2Editor(fileManager);
        }

        public ID3V2Editor GetID3V2()
        {
            return editor;
        }
    }
}
