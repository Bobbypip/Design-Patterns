using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    public interface IShapeVisitor
    {
        void Visit(Square square);
        void Visit(Circle circle);
        void Visit(JoinShapes joinShapes);

    }

    public abstract class Shape
    {
        public abstract void Accept(IShapeVisitor visitor);
        // public abstract void Print(StringBuilder sb);
    }



    public class Circle : Shape
    {
        public int Radius { get; }

        public Circle(int radius)
        {
            this.Radius = radius;
        }

        public override void Accept(IShapeVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class Square : Shape
    {
        public int Size { get; }

        public Square(int size)
        {
            this.Size = size;
        }

        public override void Accept(IShapeVisitor visitor)
        {
            visitor.Visit(this);
        }


    }

    public class JoinShapes : Shape
    {
        public Shape Left { get; }
        public Shape Right { get; }

        public JoinShapes(Shape left, Shape right)
        {
            this.Left = left;
            this.Right = right;
        }
        public override void Accept(IShapeVisitor visitor)
        {
            visitor.Visit(this);
        }

    }

    public class ShapePrint : IShapeVisitor
    {
        StringBuilder sb = new StringBuilder();

        public void Visit(Square square)
        {
            sb.AppendLine("<cuadrado>");
            sb.Append($"<tamaño value={square.Size}");
            sb.AppendLine("</cuadrado>");
        }

        public void Visit(Circle circle)
        {
            sb.AppendLine("<circulo>");
            sb.Append($"<radio value={circle.Radius}");
            sb.AppendLine("</circulo>");
        }

        public void Visit(JoinShapes joinShapes)
        {
            sb.AppendLine("<figuras>");
            joinShapes.Left.Accept(this);
            joinShapes.Right.Accept(this);
            sb.AppendLine("</figuras>");
        }

        public override string ToString() => sb.ToString();
    }

    class Program
    {
        static void Main(string[] args)
        {
            var shapes = new JoinShapes(
                left: new Circle(3),
                right: new Square(10));
            var sb = new StringBuilder();

            var print = new ShapePrint();
            print.Visit(shapes);
            Console.WriteLine(print.ToString());



        }
    }
}
