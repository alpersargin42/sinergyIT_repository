using AutoMapper;
using Repository_Pratik.Databases.Models;
using Repository_Pratik.Databases.Storage;
using Repository_Pratik.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository_Pratik.Services
{
    public class UrunServisi
    {
        private readonly UrunDeposu _urunDeposu;
        private readonly IMapper _mapper;

        // constructor
        public UrunServisi(UrunDeposu urunDeposu, IMapper mapper)
        {
            _urunDeposu = urunDeposu;
            _mapper = mapper;
        }

        public async Task UrunEkleAsync(UrunDTO urunDto)
        {
            var urun = _mapper.Map<Urun>(urunDto);
            await _urunDeposu.UrunEkleAsync(urun);
        }

        public async Task<List<UrunDTO>> UrunleriListeleAsync()
        {
            var urunler = await _urunDeposu.UrunleriListeleAsync();
            return _mapper.Map<List<UrunDTO>>(urunler);
        }

        public async Task UrunGuncelleAsync(UrunDTO urunDto)
        {
            var urun = _mapper.Map<Urun>(urunDto);
            await _urunDeposu.UrunGuncelleAsync(urun);
        }

        public async Task UrunSilAsync(int id)
        {
            await _urunDeposu.UrunSilAsync(id);
        }

        public async Task<UrunDTO> UrunGetirAsync(int id)
        {
            var urun = await _urunDeposu.UrunGetirByIdAsync(id);
            return _mapper.Map<UrunDTO>(urun);
        }
    }
}