const now = new Date();
document.getElementById('month-label').textContent =
    now.toLocaleString('ru-RU', { month: 'long', year: 'numeric' });

const total = 30;

document.querySelectorAll('.progress-fill').forEach(bar => {
    const percent = bar.dataset.percent;
    bar.style.width = percent + '%';
});