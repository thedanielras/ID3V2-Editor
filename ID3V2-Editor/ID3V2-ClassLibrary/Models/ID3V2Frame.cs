using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ID3V2_ClassLibrary.Models
{
    public abstract class ID3V2Frame
    {
        protected byte[] rawFrame;      

        public ID3V2Frame(byte[] rawFrame)
        {
            this.rawFrame = rawFrame;

            SetHeader();
        }

        public ID3V2FrameHeader Header { get; private set; }

        public bool isValid
        {
            get
            {
                return (Header.Size > 0);
            }
        }

        private void SetHeader()
        {
            byte[] rawHeader = rawFrame.Take(10).ToArray();
            Header = new ID3V2FrameHeader(rawHeader);
        }
    }
}
