using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Business.Exceptions
{
      public class ImageFileRequiredException : Exception
    {
        public string Property { get; set; }

        public ImageFileRequiredException(string property, string? message) : base(message)
        {
            Property = property;
        }
    }
}
