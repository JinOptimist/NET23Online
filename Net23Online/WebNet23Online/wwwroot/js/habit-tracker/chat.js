$(document).ready(function() {
    alert("CHAT JS LOADED");
    
    const url = 'http://localhost:5170/my-hub/habit-tracker-chat';
    const hub = new signalR.HubConnectionBuilder().withUrl(url).build();
    
    hub.on('NewMassageInChat', function(userName, content) {
        const currentUserName = $('#currentUserName').val();

        const isMine = userName === currentUserName;

        const row = $('<div>').addClass(
            isMine
                ? 'message-row mine'
                : 'message-row theirs'
        );
        const bubble = $('<div>').addClass('message-bubble');

        row.append(bubble);

        const author = $('<div>').addClass('message-author');
        author.text(userName);
        const mesText = $('<div>').addClass('message-text');
        mesText.text(content);
        const time = $('<div>').addClass('message-time');
        time.text(new Date().toLocaleTimeString('ru', {hour: '2-digit', minute:'2-digit'}));

        if (!isMine){
            bubble.append(author);
        }
        bubble.append(mesText);
        bubble.append(time);

        $('#chatMessages').append(row)
    })

    console.log(url);
    hub.start()
        .then(() => console.log("CONNECTED"))
        .catch(err => console.error(err));

    $('#sendButton').on('click', function() {
        const username = $('#currentUserName').val();
        const userId = $('#currentUserId').val();
        const message = $('#messageInput').val();
        const url = `/api/HabitTrackerApi/SendMessage?username=${username}&message=${message}&userId=${userId}`;
        $.get(url);
        $('#messageInput').val('');
    });
    
})