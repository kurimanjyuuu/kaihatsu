using Microsoft.AspNetCore.Mvc;
using TutoRealBE.Context;
using TutoRealBE.Entity;
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
        public async Task<IActionResult> Index(int EmpId)
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


            // EmpIdを取得する
            if (EmpId != 0)
            {
                empVM = new EmpInfoViewModel()
                {
                    title = "社員情報",
                    EmpId = EmpId,
                    DeptCode = empVM.DeptCode,
                    Seikanji = empVM.Seikanji,
                    Meikanji = empVM.Meikanji,
                    Seikana = empVM.Seikana,
                    Meikana = empVM.Meikana,
                    MailAddress = empVM.MailAddress,    
                };
            }
            else
            {
                EmpInfoGetContext context = new EmpInfoGetContext()
                {
                   EmpId = EmpId
                };
                   
                }
            return View("EmpInfo", empVM); // ビューを返す
        }
    }
}