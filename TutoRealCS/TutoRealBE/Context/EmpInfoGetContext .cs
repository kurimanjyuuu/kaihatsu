﻿using System.Net.Mail;
using System.Text.Json;

namespace TutoRealBE.Context
{
    /// <summary>
    /// 登録コンテキスト
    /// </summary>
    public class EmpInfoGetContext : ParentContext
    {
        // シリアライズ処理を実装
        public override string Serialize()
        {
            return JsonSerializer.Serialize(this);
        }

        // デシリアライズ処理を実装
        public override void Deserialize(string serializedData)
        {
            var obj = JsonSerializer.Deserialize<EmpInfoGetContext>(serializedData);
            if (obj != null)
            {
                EmpId = obj.EmpId;
                DeptCode = obj.DeptCode;
                Seikanji = obj.Seikanji;
                MeiKanji = obj.MeiKanji;
                Seikana = obj.Seikana;
                Meikana = obj.Meikana;
                MailAddress = obj.MailAddress;

                // 入力データの検証
                Validate();
            }
        }

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
        public string MeiKanji { get; set; } = string.Empty;

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

        /// <summary>
        /// フルネーム
        /// </summary>
        public string FullName => $"{Seikanji} {MeiKanji}";

        /// <summary>
        /// 入力データの検証
        /// </summary>
        private void Validate()
        {
            if (EmpId <= 0)
            {
                throw new ArgumentException("社員番号は正の整数でなければなりません。");
            }

            if (DeptCode <= 0)
            {
                throw new ArgumentException("部署コードは正の整数でなければなりません。");
            }

            // メールアドレスの検証
            try
            {
                var mailAddress = new MailAddress(MailAddress);
            }
            catch (FormatException)
            {
                throw new ArgumentException("メールアドレスの形式が正しくありません。");
            }
        }
    }
}