# 1.	Saga pattern mikroservis mimarisinde hangi sorunları çözmeye çalışır?
ACID prensiplerine uygun bir mimaride işlem tutarlılığını sağlamaya, hata yönetimi ve geri alma mekanizmaları oluşturmaya, verilerin bütünlüğünü ve izolasyonunu korumaya çalışır. Ayrıca mikroservislerin bağımsız ve ölçeklenebilir bir şekilde çalışmasını destekler, merkezi olmayan iş akışlarının yönetimini mümkün kılar,zayıf bağlantı problemini çözerek mikroservislerin birbirine sıkı sıkıya bağlı olmasını engeller, uzun süren işlemleri daha iyi yönetmeyi ve sistemin yanıt verilebilirliğini artırmayı hedefler,tekil kayıt tutarlılığını sağlamaya çalışır.

# 2.	Saga patterndeki choreography ve orchestration yaklaşımları arasındaki temel fark nedir?
Choreography ve orchestration arasında iletişim yöntemi,bağımsızlık ve karmaşıklık konusunda farklar olsa da, en temel fark kontrol mekanizmasıdır.Choreography yaklaşımında her mikroservis kendi kararını verirken, orchestration yaklaşımında kararlar merkez tarafından verilir.

# 3.	Orchestration Saga pattern avantajları ve dezavantajları nelerdir?
Avantajları; iş akışını takip etmek kolaydır,hata yönetimini yapmak ve geri alma işlemini uygulamak choreography yaklaşımına göre çok daha kolaydır,merkezi bir kontrol mekanizması olduğu için değişiklikleri uygulayacağımız yeri tespit etmek ve uygulamak kolaydır,karmaşık iş akışları için uygundur,tutarlılık oranı yüksektir.

Dezavantajları; merkezi birimden dolayı single point of failure riski oluşturabilir, mikroservis bağımsızlığını azaltabilir,süreç karmaşıklaşabilir çünkü merkez tüm süreci kontrol etmek zorundadır.

# 4.1. SAGA Pattern Design and State Machine Diagram
<img src="https://github.com/alpersargin42/sinergyIT_repository/blob/main/Image_1.png" width="800" height="512" />

<img src="https://github.com/alpersargin42/sinergyIT_repository/blob/main/Image_2.png" width="800" height="512" />

# 4.2. Her bir durumda, ilgili hizmetin başarılı ya da başarısız olması durumunda nasıl bir geçiş yapılacağını açıklayın.
Sipariş servis çalıştığında sipariş oluşturma aşamasına geçilir.Kontrol merkezi ilk olarak sipariş oluşturulabiliyor mu kontrol eder eğer oluşturulamıyorsa sipariş oluşturulamadı mesajıyla tekrar merkeze döner.Eğer oluşturulabiliyorsa sipariş oluşturulabiliyor mesajıyla birlikte stok kanalına geçer stok kanalından dönen mesaj stokta ürün bulunamadı şeklindeyse yine siparişi iptal et aşamasına geçer.Stokta ürün varsa yine merkeze dönüp ürünü rezerv etme kanalına geçer,burada da aynı şekilde olumsuz bir durum varsa ürün rezervini kaldırıp siparişi iptal eder.Rezerv durumu olumluysa bakiye kontrol kanalına geçerek bakiyeyi kontrol eder.Bakiye yetersiz ise yetersiz bakiye mesajıyla birlikte ürün rezervini kaldırarak siparişi iptal eder.Eğer yeterli bakiye varsa ödeme işlemine gidilir.Ödeme işleminde bir aksaklık çıkarsa merkeze başarısız ödeme mesajıyla giderek ürün rezervini kaldırır ve siparişi iptal eder.Ödeme işlemi başarılıysa kargo teslim kanalına gidilir,kargo eslim kanalından olumsuz mesaj dönerse ödeme iade edilerek sipariş iptal edilir merkeze döner.Kargo işlemi başarılıysa sırasıyla hazırlık işlemi ve teslimat işlemi yapılarak sipariş tamamlanır ve merkeze olumlu mesaj döner.

# .NET'te Unit Test Yapma: -	.NET platformunda unit test yapma sürecini açıklayın ve örnek olarak Xunit ve Moq kütüphanelerini kullanarak bir unit test yazın.
## Açıklama: 
Unit testler, birim bazlı (bir metot veya sınıf) doğru çalışıp çalışmadığını kontrol etmek için yazılan küçük ve bağımsız testlerdir.Unit testler, birim bazlı çalıştığı için hızlıdır ve otomatik çalıştırılır.
Unit test yapmak için; xunit ve moq paketleri yüklendikten sonra test edilecek hedef metod belirlenir.Test class'ı oluşturulıp test kodları yazılıp run edildikten sonra test explorer ekranından tüm test sonuçlarını görüntüleyebiliriz.Unit testlerin 3 temel bileşeni vardır bunlar;
Arrange (Hazırlık): Test için gerekli nesneler ve giriş verileri hazırlanır.
Act (Eylem): Test edilen metot çağrılır.
Assert (Doğrulama): Çıktı, beklenen değerle karşılaştırılır.
Tüm bunların yanı sıra bağımlılıkları izole etmek için "mock"lama yöntemi kullanılarak gerçek veritabanı yerine mock nesne kullanılabilir.Ayrıca Fact ve Theory test türleri ile sabit senaryo (Fact) veya birden fazla verisetiyle aynı test yöntemi (Theory) kullanılabilir.(Bir sonraki soruda daha detaylı anlatılmıştır.)

## Kodlar: 
alpersargin42 -> sinergyIT -> Unit_Test

