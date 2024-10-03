using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using TutoRealBE;
using TutoRealBE.Context;
using TutoRealBE.Entity;
using TutoRealBE.Result;

namespace TutoRealCS.Models
{
    public class EmpInfoViewModel : BaseViewModel
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; } = 0;

        /// <summary>
        /// 社員番号
        /// </summary>  
        public int EmpId { get; set; } = 0;

        /// <summary>
        /// 部署コード
        /// </summary>  
        public int DeptCode { get; set; } = 0;

        /// <summary>
        /// 姓
        /// </summary>
        public string Seikanji { get; set; } = string.Empty;

        /// <summary>
        /// 名
        /// </summary>
        public string Meikanij { get; set; } = string.Empty;

        /// <summary>
        /// せい
        /// </summary>
        public string Seikana { get; set; } = string.Empty;

        /// <summary>
        /// めい
        /// </summary>
        public string Meikana { get; set; } = string.Empty;

        /// <summary>
        /// メールアドレス
        /// </summary>
        public string MailAddress { get; set; } = string.Empty;



    }
}