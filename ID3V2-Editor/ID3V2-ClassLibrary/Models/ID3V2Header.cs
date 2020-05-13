using System;
using System.Collections;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace ID3V2_ClassLibrary
{
    class ID3V2Header
    {
        private string identifier;
        private BitArray rawFlags;

        public ID3V2Header(byte[] rawHeader)
        {
            if (rawHeader.Length != 10)
                throw new InvalidId3V2HeaderException();

            byte[] rawIdentifier = rawHeader.Take(3).ToArray();
            byte rawMajorVersionByte = rawHeader.Skip(3).Take(1).ToArray()[0];
            byte rawMinorVersionByte = rawHeader.Skip(4).Take(1).ToArray()[0];
            byte rawFlagByte = rawHeader.Skip(5).Take(1).ToArray()[0];
            byte[] rawSize = rawHeader.Skip(6).Take(4).Reverse().ToArray();

            SetIdentifier(rawIdentifier);
            SetVersion(rawMajorVersionByte, rawMinorVersionByte);
            SetSize(rawSize);

            rawFlags = new BitArray(rawFlagByte);
        }

        public int MajorVersion { get; private set; }
        public int MinorVersion { get; private set; }
        public int Size { get; private set; }
        public bool isValid
        {
            get
            {
                return (identifier == "ID3");
            }
        }

        private void SetIdentifier(byte[] rawIdentifier)
        {
            identifier = Encoding.UTF8.GetString(rawIdentifier);
        }

        private void SetVersion(byte rawMajorVersion, byte rawMinorVersion)
        {
            MajorVersion = Convert.ToInt32(rawMajorVersion);
            MinorVersion = Convert.ToInt32(rawMinorVersion);
        }

        private void SetSize(byte[] rawSize)
        {
            Size = BitConverter.ToInt32(rawSize);
        }
    }
}