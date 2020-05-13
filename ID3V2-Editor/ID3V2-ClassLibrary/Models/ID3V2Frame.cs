using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ID3V2_ClassLibrary.Models
{
    abstract class ID3V2Frame
    {
        protected byte[] rawFrame;
        protected ID3V2FrameHeader header;

        public ID3V2Frame(byte[] rawFrame)
        {
            this.rawFrame = rawFrame;

            SetHeader();
        }

        public bool isValid
        {
            get
            {
                return (header.Size > 0);
            }
        }

        private void SetHeader()
        {
            byte[] rawHeader = rawFrame.Take(10).ToArray();
            header = new ID3V2FrameHeader(rawHeader);
        }
    }
}
