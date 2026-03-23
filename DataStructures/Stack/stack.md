# Stack (Yığın) Veri Yapısı ADT Planı

Bu belge, Stack (Yığın) veri yapısı için Soyut Veri Tipi (ADT) tasarımını açıklar. Stack, LIFO (Last-In, First-Out - Son Giren İlk Çıkar) prensibiyle çalışan bir veri yapısıdır.

## Tanımlanacak İşlevler

1.  **Push(T item)**: 
    - **Açıklama**: Yığının en üstüne yeni bir eleman ekler.
    - **Neden**: LIFO prensibine göre veri ekleme işleminin temelini oluşturur.

2.  **Pop()**: 
    - **Açıklama**: Yığının en üstündeki elemanı yığından çıkarır ve döndürür.
    - **Neden**: Veri yapısından eleman eksiltmek ve o veriyi işlemek için kullanılır.

3.  **Peek()**: 
    - **Açıklama**: Yığının en üstündeki elemanı çıkarmadan sadece değerini döndürür.
    - **Neden**: Yığının durumunu bozmadan en üstteki elemanı kontrol etmek için gereklidir.

4.  **Count**: 
    - **Açıklama**: Yığındaki toplam eleman sayısını döndürür.
    - **Neden**: Yığının boyutunu takip etmek ve sınır kontrolleri yapmak için kullanılır.

5.  **IsEmpty**:
    - **Açıklama**: Yığının boş olup olmadığını kontrol eder.
    - **Neden**: Yığının boş olduğu durumlarda Pop veya Peek işlemlerinden kaçınmak için kontrol mekanizmasıdır.

6.  **Clear()**:
    - **Açıklama**: Yığındaki tüm elemanları temizler.
    - **Neden**: Veri yapısını hızlıca sıfırlamak için ihtiyaç duyulur.

## Teknik Detaylar
- **Generic Yapı**: `IStack<T>` interface'i generic olarak tanımlanarak her türlü veri tipiyle esnek bir şekilde çalışması sağlanacaktır.
- **İstisnalar**: Boş bir yığında `Pop` veya `Peek` işlemleri yapıldığında fırlatılacak hatalar implementasyon aşamasında ele alınacaktır.
