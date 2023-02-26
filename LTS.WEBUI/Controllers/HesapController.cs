using AutoMapper;
using lts.business.Abtsract;
using lts.business.Concrete;
using lts.domain.Tables;
using lts.DTOS.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LTS.WEBUI.Controllers
{
    [Authorize]
    public class HesapController : Controller
    {
        private readonly IHesapKartTipManager _hesapKartTipManager;
        private readonly IMapper _mapper;

        private readonly IHesapAltGrupManager _hesapAltGrupManager;
        private readonly IHesapKartGrupManager _hesapKartGrupManager;
        private readonly IHesapKartTurManager _hesapKartTurManager;



        public HesapController(IHesapAltGrupManager HesapAltGrupManager, IHesapKartTipManager HesapKartTipManager, IMapper mapper, IHesapKartGrupManager HesapKartGrupManager, IHesapKartTurManager hesapKartTurManager)
        {
            _hesapKartTipManager = HesapKartTipManager;
            _hesapAltGrupManager = HesapAltGrupManager;
            _hesapKartGrupManager = HesapKartGrupManager;
            _mapper = mapper;
            _hesapKartTurManager = hesapKartTurManager;
        }


        [HttpGet]
        public async Task<PartialViewResult> HesapKartTipListele()
        {
            var veri = await _hesapKartTipManager.HesapKartTipiGetir();
            var veri1 = _mapper.Map<List<HesapKartTipDTO>>(veri);

            return PartialView("~/Views/Shared/Components/HesapKartTipTanimlari/HesapKartTip.cshtml", veri1);
        }

        [HttpPost]
        public async Task<JsonResult> HesapKartTipOlustur([FromForm] HesapKartTipDTO hesapKartTipDTO)
        {
            object result;

            if (!ModelState.IsValid)
                return Json(new { result = false });


            HesapKartTip hesapKartTip = _mapper.Map<HesapKartTip>(hesapKartTipDTO);
            if (await _hesapKartTipManager.Create(hesapKartTip) == 1)
                result = new { result = true };
            else
                result = new { result = false };


            return Json(result);

        }

        [HttpPost]
        public async Task<JsonResult> HesapKartTipGuncelle([FromForm] HesapKartTipDTO hesapKartTipDTO)
        {
            object result;

            if (!ModelState.IsValid)
                return Json(new { result = false });


            HesapKartTip hesapKartTip = _mapper.Map<HesapKartTip>(hesapKartTipDTO);
            if (await _hesapKartTipManager.Update(hesapKartTip) == 1)
                result = new { result = true };
            else
                result = new { result = false };

            return Json(result);
        }
        [HttpPost]
        public async Task<JsonResult> HesapKartTipSil([FromForm] HesapKartTipDTO hesapKartTipDTO)
        {
            object result;

            if (!ModelState.IsValid)
                return Json(new { result = false });


            HesapKartTip hesapKartTip = _mapper.Map<HesapKartTip>(hesapKartTipDTO);
            if (await _hesapKartTipManager.Delete(hesapKartTip.TipID) == 1)
                result = new { result = true };
            else
                result = new { result = false };

            return Json(result);
        }

        [HttpGet]
        public async Task<PartialViewResult> HesapKartAltGrupListele()
        {
            var veri = await _hesapAltGrupManager.HesapAltGrupGetir();
            var veri2 = _mapper.Map<List<HesapAltGrupDTO>>(veri);

            return PartialView("~/Views/Shared/Components/HesapKartAltGrupTanimlari/HesapKartAltGrup.cshtml", veri2);
             }

        [HttpPost]
        public async Task<JsonResult> HesapKartAltGrupOlustur([FromForm] HesapAltGrupDTO hesapAltGrupDTO)
        {
            object result;

            if (!ModelState.IsValid)
                return Json(new { result = false });


            HesapAltGrup hesapAltGrup = _mapper.Map<HesapAltGrup>(hesapAltGrupDTO);
            if (await _hesapAltGrupManager.Create(hesapAltGrup) == 1)
                result = new { result = true };
            else
                result = new { result = false };


            return Json(result);

        }

        [HttpPost]
        public async Task<JsonResult> HesapKartAltGrupGuncelle([FromForm] HesapAltGrupDTO hesapAltGrupDTO)
        {
            object result;

            if (!ModelState.IsValid)
                return Json(new { result = false });


            HesapAltGrup hesapAltGrup = _mapper.Map<HesapAltGrup>(hesapAltGrupDTO);
            if (await _hesapAltGrupManager.Update(hesapAltGrup) == 1)
                result = new { result = true };
            else
                result = new { result = false };

            return Json(result);
        }
        [HttpPost]
        public async Task<JsonResult> HesapKartAltGrupSil([FromForm] HesapAltGrupDTO hesapAltGrupDTO)
        {
            object result;

            if (!ModelState.IsValid)
                return Json(new { result = false });


            HesapAltGrup hesapAltGrup = _mapper.Map<HesapAltGrup>(hesapAltGrupDTO);
            if (await _hesapAltGrupManager.Delete(hesapAltGrup.AltGrupID) == 1)
                result = new { result = true };
            else
                result = new { result = false };

            return Json(result);
        }

        [HttpGet]
        public async Task<PartialViewResult> HesapKartGrupListele()
        {
            var veri = await _hesapKartGrupManager.HesapKartGruplariGetir();
            var veri1 = _mapper.Map<List<HesapKartGrupDTO>>(veri);

            return PartialView("~/Views/Shared/Components/HesapKartGrup/HesapKartGrup.cshtml", veri1);
        }

        [HttpPost]
        public async Task<JsonResult> HesapKartGrupOlustur([FromForm] HesapKartGrupDTO hesapKartGrupDTO)
        {
            object result;

            if (!ModelState.IsValid)
                return Json(new { result = false });


            HesapKartGrup hesapKartGrup = _mapper.Map<HesapKartGrup>(hesapKartGrupDTO);
            if (await _hesapKartGrupManager.Create(hesapKartGrup) == 1)
                result = new { result = true };
            else
                result = new { result = false };


            return Json(result);

        }

        [HttpPost]
        public async Task<JsonResult> HesapKartGrupGuncelle([FromForm] HesapKartGrupDTO hesapKartGrupDTO)
        {
            object result;

            if (!ModelState.IsValid)
                return Json(new { result = false });


            HesapKartGrup hesapKartGrup = _mapper.Map<HesapKartGrup>(hesapKartGrupDTO);
            if (await _hesapKartGrupManager.Update(hesapKartGrup) == 1)
                result = new { result = true };
            else
                result = new { result = false };

            return Json(result);
        }

        [HttpPost]
        public async Task<JsonResult> HesapKartGrupSil([FromForm] HesapKartGrupDTO hesapKartGrupDTO)
        {
            object result;

            if (!ModelState.IsValid)
                return Json(new { result = false });


            HesapKartGrup hesapKartGrup = _mapper.Map<HesapKartGrup>(hesapKartGrupDTO);
            if (await _hesapKartGrupManager.Delete(hesapKartGrup.KartGrupID) == 1)
                result = new { result = true };
            else
                result = new { result = false };

            return Json(result);
        }
        [HttpGet]
        public async Task<PartialViewResult> HesapKartTurListele()
        {
            var veri = await _hesapKartTurManager.HesapKartTuruGetir();
            var veri1 = _mapper.Map<List<HesapKartTurDTO>>(veri);

            return PartialView("~/Views/Shared/Components/HesapKartTurleri/HesapKartTurleri.cshtml", veri1);
        }
        [HttpPost]
        public async Task<JsonResult> HesapKartTurOlustur([FromForm] HesapKartTurDTO hesapKartTurDTO)
        {
            object result;

            if (!ModelState.IsValid)
                return Json(new { result = false });


            HesapKartTur hesapKartTur = _mapper.Map<HesapKartTur>(hesapKartTurDTO);
            if (await _hesapKartTurManager.Create(hesapKartTur) == 1)
                result = new { result = true };
            else
                result = new { result = false };


            return Json(result);

        }
        [HttpPost]
        public async Task<JsonResult> HesapKartTurGuncelle([FromForm] HesapKartTurDTO hesapKartTurDTO)
        {
            object result;

            if (!ModelState.IsValid)
                return Json(new { result = false });


            HesapKartTur hesapKartTur = _mapper.Map<HesapKartTur>(hesapKartTurDTO);
            if (await _hesapKartTurManager.Update(hesapKartTur) == 1)
                result = new { result = true };
            else
                result = new { result = false };

            return Json(result);
        }

        [HttpPost]
        public async Task<JsonResult> HesapKartTurSil([FromForm] HesapKartTurDTO hesapKartTurDTO)
        {
            object result;

            if (!ModelState.IsValid)
                return Json(new { result = false });

            HesapKartTur hesapKartTur = _mapper.Map<HesapKartTur>(hesapKartTurDTO);
            if (await _hesapKartTurManager.Delete(hesapKartTur.TurID) == 1)
                result = new { result = true };
            else
                result = new { result = false };

            return Json(result);
        }

    }
}