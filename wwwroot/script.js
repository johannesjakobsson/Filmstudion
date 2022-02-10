import { runLoginPage, checkIfLoggedIn } from './modules/login.js';
import { runHomePage } from './modules/home.js';
import { runAvailableFilms } from './modules/availableFilms.js';

export const app = {
    menu: document.querySelector("#menu"),
    mainContent: document.querySelector("#main-content"),
    home: document.querySelector("#home"),
    availableFilms: document.querySelector("#available-films"),
    rentedFilms: document.querySelector("#rented-films"),
    loginLogout: document.querySelector("#login-logout"),
    token: "",
    userName: ""
};


checkIfLoggedIn();
runHomePage();
runAvailableFilms();
runLoginPage();


























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