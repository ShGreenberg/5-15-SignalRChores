$(() => {
    const fillTable = () => {
        $.get("/home/getchores", function (chores) {
            $("#chores-table").find("tr:gt(0)").remove();
            chores.forEach(c => {
                let button = "";
                if (c.status == 0) {
                    $("#chores-table").append(`<tr>
                                 <td>${c.name}</td>
                                 <td><button class="btn btn-primary do-it" data-id="${c.id}">Im doing this one</button></td>
                                                 </tr>`);
                } else if (c.status == 1) {
                    if (c.user.email == user) {
                        button = `<button class="btn btn-info done" data-id="${c.id}">Done</button>`;
                    } else {
                        button = `<button class="btn btn-warning" disabled>${c.user.name} is doing this one</button>`;
                    }
                    $("#chores-table").append(`<tr>
                                                    <td>${c.name}</td>
                                                    <td>${button}</td>
                                                 </tr>`);
                }
            });
        });
    }
    const user = $("#user").text();

    fillTable();

    const conn = new signalR.HubConnectionBuilder().withUrl("/choresHub").build();
    conn.start();

    $("#btn-add-task").on('click', function () {
        const name = $("#name").val();
        conn.invoke("AddChore", name);
    });
    conn.on("AddChore", () => {
        fillTable();
    });


    $("#chores-table").on('click', '.do-it', function () {
        const chore = {
            id: $(this).data("id"),
            user: { email: user },
            status: 1
        };
        conn.invoke("StartChore", chore);
    });
    conn.on("StartChore", () => {
        fillTable();
    });

    $("#chores-table").on('click', '.done', function () {
        const chore = {
            id: $(this).data("id"),
            user: { email: user },
            status: 2
        };
        conn.invoke("CompleteChore", chore);
    });
    conn.on("CompleteChore", () => {
        fillTable();
    });

});




