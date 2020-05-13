using System.IO;

namespace ID3V2_ClassLibrary
{
    interface IFileManager
    {
        Stream Open();
    }
}