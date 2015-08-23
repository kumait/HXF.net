using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXF.Common
{
    public class CodeWriter
    {
        private const string defaultIdent = "    ";
        private string ident;

        private StringBuilder sb;
        private Stack<string> identStack;

        public CodeWriter(string ident)
        {
            this.sb = new StringBuilder();
            this.identStack = new Stack<string>();
            this.ident = ident;
        }

        public CodeWriter() : this(defaultIdent) { }

        private string getIdent()
        {
            return string.Concat(identStack);
        }

        public void Clear()
        {
            sb.Clear();
        }

        public void ResetIdent()
        {
            identStack.Clear();
        }

        public void Reset()
        {
            sb.Clear();
            identStack.Clear();
        }

        public void PushIdent()
        {
            identStack.Push(ident);
        }

        public void PopIdent()
        {
            if (identStack.Count > 0)
            {
                identStack.Pop();
            }
            
        }

        public void Write(string text)
        {
            text = text.Replace("\n", "\n" + getIdent());
            sb.Append(getIdent());
            sb.Append(text);
        }

        public void WriteLine(string text)
        {
            text = text.Replace("\n", "\n" + getIdent());
            sb.Append(getIdent());
            sb.AppendLine(text);
        }

        public void WriteLine()
        {
            sb.Append(getIdent());
            sb.AppendLine();
        }

        public void WriteFormat(string format, params object[] args)
        {
            sb.Append(getIdent());
            sb.AppendFormat(format, args);
        }

        public void WriteLineFormat(string format, params object[] args)
        {
            sb.Append(getIdent());
            sb.AppendFormat(format, args);
            sb.AppendLine();
        }

        public void WriteNoIdent(string text)
        {
            sb.Append(text);
        }

        public void WriteLineNoIdent(string text)
        {
            sb.AppendLine(text);
        }

        public void WriteFormatNoIdent(string format, params object[] args)
        {
            sb.AppendFormat(format, args);
        }

        public void WriteLineFormatNoIdent(string format, params object[] args)
        {
            sb.AppendFormat(format, args);
            sb.AppendLine();
        }

        public string Code
        {
            get { return sb.ToString(); }
        }
    }
}
