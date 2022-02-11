//home.js

import { app } from '../script.js';

export function homePage() {
    app.mainContent.innerHTML = '';
    app.mainContent.insertAdjacentHTML('beforeend', `\
    <div id="main-home">
        Välkommen till SFF:s filmlånar-sida!
    </div>`);
}

export function runHomePage() {
    app.home.addEventListener('click', function() {
        homePage();
    });
}