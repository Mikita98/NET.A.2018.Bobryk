# NET.A.2018.Bobryk
## Задачи
### Day 14
- Реализовать метод-генератор последовательности чисел Фибоначчи. Разработать unit-тесты. 
[Решение](https://github.com/Mikita98/NET.A.2018.Bobryk/tree/master/NET.A.2018.Bobryk.14)
    
- Реализовать обобщенный алгоритм бинарного поиска (добавить в проект с методами сортировки). Методы сортировки преобразовать в обобщенные. Разработать unit-тесты.
[Решение](https://github.com/Mikita98/NET.A.2018.Bobryk/tree/master/Day%201/BinarySearch)

- Добавить в статический класс с обобщенными методами-трансформерами обобщенные методы-фильтры (реализовать как методы расширения) получения из набора данных типа TSource набора данных типа TSource, логику попадания в результирующий набор инкупсулировать в функции-предикате (рассмотреть два подхода - объектно-ориентированый и функциональный). В качестве тест-кейсов для метода-фильтра можно использовать, напимер, для строк - соответствие определенном шаблону, соответствие определенной длине и т.д. для целых чисел - наличие определенной цифры в числе, простота, четность и т.д.
[Решение](https://github.com/Mikita98/NET.A.2018.Bobryk/blob/master/NET.A.2018.Bobryk.4/Transforming/Transforming.cs) 

### Day 15

- Разработать обобщенный типизированный класс-коллекцию Queue, реализующий основные операции для работы с очередью, и предоставляющий возможность итерирования по ней, реализовав итератор «вручную» (без использования блок-итератора yield). Протестировать методы (NUnit) разработанного класса c использованием типов BCL и кастомных типов, как реализующих, так и не рализующих интерфейс IEquetable, как переопределяющих, так и не переопределяющих виртуальный метод Equals типа System.Object.
[Решение](https://github.com/Mikita98/NET.A.2018.Bobryk/blob/master/NET.A.2018.Bobryk.15/Queue/Queue.cs)

### Day 16

- Разработать обобщенный класс-коллекцию [BinarySearchTree](https://github.com/Mikita98/NET.A.2018.Bobryk/blob/master/NET.A.2018.Bobryk..16/BinarySearchTree/BinarySearchTree.cs) (бинарное дерево поиска). Предусмотреть возможности использования подключаемого интерфейса для реализации отношения порядка. Реализовать три способа обхода дерева: прямой (preorder), поперечный (inorder), обратный (postorder): для реализации использовать блок-итератор (yield). Протестировать разработанный класс, используя следующие типы:
1. System.Int32 (использовать сравнение по умолчанию и [подключаемый компаратор](https://github.com/Mikita98/NET.A.2018.Bobryk/blob/master/NET.A.2018.Bobryk..16/BinarySearchTree.Test/CustomComparers/IntComparer.cs));
2. System.String (использовать сравнение по умолчанию и [подключаемый компаратор](https://github.com/Mikita98/NET.A.2018.Bobryk/blob/master/NET.A.2018.Bobryk..16/BinarySearchTree.Test/CustomComparers/StringComparer.cs));
3. пользовательский класс Book, для объектов которого реализовано отношения порядка (использовать сравнение по умолчанию и [подключаемый компаратор](https://github.com/Mikita98/NET.A.2018.Bobryk/blob/master/NET.A.2018.Bobryk..16/BinarySearchTree.Test/CustomComparers/BookComparer.cs));
4. пользовательскую структуру Point, для объектов которого не реализовано отношения порядка (использовать [подключаемый компаратор](https://github.com/Mikita98/NET.A.2018.Bobryk/blob/master/NET.A.2018.Bobryk..16/BinarySearchTree.Test/CustomComparers/PointComparer.cs)).

### Day 19

- В текстовом файле построчно хранится информация об URL-адресах, представленных в виде где сегмент parameters - это набор пар вида key=value, при этом сегменты URL‐path и parameters или сегмент parameters могут отсутствовать. Разработать систему типов (руководствоваться принципами SOLID) для экспорта данных, полученных на основе разбора информации текстового файла, в XML-документ по следующему правилу, например, для текстового файла с URL-адресами.


[Решение](https://github.com/Mikita98/NET.A.2018.Bobryk/tree/master/NET.A.2018.Bobryk.19)
