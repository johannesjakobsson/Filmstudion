# Filmstudion - Februari 2022
## Instruktioner
**Starta applikationen**
1. Ladda ner repot från https://github.com/jajo21/Filmstudion
2. Leta upp valfri terminal och utgå från den nerladdade mappen
3. Applikationen kräver att du har .NET5.0 SDK installerat
4. Skriv kommandot ```dotnet run``` i terminalen
5. Applikationen körs nu på port 5000 och 5001
6. Öppna en webbläsare och navigera in på https://localhost:5001/ för att testa klientgränssnittet.
7. För att få ut mest av klientgränssnittet så behöver du skapa en filmstudio-användare först via åtkomstpunkten - POST - /api​/FilmStudios​/register - mer information om det finns längre ner i det här dokumentet. Alternativt på swagger-länken: **https://localhost:5001/swagger/index.html**
8. Vill du endast kontrollera API-åtkomstpunkterna så navigera in på **https://localhost:5001/swagger/index.html** för att se vidare dokumentation
9. Rekommenderat är att ha exempelvis Postman för att navigera och testa de olika åtkomstpunkterna

**ÅTKOMSTPUNKTER**  
**Films**  
Film innehåller detaljer om en film i SFFs bibliotek.  
PUT - /api​/Films - Autentiserad admin kan skapa en ny film i API:et, för mer information om vilken data som ska matas in, gå vidare in på swagger-länken ovanför.  
GET - /api​/Films - Hämtar alla filmer, beroende på roll får du mer eller mindre information.  
GET - /api​/Films​/{id} - Hämtar en specifik film beroende på ID, beroende på roll får du mer eller mindre information.  
PUT - /api​/Films​/{id} - Autentiserad admin har möjlighet att ändra informationen i en redan skapad film, för mer information om vilken data som ska matas in, gå vidare in på swagger-länken ovanför.  
PATCH - /api​/Films​/{id} - Autentiserad admin har möjlighet att ändra antalet kopior i en redan skapad film, för mer information om vilken data som ska matas in, gå vidare in på swagger-länken ovanför.  
POST - /api​/Films​/rent - Autentiserad filmstudio har möjlighet att låna en film.  
POST - /api​/Films​/return - Autentiserad filmstudio har möjlighet att lämna tillbaka en film.  

**FilmStudios**  
En studio representerar en registrerad filmstudio hos sff.  
POST - /api​/FilmStudios​/register - Här har en filmstudio möjlighet att registrera sig, för mer information om vilken data som ska matas in, gå vidare in på swagger-länken ovanför.  
GET - /api​/FilmStudios - Hämtar alla filmstudios, beroende på roll får du mer eller mindre information.  
GET - /api​/FilmStudios​/{id} - Hämtar en specifik filmstudio beroende på ID, beroende på roll får du mer eller mindre information.  

**MyStudio**  
Hämtar information om sin egena filmstudio om man är autentiserad.  
GET - /api​/MyStudio​/rentals - Autentiserad filmstudio hämtar alla lånade filmexemplar.  

**Users**  
Hantering av användare.  
POST - /api​/Users​/register - Här har en Admin möjlighet att registrera sig. För mer information om vilken data som ska matas in, gå vidare in på swagger-länken ovanför.  
POST - /api​/Users​/authenticate - Här har registrerad användare möjlighet att autentisera sig och få en JWT-Bearer-Token för vidare autentisering. För mer information om vilken data som ska matas in, gå vidare in på swagger-länken ovanför.  

## Syfte - YH-utbildning: Webbutvecklare .NET
* Inlämningsuppgift i kursen Dynamiska Webbsystem 2 - Februari 2022
* Beskrivning: I detta påhittade uppdrag så ska jag skapa en webbapplikation riktad till föreningar som är anslutna till Sveriges Förenade Filmstudios (SFF) där man via ett API och klientgränssnitt kan boka/beställa filmer till sin förening. Mer information längre ner i det här dokumentet under Kravspecifikation och uppgiftsberskrivning
* Resultat: 88/88 (VG)

## Tekniker
* C#
* ASP.NET Core
* ASP.NET Core Identity
* Entity Framework Core
* REST-API
* Swagger UI
* Automapper
* Jwt Bearer Tokens
* SQLite
* JavaScript ink. moduler
* Fetch-API
* HTML
* CSS

## Kravspecifikation och uppgiftsbeskrivning
Det här är en lång och väldigt specifik kravspecifikation: [Inlämning Filmstudion.pdf](https://github.com/jajo21/Filmstudion/files/8840174/Inlamning.Filmstudion.pdf)

## Förtydliganden/motivering
Det här har varit en stressig uppgift. Har lagt ner extremt många timmar för att ens få ihop det. Ändå känns det som man inte har åstadkommit så mycket man hade hoppats på. Den röda tråden genom min kodstruktur för API:t finns liksom inte där anser jag. Men vi är ju här för att bli bättre! Perfektion föds inte på en dag ;) Sen hade man gärna lagt ner lite mer kärlek på klientgränssnittet, men tiden räckte inte riktigt till för min del, den är väl snyggast i mobilt läge för stunden. Hade man haft lite mer tid hade man även kunnat lägga till registrering för filmstudios i klientgränssnittet. Hade även kunnat lägga till roller i detta projektet. Men ansåg att det inte behövdes ännu när jag tolkade kravlistan.
