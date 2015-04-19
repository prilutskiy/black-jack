var baraja_dealer;
var baraja_player;

function logOut() {
    jsobject.exitGameJs();
    window.location.href = '../Home/Index';
}

function logIn() {
    var user = $('#inputlogin').val();
    var pass = $('#inputPassword').val();
    var response = jsobject.logInJs(user, pass);
    var jqState = $.parseJSON(response);

    redraw(jqState);
}

function startGame() {
    var response = jsobject.newGameJs();
    var jqState = $.parseJSON(response);


    var gameTable = $('#gameTableHidden');
    var container = $('#gameTable');
    if (gameTable.hasClass('hidden') && !container.hasClass('hidden')) {
        container.replaceWith(gameTable);
        gameTable.removeClass('hidden');
    }

    redraw(jqState, true);
}

function exit() {
    var response = jsobject.exitGameJs();
    var jqState = $.parseJSON(response);
    redraw(jqState);
}

function hit() {
    var response = jsobject.hitJs();
    var jqState = $.parseJSON(response);
    redraw(jqState);
    $('#doubleButton').addClass('disabled');
}

function doubleBet() {
    var response = jsobject.doubleJs();
    var jqState = $.parseJSON(response);
    redraw(jqState);
    $('#doubleButton').addClass('disabled');
}

function stand() {
    var response = jsobject.standJs();
    var jqState = $.parseJSON(response);
    redraw(jqState);
}

function increaseBet() {
    var response = jsobject.increaseBetJs();
    var jqState = $.parseJSON(response);
    redraw(jqState);
}

function decreaseBet() {
    var response = jsobject.decreaseBetJs();
    var jqState = $.parseJSON(response);
    redraw(jqState);
}

function sendPopup(type, title, message) {
    $.notify({
        title: '<strong>' + title + '</strong><br />',
        message: message
    }, {
        newest_on_top: true,
        delay: 2500,
        type: type
    }, {
        animate: {
            enter: 'animated bounceInDown',
            exit: 'animated bounceOutUp'
        }
    });
}

function clearTable() {
    $('#gameActions').addClass('hidden');
    $('#beforeGameActions').removeClass('hidden');
}

function restart() {
    //$('#dealer-el').empty();
    //$('#player-el').empy();

    $('#gameActions').removeClass('hidden');
    $('#beforeGameActions').addClass('hidden');
    startGame();
}
function redraw(jqState, newGame) {
    if (jqState.AppStage == "game") {
        if (jqState.ErrorMessage != null) {
            sendPopup('warning', 'Oops!', jqState.ErrorMessage);
            return;
        }

        if (newGame) {
            $('#dealerCardScore').parent().addClass('hidden');
            $('#doubleButton').removeClass('disabled');
        }
        $('#playerCardScore').text(jqState.Player.CardScore);
        $('#cash').text(jqState.Player.Cash + '$');
        $('#bet').text(jqState.Bet);

        var dealerHand = $('#dealer-el');
        var playerHand = $('#player-el');

        if (newGame || dealerHand.children().length != jqState.Dealer.Cards.length || jqState.Winner != null) {
            dealerHand.empty();
            for (var i = jqState.Dealer.Cards.length - 1; i >= 0 ; i--) {
                if (i === 0 && jqState.Winner == null) {
                    dealerHand.append($('<li><img src="/Images/Cards/back.png" style="width: 100px; height: 125px"/></li>'));
                    continue;
                }
                dealerHand.append($('<li><img src="' + jqState.Dealer.Cards[i].CardImgPath + '" style="width: 100px; height: 125px"/></li>'));
            }
            baraja_dealer = dealerHand.baraja();
            baraja_dealer.fan({
                speed: 300,
                easing: 'ease-out',
                range: 1,
                direction: 'right',
                origin: { x: 0, y: 0 },
                center: true,
                translation: 200
            });
        }

        if (newGame || playerHand.children().length != jqState.Player.Cards.length) {
            playerHand.empty();
            for (var i = jqState.Player.Cards.length - 1; i >= 0; i--)
                playerHand.append($('<li><img src="' + jqState.Player.Cards[i].CardImgPath + '" style="width: 100px; height: 125px"/></li>'));
            baraja_player = playerHand.baraja();
            baraja_player.fan({
                speed: 300,
                easing: 'ease-out',
                range: 1,
                direction: 'right',
                origin: { x: 0, y: 0 },
                center: true,
                translation: 200
            });
        }


        if (jqState.Winner != null) {
            var prize = Number(jqState.Bet) * Number(jqState.DoubleFactor);
            var type = Number(jqState.Winner.PlayerType);
            if (type === 0) {
                sendPopup('danger', 'Error!', 'Cannot calculate winner.');
            } else if (type === 1) {
                sendPopup('success', 'Congrats!', 'You won the prize!<br />Player: +' + prize.toString() + '$');
            } else if (type === 2) {
                sendPopup('warning', 'Better luck next time...', 'Dealer won the prize.<br />Player: -' + prize.toString() + '$');
            } else if (type === 3) {
                sendPopup('info', 'Wtf?!', 'Draw! Nobody won.');
            }
            $('#dealerCardScore').parent().removeClass('hidden');
            $('#dealerCardScore').text(jqState.Dealer.CardScore);
            clearTable();
        }
    }
    else if (jqState.AppStage == "auth") {
        if (jqState.ErrorMessage != null) {
            sendPopup('warning', 'Oops!', jqState.ErrorMessage);
        } else {
            window.location.href = '../Home/About';
        }
    }
}