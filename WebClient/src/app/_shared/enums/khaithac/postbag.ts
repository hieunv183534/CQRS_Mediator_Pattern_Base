export enum PostBagStatus{
    KhongXacDinh =0,
    DangKhoiTao = 1,
    DaDongDi = 2,
    DangKhaiThac = 3,
    DaXacNhan = 4
  }

export enum PostBagStatusName{
  DangKhoiTao = "Khởi tạo",
  DaDongDi = "Đã đóng",
  DangKhaiThac = "Đang khai thác",
  DaXacNhan = "Đã xác nhận"
}

export enum PostBagStatusColor{
  DangKhoiTao = "#c6c7c7", // xam
  DaDongDi = "#FF9900", // cam
  DangKhaiThac = "#FF9900", // cam
  DaXacNhan = "#2db7f5" //xanh blue
}  

export enum PostBagType{
  Tui = 0,
  GiaoRoi = 1,
  DiNgoai = 2,
  TuiThuong = 3
}