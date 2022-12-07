"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/volHub").build();

//document.getElementById("btsendbutton").disabled = true;

connection.on("ReceiveMessage", function (prevu, revise, compagnie, provenance, etat) {
    var tablerow = document.getElementById("listeProduits");
    var row = document.createElement("tr");
    var cellPrevu = document.createElement("td");
    var cellRevise = document.createElement("td");
    var cellCompagnie = document.createElement("td");
    var cellProvenance = document.createElement("td");

    cellPrevu.textContent = `${prevu}`;
    cellRevise.textContent = `${revise}`;
    cellCompagnie.textContent = `${compagnie}`;
    cellProvenance.textContent = `${provenance}`;

    row.appendChild(cellPrevu);
    row.appendChild(cellRevise);
    row.appendChild(cellCompagnie);
    row.appendChild(cellProvenance);

    tablerow.appendChild(row);

});

connection.start().then(function () {
    getVols();
}).catch(function (err) {
    return console.error(err.toString());
});

const uri = "/api/vols";

function getVols() {
    fetch(uri)
        .then(response => response.json())
        .then(data =>
            data.forEach(vol => {
                var tablerow = document.getElementById("listeProduits");
                var row = document.createElement("tr");
                var cellPrevu = document.createElement("td");
                var cellRevise = document.createElement("td");
                var cellCompagnie = document.createElement("td");
                var cellProvenance = document.createElement("td");
                var cellEtat = document.createElement("td");
                
                cellPrevu.textContent = `${vol.prevu}`;
                cellRevise.textContent = `${vol.revise}`;
                cellCompagnie.textContent = `${vol.compagnie}`;
                cellProvenance.textContent = `${vol.provenance}`;
                cellEtat.textContent = `${vol.etat}`;

                row.appendChild(cellPrevu);
                row.appendChild(cellRevise);
                row.appendChild(cellCompagnie);
                row.appendChild(cellProvenance);

                tablerow.appendChild(row);
            }))
        .catch(error => alert("Erreur retournée par l'API !"));
}