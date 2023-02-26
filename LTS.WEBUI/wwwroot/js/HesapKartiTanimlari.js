var hesapkartaltgruptanimlari = {
    listele: function(){

        var page = location.origin + "/Hesap/HesapKartAltGrupListele";

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
        $('#hesapAltGrupEkle').click(function () {
            var data = $("#myModal .modal-body form").serialize();
            $.ajax({
                url: location.origin + "/Hesap/HesapKartAltGrupOlustur",
                data: data,
                type: "POST",
                success: function (res) {
                    if (res.result) {
                        swal("Kayıt Başarılı!", "", "success");
                        $("input[name='GrupAdi']").val("");
                        hesapkartaltgruptanimlari.listele();
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
        $('#hesapAltGrupGuncelle').click(function () {

            var data = $("#myModal .modal-body form").serialize();
            
            $.ajax({
                url: location.origin + "/Hesap/HesapKartAltGrupGuncelle",
                data: data,
                type: "POST",
                success: function (res) {
                    if (res.result) {
                        swal("Güncelleme Başarılı!", "", "success");
                        hesapkartaltgruptanimlari.listele();
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
        $('#hesapAltGrupSil').click(function () {

            var data = $("#myModal .modal-body form").serialize();

            $.ajax({
                url: location.origin + "/Hesap/HesapKartAltGrupSil",
                data: data,
                type: "POST",
                success: function (res) {
                    if (res.result) {
                        swal("Silme İşlemi Başarılı!", "", "success");
                        hesapkartaltgruptanimlari.listele();
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

var hesapkarttiptanimlari = {
    listele: function () {

        var page = location.origin + "/Hesap/HesapKartTipListele";

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
        $('#hesapTipEkle').click(function () {

            var data = $("#myModal .modal-body form").serialize();

            $.ajax({
                url: location.origin + "/Hesap/HesapKartTipOlustur",
                data: data,
                type: "POST",
                success: function (res) {
                    if (res.result) {
                        swal("Kayıt Başarılı!", "", "success");
                        $("input[name='TipAdi']").val("");
                        hesapkarttiptanimlari.listele();
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
        $('#hesapTipGuncelle').click(function () {

            var data = $("#myModal .modal-body form").serialize();

            $.ajax({
                url: location.origin + "/Hesap/HesapKartTipGuncelle",
                data: data,
                type: "POST",
                success: function (res) {
                    if (res.result) {
                        swal("Güncelleme Başarılı!", "", "success");
                        hesapkarttiptanimlari.listele();
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
        $('#hesapTipSil').click(function () {

            var data = $("#myModal .modal-body form").serialize();

            $.ajax({
                url: location.origin + "/Hesap/HesapKartTipSil",
                data: data,
                type: "POST",
                success: function (res) {
                    if (res.result) {
                        swal("Silme İşlemi Başarılı!", "", "success");
                        hesapkarttiptanimlari.listele();
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

var hesapkartgruptanimlari = {
    listele: function () {

        var page = location.origin + "/Hesap/HesapKartGrupListele";

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
        $('#hesapKartGrupEkle').click(function () {

            var data = $("#myModal .modal-body form").serialize();

            $.ajax({
                url: location.origin + "/Hesap/HesapKartGrupOlustur",
                data: data,
                type: "POST",
                success: function (res) {
                    if (res.result) {
                        swal("Kayıt Başarılı!", "", "success");
                        $("input[name='GrupAdi']").val("");
                        hesapkartgruptanimlari.listele();
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
        $('#hesapKartGrupGuncelle').click(function () {

            var data = $("#myModal .modal-body form").serialize();

            $.ajax({
                url: location.origin + "/Hesap/HesapKartGrupGuncelle",
                data: data,
                type: "POST",
                success: function (res) {
                    if (res.result) {
                        swal("Güncelleme Başarılı!", "", "success");
                        hesapkartgruptanimlari.listele();
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
        $('#hesapKartGrupSil').click(function () {

            var data = $("#myModal .modal-body form").serialize();

            $.ajax({
                url: location.origin + "/Hesap/HesapKartGrupSil",
                data: data,
                type: "POST",
                success: function (res) {
                    if (res.result) {
                        swal("Silme İşlemi Başarılı!", "", "success");
                        hesapkartgruptanimlari.listele();
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

var hesapkartturtanimlari = {
    listele: function () {

        var page = location.origin + "/Hesap/HesapKartTurListele";

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
        $('#hesapKartTurEkle').click(function () {

            var data = $("#myModal .modal-body form").serialize();

            $.ajax({
                url: location.origin + "/Hesap/HesapKartTurOlustur",
                data: data,
                type: "POST",
                success: function (res) {
                    if (res.result) {
                        swal("Kayıt Başarılı!", "", "success");
                        $("input[name='TurAdi']").val("");
                        hesapkartturtanimlari.listele();
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
        $('#hesapKartTurGuncelle').click(function () {

            var data = $("#myModal .modal-body form").serialize();

            $.ajax({
                url: location.origin + "/Hesap/HesapKartTurGuncelle",
                data: data,
                type: "POST",
                success: function (res) {
                    if (res.result) {
                        swal("Güncelleme Başarılı!", "", "success");
                        hesapkartturtanimlari.listele();
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
        $('#hesapKartTurSil').click(function () {

            var data = $("#myModal .modal-body form").serialize();

            $.ajax({
                url: location.origin + "/Hesap/HesapKartTurSil",
                data: data,
                type: "POST",
                success: function (res) {
                    if (res.result) {
                        swal("Silme İşlemi Başarılı!", "", "success");
                        hesapkartturtanimlari.listele();
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