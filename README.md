# NETLab4

Музика Стефан
ІС-02
11-й варіант
![image](https://user-images.githubusercontent.com/76735417/175929169-18db9aa1-3a78-4118-966d-0d1443f7e6ee.png)
ОРПЗ .NET 4-а ЛР

Патерн «Компанувальник» реалізований класами Component, Composite, і Leaf. Вони представляють деревоподібну структуру виразу. Component – абстрактний клас, що описує частину виразу (складна або проста), Composite – складний вираз, Leaf – простий вираз (константа або змінна). Connect – клас, що описує математичні оператори (*, /, +, -). Part – абстрактний клас, що описує види даних: Number – константу, та Variable – змінну.
Власне, перетворює виразу у дерево виразів статичний клас ExpressionParser.
![Untitled Diagram drawio (3)](https://user-images.githubusercontent.com/76735417/175928544-718a698c-7b08-47d1-9b27-7e4b15d12859.png)
