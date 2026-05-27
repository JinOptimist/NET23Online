$(document).ready(function() {
    
    const url = 'https://localhost:7284/my-hub/habit-tracker-chat';
    const hub = new signalR.HubConnectionBuilder().withUrl(url).build();
    
    hub.on('NewMassageInChat', function(userName, content) {
        const row = $('<div>').addClass('message-row theirs');
        const bubble = $('<div>').addClass('message-bubble');

        row.append(bubble);

        const author = $('<div>').addClass('message-author');
        author.text(userName);
        const mesText = $('<div>').addClass('message-text');
        mesText.text(content);
        const time = $('<div>').addClass('message-time');
        time.text(new Date().toLocaleTimeString('ru', {hour: '2-digit', minute:'2-digit'}));

        bubble.append(author);
        bubble.append(mesText);
        bubble.append(time);

        $('#chatMessages').append(row)
    })
    
    hub.start();


    $('#sendButton').on('click', function() {
        const username = $('#currentUserName').val();
        const userId = $('#currentUserId').val();
        const message = $('#messageInput').val();
        const url = `/api/HabitTrackerApi/SendMessage?username=${username}&message=${message}&userId=${userId}`;
        $.get(url)
    });
    
})