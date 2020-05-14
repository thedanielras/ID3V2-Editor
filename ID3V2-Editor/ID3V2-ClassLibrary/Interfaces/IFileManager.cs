using System.IO;

namespace ID3V2_ClassLibrary
{
    public interface IFileManager
    {
        Stream Open();
    }
}