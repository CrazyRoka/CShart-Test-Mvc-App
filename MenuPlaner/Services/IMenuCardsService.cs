using MenuPlaner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuPlaner.Services
{
    public interface IMenuCardsService
    {
        Task AddMenuAsync(Menu menu);
        Task DeleteMenuAsync(int id);
        Task<Menu> GetMenuByIdAsync(int id);
        Task<IEnumerable<Menu>> GetMenusAsync();
        Task<IEnumerable<MenuCard>> GetMenuCardsAsync();
        Task UpdateMenuAsync(Menu menu);
    }
}
