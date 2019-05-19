

var f = false;
var s = false;

function showLogin() {
    if (f) {
        var el = document.getElementById('signup');
        el.classList.add('my_hide');
        el = document.getElementById('login');
        el.classList.remove('my_hide');
        f = false;
    }
    s = false;
}

function showSignUp() {
    if (!s) {
        var el = document.getElementById('login');
        el.classList.add('my_hide');
        el = document.getElementById('signup');
        el.classList.remove('my_hide');
        s = true;
    }
    f = true;
}

function ValidateEmail() {
    var el = document.getElementById('Email').value;
    if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(el)) {
        el = document.getElementById('InvalidEmail').style.display = 'none';
        document.getElementById('submitIt').disabled = false;
        return (true);
    }
    el = document.getElementById('InvalidEmail').style.display = 'block';
    document.getElementById('submitIt').disabled = true;
    return (false);
}

function ValidatePasswordOne() {
    var el = document.getElementById('Pwd').value;
    if (el.length != 0) {
        el = document.getElementById('invPwd').style.display = 'none';
        document.getElementById('submitIt').disabled = false;
        return (true);
    }
    el = document.getElementById('invPwd').style.display = 'block';
    document.getElementById('submitIt').disabled = true;
    return (false);
}

function ValidatePassword() {
    var el = document.getElementById('Password').value;
    if (el.length < 8) {
        el = document.getElementById('InvalidPassword').style.display = 'block';
        document.getElementById('registerIt').disabled = false;
        return (true);
    }
    el = document.getElementById('InvalidPassword').style.display = 'none';
    document.getElementById('registerIt').disabled = true;
    return (false);
}

function ValidateEmailOne() {
    var el = document.getElementById('EmailOne').value;
    if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(el)) {
        el = document.getElementById('InvalidEmailOne').style.display = 'none';
        document.getElementById('registerIt').disabled = false;
        return (true);
    }
    el = document.getElementById('InvalidEmailOne').style.display = 'block';
    document.getElementById('registerIt').disabled = true;
    return (false);
}

function ValidateUserName() {
    var el = document.getElementById('UserName').value;

    if (!(/\W/.test(el)) && el.length >= 3) {
        el = document.getElementById('InvalidUserName').style.display = 'none';
        document.getElementById('registerIt').disabled = false;
        return (true);
    }
    el = document.getElementById('InvalidUserName').style.display = 'block';
    document.getElementById('registerIt').disabled = true;
    return (false);
}

function ValidateDate() {
    var el = document.getElementById('DOB').value;
    var d = new Date(el).getFullYear();
    var e = new Date().getFullYear();
    if (e - d >= 18) {
        el = document.getElementById('InvalidDate').style.display = 'none';
        document.getElementById('registerIt').disabled = false;
        return (true);
    }
    el = document.getElementById('InvalidDate').style.display = 'block';
    document.getElementById('registerIt').disabled = true;
    return (false);
}


