# SpeechPro

### 1. Реализовать систему шифрования методом Виженера:
Сигнатура метода шифрования:

    string Encrypt(string source, string key);

Сигнатура метода расшифрования:

    string Dencrypt(string encrypted, string key);

Плюсом будет, если кандидат реализует сигнатуры:

Сигнатура метода шифрования:

    IEnumerable<string> Encrypt(IEnumerable<string>source, string key);

Сигнатура метода расшифрования:

    IEnumerable<string> Dencrypt(IEnumerable<string> encrypted, string key);



### 2. Реализовать брокер сообщений:
Сигнатура брокера для публикации:

    void Post(IMessage message);

Сигнатура брокера для подписки:

    void Subscribe(ISubscriber Subscriber);
    void Unsubscribe(ISubscriber Subscriber);

Содержимое **IMessage** и **ISubscriber** определить кандидатом.


### Требования к решениям:
1. Основное ядро должно быть написано кандидатом.
2. Предоставляемый код должен собираться и работать.
3. Функционал должен быть покрыт минимальным набором тестов.
4. Стиль кодирования должно соответствовать МS