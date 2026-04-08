const dots = document.querySelectorAll('.dot');

const saved = JSON.parse(localStorage.getItem('habits') || '{}');

dots.forEach((dot, index) => {
    if (saved[index]) dot.classList.add('active');

    dot.addEventListener('click', function() {
        this.classList.toggle('active');
        
        const state = {};
        dots.forEach((d, i) => {
            state[i] = d.classList.contains('active');
        });
        localStorage.setItem('habits', JSON.stringify(state));
    });
});

const date = new Date(); 
const dayOfWeek = date.toLocaleString('ru-RU', { weekday: 'long' });
document.querySelector('.tracker-date').textContent = `Сегодня - ${dayOfWeek}`;