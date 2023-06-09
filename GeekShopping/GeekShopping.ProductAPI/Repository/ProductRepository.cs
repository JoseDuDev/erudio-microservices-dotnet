using AutoMapper;
using GeekShopping.ProductAPI.Data.ValueObjects;
using GeekShopping.ProductAPI.Interfaces;
using GeekShopping.ProductAPI.Model;
using GeekShopping.ProductAPI.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly MySQLContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(MySQLContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductVO>> FindAll()
        {
            var produtos = await _context.Products.ToListAsync();
            return _mapper.Map<List<ProductVO>>(produtos);
        }

        public async Task<ProductVO> FindById(long id)
        {
            var produto = await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync() ?? new();
            return _mapper.Map<ProductVO>(produto);
        }

        public async Task<ProductVO> Create(ProductVO product)
        {
            Product produto = _mapper.Map<Product>(product);
            _context.Add(produto);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductVO>(produto);
        }

        public async Task<ProductVO> Update(ProductVO product)
        {
            Product produto = _mapper.Map<Product>(product);
            _context.Update(produto);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductVO>(produto);
        }

        public async Task<bool> DeleteById(long id)
        {
            try
            {
                var produto = await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync() ?? new();
                if (produto.Id <= 0) return false;
                _context.Remove(produto);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
