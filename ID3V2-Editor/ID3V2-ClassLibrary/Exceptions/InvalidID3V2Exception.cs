using System;
using System.Runtime.Serialization;

namespace ID3V2_ClassLibrary
{
    [Serializable]
    internal class InvalidID3V2Exception : Exception
    {     
        public InvalidID3V2Exception() : base("ID3V2 corrupted or not present!")
        {
        }
    }
}