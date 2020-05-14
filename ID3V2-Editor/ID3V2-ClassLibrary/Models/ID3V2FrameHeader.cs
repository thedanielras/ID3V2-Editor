using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ID3V2_ClassLibrary.Models
{
    public class ID3V2FrameHeader
    {
        private byte[] rawHeader;

        public ID3V2FrameHeader(byte[] rawHeader)
        {
            this.rawHeader = rawHeader;

            SetID();
            SetSize();
        }

        public string ID { get; private set; }
        public int Size { get; private set; }

        private void SetID()
        {
            byte[] rawId = rawHeader.Take(4).ToArray();
            ID = Encoding.UTF8.GetString(rawHeader);
        }

        private void SetSize()
        {
            byte[] rawSize = rawHeader.Skip(4).Take(4).Reverse().ToArray();
            Size = BitConverter.ToInt32(rawSize, 0);
        }
    }
}
