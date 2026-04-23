const editSelect = document.getElementById('edit-select');
const editFields = document.getElementById('edit-fields');
const editTitle = document.getElementById('edit-title');
const editBtn = document.getElementById('edit-btn');

editSelect.addEventListener('change', function () {
    const selected = this.options[this.selectedIndex];
    if (selected.value) {
        editTitle.value = selected.dataset.title;
        document.getElementById('edit-goal').value = selected.dataset.goal;
        editFields.style.display = 'block';
        document.getElementById('edit-goal-field').style.display = 'block';
        editBtn.style.display = 'block';
    } else {
        editFields.style.display = 'none';
        document.getElementById('edit-goal-field').style.display = 'none';
        editBtn.style.display = 'none';
    }
});