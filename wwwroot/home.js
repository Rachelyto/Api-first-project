const signUp = async() =>{
    const email = document.querySelector("#Email").value
    const password = document.querySelector("#Password").value
    const lastName = document.querySelector("#LastName").value
    const firstName = document.querySelector("#FirstName").value
    
    const user = {
        email,
        password,
        firstName,
        lastName
    };
    try {
        const response = await fetch('api/users', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(user)
        });

        if (response.ok) {
            const data = await response.json();
            document.getElementById('Email').value = '';
            document.getElementById('Password').value = '';
            document.getElementById('LastName').value = '';
            document.getElementById('FirstName').value = '';
            alert("The user has been registered successfully!");
        }
        else
            throw "Network error";
    }
    catch (e) {
        alert(e);
    }


    
}
const SignIn = async () => {
    const LogInEmail = document.querySelector("#LogInEmail").value
    const LogInPassword = document.querySelector("#LogInPassword").value
    const userLog = {
        LogInEmail,
        LogInPassword
    };
    try {
        const response = await fetch('api/Users/login', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(userLog)
        });

        if (response.status != 204) {
            const logInUser = await response.json();
            alert(`Hello, ${logInUser.firstName}!!!`);
            sessionStorage.setItem("logInUser", JSON.stringify(logInUser));
            document.getElementById('LogInEmail').value = '';
            document.getElementById('LogInPassword').value = '';
            window.location.href = 'Update.html';
        }
        else
            alert("The user does not exist")   
        if (!response.ok)
            throw "network error"
    }
    catch (e) {
        alert(e);
    }
}

