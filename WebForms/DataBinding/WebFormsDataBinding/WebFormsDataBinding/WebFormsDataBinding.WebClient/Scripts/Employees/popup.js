(function () {
    const root = $("#employees-container");

    root.on("click", "tr", function (ev) {
        const target = $(ev.target);

        const tr = target.parent("tr");

        let index = tr.children("td").eq(0).text();
        index = Number(index);
        if (Number.isNaN(index)) {
            return;
        }

        $.getJSON("/api/employees/" + index)
            .done(function (data) {
                const popup = document.createElement("div");

                const fullName = document.createElement("div");
                fullName.innerHTML += data.FirstName + " " + data.LastName;

                popup.appendChild(fullName);

                document.getElementById("employees-container").appendChild(popup);
            });
    });
})();