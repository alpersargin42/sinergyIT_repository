using Moq;
using Repository_Pratik.Databases.Models;
using Repository_Pratik.Databases.Storage;
using Xunit;

namespace Repository_Pratik.Tests
{
    public class UrunTesti
    {
        private readonly Mock<UrunDeposu> _mockUrunDeposu;

        public UrunTesti()
        {
            _mockUrunDeposu = new Mock<UrunDeposu>(null);
        }
        // fact ile sabit test
        [Fact]
        public async Task UrunEkle_Test()
        {
            var urun = new Urun { Ad = "Telefon", Fiyat = 7000 };

            await _mockUrunDeposu.Object.UrunEkleAsync(urun);

            _mockUrunDeposu.Verify(m => m.UrunEkleAsync(urun), Times.Once);
        }

        // theory ile parametreli test
        [Theory]
        [InlineData("Tablet", 1000)]
        [InlineData("Bilgisayar", 15000)]
        public async Task UrunEkle_Theory_Test(string urunAd, decimal urunFiyat)
        {
            var urun = new Urun { Ad = urunAd, Fiyat = urunFiyat };

            await _mockUrunDeposu.Object.UrunEkleAsync(urun);

            _mockUrunDeposu.Verify(m => m.UrunEkleAsync(urun), Times.Once);
        }
    }
}
