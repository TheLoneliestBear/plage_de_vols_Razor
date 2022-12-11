"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/volHub").build();

//document.getElementById("btsendbutton").disabled = true;

//connection.on("ReceiveMessage", function () {
//    var tablerow = document.getElementById("listeProduits");
//    var row = document.createElement("tr");
//    var cellPrevu = document.createElement("td");
//    var cellRevise = document.createElement("td");
//    var cellCompagnie = document.createElement("td");
//    var cellProvenance = document.createElement("td");
//    var cellEtat = document.createElement("td");

//    cellPrevu.textContent = `${prevu}`;
//    cellRevise.textContent = `${revise}`;
//    cellCompagnie.textContent = `${compagnie}`;
//    cellProvenance.textContent = `${provenance}`;
//    cellEtat.textContent = `${etat}`;

//    row.appendChild(cellPrevu);
//    row.appendChild(cellRevise);
//    row.appendChild(cellCompagnie);
//    row.appendChild(cellProvenance);
//    row.appendChild(cellEtat);

//    tablerow.appendChild(row);

//});

connection.start().then(function () {
    getVols();
}).catch(function (err) {
    return console.error(err.toString());
});

const uri = "/api/vols";

document.getElementById("creerVol").addEventListener("click", function (event) {
    var prevu = document.getElementById("prevu").value;
    var revise = document.getElementById("revise").value;
    var compagnie = document.getElementById("compagnie").value;
    var provenance = document.getElementById("provenance").value;
    var etat = document.getElementById("etat").value;

    const vol =
    {
        id: 0, prevu: prevu, revise: revise, compagnie: compagnie, provenance: provenance, etat: etat
    };

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(vol)
    })
        .then(response => response.json())
        .then(() => {
            connection.invoke("SendMessage", prevu, revise, compagnie, provenance, etat).catch(function (err) {
                return console.error(err.toString());
            });
        })
        .catch(error => alert('Vol Invalide ! Remplir les trois champs !'));

    event.preventDefault();
});