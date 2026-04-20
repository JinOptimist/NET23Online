const dots = document.querySelectorAll('.dot');

dots.forEach(dot => {
    dot.addEventListener('click', function() {
        const habitId = parseInt(this.dataset.habitId);
        const dayIndex = parseInt(this.dataset.dayIndex);

        this.classList.toggle('active');
        fetch('/HabitTracker/TogglePoint', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded'
            },
            body: `habitId=${habitId}&dayIndex=${dayIndex}`
        });
    });
});

const date = new Date(); 
const dayOfWeek = date.toLocaleString('ru-RU', { weekday: 'long' });
document.querySelector('.tracker-date').textContent = `Сегодня - ${dayOfWeek}`;