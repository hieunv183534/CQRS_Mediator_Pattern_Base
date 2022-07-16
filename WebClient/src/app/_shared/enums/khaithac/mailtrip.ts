export enum MailtripStatus{
    DangKhoiTao = 1,
    DaDongDi = 2,
    DaPheDuyet = 3,
    TuChoiDuyet = 4,
    DangXacNhan =5,
    DaXacNhan = 6,
    DaHuy = 7,
    ChoXacNhan = 8,
  }

  export enum MailtripStatusName{
    DangKhoiTao = "Đang khởi tạo",
    DaDongDi = "Chờ phê duyệt đi",
    DaPheDuyet = "Đã phê duyệt đi",
    TuChoiDuyet = "Từ chối duyệt đi",
    ChoXacNhan = "Chờ xác nhận",
    DangXacNhan = "Đang xác nhận đến",
    DaXacNhan = "Đã xác nhận đến",
    DaHuy = "Đã hủy"
  }

  export enum MailtripStatusColor{
    DangKhoiTao = "#c6c7c7", // xam
    DaDongDi = "#FF9900", // cam
    DaPheDuyet = "#87d068", // xanh la
    TuChoiDuyet = "#FF0000", // do
    DangXacNhan = "#FF9900", // cam
    DaXacNhan = "#2db7f5", //xanh blue
    ChoXacNhan = "#DF8C00" // vang nhat
  }

  export enum MailtripResetType{
    Ngay = 0,
    Thang = 1,
    Nam = 2
  }

  export enum MailtripType{
    MayBay = 0
  }

  export enum MailtripExchangeType{
    DongTui = 0,
    GiaoDoi = 5
  }

  export enum MailtripExchangeTypeName{
    DongTui = "Đóng túi",
    GiaoDoi = "Giao dời"
  }

  export enum MailtripAcceptanceType{
    TatCaBuuGui = 0,
    BuuGuiThuong = 1,
    BuuGuiNoiBo = 2
  }