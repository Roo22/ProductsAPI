using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Services;

namespace ProductsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductsService _productsService;
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        private new List<string> _allowedExtenstions = new List<string> { ".jpg", ".png" };

        public ProductController(IProductsService productsService,
            IMapper mapper,
            ICategoryService categoryService)
        {
           _productsService = productsService;
           _mapper = mapper;
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var products = await _productsService.GetAllProducts();
            var data = _mapper.Map<IEnumerable<ProductDetailsDto>>(products);
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var product = await _productsService.GetById( id );
            if(product == null ) 
                return NotFound();
           var dto = _mapper.Map< ProductDetailsDto >(product);
            return Ok( dto );
        }
        [HttpGet("{category}")]
        public async Task<IActionResult> GetByCategoryNameAsync(string category)
        {
            var product = await _productsService.GetByCategory(category);
            if (product == null)
                return NotFound();
            var dto = _mapper.Map<IEnumerable<ProductDetailsDto>>(product);
            return Ok(dto);
        }
        [HttpGet("GetByCategoryId")]
        public async Task<IActionResult> GetByCategoryIdAsync(byte categoryId)
        {
            var products = await _productsService.GetAllProducts(categoryId);
            var data = _mapper.Map<IEnumerable<ProductDetailsDto>>(products);
            return Ok( data );
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] ProductDto dto)
        {
            if(dto.Image == null)
                return BadRequest("Image is required!");
            if (!_allowedExtenstions.Contains(Path.GetExtension(dto.Image.FileName).ToLower()))
                return BadRequest("Only .png and .jpg images are allowed!");
            var isValidCategory = await _categoryService.IsvalidCategory(dto.CategoryId);
            if (!isValidCategory)
                return BadRequest("Invalid Category ID!");
            using var dataStream = new MemoryStream();
            await dto.Image.CopyToAsync(dataStream);
            var product = _mapper.Map<Product>(dto);
            product.Image = dataStream.ToArray();
            _productsService.Add(product);
            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromForm] ProductDto dto)
        {
            var product = await _productsService.GetById(id);
            if(product == null)
                return NotFound($"No Product was found with ID {id}");
            var isValidCategory = await _categoryService.IsvalidCategory(dto.CategoryId);
            if (!isValidCategory)
                return BadRequest("Invalid Category ID!");
            if(dto.Image != null)
            {
                if (!_allowedExtenstions.Contains(Path.GetExtension(dto.Image.FileName).ToLower()))
                    return BadRequest("Only .png and .jpg images are allowed!");
                using var dataStream = new MemoryStream();
                await dto.Image.CopyToAsync (dataStream);
                product.Image = dataStream.ToArray ();

            }
            product.name = dto.name;
            product.description = dto.description;
            product.Duration = dto.Duration;
            product.CategoryId = dto.CategoryId;
            product.StartDate = dto.StartDate;
            product.CreatedDate = dto.CreatedDate;
            product.UserId = dto.UserId;
            product.Price = dto.Price;

            _productsService.Update(product);
            return Ok(product);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var product = await _productsService.GetById(id);
            if (product == null)
                return NotFound($"No Product was found with ID {id}");
            _productsService.Delete(product);
            return Ok(product);

        }
    }
}
