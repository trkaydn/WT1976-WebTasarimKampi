// home index sayfası slider otomatik geçiş
var owl = $('.owl-carousel');
owl.owlCarousel({
    items: 1,
    loop: true,
    margin: 10,
    autoplay: true,
    autoplayTimeout: 3000,
    autoplayHoverPause: true
});

//iletişim butonları click eventi
$(".contactButton").click(async function () {
    var button = $(this);
    await Swal.fire({
        title: 'İletişim Formu',
        html:
            '</br>' +
            '<p>Ad Soyad<p>' +
            '<input id="Name" class="swal2-input">' +
            '<p>E-Posta<p>' +
            '<input id="Mail" class="swal2-input">' +
            '<p>Mesaj<p>' +
            '<textarea id="MessageText" class="swal2-input" style="height:100px">',
        focusConfirm: true,
        showCancelButton: true,
        confirmButtonText: "Gönder",
        cancelButtonText: "Vazgeç",
        allowEscapeKey: false

    }).then((result) => {
        if (result.dismiss === Swal.DismissReason.cancel || result.dismiss == Swal.DismissReason.backdrop)
            return;
        var Message = {
            Name: document.getElementById('Name').value,
            Mail: document.getElementById('Mail').value,
            MessageText: document.getElementById('MessageText').value,
            CarId: $(this).val()
        };
        $.ajax({
            type: 'Post',
            url: '/Home/ContactForm/',
            data: { "message": Message },
            dataType: 'Json',
            success: function (control) {
                if (control == 1) {
                    Swal.fire({
                        type: 'success',
                        icon: 'success',
                        title: 'Başarılı',
                        text: 'Mesajınız başarıyla bize ulaştı.',
                        confirmButtonText: 'Tamam'

                    })
                }
                else {
                    Swal.fire({
                        icon: 'error',
                        title: 'Hata!',
                        text: 'Lütfen tüm alanları eksiksiz doldurun.',
                        confirmButtonText: 'Tamam'

                    }).then(() => {
                        button.click();
                    })
                }
            }
        })
    })
});

$('#galleryModal').on('show.bs.modal', function (e) {
    $('#galleryImage').attr("src", $(e.relatedTarget).data("large-src"));
});

function Focus(id) {
    var div = document.getElementById(id);
    div.style.backgroundColor = "darkgray";
};

function Unfocus(id) {
    var div = document.getElementById(id);
    div.style.backgroundColor = "white";
};
