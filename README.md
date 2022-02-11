# Filmstudion

## Instruktioner

*Vad behöver göras för att ditt program ska starta och gå och använda?*
**- Kräver .NET5.0 SDK**  
**- Navigera till Filmstudion-mappen via terminalen**  
**- Skriv "dotnet run"**  
**- Du behöver en webbläsare där du kan navigera in på https://localhost:5001 för att testa klientgränssnittet.**  
**- Vill du endast kontrollera API-åtkomstpunkterna så navigera in på https://localhost:5001/swagger/index.html för att se vidare dokumentation**  
**- Rekommenderat är att ha exempelvis Postman för att navigera och testa de olika åtkomstpunkterna**  

Films  
Film innehåller detaljer om en film i SFFs bibliotek  
PUT - /api​/Films - Autentiserad admin kan skapa en ny film i API:et, för mer information om vilken data som ska matas in, gå vidare in på swagger-länken ovanför.  
GET - /api​/Films - Hämtar alla filmer, beroende på roll får du mer eller mindre information.  
GET - /api​/Films​/{id} - Hämtar en specifik film beroende på ID, beroende på roll får du mer eller mindre information.  
PUT - /api​/Films​/{id} - Autentiserad admin har möjlighet att ändra informationen i en redan skapad film, för mer information om vilken data som ska matas in, gå vidare in på swagger-länken ovanför.  
PATCH - /api​/Films​/{id} - Autentiserad admin har möjlighet att ändra antalet kopior i en redan skapad film, för mer information om vilken data som ska matas in, gå vidare in på swagger-länken ovanför.  
POST - /api​/Films​/rent - Autentiserad filmstudio har möjlighet att låna en film.  
POST - /api​/Films​/return - Autentiserad filmstudio har möjlighet att lämna tillbaka en film.  

FilmStudios  
En studio representerar en registrerad filmstudio hos sff.  
POST - /api​/FilmStudios​/register - Här har en filmstudio möjlighet att registrera sig, för mer information om vilken data som ska matas in, gå vidare in på swagger-länken ovanför.  
GET - /api​/FilmStudios - Hämtar alla filmstudios, beroende på roll får du mer eller mindre information.  
GET - /api​/FilmStudios​/{id} - Hämtar en specifik filmstudio beroende på ID, beroende på roll får du mer eller mindre information.  

MyStudio  
Hämtar information om din egen filmstudio om du är authentiserad  
GET - /api​/MyStudio​/rentals - Autentiserad filmstudio hämtar alla lånade filmexemplar.  

Users  
Hantering av användare.  
POST - /api​/Users​/register - Här har en Admin möjlighet att registrera sig. För mer information om vilken data som ska matas in, gå vidare in på swagger-länken ovanför.  
POST - /api​/Users​/authenticate - Här har registrerad användare möjlighet att autentisera sig och få en JWT-Bearer-Token för vidare autentisering. För mer information om vilken data som ska matas in, gå vidare in på swagger-länken ovanför.  

## TODO - Kvar att göra

*Vad har du inte hunnit med i denna uppgift?*

 |Krav|Uppfyllt|Egna Kommentarer|
 |---|---|---|
|**1**  |**Ja**| |
|**2**  |**Ja**| |
|**3**  |**Ja**| |
|**4**  |**Ja**| |
|**5**  |**Ja**| |
|**6**  |**Ja**| |
|**7**  |**Ja**| |
|**8**  |**Ja**| |
|**9**  |**Ja**| |
|**10**  |**Ja**| |
|**11**  |**Ja**| |
|**12**  |**Ja**| |
|**13**  |**Ja**| |
|**14**  |**Ja**| |
|**15**  |**Ja**| |
|**16**  |**Ja**| |
|**17**  |**Ja**| |
|**18**  |**Ja**| |
|**19**  |**Ja**| |
|**20**  |**Ja**| |
|**21**  |**Ja**| |
|**22**  |**Ja**| |
|**23**  |**Ja**| |
|**24**  |**Ja** | |
|**25**  |**Ja** | |
|**26**  |**Ja** | |

## Förtydliganden/motivering
Det här har varit en stressig uppgift. Har lagt ner extremt många timmar för att ens få ihop det. Ändå känns det som man inte har åstadkommit så mycket man hade hoppats på. Den röda tråden genom min kodstruktur för API:t finns liksom inte där anser jag. Men vi är ju här för att bli bättre! Perfektion föds inte på en dag ;) Sen hade man gärna lagt ner lite mer kärlek på klientgränssnittet, men tiden räckte inte riktigt till för min del, den är väl snyggast i mobilt för stunden läge. Hade man haft lite mer tid hade man även kunnat lägga till registrering för filmstudios i klientgränssnittet. Hade även kunnat lägga till roller i detta projektet. Men ansåg att det inte behövdes ännu när jag tolkade kravlistan.