const notes = JSON.parse(localStorage.getItem('diary-notes') || '{}');
let current = new Date();
let selectedKey = null;

const monthNames = ['Январь','Февраль','Март','Апрель','Май','Июнь','Июль','Август','Сентябрь','Октябрь','Ноябрь','Декабрь'];

const dayNames = ['Пн','Вт','Ср','Чт','Пт','Сб','Вс'];

function renderCalendar() {
    const year = current.getFullYear();
    const month = current.getMonth();
    const today = new Date();

    document.getElementById('month-title').textContent = `${monthNames[month]} ${year}`;

    const grid = document.getElementById('calendar');
    grid.innerHTML = '';

    dayNames.forEach(d => {
        const el = document.createElement('div');
        el.className = 'day-name';
        el.textContent = d;
        grid.appendChild(el);
    });

    let firstDay = new Date(year, month, 1).getDay();
    firstDay = (firstDay + 6) % 7;

    for (let i = 0; i < firstDay; i++) {
        const el = document.createElement('div');
        el.className = 'calendar-day empty';
        grid.appendChild(el);
    }

    const daysInMonth = new Date(year, month + 1, 0).getDate();

    for (let d = 1; d <= daysInMonth; d++) {
        const key = `${year}-${month+1}-${d}`;
        const el = document.createElement('div');
        el.className = 'calendar-day';
        el.textContent = d;

        if (notes[key]) {
            el.classList.add('has-note');
        } 
        if (d === today.getDate() && month === today.getMonth() && year === today.getFullYear()) {
            el.classList.add('today');
        }

        el.addEventListener('click', () => openPopup(key, d, month, year));
        grid.appendChild(el);
    }
}

function openPopup(key, d, month, year) {
    selectedKey = key;
    document.getElementById('popup-date').textContent =
        `${d} ${monthNames[month]} ${year}`;
    document.getElementById('popup-text').value = notes[key] || '';
    document.getElementById('popup-overlay').classList.add('open');
}

document.getElementById('btn-cancel').addEventListener('click', () => {
    document.getElementById('popup-overlay').classList.remove('open');
});

document.getElementById('btn-save').addEventListener('click', () => {
    const text = document.getElementById('popup-text').value.trim();
    if (text) {
        notes[selectedKey] = text;
    } else {
        delete notes[selectedKey];
    }
    localStorage.setItem('diary-notes', JSON.stringify(notes));
    document.getElementById('popup-overlay').classList.remove('open');
    renderCalendar();
});

document.getElementById('prev').addEventListener('click', () => {
    current.setMonth(current.getMonth() - 1);
    renderCalendar();
});

document.getElementById('next').addEventListener('click', () => {
    current.setMonth(current.getMonth() + 1);
    renderCalendar();
});

renderCalendar();