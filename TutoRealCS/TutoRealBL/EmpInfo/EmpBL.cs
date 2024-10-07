using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Collections.Generic;
using TutoRealBE;
using TutoRealBE.Context;
using TutoRealBE.Result;
using TutoRealDA.Emp;
using static TutoRealCommon.CommonConst;
using static TutoRealCommon.CommonFunctionLibrary;
using TutoRealDA;
using TutoRealDA.StandBy;
using System.Data.Common;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TutoRealBL
{
    public class EmpBL : TutoRealBaseBL
    {
        private readonly EmpDA _da;

        public EmpBL(TutoRealDbContext context, IConfiguration configuration) : base(context, configuration)
        {
            // TutoRealDbContext から IDbConnection を取得
            DbConnection dbConnection = (DbConnection)context.Database.GetDbConnection();

            // DAのインスタンスを作成し、IDbConnectionを渡します。
            _da = new EmpDA(dbConnection, configuration);
        }

        public async Task<IEnumerable<ParentContext>> InsertAsync(EmpInfoGetContext context)
        {
            //INSERT実行
            List<GeneralResult> pk = (List<GeneralResult>)await _da.InsertAsync(context);
            return pk;
        }

        public async Task<IEnumerable<ParentContext>> UpdateAsync(EmpInfoGetContext context)
        {
            // 実行
            List<GeneralResult> pk = (List<GeneralResult>)await _da.UpdateAsync(context);
            if (pk != null && pk.Count > 0 && pk[0].PK != null)
            {
                return await _da.UpdateAsync(context);
            }
            return pk;
        }

        public async Task<IEnumerable<GeneralResult>> DeleteAsync(StandByConditionContext context)
        {
            return await _da.DeleteAsync(context);
        }      
    }
}
