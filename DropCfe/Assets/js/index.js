const passwordTB = document.querySelector(".thong-bao");
const passwordIN = document.querySelector(".pasword2");
function checkUsernam() {
    let psw = passwordTB.value;
    if (psw.length < 3) {
        passwordIN.innerHTML = "Vui lòng nhập mật khẩu dài ít nhất 8 ký tự";
    } else {

        location.reload();
    }
}