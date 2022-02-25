"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chathub").build();

//Disable the send button until connection is established.
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message, timeSent) {
    var div = document.createElement("div");
    div.innerHTML += '<div class="text-wrap">' + `[${timeSent}] ${user}: ${message}` + '</div>';
    document.getElementById("messagesList").appendChild(div);

    var mess = document.getElementById('messageInput');
    mess.value = '';

    // We can assign user-supplied strings to an element's textContent because it
    // is not interpreted as markup. If you're assigning in any other way, you 
    // should be aware of possible script injection concerns.
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var message = document.getElementById("messageInput").value;
    var today = new Date();
    var timeSent = today.toLocaleTimeString();

    connection.invoke("SendMessage", message, timeSent).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});