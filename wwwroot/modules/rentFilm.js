//rentFilm.js

import { app } from '../script.js';

export async function rentFilm(filmId, rentButton)
{
    rentButton.addEventListener('click', async function(){
        let response = await fetch(`api/films/rent?id=${filmId}&studioid=${app.studioId}`, {
            method: 'POST',
            headers: {
                'Authorization': 'Bearer ' + app.token,
                'Content-type': 'application/json; charset=UTF-8'}
        });
        app.mainContent.innerHTML = '';
        if(response.status == 200)
        {
            app.mainContent.innerText = 'Vad härligt, du har nu lånat filmen!';
        }else if(response.status == 403) {
            app.mainContent.innerText = 'Filmen är redan lånad av denna filmstudio.';
        }else{
            app.mainContent.innerText = 'Något gick snett. Vänlig testa igen'
        }
    });
}