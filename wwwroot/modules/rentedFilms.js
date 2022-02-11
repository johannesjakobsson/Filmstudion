//rentedFilms.js

import { app, getData } from '../script.js';
import { returnFilm } from './returnFilm.js';

export async function runRentedFilms(){

    app.rentedFilms.addEventListener('click', async function(){
        app.mainContent.innerHTML = '';

        if(app.token === "")
        {
            app.mainContent.innerHTML = "Du måste vara inloggad för att se denna sida";
        }else{

            const rentedFilmData = await getData('api/mystudio/rentals');
            const filmData = await getData('api/films');

            if(rentedFilmData.length == 0)
            {
                app.mainContent.innerHTML = "Här var det tomt. Dags att hyra filmer!";
            } else {

                app.mainContent.insertAdjacentHTML('beforeend', `\
                <div id="main-films">
                 </div>`);

                for(const filmcopy of rentedFilmData)
                {
                    for(const film of filmData)
                    {
                        if(filmcopy.filmId === film.filmId)
                        {
                            
                            let mainFilm = document.querySelector('#main-films');
                            mainFilm.insertAdjacentHTML('beforeend', `\
                            <div id="film${film.filmId}" class="film">\
                            <div>Namn: ${film.name}</div>
                            <div>Regissör: ${film.director}</div>
                            <div>Land: ${film.country}</div>
                            <div>Årtal: ${film.releaseYear}</div>
                            </div>`);
    
                            let returnButton = document.createElement('button');
                            returnButton.id = `filmBtn${film.filmId}`;
                            returnButton.innerText = 'Returnera';
    
                            let filmDiv = document.querySelector(`#film${film.filmId}`);
                            filmDiv.insertAdjacentElement('beforeend', returnButton); 
    
                            returnFilm(film.filmId, returnButton);
                        }
                    }
                } 
            }
        }
    });
}