using System;
using System.Text.Json;
using static TutoRealBE.Entity.CommonEntity;

namespace TutoRealBE
{
    [Serializable]
    public abstract class ParentContext
    {
        // シリアライズするための抽象メソッド
        public abstract string Serialize();

        // デシリアライズするための抽象メソッド
        public abstract void Deserialize(string serializedData);

        /// <summary>
        /// エラーコード
        /// </summary>
        public string ErrorCode { get; set; } = string.Empty;

        /// <summary>
        /// エラーメッセージ
        /// </summary>
        public string ErrorMsg { get; set; } = string.Empty;

        public ProcessKbn ProcessKbn { get; set; }

        /// <summary>
        /// 対象データ件数(取得・登録・更新・削除)
        /// </summary>
        public int DataCount { get; set; }

    }
}
