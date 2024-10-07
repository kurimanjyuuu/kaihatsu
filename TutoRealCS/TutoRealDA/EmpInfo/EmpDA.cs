using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Text;
using TutoRealBE.Context;
using TutoRealBE.Result;
using static TutoRealCommon.CommonConst;

namespace TutoRealDA.Emp
{
    public class EmpDA : TutoRealBaseDA
    {
        private readonly IDbConnection _dbConnection;

        public EmpDA(IDbConnection connection, IConfiguration configuration) : base(connection, configuration)
        {
            _dbConnection = connection;
        }

        private static string TblSet(string tableName)
        {
            return tableName;
        }

        // Selectメソッド
        public async Task<IEnumerable<EmpInfoGetResult>> SelectAsync(EmpInfoGetContext context)
        {
            // バリデーションチェック
            ValidateContext(context);

            // コンテキストに基づいてクエリ文字列を生成
            string query = MakeSelectQuery(context);
            var parameters = new
            {
                EmpId7 = $"%{context.EmpId7}%",
                DeptCode4 = $"%{context.DeptCode4}%",
                Seikanji = $"%{context.Seikanji}%",
                Meikanji = $"%{context.Meikanji}%",
                Seikana = $"%{context.Seikana}%",
                Meikana = $"%{context.Meikana}%",
                MailAddress = $"%{context.MailAddress}%",
            };

            return await this.Select<EmpInfoGetResult>(query, parameters);
        }

        public async Task<IEnumerable<EmpInfoGetResult>> GetAsync(EmpInfoGetContext context)
        {
            string query = MakeGetQuery(context);
            var parameters = new
            {
                @EmpId7 = $"{context.EmpId7}",
            };
            IEnumerable<EmpInfoGetResult> result = await this.Select<EmpInfoGetResult>(query, parameters);
            return result;
        }


        private static string MakeGetQuery(EmpInfoGetContext context)
        {
            return $"SELECT * FROM {TblSet("M_EmpMaster")} WHERE EmpId7 = @EmpId7";
        }

        private static string MakeSelectQuery(EmpInfoGetContext context)
        {
            var whereClause = new StringBuilder("1=1");

            if (!string.IsNullOrEmpty(context.EmpId7))
                whereClause.Append(" AND EmpId7 LIKE @EmpId7");
            if (!string.IsNullOrEmpty(context.DeptCode4))
                whereClause.Append(" AND DeptCode4 LIKE @DeptCode4");
            if (!string.IsNullOrEmpty(context.Seikanji))
                whereClause.Append(" AND Seikanji LIKE @Seikanji");
            if (!string.IsNullOrEmpty(context.Meikanji))
                whereClause.Append(" AND Meikanji LIKE @Meikanji");
            if (!string.IsNullOrEmpty(context.Seikana))
                whereClause.Append(" AND Seikana LIKE @Seikana");
            if (!string.IsNullOrEmpty(context.Meikana))
                whereClause.Append(" AND Meikana LIKE @Meikana");
            if (!string.IsNullOrEmpty(context.MailAddress))
                whereClause.Append(" AND MailAddress LIKE @MailAddress");

            return $"SELECT * FROM {TblSet("M_EmpMaster")} WHERE {whereClause}";
        }

        // Insertメソッド
        public async Task<IEnumerable<GeneralResult>> InsertAsync(EmpInfoGetContext context)
        {
            string query = $"INSERT INTO {TblSet("M_EmpMaster")} (EmpId7, DeptCode4, Seikanji, Meikanji, Seikana, Meikana, MailAddress) " +
                           "VALUES (@EmpId7, @DeptCode4, @Seikanji, @Meikanji, @Seikana, @Meikana, @MailAddress)";
            var parameters = new
            {
                EmpId7 = context.EmpId7,
                DeptCode4 = context.DeptCode4,
                Seikanji = context.Seikanji,
                Meikanji = context.Meikanji,
                Seikana = context.Seikana,
                Meikana = context.Meikana,
                MailAddress = context.MailAddress,
            };

            return await ExecuteAsync(query, parameters);
        }

        // Updateメソッド
        public async Task<IEnumerable<GeneralResult>> UpdateAsync(EmpInfoGetContext context)
        {
            string query = $"UPDATE {TblSet("M_EmpMaster")} " +
                           "SET DeptCode4 = @DeptCode4, Seikanji = @Seikanji, Meikanji = @Meikanji, Seikana = @Seikana, Meikana = @Meikana, MailAddress = @MailAddress " +
                           "WHERE EmpId7 = @EmpId7";
            var parameters = new
            {
                EmpId7 = context.EmpId7,
                DeptCode4 = context.DeptCode4,
                Seikanji = context.Seikanji,
                Meikanji = context.Meikanji,
                Seikana = context.Seikana,
                Meikana = context.Meikana,
                MailAddress = context.MailAddress,
            };
            return await ExecuteAsync(query, parameters);
        }

        // Deleteメソッド
        public async Task<IEnumerable<GeneralResult>> DeleteAsync(StandByConditionContext context)
        {
            string query = $"DELETE FROM {TblSet("M_EmpMaster")} WHERE EmpId7 = @EmpId7";
            var parameters = new
            {
                EmpId7 = context.EmpId7,
            };
            return await ExecuteAsync(query, parameters);
        }

        // ExecuteAsyncメソッド
        private async Task<IEnumerable<GeneralResult>> ExecuteAsync(string query, object parameters)
        {
            var results = await _dbConnection.ExecuteAsync(query, parameters);
            return new List<GeneralResult>
            {
                new GeneralResult { Success = results > 0 }
            };
        }

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
    }
}
