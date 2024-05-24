using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Business.Exceptions
{
    public class FileSizeException : Exception
    {
        public string Property { get; set; }

        public FileSizeException(string property, string? message) : base(message)
        {
            Property = property;
        }
}
}
