// availableFilms.js

import { app, getData } from '../script.js';
import { rentFilm } from './rentFilm.js'

export async function runAvailableFilms(){
    app.availableFilms.addEventListener('click', async function(){
        app.mainContent.innerHTML = '';

        let filmData = await getData('api/films');
        if(app.token === "")
        {
            app.mainContent.insertAdjacentHTML('beforeend', `\
            <div id="main-films">
             </div>`);
            
            for(const film of filmData)
            {
                
                let mainFilm = document.querySelector('#main-films');
                mainFilm.insertAdjacentHTML('beforeend', `\
                <div id="film${film.filmId}" class="film">\
                    <div>Namn: ${film.name}</div>
                    <div>Regissör: ${film.director}</div>
                    <div>Land: ${film.country}</div>
                    <div>Årtal: ${film.releaseYear}</div>
                </div>`);
            }
        }else{           

            app.mainContent.insertAdjacentHTML('beforeend', `\
            <div id="main-films">
             </div>`);
            
            for(const film of filmData)
            {
                let isAvailable = "Nej";
                for(const filmcopy of film.filmCopies)
                {
                    if(filmcopy.rentedOut === false)
                    {
                        isAvailable = "Ja";
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