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


        console.log(index);
    });
})();