using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.SoundCloud.Core.Data;
using Tahaluf.SoundCloud.Core.Repository;
using Tahaluf.SoundCloud.Core.Service;

namespace Tahaluf.SoundCloud.Infra.Service
{
    public class CategoryService: ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository _categoryRepository)
        {
            categoryRepository = _categoryRepository;
        }

         public List<Category> GetAllCATEGORY()
        {
            return categoryRepository.GetAllCATEGORY();
        }


        public bool CreateCATEGORY(Category category)
        {
            return categoryRepository.CreateCATEGORY(category);
        }
        public bool UpdateCATEGORY(Category category)
        {
            return categoryRepository.UpdateCATEGORY(category);
        }
        public bool DeleteCATEGORY(int id)
        {
            return categoryRepository.DeleteCATEGORY(id);
        }

        public List<Category> GetByCATEGORYName(string CategoryName)
        {
            return categoryRepository.GetByCATEGORYName(CategoryName);
        }
       
  

    }
}

