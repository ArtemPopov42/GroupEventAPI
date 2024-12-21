function Exit(){
    localStorage.removeItem("token");
    open("HomePage.html", "_self");
}

async function CreateEvent() {
    const data = {
        Description: document.getElementById("eventDescInput").value,
        DateTime: document.getElementById("eventTimeInput").value
    }

    const url = "https://localhost:5000/api/User/CreateEvent"

    const token = localStorage.getItem("token")

    console.log(data);

    let response = await fetch(url, {
        method: "POST",
        headers:{
            "Accept":"*/*",
            "Content-Type":"application/json",
            "Authorization":`Bearer ${token}`
        },
        body: JSON.stringify(data)
    });

    if(response.ok){
        
    }
}

async function LoadEvents() {
    const url = "https://localhost:5000/api/User/GetEvents";

    const token = localStorage.getItem("token");

    let response = await fetch(url,{
        method: "GET",
        headers: {
            "Accept":"*/*",
            "Content-Type":"application/json",
            "Authorization":`Bearer ${token}`
        }
    });

    if(response.ok){
        let responseJson = await response.json();
        console.log(responseJson);
        return responseJson;
    }
}

async function LoadList() {
    let list = document.getElementById("eventList");
    list.innerHTML = "";
    let events = await LoadEvents();

    for(let i = 0; i < events.length; i++){
        let newItem = document.createElement("li");
        let itemDesc = document.createElement("p");
        itemDesc.innerHTML = events[i].description;
        let itemTime = document.createElement("p");
        itemTime.innerHTML = events[i].endDate.toLocaleString();
        newItem.appendChild(itemDesc);
        newItem.appendChild(itemTime);
        list.appendChild(newItem);
    }
}