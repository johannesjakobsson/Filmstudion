//login.js

import { app } from '../script.js';
import { welcome } from './welcome.js';
import { homePage } from './home.js';

async function loginUser (){
    let loginBtn = document.querySelector('#login-submit');

    loginBtn.addEventListener('click', async function(){

        let error = document.querySelector("#error-login");
        if(error !== null)
        {
            error.remove();
        }

        let username = document.querySelector('#username-input').value;
        let password = document.querySelector('#password-input').value;

        let response = await fetch('api/Users/authenticate', {
            method: 'POST',
            body: JSON.stringify({
                UserName: username,
                Password: password
            }),
            headers: {
                'Content-type': 'application/json; charset=UTF-8',
            }
        })

        let userData = await response.json();
        app.token = userData.token;
        app.userName = userData.userName;
        app.studioId = userData.filmStudio.filmStudioId;
        console.log(userData);
        console.log(app.studioId);
        if(app.token === undefined) // Kontroller om det är filmstudio eller admin också?
        {
            let mainLogin = document.querySelector('#main-login');
            mainLogin.insertAdjacentHTML('beforeend', '\
            <p id="error-login">Användarnamn eller lösenord är fel</p>\
            ');
        }
        else
        {
            localStorage.setItem('userToken', app.token);
            localStorage.setItem('userName', app.userName);
            localStorage.setItem('studioId', app.studioId);
            welcome(userData.userName);
            logoutButton();
        }       
        
    });
}

async function logoutButton() {
    app.loginLogout.innerHTML = "Logga ut"
    app.loginLogout.addEventListener('click', async function ()
    {
        localStorage.removeItem('userToken');
        localStorage.removeItem('userName');
        localStorage.removeItem('studioId');
        app.token = '';
        app.userName = '';
        app.studioId = '';
        runLoginPage();
        app.loginLogout.innerHTML = "Logga in";
    });
}
export async function checkIfLoggedIn(){
    if(localStorage.getItem('userToken') !== null)
    {
        app.userName = localStorage.getItem('userName');
        app.token = localStorage.getItem('userToken');
        app.studioId = localStorage.getItem('studioId');
        welcome(app.userName);
        logoutButton();
    } else{
        homePage();
    }
}

export async function runLoginPage () {
    app.loginLogout.addEventListener('click', function(){
    
        app.mainContent.innerText = '';

        app.mainContent.insertAdjacentHTML('beforeend', '\
        <div id="main-login">\
            <h3>Logga in</h3>\
            <input type="text" id="username-input" placeholder="Användarnamn">\
            <input type="password" id="password-input" placeholder="Lösenord"><br>\
            <button id="login-submit" type="button">Logga in</button>\
        </div>');

        loginUser();
    });
}