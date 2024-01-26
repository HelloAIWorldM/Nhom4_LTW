set dateformat dmy

create database DripCofe1
use DripCofe1

create table khachhang
(
	maKH int identity(1,1) not null primary key,
	tenKH nvarchar(50) not null,
	soDT varchar(10) ,
	email varchar(50) not null,
)
create table loaiSP
(
maLoai int not null primary key,
loaiHang nvarchar(88) not null,
ghiChu ntext,
)

create table sanPham
(
	maSP varchar(10) not null primary key,
	tenSP nvarchar(50) not null,
	hinhSP varchar(max) not null,
	giaBan int not null,
	ndTomTat nvarchar(500) not null,
	calories nvarchar(10),
	fat nvarchar(50),
	Total varchar(10),
	percentFat varchar(10),
	Saturated varchar(10),
	percentSaturated varchar(10),
	Cholesterol  varchar(10),
	percentCholesterol  varchar(10),
	Sodium varchar(10),
	percentSodium varchar(10),
	Carbohydrates varchar(10),
	percentCarbohydrates varchar(10),
	Sugars varchar(10),
	Protein varchar(10),
	Caffeine varchar(10),
	percentCaffeine  varchar(10),
	thanhPhan nvarchar(20) not null,
	maLoai int not null,
	FOREIGN KEY (maLoai) REFERENCES loaiSP(maLoai)
)
alter table sanPham add percentProtein varchar(10)
 

create table taiKhoanTV
(
	taiKhoan varchar(20) not null primary key,
	matKhau varchar(100) not null,
	email nvarchar(50) not null,
)

create table donHang
(
	soDH varchar(10) not null primary key,
	maKH int not null,
	taiKhoan varchar(20) not null,
	ngayDat datetime,
	ngayGH datetime,
	diaChiGH nvarchar(250),
	ghiChu ntext,
	trangthai int,
)



CREATE TABLE ctDonHang
(
    soDH VARCHAR(10) NOT NULL,
    maSP VARCHAR(10) NOT NULL,
    soLuong INT,
    giaBan BIGINT,
    PRIMARY KEY (soDH, maSP), -- Combined primary key
    CONSTRAINT FK_ctDonHang_donHang
    FOREIGN KEY (soDH)
    REFERENCES donHang(soDH),
    CONSTRAINT FK_ctDonHang_sanPham
    FOREIGN KEY (maSP)
    REFERENCES sanPham(maSP)
);

create table AdminAccount
(
	idAdmin	int identity(1,1) not null primary key,
	taikhoanAdmin varchar(10) not null,
	passAdmin varchar(20) not null,
)

ALTER TABLE donHang
ADD CONSTRAINT FK_donHang_khachhang
FOREIGN KEY (maKH)
REFERENCES khachhang(maKH);

ALTER TABLE donHang
ADD CONSTRAINT FK_donHang_taiKhoanTV
FOREIGN KEY (taiKhoan)
REFERENCES taiKhoanTV(taiKhoan);

ALTER TABLE ctDonHang
ADD CONSTRAINT FK_ctDonHang_donHang
FOREIGN KEY (soDH)
REFERENCES donHang(soDH);

ALTER TABLE ctDonHang
ADD CONSTRAINT FK_ctDonHang_sanPham
FOREIGN KEY (maSP)
REFERENCES sanPham(maSP);

insert into loaiSP values(1,N'Caffè Americano',N'')
insert into loaiSP values(2,N'Caffè Misto',N'')
insert into loaiSP values(3,N'Blonde Caffè Americano',N'')
insert into loaiSP values(4,N'Blonde Roast',N'')
insert into loaiSP values(5,N'Dark Roast Coffee',N'')
insert into loaiSP values(6,N'Pike Place® Roast',N'')
insert into loaiSP values(7,N'Decaf Pike Place® Roast',N'')
insert into loaiSP values(8,N'Cappuccino',N'')
insert into loaiSP values(9,N'Blonde Cappuccino',N'')
insert into loaiSP values(10,N'Espresso',N'')
insert into loaiSP values(11,N'Espresso Macchiato',N'')
insert into loaiSP values(12,N'Flat White',N'')


