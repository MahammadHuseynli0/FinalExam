using Exam.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Business.Services.Abstracts
{
    public interface IChefService
    {
        void AddChef(Chef chef);
        void RemoveChef(int id);

        void UpdateChef(Chef chef);
        Chef GetChef(Func<Chef, bool>? func = null);

        List<Chef> GetAllChef(Func<Chef, bool>? func = null);
    }
}
