using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.Common;
using TutoRealBE;
using TutoRealBE.Context;
using TutoRealBE.Result;
using TutoRealDA;
using TutoRealDA.Emp;
using static TutoRealCommon.CommonConst;
using static TutoRealCommon.CommonFunctionLibrary;

namespace TutoRealBL
{
    // BLプロジェクト内
    public class EmpBL : TutoRealBaseBL
    {
        private readonly EmpDA _da;

        public EmpBL(TutoRealDbContext context, IConfiguration configuration) : base(context, configuration)
        {
            // IDbConnectionをDbConnectionにキャスト
            DbConnection dbConnection = (DbConnection)context.Database.GetDbConnection();

            // DAのインスタンスを作成し、DbConnectionを渡します。
            _da = new EmpDA(dbConnection, configuration);
        }

        public async Task<IEnumerable<ParentContext>> InsertAsync(EmpInfoGetContext context)
        {
            //INSERT実行
            List<GeneralResult> pk = (List<GeneralResult>)await _da.InsertAsync(context);
            return pk;
        }

    }
}