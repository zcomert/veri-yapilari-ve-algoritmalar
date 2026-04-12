# Veri Yapıları ve Algoritmalar

Veri yapıları ve algoritmaları, bilgisayar bilimlerinin temel taşlarıdır ve bilgisayar biliminin en önemli alanlarından birini oluştururlar. 

Veri yapıları, bilgisayar programlarında bilgiyi düzenlemek, depolamak ve işlemek için kullanılan yapılardır. Algoritmalar ise belirli bir problemi çözmek veya belirli bir görevi gerçekleştirmek için adım adım talimatları tanımlayan mantıksal işlemlerdir. Bu iki kavram, yazılım geliştirme sürecinde temel bir rol oynar; verimli ve etkili bir şekilde veri yönetimi ve işlemleri için gereklidirler. 

Veri yapılarının ve algoritmaların iyi anlaşılması, yazılım geliştiricilerin performansı, kodun optimize edilmesi ve hata ayıklama süreçlerinde kritik öneme sahiptir. Bu nedenle, bilgisayar bilimleri alanında çalışan herkesin, veri yapıları ve algoritmaları öğrenmesi ve ustalaşması gerekmektedir.

Bu kod deposu, Samsun Üniversitesi, Bilgisayar ve Bilişim Bilimleri Fakültesi, Yazılım Mühendisliği Bölümü YZM202 Veri Yapıları ve Algoritmalar ve YMZ204 Veri Yapıları ve Algoritmalar Lab. dersine ait içerikleri kapsamaktadır. 

## Discord

Derslere ait tartışmalara katılmak, ek materyallere erişmek ve anlık bildirimleri almak üzere lütfen *Discord* kanalı üye olunuz. 

> Discord'a erişim ülkemizde şu an yasak olduğu için yeni üye kayıtları durdurulmuştur.

## Proje Altyapısı

Bu repo, `VeriYapilariAlgoritmalar.sln` altında toplanan çok projeli bir .NET çözümüdür. İçerik; veri yapıları, sıralama algoritmaları, örnek console uygulamaları, yardımcı kütüphaneler ve bunlara ait test projelerinden oluşur. Çözüm yapısı eğitim odaklıdır; ancak modüler proje ayrımı sayesinde geliştirme, test ve bakım süreçleri düzenli ilerler.

### Kullanılan Teknoloji ve Şablonlar

- Tüm projeler `Microsoft.NET.Sdk` tabanlıdır.
- Çözümdeki tüm `csproj` dosyaları `net10.0` hedef framework'üne geçirilmiştir.
- Proje tipleri ağırlıklı olarak `class library`, `console application` ve `xUnit test project` yapılarından oluşur.
- Test tarafında `xUnit`, `Microsoft.NET.Test.Sdk` ve `coverlet.collector` kullanılmaktadır.
- Çözümde aktif bir `mvc` projesi bulunmamaktadır.

### Çözüm Organizasyonu

#### `Applications`

Bu klasör altında örnek kullanım ve problem çözümü amaçlı console projeleri yer alır:

- `DataTypeConsoleApp`
- `DataMinMax`
- `LinkedListConsoleApp`
- `Brackets`

Bu projeler, sınıf kütüphanelerinde geliştirilen veri yapılarının ve algoritmaların terminal üzerinden çalıştırılmasını sağlar.

#### `DataStructures`

Temel veri yapıları ayrı class library projeleri olarak düzenlenmiştir:

- `Array`
- `LinkedList`
- `Stack`
- `Queue`

Bu yaklaşım, her veri yapısının bağımsız geliştirilmesini ve diğer projeler tarafından referans verilerek yeniden kullanılmasını kolaylaştırır.

#### `SortingAlgorithms`

Sıralama algoritmaları bu klasörde ayrı bir kütüphane olarak tutulur. `SortingAlgorithms` projesi, ortak yardımcı işlevler için `Shared/Utilities` projesine referans verir. Böylece algoritma kodu ile yardımcı altyapı birbirinden ayrılmış olur.

#### `Shared`

`Shared/Utilities` projesi, birden fazla proje tarafından kullanılabilecek ortak yardımcı bileşenleri içerir. Bu katman, tekrar eden kodun merkezileştirilmesini sağlar.

#### `Tests`

Test projeleri hem `Tests` hem de `YZM204/Tests` altında yer alır. Bu testler veri yapıları, uygulama projeleri ve algoritma projeleri için doğrulama sağlar. Örnek test projeleri:

