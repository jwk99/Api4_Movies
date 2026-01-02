# Ranking filmów (ASP.NET Core)

Projekt przedstawia prostą aplikację do **rankingu filmów** z możliwością:

- przeglądania listy filmów,
- dodawania nowych filmów,
- dodawania ocen przez użytkowników,
- wyliczania średniej oceny i liczby głosów.

Backend został zrealizowany w **ASP.NET Core Web API**, a frontend jako **minimalny HTML + JavaScript**.

---

## Funkcjonalności

### Filmy
- Dodawanie filmów (`title`, `year`)
- Walidacja tytułu i roku (`1888–2100`)
- Lista filmów dostępna przez API i UI

### Oceny
- Dodawanie oceny (`score ∈ [1..5]`) dla danego filmu (`movieId`)
- Wyliczanie średniej oceny (`AvgScore`) i liczby głosów (`Votes`) dla każdego filmu
- Aktualizacja średniej i liczby głosów w UI bez przeładowania strony

---

## Model danych

```sql
Movies(Id, Title, Year)
Ratings(Id, MovieId → Movies.Id, Score CHECK 1..5)
```
- Movies – lista filmów
- Ratings – oceny przypisane do filmów przez MovieId
- Średnia ocena wyliczana w backendzie

---

## Technologie

- .NET 8  
- ASP.NET Core Web API  
- Entity Framework Core  
- SQL Server  
- HTML + JavaScript (minimalny, bez frameworków)

---

## Uruchomienie projektu

- Sklonuj repozytorium  
- Skonfiguruj połączenie do SQL Server w `appsettings.json`  
- Utwórz bazę danych i uruchom skrypt SQL (`Movies`, `Ratings`, widok `vMoviesRanking`)  
- Uruchom aplikację:
```
dotnet run
```
- Aplikacja dostępna pod adresem:
```
https://localhost:XXXX
```
- Swagger:
```
https://localhost:XXXX/swagger
```
- Strona z UI:
```
https://localhost:XXXX/index.html
```
XXXX odpowiada portowi, który może się różnić przy każdym uruchomieniu.

---

## UI

Minimalny interfejs użytkownika znajduje się w:
```
wwwroot/index.html
```
Umożliwia:
- przeglądanie listy filmów z średnią i liczbą głosów
- wybór filmu i dodanie oceny
- automatyczne odświeżanie tabeli i listy rozwijanej po dodaniu oceny

---

## Testy API

Plik `tests.rest` zawiera przykładowe wywołania API:

- pobieranie filmów (`GET /api/movies`)
- dodawanie filmów (`POST /api/movies`)
- dodawanie ocen (`POST /api/ratings`)
- testy walidacji (nieprawidłowy rok, brak tytułu, ocena poza zakresem, nieistniejący film)

Testy przedstawiają poprawny scenariusz „happy path” oraz obsługę błędów.

---

## Zrzuty Ekranu

Do projektu dołączono screenshoty prezentujące:

- listę filmów z rankingiem i liczbą głosów
- dodawanie nowych filmów
- dodawanie ocen
- odświeżanie UI po dodaniu oceny

---

## Uwagi końcowe

- Walidacja danych realizowana jest na poziomie DTO i kontrolerów  
- Modele domenowe nie zawierają kolekcji, tylko referencje przez `Id`  
- Zastosowano DTO (record) do komunikacji API  
- UI w HTML/JS minimalny, bez frameworków  
- Backend zwraca poprawne statusy HTTP
