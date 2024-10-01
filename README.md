Веб-приложение ASP.NET Core, которое предоставляет CRUD-операции для управления контактами. Приложение использует базу данных в оперативной памяти для хранения информации о контактах 
и предоставляет конечные точки для создания, чтения, обновления и удаления контактов.

Возможности
Создание/Обновление контакта: Добавление нового контакта или обновление существующего.
Получение контакта по ID: Извлечение конкретного контакта по его уникальному идентификатору.
Получение всех контактов: Извлечение списка всех контактов.
Удаление контакта по ID: Удаление контакта по его уникальному идентификатору.
Документация Swagger: Автоматически сгенерированная документация API с использованием Swagger UI.

Технологический стек:
  ASP.NET Core 6.0+
  Entity Framework Core (In-Memory Database)
  Swagger / OpenAPI
  C#
Предварительные требования
  .NET 6 SDK или выше
  Visual Studio или VS Code
  Postman (опционально, для тестирования API)
Начало работы
1. Клонируйте репозиторий:
  git clone https://github.com/your-repository/ContactManagerAPI.git
2. Перейдите в директорию проекта:
  cd ContactManagerAPI
3. Соберите проект:
  dotnet build
4. Запустите проект:
  dotnet run
По умолчанию приложение будет запущено на https://localhost:5001.

5. Доступ к Swagger UI
Перейдите по следующему адресу в браузере для просмотра и тестирования API через Swagger UI:
  https://localhost:5001/swagger
  
1. Создание или обновление контакта
Метод: POST
Адрес: /api/ContactManager/CreateEdit
Тело запроса:
json
Copy code
{
  "id": 0, // Укажите 0 для нового контакта или ID для обновления существующего.
  "name": "Иван Иванов",
  "email": "ivan@example.com",
  "phoneNumber": "1234567890"
}
Ответ:
Успех: Возвращает созданный/обновленный объект контакта.
Ошибка: Возвращает сообщение об ошибке.
2. Получение контакта по ID
Метод: GET
Адрес: /api/ContactManager/GetById?id={id}
Ответ:
Успех: Возвращает объект контакта с указанным ID.
Ошибка: Возвращает сообщение об ошибке, если контакт не найден.
3. Получение всех контактов
Метод: GET
Адрес: /api/ContactManager/GetAll
Ответ: Возвращает список всех контактов.
4. Удаление контакта по ID
Метод: DELETE
Адрес: /api/ContactManager/DeleteById?id={id}
Ответ:
Успех: Возвращает сообщение об успешном удалении контакта.
Ошибка: Возвращает сообщение об ошибке, если контакт не найден.
Структура проекта
plaintext
Copy code
ContactManagerAPI/
  Controllers/
    ContactManagerController.cs  // Обрабатывает API-запросы
  Data/
    ApiContext.cs                // Контекст базы данных Entity Framework
  Models/
    Contact.cs                   // Модель контакта
  Program.cs                     // Основная точка входа и настройки
  appsettings.json               // Файл настроек конфигурации
  Properties/
  launchSettings.json            // Настройки запуска для разработки
Entity Framework (In-Memory Database)
API использует провайдер In-Memory базы данных Entity Framework Core для хранения контактов во время выполнения. База данных сбрасывается при каждом перезапуске приложения.

Тестирование API
Вы можете использовать Postman или Swagger UI для тестирования конечных точек API. 

Пример POST-запроса:
POST /api/ContactManager/CreateEdit
Content-Type: application/json
{
    "id": 0,
    "name": "Анна Иванова",
    "email": "anna.ivanova@example.com",
    "phoneNumber": "+7777654321"
}

Пример GET-запроса:
GET /api/ContactManager/GetById?id=1
