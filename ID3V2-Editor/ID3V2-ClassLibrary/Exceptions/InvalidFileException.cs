using System;
using System.Runtime.Serialization;

namespace ID3V2_ClassLibrary
{
    [Serializable]
    internal class InvalidFileException : Exception
    {
        public InvalidFileException(string path) : base(String.Format("The file at directory: \"{0}\" was not found!", path))
        {
        }
    }
}