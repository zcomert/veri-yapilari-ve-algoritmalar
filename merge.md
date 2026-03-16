# SinglyLinkedList.Merge Metodu Gerçekleştirim Planı

## 1. Amaç
`SinglyLinkedList<T>` sınıfına, parametre olarak verilen başka bir `SinglyLinkedList<T>` nesnesini mevcut listeye bağlayacak (birleştirecek) bir `Merge` metodu eklenmesi.

## 2. Metot İmzası
```csharp
public void Merge(SinglyLinkedList<T> otherList)
```

## 3. Algoritma ve Adımlar
1. **Parametre Kontrolü:** Eğer parametre olarak gelen `otherList` null ise veya boşsa (`otherList.Head == null`), hiçbir işlem yapmadan fonksiyondan çıkılır.
2. **Mevcut Listenin Boş Olma Durumu:** Eğer işlem yapılan (mevcut) liste boşsa (`this.Head == null`), mevcut listenin `Head` referansına `otherList`'in `Head` referansı atanır. Listenin `_count` özelliğine `otherList.Count` eklenir ve metot sonlandırılır.
3. **Mevcut Liste Doluysa:** Liste boş değilse, mevcut listenin en son düğümünü (node) bulmak için `Head`'den başlanarak listenin sonuna kadar (`curr.Next != null`) gezinilir.
4. **Listelerin Bağlanması:** Mevcut listenin son düğümünün `Next` referansına, `otherList`'in `Head` düğümü atanır. Böylece iki liste uç uca eklenmiş olur.
5. **Kapasite Güncellemesi:** Mevcut listenin `_count` değişkeni, `otherList.Count` kadar artırılarak toplam eleman sayısı güncellenir.

## 4. Dikkat Edilmesi Gereken Noktalar
- **Performans (Zaman Karmaşıklığı):** Son elemanı bulmak için liste üzerinde dolaşmak gerektiğinden çalışma zamanı **O(N)**'dir (N: ilk listenin eleman sayısı). Eğer yapıda bir `Tail` (kuyruk) referansı bulunsaydı bu işlem O(1)'de gerçekleştirilebilirdi.
- **Referans Paylaşımı:** Düğümler kopyalanmadığı, sadece referanslar bağlandığı için birleştirme sonrasında orijinal `otherList` üzerinde yapılabilecek değişiklikler birleşen listeyi de etkileyecektir.
