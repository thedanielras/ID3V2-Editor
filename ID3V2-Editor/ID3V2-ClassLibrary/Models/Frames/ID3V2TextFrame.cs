using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ID3V2_ClassLibrary.Models.Frames
{
    class ID3V2TextFrame : ID3V2Frame
    {
        public ID3V2TextFrame(byte[] rawFrame) : base(rawFrame)
        {
        }

        public string GetContent()
        {
            byte[] rawContent = rawFrame.Skip(10).ToArray();

            return Encoding.Unicode.GetString(rawContent);
        }
    }
}
