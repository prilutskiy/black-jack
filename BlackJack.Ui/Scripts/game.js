var baraja_dealer;
var baraja_player;


function startGame() {
    var response = jsobject.newGameJs();
    var jqState = $.parseJSON(response);

    var gameTable = $('#gameTableHidden');
    var container = $('#gameTable');
    container.replaceWith(gameTable);
    gameTable.removeClass('hidden');

    //alert(jqState.Dealer.Cards[0].CardImgPath);

    //addCards();
    redraw(jqState);
}

function hit() {
    var response = jsobject.hitJs();
    var jqState = $.parseJSON(response);
    redraw(jqState);
}

function redraw(jqState) {
    $('#playerCardScore').text(jqState.Player.CardScore);
    $('#cash').text(jqState.Player.Cash + '$');
    $('#bet').text(jqState.Bet);

    var dealerHand = $('#dealer-el');
    var playerHand = $('#player-el');

    dealerHand.empty();
    for (var i = jqState.Dealer.Cards.length - 1; i >=0 ; i--) {
        if (i === 0) {
            dealerHand.append($('<li><img src="/Images/Cards/back.png" style="width: 100px; height: 125px"/></li>'));
            continue;
        }
        dealerHand.append($('<li><img src="' + jqState.Dealer.Cards[i].CardImgPath + '" style="width: 100px; height: 125px"/></li>'));
    }

    playerHand.empty();
    for (var i = jqState.Player.Cards.length - 1; i >= 0; i--)
        playerHand.append($('<li><img src="' + jqState.Player.Cards[i].CardImgPath + '" style="width: 100px; height: 125px"/></li>'));

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

$(document).ready(function () {
    $('form').removeAttr('novalidate');
    //$('#startButton').on('click', function () {
    //    response = jsobject.newGameJs('hello');
    //    var state = JSON.parse(response);
    //    alert(state);
    //    var gameTable = $('#gameTableHidden');
    //    var container = $('#gameTable');
    //    container.replaceWith(gameTable);
    //    gameTable.removeClass('hidden');
    //    addCard();
    //});
});

function addCards() {
    var el_d = $('#dealer-el');
    var el_p = $('#player-el');
    setTimeout(el_d.empty(), 1000);
    setTimeout(el_p.empty(), 1000);

    el_d.append($('<li><img src="/Images/1.png" style="width: 100px; height: 125px"/></li>'));
    el_d.append($('<li><img src="/Images/2.png" style="width: 100px; height: 125px"/></li>'));
    el_d.append($('<li><img src="/Images/3.png" style="width: 100px; height: 125px"/></li>'));
    el_d.append($('<li><img src="/Images/4.png" style="width: 100px; height: 125px"/></li>'));
    el_d.append($('<li><img src="/Images/5.png" style="width: 100px; height: 125px"/></li>'));
    el_d.append($('<li><img src="/Images/2.png" style="width: 100px; height: 125px"/></li>'));
    el_d.append($('<li><img src="/Images/3.png" style="width: 100px; height: 125px"/></li>'));
    el_d.append($('<li><img src="/Images/4.png" style="width: 100px; height: 125px"/></li>'));
    el_d.append($('<li><img src="/Images/5.png" style="width: 100px; height: 125px"/></li>'));
    el_d.append($('<li><img src="/Images/2.png" style="width: 100px; height: 125px"/></li>'));
    el_d.append($('<li><img src="/Images/3.png" style="width: 100px; height: 125px"/></li>'));
    el_d.append($('<li><img src="/Images/4.png" style="width: 100px; height: 125px"/></li>'));
    el_d.append($('<li><img src="/Images/5.png" style="width: 100px; height: 125px"/></li>'));

    el_p.append($('<li><img src="/Images/5.png" style="width: 100px; height: 125px"/></li>'));
    el_p.append($('<li><img src="/Images/12.png" style="width: 100px; height: 125px"/></li>'));
    el_p.append($('<li><img src="/Images/12.png" style="width: 100px; height: 125px"/></li>'));

    baraja_dealer = el_d.baraja();
    baraja_dealer.fan({
        speed: 300,
        easing: 'ease-out',
        range: 1,
        direction: 'right',
        origin: { x: 0, y: 0 },
        center: true,
        translation: 200
    });


    baraja_player = el_p.baraja();
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


function myMethod() {
    $.notify({
        title: '<strong>Heads up!</strong>',
        message: 'You can use any of bootstraps other alert styles as well by default.'
    }, {
        newest_on_top: true,
        delay: 0,
        type: 'success'
    }, {
        animate: {
            enter: 'animated bounceInDown',
            exit: 'animated bounceOutUp'
        }
    });
    //alert("In myMethodExpectingReturn, calling .NET and expecting return value.");

    //var returnVal2 = jsobject.test("some argument");
    //alert("Got value from .NET: " + returnVal2);
}

function myMethodProvidingReturn(whatToReturn) {
    var returnVal = whatToReturn + "bar";
    document.write("Returning '" + returnVal + "' to .NET.");

    return returnVal;
}

