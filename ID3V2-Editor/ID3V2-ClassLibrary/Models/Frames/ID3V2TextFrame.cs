using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ID3V2_ClassLibrary.Models.Frames
{
    public class ID3V2TextFrame : ID3V2Frame
    {
        public ID3V2TextFrame(byte[] rawFrame) : base(rawFrame)
        {
        }

        public string GetContent()
        {
            byte[] rawContent = rawFrame.Skip(10).ToArray();
            int encodingFlag = Convert.ToInt32(rawContent[0]);

            Encoding encoder = Encoding.Default;
            bool hasPreamble = false;

            if (encodingFlag == 0) encoder = Encoding.ASCII;
            else if (encodingFlag == 1)
            {
                hasPreamble = true;
                encoder = (rawContent[1] == 0xFE) ? Encoding.BigEndianUnicode : Encoding.Unicode;
            }

            // Skip encoding byte
            rawContent = rawContent.Skip(1).ToArray();
            
            if (hasPreamble)
            {
                //skip preamble
                rawContent = rawContent.Skip(2).ToArray();
            }

            return encoder.GetString(rawContent).Replace("\0", String.Empty);
        }
    }
}
