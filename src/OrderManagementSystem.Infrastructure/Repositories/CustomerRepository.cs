using Microsoft.EntityFrameworkCore;
using OrderManagementSystem.Domain.Entities;
using OrderManagementSystem.Domain.Repositories;
using OrderManagementSystem.Infrastructure.Data;

namespace OrderManagementSystem.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly OrderDbContext _context;

        public CustomerRepository(OrderDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Customer customer)
        {
            if (customer.Id == Guid.Empty) customer.Id = Guid.NewGuid();
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null) return;
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer?> GetByIdAsync(Guid id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task UpdateAsync(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }
    }
}
