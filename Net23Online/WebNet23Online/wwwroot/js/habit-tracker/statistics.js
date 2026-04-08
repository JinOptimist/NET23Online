const now = new Date();
document.getElementById('month-label').textContent =
    now.toLocaleString('ru-RU', { month: 'long', year: 'numeric' });

const data = {
    sport: 18,
    english: 12,
    programming: 25,
    water: 9
};

const total = 30;

Object.entries(data).forEach(([habit, done]) => {
    const percent = Math.round((done / total) * 100);
    document.getElementById(`bar-${habit}`).style.width = percent + '%';
    document.getElementById(`val-${habit}`).textContent = `${done} / ${total}`;
});