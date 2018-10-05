﻿namespace Document_System.Structure
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using Utils;

    public class Heading : Element
    {
        private int headingSize;

        public Heading(string text, int headingSize = 1)
        {
            this.HeadingSize = headingSize;
            this.Text = text;
        }

        public int HeadingSize
        {
            get => this.headingSize;
            private set
            {
                if (value < 1 || value > 6)
                {
                    throw new ArgumentOutOfRangeException(nameof(this.HeadingSize), "The hading size should be [1...6].");
                }

                this.headingSize = value;
            }
        }

        public string Text { get; private set; }

        public override void RenderHtml(TextWriter writer)
        {
            writer.WriteLine();
            writer.WriteLine($"<h{this.HeadingSize}>{this.Text.HtmlEncode()}</h{this.HeadingSize}>");
        }

        public override void RenderText(TextWriter writer)
        {
            writer.WriteLine();
            writer.WriteLine(this.Text.ToUpper());
            
        }
    }
}