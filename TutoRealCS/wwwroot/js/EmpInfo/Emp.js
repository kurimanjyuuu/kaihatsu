﻿$(function () {
    // CSRFトークンの設定
    $.ajaxSetup({
        headers: {
            'RequestVerificationToken': $('input[name="__RequestVerificationToken"]').val()
        }
    });

    // 登録ボタンのクリックイベント
    $('.btnActive').on('click', function (e) {
        e.preventDefault();
        handleEmployee();
    });

    // 新規登録または更新関数
    function handleEmployee() {
        var empId = $('#EmpId').val();
        var deptCode = $('#DeptCode').val();
        var seiKanji = $('#Seikanji').val();
        var meiKanji = $('#Meikanji').val();
        var seiKana = $('#Seikana').val();
        var meiKana = $('#Meikana').val();
        var mailAddress = $('#MailAddress').val();

        if (!validateForm(empId, deptCode, seiKanji, meiKanji, seiKana, meiKana, mailAddress)) {
            return;
        }

        var formData = {
            empId7: empId,
            deptCode4: deptCode,
            seiKanji: seiKanji,
            meiKanji: meiKanji,
            seiKana: seiKana,
            meiKana: meiKana,
            mailAddress: mailAddress,
            ActionType: 'Register'
        };

        $.ajax({
            url: '/EmpInfo/Regist',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(formData),
            success: function (response) {
                if (response.success) {
                    Swal.fire({
                        title: '登録完了',
                        icon: 'success',
                        confirmButtonText: 'OK',
                    }).then(() => {
                        window.location.reload();
                    });
                } else {
                    showError(response.message);
                }
            },
            error: function (xhr) {
                showError('処理に失敗しました。' + xhr.status + ': ' + xhr.statusText);
            }
        });
    }

    // バリデーション関数
    function validateForm(empId, deptCode, seiKanji, meiKanji, seiKana, meiKana, mailAddress) {
        if (!empId) {
            showError('社員番号は必須です。');
            return false;
        }
        if (!deptCode) {
            showError('部署コードは必須です。');
            return false;
        }
        if (!seiKanji) {
            showError('姓は必須です。');
            return false;
        }
        if (!meiKanji) {
            showError('名は必須です。');
            return false;
        }
        if (!seiKana) {
            showError('せいは必須です。');
            return false;
        }
        if (!meiKana) {
            showError('めいは必須です。');
            return false;
        }
        if (!mailAddress) {
            showError('メールアドレスは必須です。');
            return false;
        }
        return true;
    }

    // エラーメッセージ表示関数
    function showError(message) {
        Swal.fire({
            title: 'エラー',
            text: message,
            icon: 'error',
            confirmButtonText: 'OK',
        });
    }
});
