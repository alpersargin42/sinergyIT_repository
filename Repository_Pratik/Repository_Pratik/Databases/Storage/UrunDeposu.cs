using Microsoft.EntityFrameworkCore;
using Repository_Pratik.Databases.DbContext;
using Repository_Pratik.Databases.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository_Pratik.Databases.Storage
{
    public class UrunDeposu
    {
        private readonly UrunDbContext _context;

        // constructor
        public UrunDeposu(UrunDbContext context)
        {
            _context = context;
        }

        // tüm ürünleri asenkron olarak getirme methodu
        public async Task<List<Urun>> UrunleriListeleAsync()
        {
            return await _context.Urunler.ToListAsync();
        }

        // ID'ye göre ürünü getirme methodu
        public async Task<Urun> UrunGetirByIdAsync(int id)
        {
            return await _context.Urunler.FindAsync(id);
        }

        // yeni bir ürün ekleme methodu
        public async Task UrunEkleAsync(Urun urun)
        {
            await _context.Urunler.AddAsync(urun);
            await _context.SaveChangesAsync();
        }

        // var olan ürünü güncelleme methodu
        public async Task UrunGuncelleAsync(Urun urun)
        {
            _context.Urunler.Update(urun);
            await _context.SaveChangesAsync();
        }

        // ürünü silme methodu
        public async Task UrunSilAsync(int id)
        {
            var urun = await _context.Urunler.FindAsync(id);
            if (urun != null)
            {
                _context.Urunler.Remove(urun);
                await _context.SaveChangesAsync();
            }
        }
    }
}