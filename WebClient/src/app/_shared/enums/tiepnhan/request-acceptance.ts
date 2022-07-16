
export enum RequestType{
  TiepNhanTaiDiaChi = 0,
  TiepNhanTaiQuay = 1,
  GDVTiepNhan = 2,
  BuuTaTiepNhan =3,
  MobileTiepNhan =9
}
export enum RequestTypeName{
  TiepNhanTaiDiaChi = "Tiếp nhận tại địa chỉ",
  TiepNhanTaiQuay = "Tiếp nhận tại quầy",
  GDVTiepNhan = "GDV nhập yêu cầu",
  BuuTaTiepNhan = "Bưu tá nhập yêu cầu"
}

export enum RequestAcceptedType{
  YeuCauThuong = 1,
  YeuCauDacBiet = 2
}
export enum RequestAcceptedTypeName{
  YeuCauThuong = "Gửi thường",
  YeuCauDacBiet = "Gửi đặc biệt"
}

export enum RequestStatus{
    DangKhoiTao = 1,
    ChoBuuTaXacNhan = 2,
    BuuTaDaXacNhan = 3,
    BuuTaTuChoiNhan = 4,
    ChoGDVXacNhan = 5,
    GDVDaXacNhan = 6,
    GDVTuChoiNhan = 7,
    DaChapNhanGui = 8
  }
  export enum RequestStatusName{
    DangKhoiTao = "Đang khởi tạo",
    ChoBuuTaXacNhan = "Chờ bưu tá xác nhận",
    BuuTaDaXacNhan = "Bưu tá đã xác nhận",
    BuuTaTuChoiNhan = "Bưu tá từ chối nhận",
    ChoGDVXacNhan = "Chờ GDV xác nhận",
    GDVDaXacNhan = "GDV đã xác nhận",
    GDVTuChoiNhan = "GDV từ chối nhận",
    DaChapNhanGui = "Đã chấp nhận"
  }

  export enum RequestStatusColor{
    DangKhoiTao = "#c6c7c7", //xam
    ChoBuuTaXacNhan = "#FF9900", //cam
    BuuTaDaXacNhan = "#87d068",//xanh la
    BuuTaTuChoiNhan = "#FF0000", //do
    ChoGDVXacNhan = "#FF9900", //cam
    GDVDaXacNhan = "#87d068", // xanh la
    GDVTuChoiNhan = "#FF0000", // do
    DaChapNhanGui = "#2db7f5" // xanh blue
  }
  