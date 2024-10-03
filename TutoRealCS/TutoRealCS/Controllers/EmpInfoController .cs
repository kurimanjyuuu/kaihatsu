
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TutoRealBE.Context;
using TutoRealBE.Result;
using TutoRealBF;
using TutoRealCS.Models;
using static TutoRealCommon.CommonConst;

namespace TutoRealCS.Controllers
{
    public class EmpInfoController : BaseController
    {
        private readonly ITutoRealBaseBF _baseBF;

        public EmpInfoController(ITutoRealBaseBF baseBF) : base(baseBF)
        {
            _baseBF = baseBF;
        }

        [HttpGet]
        public async Task<IActionResult> index(string id)
        {
            // 永続保持情報を取得
            MasterDataResult? master = (MasterDataResult)GetSession(SESSIONKEY.MASTERDATAS);

            if (master is null)
            {
                // Master情報が取れない場合は再ログイン
                return RedirectToAction("Login", "Login");
            }

            // ViewModelの初期化
            EmpInfoViewModel empVM = new();

            // 書籍idが連携された場合は情報を取得する
            if (string.IsNullOrWhiteSpace(id))
            {
                empVM = new EmpInfoViewModel()
                {
                    title = "登録",
                };
                return View(empVM); // IDが空の場合はビューを返す
            }
            else
            {
                EmpInfoGetContext context = new EmpInfoGetContext()
                {
                    Id = id,
                };

                return View(empVM); // IDが存在する場合のビューを返す
            }
        }

    }
}





