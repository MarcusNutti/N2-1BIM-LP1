$("#table tr").click(function () {
    $(this).addClass('selected').siblings().removeClass('selected');
    var value = $(this).find('td:first').html();
    //alert(value);
    document.getElementById("txtDataSwapA").value = value; /* passa do JS para uma textbox, para dela passar para o C# */
    document.getElementById("txtDataSwapB").value = value; /* passa do JS para uma textbox, para dela passar para o C# */
});

$('.ok').on('click', function (e) {
    alert($("#table tr.selected td:first").html());
});