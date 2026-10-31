const email = document.querySelector("#Email")
const password = document.querySelector("#Password")
const lastName = document.querySelector("#LastName")
const firstName = document.querySelector("#FirstName")

const userData = sessionStorage.getItem("logInUser");
if (userData) {
    const user = JSON.parse(userData);
    document.querySelector("#welcome").innerHTML = `${user.firstName},<br>!!ברוכים הבאים`
    email.value = user.email
    password.value = user.password
    firstName.value=user.firstName
    lastName.value=user.lastName
}

const update = async () => {
    const upUser={
        Email: email.value,
        Password: password.value,
        FirstName: firstName.value,
        LastName: lastName.value
    }

    try {
        const response = await fetch(`api/users/${JSON.parse(userData).id}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(upUser)
        });
        if (response.ok) {
            alert("הפרטים עודכנו בהצלחה")
        }
        else {
            throw "Network error"
        }
    }
    catch (e) {
        alert(e)
    }
}
