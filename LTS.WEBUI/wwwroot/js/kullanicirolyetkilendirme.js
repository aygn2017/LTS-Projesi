var kullanicirolyetkilendirme = {
    listele: function () {
        var page = location.origin + "/Account/KullaniciRolListele";

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
    kullanicirollistele: function (rolId) {
        var page = location.origin + "/Account/RolKullanicilariListele";

        $.ajax({
            type: "GET",
            url: page,
            success: function (e) {
                $('#myModal .modal-body').html(`<form><input name='rolId' type='hidden' value='${rolId}' /> ${e}</form>`);
                $('#myModal .modal-footer').html("<button type='button' onClick='kullanicirolyetkilendirme.rolAta()' class='btn btn-outline-success'>Save changes</button>");
                $('#myModal').modal('show');
            },
            error: function (hata, ajaxoptions, throwerror) {
                console.log("Hata :" + hata.status + " " + throwerror + " " + hata.responseText);
            }
        });
    },
    rolAta: function () {

        let data = $("select[name='kullanicilar']").val();
        let rolId = $("input[name='rolId']").val();

        if (data.indexOf("") > -1 || data.length === 0) {
            return false;
        } else {
            $.ajax({
                url: location.origin + "/Account/KullaniciRolAta",
                data: {rolId: rolId, usersId: data},
                type: "POST",
                success: function (res) {
                    if (res.result) {
                        swal("Kayıt Başarılı!", "", "success");
                        $('#myModal').modal('hide');
                        kullanicirolyetkilendirme.listele();
                    } else {
                        swal("Kayıt Başarısız!", "", "error");
                    }
                }, error: function (hata, ajaxoptions, throwerror) {
                    alert("Hata :" + hata.status + " " + throwerror + " " + hata.responseText);
                }
            });
        }
    },
    Guncelle: function () {
        $('#RolGuncelle').click(function () {

            var data = decodeURIComponent($("#myModal .modal-body form").serialize());

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