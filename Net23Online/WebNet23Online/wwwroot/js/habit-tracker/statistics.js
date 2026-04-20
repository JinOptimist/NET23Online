document.addEventListener('DOMContentLoaded', function () {
    const now = new Date();
    const monthLabel = document.getElementById('month-label');

    if (monthLabel) {
        monthLabel.textContent =
            now.toLocaleString('ru-RU', { month: 'long', year: 'numeric' });
    }

    document.querySelectorAll('.progress-fill').forEach(bar => {
        const raw = bar.dataset.percent;
        if (!raw) return;

        const percent = parseFloat(raw.replace(',', '.'));
        if (!Number.isNaN(percent)) {
            bar.style.width = percent + '%';
        }
    });
});