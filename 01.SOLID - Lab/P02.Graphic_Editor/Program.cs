using System;

namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {
            GraphicEditor.DrawShape(new Circle());
            GraphicEditor.DrawShape(new Rectangle());
            GraphicEditor.DrawShape(new Square());
        }
    }
}
