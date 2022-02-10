// availableFilms.js

import { app } from '../script.js';

export async function runAvailableFilms(){
    app.availableFilms.addEventListener('click', async function(){
        app.mainContent.innerHTML = '';

        if(app.token === "")
        {
            app.mainContent.innerHTML = "Du måste vara inloggad för att se denna sida";
        }else{

            let response = await fetch('api/films', {
                method: 'GET',
                headers: {
                    'Authorization': 'Bearer ' + app.token,
                    'Content-type': 'application/json; charset=UTF-8'}
            });
            
            let filmData = await response.json();
            console.log(filmData);

            app.mainContent.insertAdjacentHTML('beforeend', `\
            <div id="main-films">
             </div>`);
            
            for(const film of filmData)
            {
                let isAvailable = "Nej";
                //let filmCopyId; // bort?
                for(const filmcopy of film.filmCopies)
                {
                    if(filmcopy.rentedOut === false)
                    {
                        isAvailable = "Ja";
                        //filmCopyId = filmcopy.filmCopyId; // bort?
                        break;
                    }
                }
                
                let mainFilm = document.querySelector('#main-films');
                mainFilm.insertAdjacentHTML('beforeend', `\
                <div id="film${film.filmId}" class="film">\
                    <div>Namn: ${film.name}</div>
                    <div>Regissör: ${film.director}</div>
                    <div>Land: ${film.country}</div>
                    <div>Årtal: ${film.releaseYear}</div>
                    <div>Ledig: ${isAvailable}</div>
                </div>`);

                let rentButton = document.createElement('button');
                if(isAvailable === "Ja")
                {
                    rentButton.id = `filmBtn${film.filmId}`;
                    rentButton.innerText = 'Låna';
                    let filmDiv = document.querySelector(`#film${film.filmId}`);
                    filmDiv.insertAdjacentElement('beforeend', rentButton); 
                }
                rentFilm(film.filmId, rentButton);
            }
        }
    });
}

async function rentFilm(filmId, button)
{
    button.addEventListener('click', async function(){
        console.log(app.studioId);
        let response = await fetch(`api/films/rent?id=${filmId}&studioid=${app.studioId}`, {
            method: 'POST',
            headers: {
                'Authorization': 'Bearer ' + app.token,
                'Content-type': 'application/json; charset=UTF-8'}
        });
        let data = await response.json();
        console.log(data);
        app.mainContent.innerHTML = '';
        if(data.message == "Successful")
        {
            app.mainContent.innerText = 'Vad härligt, du har nu lånat filmen!';
        }else {
            app.mainContent.innerText = data.message;
        }
    });
}