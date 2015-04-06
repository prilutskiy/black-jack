#### Black Jack
A game of cards

####Прилуцкий Максим Петрович

Гуппа 250502

####Тема проекта:

Клиент-серверное приложение-игра "Black Jack"
В процессе разработки будет использоваться модель ветвления [Git Flow](http://habrahabr.ru/post/106912/)

####Краткое описание:

Логика находится на сервере, игроки подсоединяются по сети к серверу и играют. Весь игровой процесс, данные, статистика хранятся на серверной стороне и передаются клиентам через сеть, клиент отвечает лишь за GUI (т.н. [Тонкий клиент] (https://ru.wikipedia.org/wiki/%D0%A2%D0%BE%D0%BD%D0%BA%D0%B8%D0%B9_%D0%BA%D0%BB%D0%B8%D0%B5%D0%BD%D1%82)). 

#####Спецификация серверной части

Для игры пользователи должны будут зарегистрироваться. Информация о пользователях будет храниться в базе данных MS SQL Server, механизм доступа к данным - Entity Framework (Code first).

Серверное приложение содержит GUI и поддерживает вывод некоторой системной информации, логов. Серверный модуль также поддерживает механизм плагинов.

#####Спецификация клиентской части

*Возможно будет использоваться Unity/XNA для реализации красивого GUI.*
Клиентское приложение подключается к серверному через сеть. Конфигурация подключения к серверу (адрес, порт) устанавливается в специальном меню. Есть возможность просмотр статистики игроков: как общий топ пользователей, так и своё положение в рейтинге. Возможен просмотр игроков, которые онлайн в данный момент (*опционально: обмен сообщениями между игроками, обмен игровой валютой*).
