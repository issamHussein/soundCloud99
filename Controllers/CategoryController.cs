using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using Tahaluf.SoundCloud.Core.Data;
using Tahaluf.SoundCloud.Core.Service;

namespace Tahaluf.SoundCloud.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService _categoryService)
        {
            categoryService = _categoryService;
        }


        [HttpGet]
        [Route("GetAllCATEGORY")]
        //get all categoru except user category
        public List<Category> GetAllCATEGORY()
        {
            return categoryService.GetAllCATEGORY();
        }

        [HttpPost]
        [Route("CreateCATEGORY")]
        public bool CreateCATEGORY([FromBody] Category category)
        {
            return categoryService.CreateCATEGORY(category);
        }

        [HttpPut]
        [Route("UpdateCATEGORY")]
        //GetByCATEGORYName
        //200 ok
        //404 page not found == problem in controller
        //400 bad request == مشكله في الداتا يلي بتنبعث
        //401 unautherization
        [ProducesResponseType(typeof(List<Category>), StatusCodes.Status200OK)]
        public bool UpdateCATEGORY([FromBody] Category category)
        {
            return categoryService.UpdateCATEGORY(category);
        }

        [HttpDelete]
        [Route("DeleteCATEGORY/{id}")]

        //200 ok
        //404 page not found == problem in controller
        //400 bad request == مشكله في الداتا يلي بتنبعث
        //401 unautherization
        [ProducesResponseType(typeof(List<Category>), StatusCodes.Status200OK)]
        public bool DeleteCATEGORY(int id)
        {
            return categoryService.DeleteCATEGORY(id);
        }

        [HttpGet]
        [Route("GetByCATEGORYName/{CategoryName}")]
        //get the category by the name input by the customer(search)
        public List<Category> GetByCATEGORYName(string CategoryName)
        {
            return categoryService.GetByCATEGORYName(CategoryName);
        }







        [HttpPost]
        [Route("UploadImage")]
        public Category UploadImage()
        {
            try
            {
                var file = Request.Form.Files[0]; //retrive file{Image} from Form which is part of the Request

                var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                var path = Path.Combine("C:\\Users\\issam\\Desktop\\soundCloud\\src\\assets\\img", fileName); ///Image/nvjfjgfgdtget53536ywwsyh_Aseel.jpg

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                Category category = new Category();
                category.Image = fileName;
                return category;

            }
            catch (Exception e)
            {
                return null;
            }
        }







    }
}
