# Arbeidskrav: Dockerisert Applikasjon
## Her skulle jeg lage et docker-compose.yml fil hvor jeg skulle bruke et conatainerized image for et api som jeg har laget og lastet opp til DockerHub.

Jeg valgte å lage en enkel to do list applikasjon som API, hvor tanken er å kunne legge til tasks og se tasks som er lagt til med filtreringsmuligheter. Først laget jeg apiet og endepunktene med bruk av .NET og Swagger, og hvordan databasen skulle settes opp ved bruk av modeller.  Så laget jeg en Dockerfil som ble grunnlaget for å lage API imaget mitt som kunne lastes opp.

Så i en docker-compose.yml fil laget jeg servicene hvor jeg oppretter SQL database containeren, API containeren ved å bruke API imaget jeg laget, og nginx containeren. Her har jeg lagt in dependencies og healthchecks slik at API ikke prøver å koble seg til databasen før den er klar. 

Til slutt lastet jeg opp API imaget mitt opp som multiarch og for hver av amd64 og arm64 på dockerhub som er lenket under.


Lenke til images på Dockerhub: https://hub.docker.com/r/louniverse/arbeidskrav-api/tags

# kjøring
i terminal input følgende: docker-compose up -d

# refleksjon
Dette var en krevende oppgave da jeg valgte å gjøre dette i .NET og innså fort at i VS så er mye gjort i bakgrunnen, og mye av det som lå tilgjenglig på nett var relativt utdatert. Men det var også litt morsomt å leke detektiv å prøve å finne løsningene litt overalt, og snekkre sammen slikt at det fungerte slik jeg ville ha det. Jeg har  derimot tatt i bruk VS sitt tool for å lage .dockerignore filen. Jeg hadde noen problemer med filstrukturen min siden jeg hadde endret navn på prosjektet i VS men det hadde ikke blitt endret i selve  mappen som skapte litt krøll, siden jeg ikke helt klarte å skjønne hvorfor docker-compose filen min ikke skulle være riktig, men som jeg heldigvis fikk løst til slutt! 

Videre, hvis jeg hadde hatt mer tid kunne jeg tenkt meg å utvide applikasjonen med blazor og ha en egen container for frotendbiten. jeg ville hatt en smidig applikasjon hvor man fort og enkelt kan legge til tasks, og se alle tasks i en tabell liste med filtrering på completed, og da og med en checkbox funksjonalitet for å raskt merke tasken som fullført.

# kilder
https://nginx.org/en/docs/beginners_guide.html
https://medium.com/@gitesky14/build-your-first-net-web-api-a-todo-app-b79fec353167
https://medium.com/@stas_khavruk/how-to-properly-use-ef-core-in-asp-net-core-with-mysql-database-a75f56c97318
https://github.com/MikeyFriedChicken/MikeyFriedChicken.DockerWebAPI.Example/blob/master/nginx/nginx.conf
https://www.ledjonbehluli.com/posts/blazor_wasm_nginx_docker/
https://medium.com/@fsilva0703/dockerize-asp-net-core-web-api-and-react-web-application-d180d8ce44b0
https://stackoverflow.com/questions/76498526/http-ports-when-running-asp-net-8-container-in-aks
https://stackoverflow.com/questions/77502099/dockerized-net-8-app-doesnt-expose-port-correctly
https://stackoverflow.com/questions/38346847/nginx-docker-container-502-bad-gateway-response

# ChatGPT prompts:
- ERROR: failed to build: failed to solve: failed to compute cache key: failed to calculate checksum of ref 6wvo09gwcin9tfid9n7p4v51p::61qigxq53kcstujsgrsbhcw55: "/ArbeidskravCloud/ArbeidskravCloud.csproj": not found
- ERROR: failed to build: failed to solve: failed to compute cache key: failed to calculate checksum of ref 6wvo09gwcin9tfid9n7p4v51p::zklzkxdhfgevs2qf5k9guvjt5: "/ArbeidskravCloud/Arbeidskrav.Api.csproj": not found
- so I think my problem is that I renamed the folder in the project, but when I open it in file explorer it has the old name. Could any of my issues stem from this?
- if I've made a project with an API and containerized it using docker and nginx. How would I proceed to adding blazor? Will I have to make a seperate project or can it be in the same?