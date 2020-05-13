using System;
using System.Collections.Generic;
using System.Text;

namespace ID3V2_ClassLibrary.Models.Frames
{
    class ID3V2PictureFrame : ID3V2Frame
    {
        public ID3V2PictureFrame(byte[] rawFrame) : base(rawFrame)
        {
        }
    }
}
