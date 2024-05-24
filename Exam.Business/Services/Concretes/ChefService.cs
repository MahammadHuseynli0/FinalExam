using Exam.Business.Exceptions;
using Exam.Business.Extension;
using Exam.Business.Services.Abstracts;
using Exam.Core.Models;
using Exam.Core.RepositoryAbstracts;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Business.Services.Concretes
{
    public class ChefService : IChefService
    {
        private readonly IChefRepository _chefRepository;

        private readonly IWebHostEnvironment _env;

        public ChefService(IChefRepository chefRepository, IWebHostEnvironment env)
        {
            _chefRepository = chefRepository;
            _env = env;
        }

        public void AddChef(Chef chef)
        {
            if (chef.ImageFile == null) throw new ImageFileRequiredException("ImageFile", "Image file is required!");



            chef.ImageUrl = Helper.SaveFile(_env.WebRootPath, $@"uploads\chefs", chef.ImageFile);
            _chefRepository.Add(chef);
            _chefRepository.Commit();
        }

      

        public List<Chef> GetAllChef(Func<Chef, bool>? func = null)
        {
            return _chefRepository.GetAll(func);
        }

   

        public Chef GetChef(Func<Chef, bool>? func = null)
        {
            return _chefRepository.Get(func);
        }

     

        public void RemoveChef(int id)
        {
            var existchef = _chefRepository.Get(x => x.Id == id);
            if (existchef == null) throw new EntityNotFoundException("", "Entity not found!");

            if (existchef.ImageUrl != null)
                Helper.DeleteFile(_env.WebRootPath, @"\uploads\chefs", existchef.ImageUrl);

            _chefRepository.Delete(existchef);
            _chefRepository.Commit();

        }

      

        public void UpdateChef(Chef chef)
        {
            var existchef = _chefRepository.Get(x => x.Id == chef.Id);
            if (existchef == null) throw new EntityNotFoundException("", "Entity not found!");

            if (chef.ImageFile != null)
            {
                if (existchef.ImageUrl != null)
                    Helper.DeleteFile(_env.WebRootPath, @"uploads\chefs", existchef.ImageUrl);
                existchef.ImageUrl = Helper.SaveFile(_env.WebRootPath, @"uploads\chefs", chef.ImageFile);

            }

            existchef.Name = chef.Name;
            existchef.Description = chef.Description;

            _chefRepository.Commit();
        }

     }
    }

