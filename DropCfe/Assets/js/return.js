
    document.addEventListener('DOMContentLoaded', function () {
        // Lắng nghe sự kiện click cho tất cả các nút xóa sản phẩm
        const removeButtons = document.querySelectorAll('.remove-item-btn');
        removeButtons.forEach(button => {
        button.addEventListener('click', function () {
            // Lấy mã sản phẩm từ thuộc tính data-masp
            const maSP = this.getAttribute('data-masp');

            // Gửi yêu cầu xóa sản phẩm thông qua Ajax
            $.ajax({
                url: '/Menu/XoaItem', // Đường dẫn đến action XoaItem
                type: 'POST',
                data: { maSP: maSP },
                success: function (result) {
                    // Cập nhật giỏ hàng trên trang mà không cần tải lại
                    // Đặt lại nội dung giỏ hàng với dữ liệu mới từ server
                    const cartOverlay = document.querySelector('.cart-overlay');
                    cartOverlay.innerHTML = result;
                },
                error: function () {
                    alert('Đã xảy ra lỗi khi gửi yêu cầu xóa');
                }
            });
        });
        });
    });

