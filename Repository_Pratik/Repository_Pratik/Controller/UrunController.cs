using Microsoft.AspNetCore.Mvc;
using Repository_Pratik.Databases.Models;
using Repository_Pratik.DTO;
using Repository_Pratik.Services;

namespace Repository_Pratik.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrunController : ControllerBase
    {
        private readonly UrunServisi _urunServisi;

        // urunServisi'ni inject etme komutu
        public UrunController(UrunServisi urunServisi)
        {
            _urunServisi = urunServisi;
        }

        // ürünleri listeleme
        [HttpGet]
        public async Task<IActionResult> GetUrunler()
        {
            // urunServisi'ni kullanarak DTO'ya(data transfer object) dönüştürülmüş ürünleri alıyoruz
            var urunler = await _urunServisi.UrunleriListeleAsync();
            return Ok(urunler); // DTO olarak döndürüyoruz
        }

        // ID'ye göre ürün getirme
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUrunById(int id)
        {
            var urun = await _urunServisi.UrunGetirAsync(id); // servisten DTO almak
            if (urun == null)
            {
                return NotFound();
            }

            return Ok(urun); // DTO olarak döndürüyoruz
        }

        // yeni ürün ekleme
        [HttpPost]
        public async Task<IActionResult> CreateUrun([FromBody] UrunDTO urunDto)  // [FromBody] ekliyoruz
        {
            // DTO'yu model'e dönüştürüp ekliyoruz
            await _urunServisi.UrunEkleAsync(urunDto);
            return CreatedAtAction(nameof(GetUrunById), new { id = urunDto.Id }, urunDto);
        }

        // var olan ürünü güncelleme
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUrun(int id, [FromBody] UrunDTO urunDto)  // [FromBody] ekliyoruz
        {
            if (id != urunDto.Id)
            {
                return BadRequest();
            }

            // DTO'yu model'e dönüştürüp güncelliyoruz
            await _urunServisi.UrunGuncelleAsync(urunDto);
            return NoContent();
        }

        // ürün silme
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUrun(int id)
        {
            await _urunServisi.UrunSilAsync(id);
            return NoContent();
        }
    }
}
