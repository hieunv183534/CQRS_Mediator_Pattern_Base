export enum AcceptanceStatus{
  ChapNhanGui = 1,
  ChoPheDuyet = 2,
  DaPheDuyet = 3,
  TuChoiDuyet= 4,
  DongChuyenThuDi = 5
}

export enum AcceptanceStatusName{
  ChapNhanGui = "Đã chấp nhận",
  ChoPheDuyet = "Chờ phê duyệt",
  DaPheDuyet = "Đã phê duyệt",
  TuChoiDuyet= "Từ chối duyệt",
  DongChuyenThuDi = "Đã đóng chuyến thư đi"
}

export enum AcceptanceStatusColor{
  ChapNhanGui = "#c6c7c7",  //xám
  ChoPheDuyet = "#FF9900", //cam
  DaPheDuyet = "#87d068", //xanh lá
  TuChoiDuyet = "#FF0000", //đỏ
  DongChuyenThuDi = "#87d068"//xanh lá
}


export enum DeviceStatusColor{
  DangSuDung = "#87d068", //xanh lá
  KhongSuDung = "#FF0000" // đỏ
}


export enum UserStatusColor{
  DangSuDung = "#87d068", //xanh lá
  KhongSuDung = "#FF0000" // đỏ
}



export enum ItemStatus{
  ChapNhanGui = 1,
  ChoPheDuyet = 2,
  DaPheDuyet = 3,
  TuChoiDuyet= 4,
  DongChuyenThuDi = 5,
  XacNhanDen = 6,
  GiaoChoBuuTa = 7,
  PhatThanhCong = 8,
  PhatKhongThanhCong = 9,
  ChuyenHoan = 10,
  ChuyenTiep = 11,
  VoThuaNhan = 12,
  DaLoaiBo = 13
}

export enum ItemStatusName{
  ChapNhanGui = "Đã chấp nhận",
  ChoPheDuyet = "Chờ phê duyệt",
  DaPheDuyet = "Đã phê duyệt",
  TuChoiDuyet= "Từ chối duyệt",
  DongChuyenThuDi = "Đã đóng chuyến thư đi",
  XacNhanDen = "Đã xác nhận đến",
  GiaoChoBuuTa = "Giao cho bưu tá",
  PhatThanhCong = "Phát thành công",
  PhatKhongThanhCong = "Phát không thành công",
  ChuyenHoan = "Chuyển hoàn",
  ChuyenTiep = "Chuyển tiếp",
  VoThuaNhan = "Vô thừa nhận",
  DaLoaiBo = "Đã loại bỏ"
}

export enum TraceItemStatus{
    ChapNhanGui = 1,
    ChoPheDuyet = 2,
    DaPheDuyet = 3,
    TuChoiDuyet= 4,
    DongChuyenThuDi = 5,
    XacNhanDen = 6,
    GiaoChoBuuTa = 7,
    PhatThanhCong = 8,
    PhatKhongThanhCong = 9,
    ChuyenHoan = 10,
    ChuyenTiep = 11,
    VoThuaNhan = 12,
    DaLoaiBo = 13
  }

  export enum TraceItemStatusName{
    ChapNhanGui = "Đã chấp nhận",
    ChoPheDuyet = "Chờ phê duyệt",
    DaPheDuyet = "Đã phê duyệt",
    TuChoiDuyet= "Từ chối duyệt",
    DongChuyenThuDi = "Đã đóng chuyến thư đi",
    XacNhanDen = "Đã xác nhận đến",
    GiaoChoBuuTa = "Giao cho bưu tá",
    PhatThanhCong = "Phát thành công",
    PhatKhongThanhCong = "Phát không thành công",
    ChuyenHoan = "Chuyển hoàn",
    ChuyenTiep = "Chuyển tiếp",
    VoThuaNhan = "Vô thừa nhận",
    DaLoaiBo = "Đã loại bỏ"
  }

  // export enum TraceItemStatusColor{
  //   ChapNhanGui = "#c6c7c7",  //xám
  //   ChoPheDuyet = "#FF9900", //cam
  //   DaPheDuyet = "#87d068", //xanh lá
  //   TuChoiDuyet= "#FF0000", //đỏ
  //   DongChuyenThuDi = "#2db7f5", //xanh blue
  //   XacNhanDen = "#2db7f5",
  //   GiaoChoBuuTa = "#2db7f5",
  //   PhatThanhCong = "#2db7f5",
  //   PhatKhongThanhCong = "#2db7f5",
  //   ChuyenHoan = "#2db7f5",
  //   ChuyenTiep = "#2db7f5",
  //   VoThuaNhan = "#2db7f5",
  //   DaLoaiBo = "#2db7f5"
  // }

  export enum UndeliveryGuide{
    ChuyenHoanNgay = 1
  }

  export enum AcceptedType{
    RP = 1,
    SLL = 3,
    DB= 4
  }

  export enum AcceptedTypeName{
    RP = 'Nhập thay thế',
    SLL = "Chấp nhận gửi thường",
    DB= "Chấp nhận đặc biệt"
  }

  export enum ShiftHandoverItemStatus{
    DenTrongCa = 0,
    RaKhoiCa = 1,
    ChuyenHoanDacBiet = 2,
    DongChuyenThuDi = 5,
    XacNhanDen = 6
  }

  export enum ItemInventoryStatus
  {
      ChuaXacNhan = 0,
      DaXacNhan = 1
  }