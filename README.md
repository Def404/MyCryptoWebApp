#  Веб приложение с методами шифрования

Данный проект был разработан для учебной программы "Криптографическая защита информации" РТУ МИРЭА. 
В нем представлены методы шифрования и расшифрования сообщения способом замены и перестановки.

#### В данном проекте были реализованы следующие методы шифрования:

- Шифр «Полибианский квадрат» (метод замены)
- Перестановка по таблице (метод перестановки)

## Шифр «Полибианский квадрат»

Такое название шифр получил благодаря его изобретателю – греческому историку Полибию. 
Ключом являлся квадрат размерностью n×n, который заполнялся алфавитом в случайном порядке. 
Для шифрования в квадрате Полибий находил букву текста и вставлял в шифровку нижнюю от нее в том же столбце. 
Если буква была в нижней строке – то для шифровки он выбирали верхнюю из того же столбца.

## Используемый алфавит

```text
'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф',
'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '-',
'.', ',', '!', '?', ';', ':', '(', ')', '[', ']', '{', '}', '_', '%', '#', '№', '@', '+', '/', '*'
```

## Перестановка по таблице

Таблицами для перестановки стали пользоваться в Эпоху Возрождения.
Ключом в них служат размер таблицы, фраза, задающая перестановку или
специальная особенность таблиц. 

Простая перестановка по таблице: для шифровки выбрать размер
таблицы (в зависимости от длины фразы), вписать открытый текст по
столбцам, тогда шифровка получается при считывании по строкам, для
усложнения шифротекст можно разбить на любое одинаковое количество букв.

Выписывать шифротекст из таблицы можно по строкам, столбцам,
прямой или обратной спирали, диагоналям, то есть шифровать и дешифровать
можно в различных направлениях. 

## Запуск в docker

```shell
docker compose up
```

## Запуск в Windows/Linux

Необходим dotnet 7

```shell
dotnet publish
```

В папке будет готовый проект, который можно запусть с помощью exe или dll файла

```text
bin/Debug/net7.0/publish
```