using System;
using System.Collections.Generic;
using System.Text;

namespace P02.Graphic_Editor
{
    public static class GraphicEditor
    {
        public static void DrawShape(IShape shape)
        {
            Console.WriteLine(shape.Draw());
        }
    }
}
