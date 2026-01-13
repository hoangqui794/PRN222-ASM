using eyeWearShop.Repositories.Basis;
using EyewearShop.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EyewearShop.Repositories.NamTMH;

public class OrderNamtmhRepository : GenericRepo<OrderNamtmh>
{
    public OrderNamtmhRepository()
    {
    }

    public OrderNamtmhRepository(Prn222EyewearshopContext context)
    {
        _context = context;
    }

    //getall
    public async Task<List<OrderNamtmh>> GetAllAsync()
    {
        var orderList = await _context.OrderNamtmhs.Include(c => c.OrderItemNamtmhs).ToListAsync();
        return  orderList;
    }


    //getbyid
    public async Task<OrderNamtmh> GetByIdAsync(int id)
    {
        var orderById = await  _context.OrderNamtmhs.Include(c => c.OrderItemNamtmhs).FirstAsync(order => order.OrderId == id);
       return orderById ?? new OrderNamtmh();
    }

    //searchAsync
    public async Task<List<OrderNamtmh>> searchAsync(string orderNumber)
    {
        var orderSearch = await _context.OrderNamtmhs.Include(order => order.OrderItemNamtmhs)
        .Where(order => order.OrderNumber.Contains(orderNumber)).ToListAsync();
        return orderSearch ?? new List<OrderNamtmh>();
      
    }

    public async Task<List<OrderNamtmh>> searchAsync(int CustomerId)
    {
        var orderSearch = await _context.OrderNamtmhs.Include(order => order.OrderItemNamtmhs)
        .Where(order => order.CustomerId == CustomerId).ToListAsync();
        return orderSearch ?? new List<OrderNamtmh>();  

    }
}
