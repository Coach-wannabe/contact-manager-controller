# Contact Manager API

## Обзор
**Contact Manager API** — это простой RESTful веб-API, созданный с использованием ASP.NET Core, Entity Framework Core и встроенной базы данных (In-Memory). Он позволяет пользователям управлять контактной информацией, включая добавление, обновление, получение и удаление контактов.

## Функциональные возможности
- **Операции CRUD**: API поддерживает операции создания, чтения (одного и нескольких контактов), обновления и удаления контактов.
- **Swagger UI**: Интегрирован Swagger UI для исследования и тестирования конечных точек API.
- **Встроенная база данных**: Использует встроенную базу данных для простой настройки и тестирования.
- **Обработка ошибок**: Реализована базовая обработка ошибок для предоставления удобных сообщений об ошибках.

## Технологический стек

- **ASP.NET Core 6.0+**
- **Entity Framework Core (In-Memory Database)**
- **Swagger / OpenAPI**
- **C#**

## Предварительные требования

- .NET 6 SDK или выше
- Visual Studio или VS Code
- Postman (опционально, для тестирования API

## Структура проекта
Проект организован в следующие ключевые компоненты:

- **Program.cs**: Настройка сервисов, контекста базы данных и middleware для API.
- **Controllers/ContactManagerController.cs**: Содержит конечные точки API для управления контактами.
- **Models/Contact.cs**: Определяет модель `Contact` с такими свойствами, как Id, Name, Email и PhoneNumber.
- **Data/ApiContext.cs**: Определяет контекст базы данных для работы с контактами в встроенной базе данных.

## Endpoint API

### POST: Создание или редактирование контакта
- **URL**: `api/ContactManager/CreateEdit`
- **Описание**: Создает новый контакт, если не указан `Id`. Обновляет существующий контакт, если указан `Id`.
- **Тело запроса**: 
    ```json
    {
        "id": 0,
        "name": "John Doe",
        "email": "john.doe@example.com",
        "phoneNumber": "123-456-7890"
    }
    ```
- **Ответ**: 
    ```json
    {
        "success": true,
        "data": {
            "id": 1,
            "name": "John Doe",
            "email": "john.doe@example.com",
            "phoneNumber": "123-456-7890"
        }
    }
    ```

### GET: Получение контакта по ID
- **URL**: `api/ContactManager/GetById`
- **Параметр запроса**: `id` (int) - Идентификатор контакта для получения.
- **Ответ**: 
    ```json
    {
        "success": true,
        "data": {
            "id": 1,
            "name": "John Doe",
            "email": "john.doe@example.com",
            "phoneNumber": "123-456-7890"
        }
    }
    ```

### GET: Получение всех контактов
- **URL**: `api/ContactManager/GetAll`
- **Ответ**: 
    ```json
    {
        "success": true,
        "data": [
            {
                "id": 1,
                "name": "John Doe",
                "email": "john.doe@example.com",
                "phoneNumber": "123-456-7890"
            },
            ...
        ]
    }
    ```

### DELETE: Удаление контакта по ID
- **URL**: `api/ContactManager/DeleteById`
- **Параметр запроса**: `id` (int) - Идентификатор контакта для удаления.
- **Ответ**: 
    ```json
    {
        "success": true,
        "message": "Contact deleted successfully"
    }
    ```

## Запуск приложения

1. **Клонируйте репозиторий**:
   git clone https://github.com/your-repo/contact-manager-api.git
1. **Перейдите в каталог проекта**:
   cd contact-manager-api
1. **Соберите проект**:
   dotnet build
1. **Запустите проект**:
   dotnet run
1. **После запуска приложения Swagger UI будет доступен по адресу**:
   https://localhost:<port>/swagger

## Примечания
- API использует провайдер In-Memory базы данных Entity Framework Core для хранения контактов во время выполнения. База данных сбрасывается при каждом перезапуске приложения.
