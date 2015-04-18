var baraja_dealer;
var baraja_player;


$(document).ready(function () {
    $('#startButton').on('click', function () {
        var gameTable = $('#gameTableHidden');
        var container = $('#gameTable');
        container.replaceWith(gameTable);
        gameTable.removeClass('hidden');
        addCard();
    });
});

function addCard(card) {
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

