using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ID3V2_ClassLibrary
{
    class FileManager : IFileManager
    {
        private string path;

        public FileManager(string path)
        {
            this.path = path;
            Validate();
        }

        private void Validate()
        {
            if (File.Exists(path))
                throw new InvalidFileException(path);
        }

        public Stream Open()
        {
            return new FileStream(path, FileMode.Open);
        }
    }
}
