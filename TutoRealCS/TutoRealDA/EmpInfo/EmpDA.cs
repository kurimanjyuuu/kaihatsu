using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Text;
using TutoRealBE;
using TutoRealBE.Context;
using TutoRealBE.Result;
using TutoRealBE.Entity;
using static TutoRealCommon.CommonConst;
using static TutoRealCommon.CommonFunctionLibrary;

namespace TutoRealDA.Emp
{
    public class EmpDA : TutoRealBaseDA
    {
        private readonly IDbConnection _dbConnection;

        public EmpDA(IDbConnection connection, IConfiguration configuration) : base(connection, configuration)
        {
            _dbConnection = connection;

        }
        private static string MakeInsertQuery(EmpInfoGetContext context)
        {
            StringBuilder query = new StringBuilder();

            // 登録クエリ
            query.AppendLine($"INSERT INTO {TblSet(TBLNAME.M_EMPMASTER)} (EmpId7, Seikanji, Meikanji, Seikana, Meikana, DeptCode4, MailAddress) VALUES ");
            query.AppendLine("(");
            query.AppendLine("@EmpId7");
            query.AppendLine(",@Seikanji");
            query.AppendLine(",@Meikanji");
            query.AppendLine(",@Seikana");
            query.AppendLine(",@Meikana");
            query.AppendLine(",@DeptCode4");
            query.AppendLine(",@MailAddress");
            query.AppendLine(")");

            //query.AppendLine("SELECT @Empnum");

            return query.ToString();
        }

        // Updateメソッド
        //public async Task<IEnumerable<GeneralResult>> UpdateAsync(EmpInfoGetContext context)
        //{
        //    string query = $"UPDATE {TblSet("M_EmpMaster")} " +
        //                   "SET DeptCode4 = @DeptCode4, Seikanji = @Seikanji, Meikanji = @Meikanji, Seikana = @Seikana, Meikana = @Meikana, MailAddress = @MailAddress " +
        //                   "WHERE EmpId7 = @EmpId7";
        //    var parameters = new
        //    {
        //        @EmpId7 = context.EmpId7,
        //        @DeptCode4 = context.DeptCode4,
        //        @Seikanji = context.Seikanji,
        //        @Meikanji = context.Meikanji,
        //        @Seikana = context.Seikana,
        //        @Meikana = context.Meikana,
        //        @MailAddress = context.MailAddress,
        //    };
        //    return await ExecuteAsync(query, parameters);
        // }

        // Deleteメソッド
        //public async Task<IEnumerable<GeneralResult>> DeleteAsync(StandByConditionContext context)
        //{
        //    string query = $"DELETE FROM {TblSet("M_EmpMaster")} WHERE EmpId7 = @EmpId7";
        //    var parameters = new
        //    {
        //        EmpId7 = context.EmpId7,
        //    };
        //    return await ExecuteAsync(query, parameters);
        //}

        // ExecuteAsyncメソッド
        //private async Task<IEnumerable<GeneralResult>> ExecuteAsync(string query, object parameters)
        //{
        //    var results = await _dbConnection.ExecuteAsync(query, parameters);
        //    return new List<GeneralResult>
        //    {
        //        new GeneralResult { Success = results > 0 }
        //    };
        //}

        // バリデーションチェック
        private void ValidateContext(EmpInfoGetContext context)
        {
            if (string.IsNullOrEmpty(context.EmpId7))
                throw new ArgumentException("EmpId7は必須です。");
            if (string.IsNullOrEmpty(context.DeptCode4))
                throw new ArgumentException("DeptCode4は必須です。");
            if (string.IsNullOrEmpty(context.Seikanji))
                throw new ArgumentException("Seikanjiは必須です。");
            if (string.IsNullOrEmpty(context.Meikanji))
                throw new ArgumentException("Meikanjiは必須です。");
            if (string.IsNullOrEmpty(context.Seikana))
                throw new ArgumentException("Seikanaは必須です。");
            if (string.IsNullOrEmpty(context.Meikana))
                throw new ArgumentException("Meikanaは必須です。");
            if (string.IsNullOrEmpty(context.MailAddress))
                throw new ArgumentException("MailAddressは必須です。");
        }

        public async Task<List<GeneralResult>> InsertAsync(EmpInfoGetContext context)
        {
            throw new NotImplementedException();
        }
    }
}
