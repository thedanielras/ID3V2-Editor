using System;
using System.Collections.Generic;
using System.Text;

namespace ID3V2_ClassLibrary.Models
{
    abstract class ID3V2Frame
    {
        protected byte[] rawFrame;

        public ID3V2Frame(byte[] rawFrame)
        {
            this.rawFrame = rawFrame;
        }

        public string ID { get; private set; }
        public int Size { get; private set; }
    }
}
