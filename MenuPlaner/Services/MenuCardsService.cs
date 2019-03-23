using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MenuPlaner.Models;
using Microsoft.EntityFrameworkCore;

namespace MenuPlaner.Services
{
    public class MenuCardsService : IMenuCardsService
    {
        private MenuCardsContext _context;
        public MenuCardsService(MenuCardsContext context) =>
            _context = context;

        public async Task<IEnumerable<MenuCard>> GetMenuCardsAsync()
        {
            await EnsureDatabaseCreatedAsync();
            var menuCards = _context.MenuCards;
            return await menuCards.ToArrayAsync();
        }

        public async Task<IEnumerable<Menu>> GetMenusAsync()
        {
            await EnsureDatabaseCreatedAsync();
            var menus = _context.Menus.Include(m => m.MenuCard);
            return await menus.ToArrayAsync();
        }

        public async Task<Menu> GetMenuByIdAsync(int id) =>
            await _context.Menus.SingleOrDefaultAsync(m => m.Id == id);

        public async Task AddMenuAsync(Menu menu)
        {
            await _context.Menus.AddAsync(menu);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMenuAsync(Menu menu)
        {
            _context.Menus.Update(menu);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMenuAsync(int id)
        {
            var menu = await _context.Menus.SingleAsync(m => m.Id == id);
            _context.Remove(menu);
            await _context.SaveChangesAsync();
        }

        private async Task EnsureDatabaseCreatedAsync()
        {
            var init = new MenuCardDatabaseInitializer(_context);
            await init.CreateAndSeedDatabaseAsync();
        }
    }
}
