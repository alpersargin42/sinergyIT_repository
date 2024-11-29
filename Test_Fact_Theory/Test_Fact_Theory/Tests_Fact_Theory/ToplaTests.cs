using Xunit;
namespace Test_Fact_Theory.Tests_Fact_Theory
{
    public class ToplaTests
    {
        [Fact]
        public void Sabit_Deger_Test()
        {
            // nesne üretme
            var topla = new Toplama();

            // işlem
            var sonuc = topla.Topla(2, 3);

            // test etme (Fact,verilen sabit değer ile test eder.)
            Assert.Equal(5, sonuc);
        }

        [Theory]
        [InlineData(2, 3, 5)]  // 2 + 3 = 5
        [InlineData(1, 1, 2)]  
        [InlineData(-1, -1, -2)] 
        public void Belirlenen_Deger_Test(int sayi1, int sayi2, int beklenen)
        {
            // nesne üretme
            var topla = new Toplama();

            // işlem
            var sonuc = topla.Topla(sayi1, sayi2);

            // test etme (Theory,belirlenen değer ile test eder.)
            Assert.Equal(beklenen, sonuc);
        }
    }
}
