document.getElementById('searchQuery').addEventListener('input', function () {
    var searchQuery = this.value.toLowerCase();
    var rows = document.querySelectorAll('.table tbody tr');

    rows.forEach(function (row) {
        var name = row.cells[1].textContent.toLowerCase();
        if (name.includes(searchQuery)) {
            row.style.display = '';
        } else {
            row.style.display = 'none';
        }
    });
});