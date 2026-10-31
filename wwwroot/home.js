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
        await (checkPass());
        const progress = document.querySelector("#passwordProgress").value;

        if (progress < 3) {
            return;
        }
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
            document.querySelector("#passwordProgress").style.display = "none";
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
    const Email = document.querySelector("#LogInEmail").value
    const Password = document.querySelector("#LogInPassword").value
    const userLog = {
        Email,
        Password
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

const checkPass = async () => {
    const password = document.querySelector("#Password").value
    
    try {
        if (password == '') {
            throw ("enter password");
        }
        const response = await fetch('api/Passwords', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(password)
        });

        if (response.ok) {
            const score = await response.json();
            const prog = document.querySelector("#passwordProgress")
            prog.style.display = "block"
            prog.value = score;
            if (score < 3) {
                throw ("not a strong password");
            }
        }
        else
            throw "Network error";
    }
    catch (e) {
        alert(e);
    }
    
}