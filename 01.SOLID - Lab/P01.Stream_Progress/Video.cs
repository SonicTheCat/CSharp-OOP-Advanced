using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Stream_Progress
{
    class Video : IStreamProgressor
    {
        private string director;
        private double budget; 

        public Video(string director, double budget, int length, int bytesSent)
        {
            this.director = director;
            this.Length = length;
            this.BytesSent = bytesSent;
        }

        public int Length { get; set; }

        public int BytesSent { get; set; }
    }
}