# Xunit ve Moq Temel Kavramları:-	Bu kütüphanelerde sıkça kullanılan fonksiyonları ve kavramları açıklayın. Özellikle aşağıdaki kavramlara odaklanın: -	Mocked object üretme: Testlerde bağımlılıkları izole etmek için nesneleri nasıl "mock"layabiliriz? -	Assert işlemleri: Beklenen ve gerçek değerleri doğrulama yöntemleri. -	Fact ve Theory: Farklı test senaryoları için Fact ve Theory kullanımını kod üzerinde uygulayalım.

## Kavramlar:
Mocked Object: Birim testlerinde bağımlılıkları taklit etmek ("mock"lamak) için kullanılan bir kütüphanedir. Bağımlılıkların gerçek implementasyonlarına ihtiyaç duymadan test yazmayı sağlar.
var mockedObj = new Mock<T>(); // Mock<T> şeklinde bir kullanımı vardır.

Setup: Mock nesnesinin bir yöntemi veya özelliği için beklenen davranışı tanımlar.

Verify: Bir yöntemin belirli bir çağrının yapılıp yapılmadığını doğrular.

Returns: Bir metodun döndüreceği sonucu tanımlar.

Callback: Bir metoda özel bir işlem veya yan etki tanımlamak için kullanılır.

It: Parametreler üzerinde koşul tanımlamak için kullanılır.It.IsAny<T>() komutu herhangi bir değeri kabul eder, It.Is<T>(predicate) komutu belirli bir koşulu sağlayan değerleri kabul eder.

Times: Bir metodun kaç kez çağrılması gerektiğini belirtir.Times.Once() komutu bir kez,Times.Never() komutu hiç çağrılmamalı,Times.Exactly(n) komutu belirli bir sayı kadar çağrılmalı anlamlarına gelir.

Assert: Test sonuçlarını doğrulamak için kullanılır. XUnit'de sık kullanılan Assert yöntemleri:
Assert.Equal(beklenen, gercek): Beklenen ve gerçek değeri karşılaştırır.
Assert.NotEqual(beklenen, gercek): Beklenen ve gerçek değerin farklı olduğunu doğrular.
Assert.True(durum): Koşulun doğru olduğunu kontrol eder.
Assert.Throws<ExceptionType>(() => action): Belirtilen türde bir hatanın atıldığını doğrular.

Fact: Basit ve bağımsız birim testleri yazmak için kullanılır.Sabit bir senaryo uygulanır, parametre almayan testler için uygundur.

Theory: Birden fazla veri kümesi ile aynı testin farklı varyasyonlarını çalıştırmak için kullanılır, veri kaynakları genellikle "InlineData" veya özel veri sağlayıcılar ile tanımlanır.

Setup: Test sınıflarını başlatmak için kullanılan mekanizmadır.

Cleanup: Test sınıflarını temizlemek için kullanılan mekanizmadır.IDisposable interface'i her testin ardından temizleme işlemleri için kullanılır.

Collection: Birden fazla test sınıfını gruplamak ve bu gruplar arasında ortak bir bağlam oluşturmak için kullanılır.

CollectionDefination: Ortak bir bağlam tanımlamak için kullanılır. Bu bağlam tüm test sınıfları tarafından paylaşılır.

## Kodlar:
alpersargin42 -> sinergyIT -> Test_Fact_Theory

# Repository Sınıfları Üzerinde Pratik: - Repository sınıfları için bir CRUD yapısı kurarak testler yazın. Bu süreçte Entity Framework Core kullanarak basit bir CRUD işlemi hazırlayın.-	Mapper’ı ve veritabanını mocklama işlemlerini nasıl yapacağınızı gösterin.-	Yerel bir veritabanı (MSSQL) kullanarak Visual Studio 2022'nin SQL Object Explorer'ı üzerinden bağlantı kurarak CRUD işlemlerini gerçekleştirin.

## Kodlar:
alpersargin42 -> sinergyIT -> Repository_Pratik

### Proje uygulama videosu (SQL Object Explorer CRUD): 
https://www.youtube.com/watch?v=74cTFhRVnLs

### Proje uygulama videosu (Swagger CRUD): 
https://www.youtube.com/watch?v=QaIwPw-C12o

## Kaynakça:
https://sefikcankanber.medium.com/saga-pattern-nedir-e4a447bef361
https://www.gencayyildiz.com/blog/microservice-mimarilerde-saga-pattern-ile-transaction-yonetimi/#google_vignette
https://www.gencayyildiz.com/blog/transact-sql-transaction/
https://burakneis.com/saga-pattern-distributed-transaction-handling/
https://ilaydakosar.com/microservice-mimarisinde-transaction-yonetimi-2pc-ve-saganin-karsilastirilmasi/
https://learn.microsoft.com/tr-tr/dotnet/core/testing/unit-testing-with-dotnet-test
https://www.gencayyildiz.com/blog/net-core-unit-test-nedir-nasil-yapilir-derinlemesine-inceleyelim/
https://orhanrecep90.medium.com/test-nedir-nette-birim-testler-nasıl-yazılır-a1c137189fc8
https://ismailkasan.medium.com/asp-nette-moq-kütüphanesi-ile-unit-test-yazımı-74a1b108b41d
https://orhunbegendi.medium.com/moqnun-efektif-kullanimi-mock-framework-net-53edb0141b82
https://medium.com/@e.karabudak7/net-core-ile-unit-test-xunit-eaf0d94edd71
https://www.gencayyildiz.com/blog/c-repository-design-patternrepository-tasarim-deseni/
https://medium.com/bilişim-hareketi/repository-ve-unit-of-work-tasarım-kalıbı-ve-uygulanması-9d471d617a9d
https://www.turkhackteam.org/konular/teknik-konular-generic-repository-pattern-ve-entity-framework-ihan3t.1578697/
