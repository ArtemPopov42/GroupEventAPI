let isSignIn = true;

function SwitchForm(){

    if(isSignIn){
        document.getElementById("SignInForm").setAttribute("hidden", "true");
        document.getElementById("SignUpForm").removeAttribute("hidden");
        document.getElementById("SwitchFormLbl").innerHTML = "If you already have an account: ";
        document.getElementById("SwitchFormBtn").innerHTML = "Sign in";
        isSignIn = false;
    } else {
        document.getElementById("SignInForm").removeAttribute("hidden");
        document.getElementById("SignUpForm").setAttribute("hidden", "true");
        document.getElementById("SwitchFormLbl").innerHTML = "If you don't have an account: ";
        document.getElementById("SwitchFormBtn").innerHTML = "Sign up";
        isSignIn = true;
    }
}

//sign up submit
document.getElementById("SignUpForm").addEventListener("submit", async function(event) {
    event.preventDefault();

    const data = {
        username: document.getElementById("usernameSU").value,
        email: document.getElementById("emailSU").value,
        password: document.getElementById("passwordSU").value
    };

    const url = "https://localhost:5000/api/Account/Register";

    let response = await fetch(url, {
        method: "POST",
        headers: {
            'Accept': '*/*',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    });

    if(response.ok){
        let responseJson = await response.json();
        console.log(JSON.stringify(responseJson));

        if(responseJson.succeeded == "true"){
            alert("Account successfully created");
            SwitchForm();
            document.getElementById("passwordSU").value == "";
        } else {
            alert(JSON.stringify(responseJson.errors));
            document.getElementById("passwordSU").value == "";
        }
    }

    });

//sign in submit
document.getElementById("SignInForm").addEventListener("submit", async function (event) {
    event.preventDefault();

    const data = {
        email: document.getElementById("emailSI").value,
        password: document.getElementById("passwordSI").value,
    }

    const url = "https://localhost:5000/api/Account/Login";

    let response = await fetch(url, {
        method: "POST",
        headers: {
            'Accept': '*/*',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    });

    if (response.ok){
        let responseJson = await response.json();

        if(responseJson.success == true){
            localStorage.setItem("token", responseJson.token);
            console.log("token: " + responseJson.token);
            open("AccountPage.html", "_self");
        }
    }
});