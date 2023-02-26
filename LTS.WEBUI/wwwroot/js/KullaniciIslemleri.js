var kullaniciislemleri = {
    listele: function () {
        var page = location.origin + "/Account/KullanicilariListele";

        $.ajax({
            type: "GET",
            url: page,
            success: function (e) {
                $(".mycol").html("");
                $(".mycol").html(e);
            },
            error: function (hata, ajaxoptions, throwerror) {
                console.log("Hata :" + hata.status + " " + throwerror + " " + hata.responseText);
            }
        });
    },
    Ekle: function () {
        $('#KullaniciEkle').click(function () {
            
            var data = decodeURIComponent($("#myModal .modal-body form").serialize());

            $.ajax({
                url: location.origin + "/Account/KullaniciKaydet",
                data: data,
                type: "POST",
                success: function (res) {
                    if (res.result) {
                        swal("Kayıt Başarılı!", "", "success");
                        $("input[name='UserName']").val("");
                        $("input[name='Email']").val("");
                        kullaniciislemleri.listele();
                    } else {
                        swal("Kayıt Başarısız!", "", "error");
                    }
                }, error: function (hata, ajaxoptions, throwerror) {
                    alert("Hata :" + hata.status + " " + throwerror + " " + hata.responseText);
                }
            });
         
        });
    },
    Guncelle: function () {
        $('#KullaniciGuncelle').click(function () {

            var data = decodeURIComponent($("#myModal .modal-body form").serialize());
           
            console.log(data)

            $.ajax({
                url: location.origin + "/Account/KullaniciGuncelle",
                data: data,
                type: "POST",
                success: function (res) {
                    if (res.result) {
                        swal("Güncelleme Başarılı!", "", "success");
                        kullaniciislemleri.listele();
                    } else {
                        swal("Güncelleme Başarısız!", "", "error");
                    }
                }, error: function (hata, ajaxoptions, throwerror) {
                    alert("Hata :" + hata.status + " " + throwerror + " " + hata.responseText);
                }
            });
        });
    },
    Sil: function () {
        $('#KullaniciSil').click(function () {

            var data = decodeURIComponent($("#myModal .modal-body form").serialize());

            $.ajax({
                url: location.origin + "/Account/KullaniciSil",
                data: data,
                type: "POST",
                success: function (res) {
                    if (res.result) {
                        swal("Silme İşlemi Başarılı!", "", "success");
                        kullaniciislemleri.listele();
                        $('#myModal').modal('hide');
                    } else {
                        swal("Silme İşlemi Başarısız!", "", "error");
                    }
                }, error: function (hata, ajaxoptions, throwerror) {
                    alert("Hata :" + hata.status + " " + throwerror + " " + hata.responseText);
                }
            });
        });
    }
}