document.querySelector('form').addEventListener('submit', function (e) {
    if (!document.getElementById('EditHabit_Id').value) {
        e.preventDefault();
        alert('Выберите привычку');
    }
});
document.getElementById('habitSelect').addEventListener('change', function () {
    const option = this.options[this.selectedIndex];

    document.getElementById('EditHabit_Id').value = option.value;
    document.getElementById('EditHabit_Title').value = option.dataset.title;
    document.getElementById('EditHabit_MonthGoal').value = option.dataset.goal;
});