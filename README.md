# rentApart

Уеб приложение за продажба и отдаване под наем на имоти.

Дипломен проект – ЧПГДН „СофтУни Будител“, професия „Системно програмиране“, специалност „Системен програмист“.

## Предназначение и основна цел

rentApart позволява на собственици и агенти да публикуват обяви за продажба и наем на имоти, а на потребителите – да ги търсят, филтрират, запазват като любими и да изпращат запитвания към публикуващите.

**Цел на проекта:** да се разработи уеб приложение за публикуване, търсене и управление на обяви за имоти, с регистрация на потребители, роли и административен панел.

## Основни функционалности

Планирани (статусът се обновява в хода на разработката):

- Регистрация, вход и изход на потребители (ASP.NET Core Identity)
- Публикуване, редактиране и изтриване на обяви за имоти със снимки
- Търсене и филтриране по тип (продажба / наем), цена, град, квадратура
- Запитвания към собственика и любими обяви
- Роли и оторизиран достъп до действията в контролерите
- Административен панел (Admin area) за управление на потребители и обяви
- Персонализирани страници за грешки (404, 500)
- Валидация на входните данни със съобщения към потребителя
- Запазване на сесията на потребителя чрез бисквитки

## Използвани технологии

| Слой | Технология |
|------|------------|
| База данни | Microsoft SQL Server 2022 (в Docker) |
| Сървърна част | ASP.NET Core MVC (.NET 10) |
| Достъп до данни | Entity Framework Core 10 |
| Клиентска част | Razor Views, HTML, CSS, JavaScript, Bootstrap |
| Тестване | xUnit, Moq |
| CI/CD | GitHub Actions |
| Контейнери | Docker Compose |

## Структура на проекта

```
rentApart/
├── .github/workflows/ci.yml   # CI: build + тестове
├── src/
│   ├── RentApart.Web/         # Controllers, Views, Areas/Admin, wwwroot
│   ├── RentApart.Data/        # Entities, DbContext, Migrations
│   └── RentApart.Services/    # Бизнес логика
├── tests/
│   └── RentApart.Tests/       # Unit и Integration тестове
├── docker-compose.yml         # SQL Server в контейнер
├── .env.example               # Шаблон за паролата на SQL Server
├── RentApart.slnx
└── README.md
```

## Инструкции за стартиране

### Изисквания

- [.NET SDK 10.0](https://dotnet.microsoft.com/download) (минимум .NET 6)
- [Docker](https://docs.docker.com/engine/install/) с Docker Compose
- Git

### Стъпки

1. Клонирайте репото:
   ```bash
   git clone https://github.com/DaniGechev/rentApart.git
   cd rentApart
   ```
2. Задайте парола за SQL Server (поне 8 знака, с главни и малки букви, цифри и символ, без `;`):
   ```bash
   cp .env.example .env
   # редактирайте .env и сменете MSSQL_SA_PASSWORD
   ```
3. Стартирайте базата данни:
   ```bash
   docker compose up -d
   ```
4. Задайте connection string в User Secrets (виж „Необходими настройки“).
5. Създайте таблиците чрез миграциите:
   ```bash
   dotnet ef database update --project src/RentApart.Data --startup-project src/RentApart.Web
   ```
   (Ако нямате инструмента: `dotnet tool install --global dotnet-ef --version "10.*"`.)
6. Стартирайте приложението:
   ```bash
   dotnet run --project src/RentApart.Web
   ```
7. Отворете адреса, изписан в конзолата (по подразбиране `http://localhost:5201`).

Спиране на базата: `docker compose stop`. Повторно стартиране: `docker compose start`.

## Необходими настройки

Чувствителните данни **не се съхраняват в репото**. Използват се .NET User Secrets:

```bash
cd src/RentApart.Web
dotnet user-secrets init
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=localhost,1433;Database=RentApart;User Id=sa;Password=<паролата-от-.env>;TrustServerCertificate=True"
```

Файлът `.env` е в `.gitignore` и не се публикува. В репото има само `.env.example`.

## Структура на базата данни

Схемата се създава от миграциите в `src/RentApart.Data/Migrations`. Основни таблици:

| Таблица | Описание |
|---------|----------|
| AspNetUsers / AspNetRoles | Потребители и роли (Identity) |
| Properties | Обяви за имоти |
| PropertyTypes | Типове имоти (апартамент, къща, офис, парцел) |
| Cities | Населени места |
| PropertyImages | Снимки към обявите |
| Inquiries | Запитвания към собственика |
| Favorites | Любими обяви на потребителите |

Началните данни (градове и типове имоти) се добавят автоматично с миграцията.

## Тестови потребители и роли

Тестови акаунти все още не са създадени (предстои seed на администратор). Паролите ще се задават локално чрез User Secrets, а в репото няма да има реални пароли.

| Роля | Права |
|------|-------|
| Administrator | Пълен достъп, Admin area |
| User | Публикуване и управление на собствени обяви |
| Гост | Разглеждане и търсене на обяви |

## Тестване

```bash
dotnet test
```

Проектът ще включва unit тестове за бизнес логиката (цел: покритие 65% от функционалността), както и тестове с mocking и integration.

## CI/CD

При всеки push и pull request към `main` GitHub Actions изпълнява restore, build и тестове (`.github/workflows/ci.yml`).

## Автор

**Даниел Йорданов Гечев**, XII Д клас, ЧПГДН „СофтУни Будител“, гр. София

Дипломен консултант: <!-- име на консултанта -->

Учебна година: 2026/2027

## Лиценз

Проектът е под [MIT лиценз](LICENSE).
