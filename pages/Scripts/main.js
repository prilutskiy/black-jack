var CurrentUser = "undefined";

$(document).ready(function () {
    $('form').removeAttr('novalidate');
    
});

function getAuthState() {
    var response = jsobject.getAuthStateJs();
    var result = response.toLowerCase() === 'true';
    return result;
}

function logIn() {
    var user = $('#inputlogin').val();
    var pass = $('#inputPassword').val();
    alert(user + ' : ' + pass);
    var response = jsobject.logInJs(user, pass);
    var jqState = $.parseJSON(response);
}

function logOut() {
    jsobject.logOutJs();
    window.location.href = 'index.html';
}