insert into sanPham values('sp00000001',
					N'Caffè Americano',
	'~/Assets/img/caffe-americano.jpg',
								'48000',
					'15','0','0','','0','','0','','10','0','2','1','0','1','225','',N'Nước, Pha Espresso','1','2',N'Những ly cà phê Espresso được thêm nước nóng sẽ tạo ra một lớp crema nhẹ
                    đỉnh cao là chiếc cốc phong phú tuyệt vời này với chiều sâu và sắc thái.
                    Mẹo chuyên nghiệp: Để tăng thêm hiệu quả, hãy yêu cầu nhân viên pha chế của bạn thử cách này
                    với một cú đánh bổ sung.')
insert into sanPham values('sp00000002',N'Caffè Misto','~/Assets/img/caffe-misto.jpg','48000','110','35','4','5','2','10','15','5','100','4','10','4','10','7','150','',N'Cà Phê Pha, Sữa','2','14',N'Sự kết hợp có một không hai giữa cà phê mới pha và sữa nóng thêm vào một thức uống cà phê thơm ngon rõ rệt được pha trộn đáng kể.')
insert into sanPham values('sp00000003',N'Blonde Caffè Americano','~/Assets/img/caffe-americano.jpg','50000','15','0','0','','0','','0','','10','0','2','1','0','1','225','',N'Nước, Pha Espresso','3','2',N'Những ly cà phê Espresso được phủ bằng nước nóng để tạo ra một lớp cà phê nhẹ
                    crema và được làm bằng Starbucks® Blonde Roast của chúng tôi để có một
                    cốc siêu mịn, ngọt ngào và tinh tế. <br />
                    Mẹo chuyên nghiệp: Để tăng thêm hiệu quả, hãy yêu cầu nhân viên pha chế của bạn thử điều này với
                    một mũi bổ sung (85 mg caffein mỗi mũi).')
insert into sanPham values('sp00000004',N'Blonde Roast','~/Assets/img/dark-roast-coffee.jpg','45000',
					'5','0','0','','0','','0','','10','0','0','','0','1','360','',N'Coffee pha
					','4','2',N'Cà phê rang nhẹ, mềm, êm dịu và có hương vị. Dễ uống và thơm ngon với sữa, đường hoặc có hương vị vani, caramel hoặc quả phỉ.')
insert into sanPham values('sp00000005',N'Dark Roast Coffee','~/Assets/img/dark-roast-coffee.jpg','45000',
					'5','0','0','','0','','0','','10','0','0','','0','1','260','',N'Coffee pha
					','5','2',N'
                    Loại cà phê rang đậm đặc này với hương vị đậm đà, mạnh mẽ
                    giới thiệu nghệ thuật rang và pha trộn của chúng tôi—một sự pha trộn thiết yếu của
                    hương vị cân bằng và kéo dài.')
insert into sanPham values('sp00000006',N'Pike Place® Roast','~/Assets/img/dark-roast-coffee.jpg','48000',
					'5','0','0','','0','','0','','10','0','0','','0','1','310','',N'Coffee pha
					','6','2',N'Từ cửa hàng đầu tiên của chúng tôi ở Chợ Pike Place của Seattle đến
                    quán cà phê trên khắp thế giới, khách hàng yêu cầu một
                    cà phê pha sẵn mà họ có thể thưởng thức suốt cả ngày. Trong năm 2008 của chúng tôi
                    các nhà chế biến và rang xay bậc thầy đã tạo ra thứ này cho bạn—một hỗn hợp mịn,
                    sự pha trộn hoàn hảo của cà phê Mỹ Latinh với sự phong phú tinh tế
                    hương vị của sô cô la và hạt nướng, nó được phục vụ tươi mỗi ngày
                    tại một cửa hàng Starbucks® gần bạn.')
insert into sanPham values('sp00000007',N'Decaf Pike Place® Roast','~/Assets/img/caffe-americano.jpg','47000',
					'5','0','0','','0','','0','','10','0','0','','0','1','25','',N'Coffee Decaf Pha',
					'7','2',N'Từ cửa hàng đầu tiên của chúng tôi ở Chợ Pike Place của Seattle đến
                    quán cà phê trên khắp thế giới, khách hàng yêu cầu một
                    cà phê pha sẵn mà họ có thể thưởng thức suốt cả ngày. Trong năm 2008 của chúng tôi
                    các nhà chế biến và rang xay bậc thầy đã tạo ra thứ này cho bạn—một hỗn hợp mịn,
                    sự pha trộn hoàn hảo của cà phê Mỹ Latinh với sự phong phú tinh tế
                    hương vị của sô cô la và hạt nướng, nó được phục vụ tươi mỗi ngày
                    tại một cửa hàng Starbucks® gần bạn. (Decaf như bạn thích.)')
insert into sanPham values('sp00000008',N'Cappuccino','~/Assets/img/cappuccino.jpg','47000',
					'120','35','4','5','2','10','15','5','100','4','12','4','10','8','150','',N'Sữa, Pha Espresso','8','16',N'Cà phê espresso đậm đà, đậm đà nằm chờ dưới lớp cà phê được làm mịn và kéo dài
                    lớp bọt sữa dày. Một thuật giả kim của nghệ thuật barista và
                    thủ công.')
insert into sanPham values('sp00000009',N'Blonde Cappuccino','~/Assets/img/cappuccino.jpg','45000',
					'120','35','4','5','2','10','15','5','100','4','12','4','10','8','170','',N'Sữa, Pha Espresso','9','16',N'Espresso Blonde ngọt ngào và êm dịu nghiêm túc của chúng tôi đang chờ đợi
                    dưới một lớp bọt dày được làm mịn và kéo dài. Cái này
                    cappuccino mang đến kết cấu sang trọng và lớp bọt mịn như nhung
                    với một dòng chảy ngầm sắc nét, mát mẻ.')
insert into sanPham values('sp00000010',N'Espresso','~/Assets/img/espresso.jpg','50000',
					'10','0','0','','0','','0','','0','','2','1','0','1','150','',N'Espresso ủ','10','2',N'Espresso Roast mịn màng đặc trưng của chúng tôi với hương vị đậm đà và caramel
                    sự ngọt ngào là cốt lõi của mọi việc chúng tôi làm.')
insert into sanPham values('sp00000011',N'Espresso Macchiato','~/Assets/img/espresso-macchiato.jpg','45000',
					'15','0','0','','0','','0','','0','','2','1','0','1','150','',N'Espresso pha, sữa','11','2',N'Cà phê espresso đậm đà của chúng tôi được đánh dấu bằng sữa hấp và bọt. MỘT
                    Phong cách Châu Âu cổ điển.')
insert into sanPham values('sp00000012',N'Flat White','~/Assets/img/flat-white.jpg','48000',
					'170','80','9','12','5','25','25','8','115','5','14','5','13','9','130','',N'Sữa, Pha Espresso','12','18',N'Những bức ảnh ristretto mượt mà của cà phê espresso có được lượng cà phê hoàn hảo
                    hấp sữa nguyên chất để tạo ra một loại sữa không quá đặc, không quá béo,
                    hương vị vừa phải.')
insert into sanPham values('sp00000013',N'Flat White','~/Assets/img/flat-white.jpg','48000',
					'170','80','9','12','5','25','25','8','115','5','14','5','13','9','130','',N'Sữa, Pha Espresso','12','18',N'Những bức ảnh ristretto mượt mà của cà phê espresso có được lượng cà phê hoàn hảo hấp sữa nguyên chất để tạo ra một loại sữa không quá đặc, không quá béo, hương vị vừa phải.')
select * from sanPham

select * from taiKhoanTV
insert into taiKhoanTV values('admin','123','admin@gmail.com')