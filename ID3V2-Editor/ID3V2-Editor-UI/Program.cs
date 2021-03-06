﻿using ID3V2_ClassLibrary;
using ID3V2_ClassLibrary.Models;
using ID3V2_ClassLibrary.Models.Frames;
using System;
using System.IO;

namespace ID3V2_Editor_UI
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Usage: ID3V2-Editor --path");
                return;
            }

            Console.WriteLine("!-- ID3V2 Editor alpha --!");
            string path = args[0];
            if (!File.Exists(path))
            {
                Console.WriteLine("Invalid file, try again...");
                return;
            }

            ID3V2_ClassLibrary.Application app = new ID3V2_ClassLibrary.Application(path);

            var frames = app.GetID3V2().Frames;
            int counter = 1;
            Console.WriteLine("--------- ID3V2 Frames ----------");
            foreach (var frame in frames)
            {
                Console.WriteLine("Frame {0}:", counter);
                if ((frame as ID3V2TextFrame) != null)
                    Console.WriteLine("  ID: {0}, Content: {1}", frame.Header.ID, (frame as ID3V2TextFrame).GetContent());
                else
                    Console.WriteLine("  ID: {0}, Content: NonText", frame.Header.ID);
                counter++;
            }
        }
    }
}
