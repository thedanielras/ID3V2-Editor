using ID3V2_ClassLibrary.Models;
using ID3V2_ClassLibrary.Models.Frames;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ID3V2_ClassLibrary
{
    public class ID3V2Editor
    {
        private Stream fileStream;
        private ID3V2Header header;
        private List<ID3V2Frame> frames;

        public ID3V2Editor(IFileManager fileManager)
        {
            fileStream = fileManager.Open();
            ReadHeader();
            ReadFrames();
        }

        public List<ID3V2Frame> Frames
        {
            get
            {
                return frames;
            }
        }

        private void ReadHeader()
        {
            byte[] rawHeader = new byte[10];
            fileStream.Read(rawHeader, 0, 10);

            header = new ID3V2Header(rawHeader);
            if (!header.isValid) throw new InvalidID3V2Exception();
        }

        private void ReadFrames()
        {
            if (header == null) ReadHeader();

            int rawFramesSize = header.Size;
            byte[] rawFrames = new byte[rawFramesSize];
            long position = fileStream.Position;
            fileStream.Read(rawFrames, 0, rawFramesSize);

            int skipSize = 0;
            while (true)
            {
                byte[] currentFrameHeaderRaw = rawFrames.Skip(skipSize).Take(10).ToArray();
                ID3V2FrameHeader currentFrameHeader = new ID3V2FrameHeader(currentFrameHeaderRaw);
                int currentFrameTotalSize = currentFrameHeader.Size + 10;
                byte[] currentFrameRaw = rawFrames.Skip(skipSize).Take(currentFrameTotalSize).ToArray();

                ID3V2Frame currentFrame = null;

                if (currentFrameHeader.ID[0] == 'T' && currentFrameHeader.ID != "TXXX")
                    currentFrame = new ID3V2TextFrame(currentFrameRaw);
                else if (currentFrameHeader.ID != "APIC")
                    currentFrame = new ID3V2PictureFrame(currentFrameRaw);

                if (currentFrame != null && currentFrame.isValid)
                {
                    frames.Add(currentFrame);
                    skipSize += currentFrameTotalSize;
                }
                else break;
            }
        }
    }
}