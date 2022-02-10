
const app = {
    menu: document.querySelector("#menu"),
    mainContent: document.querySelector("#main-content"),
    home: document.querySelector("#home"),
    studio: document.querySelector("#studio"),
    films: document.querySelector("#films"),
    login: document.querySelector("#login"),
    token: ""
};

/* LOGIN */



async function loginUser (){
    let loginBtn = document.querySelector('#login-submit');

    loginBtn.addEventListener('click', async function(e){
        e.preventDefault();

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
        
        if(app.token === undefined)
        {
            let mainLogin = document.querySelector('#main-login');
            mainLogin.insertAdjacentHTML('beforeend', '\
            <p id="error-login">Användarnamn eller lösenord är fel</p>\
            ');
        }

        console.log("app.token", app.token);
        localStorage.setItem("userToken", app.token);
        
    });
}

async function showLoginPage () {
    app.login.addEventListener('click', function(){
    
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

showLoginPage();


























// TEST SCRIPT


/* const getData = async (url) => {
    const response = await fetch(url);
    const data = await response.json();
    return data;
}

const getFilms = async () => {
    var data = await getData("api/films");
    console.log(data);
}


getFilms();

const getDataWithToken = async (url) => {
    const token = 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJBZG1pbiIsImp0aSI6ImRiOGNjODU3LTBhMWItNDgyMC1iYmYyLTQ5Y2QyZDI3YmNlMCIsInVuaXF1ZV9uYW1lIjoiQWRtaW4iLCJleHAiOjE2NDQ1MTkyNDMsImlzcyI6Imh0dHBzLy9sb2NhbGhvc3Q6NTAwMSIsImF1ZCI6Imh0dHBzLy9sb2NhbGhvc3Q6NTAwMSJ9.YR4kHXP6UgdWIj9DaV4Az94tcVUxcdV-_AxrkFQzcmk';
    const response = await fetch(url, {
        method: 'GET',
        headers: {
            'Authorization': 'Bearer ' + token}
    });
    const data = await response.json();
    return data;
}

const getFilmsWithToken = async() => {
    var data = await getDataWithToken("api/films");
    console.log(data);
}
getFilmsWithToken(); */