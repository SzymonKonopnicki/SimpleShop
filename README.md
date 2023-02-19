# SimpleShop API 

>  Prosty Internetowy Interfejs stworzony celem pogłębiania wiedzy w zakresie tworzenia API. 

 

## Spis treści 

* [Informacje ogólne](#informacje-ogólne) 

* [Użyte technologie](#użyte-technologie) 

* [Funkcje](#funkcje)

* [Status](#status) 

* [Inspiracje](#inspiracje) 

 

## Informacje ogólne 

- Projekt powstał celem pogłębienia wiedzy w zakresie tworzenia REST API 

- Najlepszym sposobem zdobywania wiedzy w zakresie programowania jest tworzenie czegoś w praktyce. 

- Chciałem stworzyć aplikacje która potrafi zapisywać oraz wyświetlać dane poprzez połączenie z bazą danych. 

- Chciałem także w podstawowym stopniu zaznajomić się z pojęcie Autoryzacji użytkowników. 

  

## Użyte technologie 

- ASP.NET Core 6 

- FluentValidation.AspNetCore 

- Microsoft.AspNetCore.Authentication.JwtBearer 

- Microsoft.EntityFrameworkCore.SqlServer 

- Microsoft.EntityFrameworkCore.Tools 

- NLog.Web.AspNetCore 

- Swashbuckle.AspNetCore 

  

## Funkcje 

- Dodawanie, Usuwanie, Edytowanie oraz Odczytywanie Produktów zapisanych w bazie danych, 

- Rejestrowanie, Logowanie, Wyświetlanie użytkowników oraz listy dostępnych ról, 

- Autoryzacja użytkowników poprzez token JWT w którym kluczową role pełni “Rola” danego użytkownika, 

- Użycie Logera celem zapisywania pewnych akcji lokalnie oraz w konsoli, 

- Obsługa podstawowych błędów poprzez Middleware, 

- Dodanie walidatorów, który weryfikuje wprowadzane dane od użytkownika. 

  

## Status 

Aktualnie projekt nie jest rozwijany. Natomiast w niedalekiej przyszłości będę backend sklepu internetowego celem dalszej naukii. 

   

## Inspiracje 

- Początkowo projekt miał być kopią z kursu Praktyczny kurs ASP.NET Core REST Web API od podstaw (C#) Jakuba Kozary. Natomiast moja wizja sklepu internetowego była dla mnie bardziej pociągająca więc jedynie zainspirowałem się tym kursem. 
