checkLogin = async () => {
    const res = await fetch("/api/me")
    if (res.status == 401) {
        console.log("You are not logged in")
        document.querySelectorAll(".loggedIn").forEach(x => x.classList.add("hidden"))
    }
    else if (res.status == 200) {
        document.querySelectorAll(".loggedOut").forEach(x => x.classList.add("hidden"))
        console.log("You are logged in");
        const json = await res.json()
        document.querySelector("#name").textContent = json['name']
        document.querySelector("#email").textContent = json['email']
    }
    else {
        console.error("Error while checking auth status", res.status);
        document.querySelector('.content').innerHTML = `Error while checking auth status: <b>${res.status} (${res.statusText})</b>`
    }
}

checkLogin()