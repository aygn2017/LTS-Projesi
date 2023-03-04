var rolislemleri = {
    listele: function () {
        var page = location.origin + "/Account/RolleriListele";

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
        $('#RolEkle').click(function () {

            var data = decodeURIComponent($("#myModal .modal-body form").serialize());

            $.ajax({
                url: location.origin + "/Account/RolKaydet",
                data: data,
                type: "POST",
                success: function (res) {
                    if (res.result) {
                        swal("Kayıt Başarılı!", "", "success");
                        $("input[name='Name']").val("");
                        rolislemleri.listele();
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
        $('#RolGuncelle').click(function () {

            var data = decodeURIComponent($("#myModal .modal-body form").serialize());

            console.log(data)

            $.ajax({
                url: location.origin + "/Account/RolGuncelle",
                data: data,
                type: "POST",
                success: function (res) {
                    if (res.result) {
                        swal("Güncelleme Başarılı!", "", "success");
                        rolislemleri.listele();
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
        $('#RolSil').click(function () {

            var data = decodeURIComponent($("#myModal .modal-body form").serialize());

            $.ajax({
                url: location.origin + "/Account/RolSil",
                data: data,
                type: "POST",
                success: function (res) {
                    if (res.result) {
                        swal("Silme İşlemi Başarılı!", "", "success");
                        rolislemleri.listele();
                        $('#myModal').modal('hide');
                    } else {
                        swal("Silme İşlemi Başarısız!", "", "error");
                    }
                }, error: function (hata, ajaxoptions, throwerror) {
                    alert("Hata :" + hata.status + " " + throwerror + " " + hata.responseText);
                }
            });
        });
    },
    RolAktifPasif: function (obj) {
        $.ajax({
            url: location.origin + "/Account/RolAktifPasif",
            data: { Id: $(obj).attr("rolId"), aktifPasif: $(obj).is(':checked') },
            type: "POST",
            success: function (res) {
                if (res.result) {
                    rolislemleri.listele();
                } else {
                    swal("Beklenmeyen Bir Hata Oluştu!", "", "error");
                }
            }, error: function (hata, ajaxoptions, throwerror) {
                alert("Hata :" + hata.status + " " + throwerror + " " + hata.responseText);
            }
        });
    }
}