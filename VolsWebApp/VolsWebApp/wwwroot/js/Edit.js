"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/volHub").build();

//Disable the send button until connection is established.
document.getElementById("btsave").disabled = true;

connection.start().then(function () {
    document.getElementById("btsave").disabled = false;
    //document.getElementById("editsubmit").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

const uri = "/api/chats";
document.getElementById("btsave").addEventListener("click", function (event) {
    var id = document.getElementById("id").value;

    var prevu = document.getElementById("prevu").value;
    var revise = document.getElementById("revise").value;
    var compagnie = document.getElementById("compagnie").value;
    var provenance = document.getElementById("provenance").value;
    var etat = document.getElementById("etat").value;
    const vol =
    {
        id: id, prevu: prevu, revise: revise, compagnie: compagnie, provenance: provenance, etat: etat
    };

    var uri2 = uri + "/" + id;
    fetch(uri2, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(vol)
    })
        .then(response => response.json())
        .then(() => {
            //message = message + " ( reprise )"
            connection.invoke("SendMessage", prevu, revise,compagnie,provenance,etat).catch(function (err) {
                return console.error(err.toString());
            });
            alert('vol envoyé et enregistré !')
        })
        .catch(error => alert('Vol invalide ! Remplir tous les champs !'));

    event.preventDefault();
});
