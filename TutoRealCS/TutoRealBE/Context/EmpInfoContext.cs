using System.Net.Mail;
using System.Text.Json;

namespace TutoRealBE.Context
{
    /// <summary>
    /// 登録コンテキスト
    /// </summary>
    public class EmpInfoContext : ParentContext
    {
        // シリアライズ処理を実装
        public override string Serialize()
        {
            return JsonSerializer.Serialize(this);
        }

        // デシリアライズ処理を実装
        public override void Deserialize(string serializedData)
        {
            var obj = JsonSerializer.Deserialize<EmpInfoContext>(serializedData);
            if (obj != null)
            {
                EmpId7 = obj.EmpId7;
     
            }
        }

        /// <summary>
        /// 社員番号
        /// </summary>
        public string EmpId7 { get; set; } = string.Empty; // char
  
    }
}
