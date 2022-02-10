//rentFilm.js

import { app } from '../script.js';

export async function rentFilm(filmId, rentButton)
{
    rentButton.addEventListener('click', async function(){
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