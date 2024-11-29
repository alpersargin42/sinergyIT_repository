using Moq;
using Xunit;
using Unit_Test.Abstract;
using Unit_Test.Concrate;
using Unit_Test.Repository;

public class KitapRepositoryTests
{
    //class_public değişkenler
    private readonly Mock<IKitapRepository> _mockKitapRepo;
    private readonly KitapRepository _kitapRepository;

    //constructor
    public KitapRepositoryTests()
    {
        _mockKitapRepo = new Mock<IKitapRepository>();
        _kitapRepository = new KitapRepository();
    }

    [Fact]
    public void mevcutKitap() //bulunan kitabı getirme mevcut kitabı mocklama işlemi.
    {
        // test verisi (Arrange)
        var kitap = new Kitap { Id = 1, Ad = "Melekler ve Şeytanlar", Yazar = "Dan Brown", YayinYili = 2004 };
        _mockKitapRepo.Setup(repo => repo.Getir(1)).Returns(kitap);

        // test edilecek yöntem (act)
        var sonuc = _mockKitapRepo.Object.Getir(1);

        // doğrulama(Assert)
        Assert.NotNull(sonuc);
        Assert.Equal(kitap.Ad, sonuc.Ad);
    }

    [Theory]
    [InlineData(1, "Başlangıç", "Dan Brown", 2017)]
    [InlineData(2, "Suç ve Ceza", "Dostoyevski", 1866)]
    public void yeniKitap(int id, string ad, string yazar, int yayinYili) //yeni kitaplar listeye eklenir.
    {
        // verileri class'a gönder
        var kitap = new Kitap { Id = id, Ad = ad, Yazar = yazar, YayinYili = yayinYili };

        // kitapları ekle
        _kitapRepository.Ekle(kitap);

        // doğrula
        var eklenenKitap = _kitapRepository.Getir(id);
        Assert.NotNull(eklenenKitap);
        Assert.Equal(ad, eklenenKitap.Ad);
    }
}