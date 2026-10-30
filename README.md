# rentApart

Уеб приложение за продажба и отдаване под наем на имоти.

Дипломен проект – ЧПГДН „СофтУни Будител“, професия „Системно програмиране“, специалност „Системен програмист“.

## Предназначение и основна цел

<!-- 2–3 изречения: какъв проблем решава приложението и за кого е. -->
rentApart позволява на собственици и агенти да публикуват обяви за продажба и наем на имоти, а на потребителите – да ги търсят, филтрират и да се свързват с публикуващите. Целта на проекта е ...

## Основни функционалности

- Регистрация, вход и изход на потребители (ASP.NET Core Identity)
- Публикуване, редактиране и изтриване на обяви за имоти
- Търсене и филтриране по тип (продажба / наем), цена, локация, квадратура
- Роли и оторизиран достъп до действията в контролерите
- Административен панел (Admin area) за управление на потребители и обяви
- Персонализирани страници за грешки (404, 500)
- Валидация на входните данни със съобщения към потребителя
- Запазване на сесията на потребителя чрез бисквитки
- <!-- допълнителни функционалности -->

## Използвани технологии

| Слой | Технология |
|------|------------|
| База данни | Microsoft SQL Server |
| Сървърна част | ASP.NET Core MVC (.NET 8) |
| Достъп до данни | Entity Framework Core |
| Клиентска част | Razor Views, HTML, CSS, JavaScript, Bootstrap |
| Тестване | xUnit, Moq |
| CI/CD | GitHub Actions |

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
├── database/                  # schema.sql и примерни данни
├── docs/                      # Документация (PDF), диаграми
├── RentApart.sln
└── README.md
```

## Инструкции за стартиране

### Изисквания

- [.NET SDK 8.0](https://dotnet.microsoft.com/download) (минимум .NET 6)
- Microsoft SQL Server (LocalDB, Express или пълна версия)
- Git

### Стъпки

```bash
git clone https://github.com/DaniGechev/rentApart.git
cd rentApart
dotnet restore
```

1. Задайте необходимите настройки (виж по-долу).
2. Създайте базата данни:
   ```bash
   dotnet ef database update --project src/RentApart.Data --startup-project src/RentApart.Web
   ```
   Алтернативно изпълнете `database/schema.sql` в SQL Server Management Studio.
3. Стартирайте приложението:
   ```bash
   dotnet run --project src/RentApart.Web
   ```
4. Отворете адреса, изписан в конзолата (напр. `https://localhost:7001`).

## Необходими настройки

Чувствителните данни **не се съхраняват в репото**. Използват се .NET User Secrets:

```bash
cd src/RentApart.Web
dotnet user-secrets init
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=(localdb)\\MSSQLLocalDB;Database=RentApart;Trusted_Connection=True;"
dotnet user-secrets set "AdminSeed:Email" "admin@example.com"
dotnet user-secrets set "AdminSeed:Password" "<задайте-парола>"
```

<!-- Добавете други ключове, ако има (напр. email услуга, API ключове). -->

## Структура на базата данни

Схемата е в `database/schema.sql`. Основни таблици:

| Таблица | Описание |
|---------|----------|
| AspNetUsers / AspNetRoles | Потребители и роли (Identity) |
| Properties | Обяви за имоти |
| PropertyTypes | Типове имоти |
| Cities | Населени места |
| ... | ... |

<!-- Тук може да добавите ER диаграма: docs/er-diagram.png -->

## Тестови потребители и роли

Паролите се задават локално чрез User Secrets (виж по-горе). В репото няма реални пароли.

| Роля | Имейл | Права |
|------|-------|-------|
| Administrator | admin@example.com | Пълен достъп, Admin area |
| User | user@example.com | Публикуване и управление на собствени обяви |
| Гост | – | Разглеждане и търсене на обяви |

## Тестване

```bash
dotnet test
```

Проектът включва Unit тестове за бизнес логиката (цел: покритие 65% от функционалността), както и тестове с mocking/integration.

## CI/CD

При всеки push и pull request към `main` GitHub Actions изпълнява restore, build и тестове (`.github/workflows/ci.yml`).

## Автор

**Даниел Гечев**, XII клас, ЧПГДН „СофтУни Будител“, гр. София
Дипломен консултант: <!-- име -->
Учебна година: <!-- 2025/2026 -->

## Лиценз

Проектът е под [MIT лиценз](LICENSE).
