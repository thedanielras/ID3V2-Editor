using System;
using System.Runtime.Serialization;

namespace ID3V2_ClassLibrary
{
    [Serializable]
    internal class InvalidID3V2HeaderException : Exception
    {
        public InvalidID3V2HeaderException() : base("Invalid ID3V2Header!")
        {
        }
    }
}