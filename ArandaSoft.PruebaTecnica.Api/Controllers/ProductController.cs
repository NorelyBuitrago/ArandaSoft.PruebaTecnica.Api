using ArandaSoft.PruebaTecnica.Entities.DTOs;
using ArandaSoft.PruebaTecnica.Entities.Entities;
using ArandaSoft.PruebaTecnica.Entities.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ArandaSoft.PruebaTecnica.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _productServices;
        public ProductController(IProductServices productServices)
        {
            _productServices = productServices;

        }

        /// <summary>
        /// Método que retorna una lista de productos de acuerdo a los parametros de FilterDTO prueba
        /// </summary>
        /// <param name="productFilterDTO">Permite filtrar por Categoría, Nombre y Descripción, ordenar por Nombre y Categoría y trarse un número de regitros indicando la Pág </param>
        /// <returns>Retorna una lista de productos de acuerdos a los parametros dados</returns>
        [HttpPost("GetAllParameters")]
        public async  Task<IActionResult> GetAllParameters(ProductFilterDTO productFilterDTO)
        {
            try
            {
                if (productFilterDTO == null) {
                    return BadRequest();
                }

                if (productFilterDTO.PageSize == 0 && productFilterDTO.Count == 0)
                {
                    return BadRequest();
                }

                return Ok(await _productServices.GetByParameters(productFilterDTO).ToListAsync());  

            }
            catch (Exception exc)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }

        }

        /// <summary>
        /// Método que actualiza un producto desde su Id pricipal
        /// </summary>
        /// <param name="product">Indique que campos se van a actualizar</param>
        /// <returns> Retorna una respuesta http de acuerdo a la solicitud</returns>        
        [HttpPut]
        public async Task<IActionResult> UpdateById(Product product)
        {
            try
            {
                if (string.IsNullOrEmpty(product.Id))
                {
                    return BadRequest();
                }

                return Ok( _productServices.UpdateProduct(product));
            }
            catch (Exception exc)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Metodo para crear un nuevo producto
        /// </summary>
        /// <param name="product"> Se diligencia el nuevo producto </param>
        /// <returns>Retorna una respuesta http de acuerdo la creación de producto</returns>
        [HttpPost]
        public async Task<ActionResult> Create(Product product)
        {
            try
            {
                if (product == null)
                    return BadRequest();

                var createdEmployee = await _productServices.SaveProduct(product);

                return StatusCode((int)HttpStatusCode.Created);
            }
            catch (Exception exc)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Metodo que elimina un producto por el código
        /// </summary>
        /// <param name="code">´Pide el código del elemento a eliminar</param>
        /// <returns>Retorna una respuesta http de acuerdo la eliminación de un producto</returns>
        [HttpDelete("code/{code}")]
        public async Task<IActionResult> DeleteByCode(string code)
        {
            try
            {
                if (string.IsNullOrEmpty(code))
                {
                    return BadRequest();
                }

                return Ok(await _productServices.DeleteProduct(code));
            }
            catch (Exception exc)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }

        }
    }
}
