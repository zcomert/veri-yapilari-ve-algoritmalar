# SinglyLinkedList Merging

## Problem Tanımı: Bağlı Listeleri Birleştirme

Verilen iki bağımsız bağlı liste bulunmaktadır. Her iki bağlı liste de aynı türde elemanlara sahiptir. Bu bağlı listeleri birleştiren bir fonksiyon yazılması gerekmektedir.

## Giriş:

İki bağımsız bağlı liste başlangıç düğümleri olarak verilmektedir. Başlangıç düğümleri null olabilir.
Elemanlar aynı türdedir.

## Çıkış:

Birleştirilmiş bağlı listenin başlangıç düğümüdür.

## Kısıtlar:

Bağlı listelerde döngü olmadığı varsayılır.

## Problemin Çözümü:

İlk bağlı listenin son elemanının referansını ikinci bağlı listenin başına bağlayarak birleştirme işlemi gerçekleştirilir.
Eğer birinci bağlı liste boş ise, ikinci bağlı liste dönülür.
Eğer ikinci bağlı liste boş ise, birinci bağlı liste dönülür.

## Çözümü

Hazırladığınız kodları SinglyLinkedList<T> sınıfı içerisine ``static`` bir metot olacak şekilde tasarlayınız. 

İlgili problem çözümü için test yazınız. 

```csharp
public class SinglyLinkedList<T> : IEnumerable<T>
    {
        public static SinglyLinkedList<T> Concatenate(SinglyLinkedList<T> l1, 
            SinglyLinkedList<T> l2)
        {
            throw new NotImplementedException();
        }
    }
``