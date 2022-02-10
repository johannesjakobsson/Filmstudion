import { app } from '../script.js';

export function welcome(userName) {
    app.mainContent.innerHTML = '';
    app.mainContent.insertAdjacentHTML('beforeend', `\
    <div id="welcome">\
    Hej och välkommen ${userName}. Här kan du hantera dina filmer.\
    </div>`);
}