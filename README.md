# RetailRocketInterviewTest
## Settings
.Net Core 5 и выше <br>
Entity Framework Core (localhost) <br>
Удостоверьтесь что у вас установлен SQL Express.
________
## TASK
Интернет магазины часто предоставляют информацию о своем товарном каталоге в виде специального xml-файла в yml-формате.

Требуется написать приложение, которое способно выполнить 2 команды

Запуск dotnet run -- save <shopId> <url> приводит к скачиванию yml файла по указанному url, его парсингу и сохранению данных о товарах(id и name) в хранилище для магазина с указанным shopId.

Запуск dotnet run -- print <shopId> приводит к выводу в консоль текущего каталога магазина shopId (произвольная строка до 50 символов) из хранилища в csv формате (требования к формату).

Используемый .Core Runtime 3.1 или 5.0.
Для примера можно использовать следующие yml файлы:

https://drive.google.com/uc?export=download&confirm=Hp09&id=1sSR9kWifwjIP5qFWcyxGCxN0-MoEd_oo
