using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Strategy
{

    public enum OutputFormat
    {
        NumberList,
        Html
    }

    public interface IListFormatStrategy
    {
        void Start(StringBuilder sb);
        void AddItem(StringBuilder sb, string item);
        void End(StringBuilder sb);
    }

    public class Html : IListFormatStrategy
    {
        public void Start(StringBuilder sb)
        {
            sb.AppendLine("<ul>");
        }

        public void AddItem(StringBuilder sb, string item)
        {
            sb.AppendLine($" <li>{item}</li>");
        }

        public void End(StringBuilder sb)
        {
            sb.AppendLine("</ul>");
        }
    }

    public class NumberList : IListFormatStrategy
    {
        public void AddItem(StringBuilder sb, string item)
        {
            var itemNumber = Regex.Matches(sb.ToString(), Environment.NewLine).Count + 1;
            sb.AppendLine($"{itemNumber} {item}");
        }

        public void End(StringBuilder sb)
        {
        }

        public void Start(StringBuilder sb)
        {
        }
    }

    // Context
    public class TextProcessor
    {
        private StringBuilder sb = new StringBuilder();
        private IListFormatStrategy _listStrategy;


        public TextProcessor(OutputFormat format)
        {
            _listStrategy = (IListFormatStrategy)Activator.
                CreateInstance(Type.GetType($"Strategy.{Enum.GetName(typeof(OutputFormat), format)}"));
        }
        public void AppendList(IEnumerable<string> items)
        {
            _listStrategy.Start(sb);
            foreach (var item in items)
                _listStrategy.AddItem(sb, item);
            _listStrategy.End(sb);
        }

        public StringBuilder Clear() => sb.Clear();
        public override string ToString()
        {
            return sb.ToString();
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            var tp = new TextProcessor(OutputFormat.NumberList);
            tp.AppendList(new[] { "c#", "Java", "Phyton" });
            Console.WriteLine(tp);
            tp.Clear();

            tp = new TextProcessor(OutputFormat.Html);
            tp.AppendList(new[] { "c#", "Java", "Phyton" });
            Console.WriteLine(tp);
            tp.Clear();
        }
    }

}