using System;
using System.Text;

namespace Util.ConfigErrors
{
    public static class ExceptionExtension
    {
        public static string GetCompleteDescription(this Exception ex)
        {
            var sb = new StringBuilder();
            do
            {
                sb.AppendLine("Error: " + ex.Message);
                sb.AppendLine("Stack Trace: " + ex.StackTrace);
                if (ex.InnerException != null)
                {
                    sb.AppendLine();
                    sb.AppendLine("InnerException:");
                }
                ex = ex.InnerException;
            }
            while (ex != null);
            return sb.ToString();
        }
    }
}