- `ArrayTests`
- `LinkedListTests`
- `StackTests`
- `QueueTests`
- `BracketTests`
- `DataMinMaxTests`
- `DataTypeConsoleAppTests`
- `SortingAlgorithmsTests`
- `ConversionTests`
- `InSystemDataStructureTest`

### Mimari Yaklaşım

Çözümün temel yaklaşımı şu şekildedir:

- Çekirdek veri yapıları ve algoritmalar `class library` projelerinde geliştirilir.
- Kullanım senaryoları `console` projeleri üzerinden gösterilir.
- Davranış doğrulaması `xUnit` test projeleriyle yapılır.
- Ortak yardımcı kodlar ayrı bir `shared` katmanda toplanır.

Bu yapı, ders içeriğinin parça parça ilerletilmesine uygun olduğu gibi, her modülün bağımsız test edilmesini ve gerektiğinde yeni projelerin aynı çözüm içine eklenmesini de kolaylaştırır.

### Kısa Değerlendirme

Bu repo için proje altyapısı özetle:

> `.NET 10`
>
> `class library`
>
> `xUnit`
>
> `console`

şeklinde tanımlanabilir. Önceki kısa tanımda geçen `mvc` ifadesi mevcut çözüm yapısıyla örtüşmemektedir; güncel çözüm daha doğru biçimde class library, console ve test projeleri ekseninde yapılandırılmıştır.

## Hafta 01
- Veri Yapıları ve Algoritmalara Giriş
- Veri, bilgi ve soyut veri tipi kavramları
- Algoritma nedir, neden önemlidir
- Problem çözümünde algoritmik düşünme
- Veri yapılarının yazılım geliştirmedeki rolü

## Hafta 02
- Array
- Dizi yapısının temel özellikleri
- Bellek yerleşimi ve indis mantığı
- Dizilerde erişim, güncelleme ve dolaşma
- Statik ve dinamik dizi yaklaşımı

## Hafta 03
- Collections
- Koleksiyon kavramına giriş
- Generic ve non-generic koleksiyonlar
- `List`, `Dictionary`, `HashSet` yapılarının kullanımı
- Doğru koleksiyon seçimi için temel ölçütler

## Hafta 04
- LinkedList
- Node yapısı ve referans mantığı
- Singly linked list ve doubly linked list
- Başa, sona ve araya ekleme işlemleri
- Silme, arama ve liste üzerinde gezinme

## Hafta 05
- Stack
- LIFO mantığı
- Push, Pop ve Peek işlemleri
- Dizi tabanlı stack tasarımı
- Bağlı liste tabanlı stack tasarımı

## Hafta 06
- Queue
- FIFO mantığı
- Enqueue, Dequeue ve Front işlemleri
- Dizi tabanlı queue yaklaşımı
- Bağlı liste tabanlı queue yaklaşımı

## Hafta 07
- Time Complexity
- Zaman karmaşıklığına giriş
- Big-O gösterimi
- En iyi, ortalama ve en kötü durum analizi
- Veri yapılarında işlem maliyetlerinin karşılaştırılması

## Hafta 08
- Sorting Algorithms
- Sıralama probleminin temelleri
- Bubble Sort ve Selection Sort
- Insertion Sort ve Merge Sort
- Quick Sort ve algoritmaların performans karşılaştırması

## Hafta 09
- Tree
- Ağaç veri yapısının temel kavramları
- Kök, ebeveyn, çocuk, yaprak ve derinlik kavramları
- Ağaç yapılarının kullanım alanları
- Ağaçlarda gezinme mantığına giriş

## Hafta 10
- Binary Tree
- Binary tree tanımı ve özellikleri
- Binary tree oluşturma mantığı
- Preorder, Inorder ve Postorder dolaşmaları
- Binary tree üzerinde temel işlemler

## Hafta 11
- Binary Search Tree
- BST yapısının kuralları
- Arama, ekleme ve silme işlemleri
- Minimum ve maksimum değer bulma
- BST performansı ve dengesiz ağaç problemi

## Hafta 12
- Priority Queue
- Öncelik kavramı ve standart kuyruktan farkı
- Priority queue kullanım senaryoları
- Heap tabanlı priority queue yaklaşımı
- Min-Heap ve Max-Heap ilişkisi

## Hafta 13
- Graph
- Graf veri yapısına giriş
- Düğüm ve kenar kavramları
- Yönlü, yönsüz, ağırlıklı ve ağırlıksız grafikler
- Komşuluk matrisi ve komşuluk listesi gösterimleri

## Hafta 14
- Graph based Algorithms
- BFS ve DFS algoritmaları
- En kısa yol problemlerine giriş
- Minimum spanning tree kavramı
- Grafik tabanlı gerçek yaşam problemleri
