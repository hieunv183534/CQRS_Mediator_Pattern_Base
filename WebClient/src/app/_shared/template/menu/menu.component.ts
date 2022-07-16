import { MessageService } from './../../../_base/servicers/message.service';
import { IdentityMenuGetAllByUserQuery, MenuApi } from 'src/app/_shared/bccp-api.services';
import { Component, ViewEncapsulation, OnInit } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
import { LocationStrategy, Location } from '@angular/common';
import { filter } from 'rxjs/operators';
import { TableTreeConfigModel } from 'src/app/_base/models/table-tree-config-model';

declare let $;
@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss'],
  encapsulation: ViewEncapsulation.None
})


export class MenuComponent implements OnInit {

  public menuData = [];
  public isShowFullMenuMobile = false;
  public isLoading = true;

  constructor(private rt: Router,
    private location: Location,
    private messageService: MessageService,
    private menuApi: MenuApi) { }

  async ngOnInit(): Promise<void> {
    const url = this.location.path();
    // gọi lần đầu
    this.getDataMenu(url);

    // goi khi thay doi url
    this.rt.events.pipe(filter(x => x instanceof NavigationEnd))
      .subscribe((x: NavigationEnd) => {
        // gọi khi thay đổi url
        this.getDataMenu(x.url);
      });

    this.resizeDocument();
  }

  async getData(): Promise<void> {
    this.isLoading = true;
    const rs = await this.menuApi.getAllByUser(new IdentityMenuGetAllByUserQuery()).toPromise();
    if (rs.success) {
      let dataRaw = rs.result.map(x => {
        return {
          id: x.id,
          icon: x.icon,
          name: x.name,
          url: x.link,
          parentId: x.parentId,
          params: x.queryParams ? JSON.parse(x.queryParams) : null,
          isOpen: false,
          exact: true,
          child: [],
        };
      });

      // convert data to tree
      dataRaw.forEach(item => {
        item.child = dataRaw.filter(x => x.parentId === item.id);
      });

      const convertData = dataRaw.filter(x => x.parentId === null);
      this.menuData = convertData;
    } else {
      this.messageService.notiMessageError(rs.error);
    }
    this.isLoading = false;
  }

  async getDataMenu(url: string): Promise<void> {
    if (this.isLoading) {
      //await this.getMenuDefault();
      await this.getData();
    }

    this.clearActiveMenu(this.menuData);
    this.autoOpenMenuByUrl(this.menuData, url);
  }

  async getMenuDefault(): Promise<void> {
    this.menuData = [
      {
        icon: 'icon-home4',
        name: 'Trang chủ',
        url: '/',
        isOpen: false,
        exact: true,
        child: [],
      },
      {
        icon: 'icon-chip',
        name: 'Quản trị ứng dụng',
        url: null,
        isOpen: false,
        exact: true,
        child: [
          {
            icon: 'icon-cog4',
            name: 'Quản trị hệ thống',
            url: null,
            isOpen: false,
            exact: true,
            child: [
              {
                icon: 'icon-list-unordered',
                name: 'Quản trị menu',
                url: '/qtud/menu',
                isOpen: false,
                exact: true,
                child: []
              },
              {
                icon: 'icon-user-check',
                name: 'Quản trị người dùng',
                url: null,
                isOpen: false,
                exact: true,
                child: [
                  {
                    icon: 'icon-collaboration',
                    name: 'Quản trị nhóm quyền',
                    url: '/qtud/quan-tri-nguoi-dung/nhom-quyen',
                    isOpen: false,
                    exact: true,
                    child: []
                  },
                  {
                    icon: 'icon-vcard',
                    name: 'Quản lý tài khoản',
                    url: '/qtud/quan-tri-nguoi-dung/tai-khoan',
                    isOpen: false,
                    exact: true,
                    child: []
                  },
                ]
              }
            ],
          }

        ],
      },
      {
        icon: 'icon-notebook',
        name: 'Quản lý tiếp nhận, giao dịch',
        url: null,
        isOpen: false,
        exact: false,
        child: [{
          icon: 'icon-file-plus',
          name: 'Tiếp nhận yêu cầu',
          url: '/tiepnhan-giaodich/tiepnhanyeucau',
          isOpen: false,
          exact: false,
          child: [],
        },
        {
          icon: 'icon-file-eye',
          name: 'Bưu tá xác nhận yêu cầu',
          url: '/tiepnhan-giaodich/kiemsoatyeucau',
          isOpen: false,
          exact: false,
          child: [],
        },
        {
          icon: 'icon-file-stats',
          name: 'GDV xác nhận từ bưu tá',
          url: '/tiepnhan-giaodich/kiemsoatyeucaugdv',
          isOpen: false,
          exact: false,
          child: [],
        },
        {
          icon: 'icon-qrcode',
          name: 'Chấp nhận gửi',
          url: '/tiepnhan-giaodich/chapnhangui',
          isOpen: false,
          exact: false,
          child: [],
        },
        {
          icon: 'icon-eye',
          name: 'Kiểm soát bưu gửi',
          url: '/tiepnhan-giaodich/kiemsoatbuugui',
          isOpen: false,
          exact: false,
          child: [],
        }
          //,
          // {
          //   icon: 'icon-link',
          //   name: 'Giao dịch điều chỉnh',
          //   url: '/tiepnhan-giaodich/giaodichdieuchinh',
          //   isOpen: false,
          //   exact: false,
          //   child: [],
          // }
        ]
      },
      {
        icon: 'icon-truck',
        name: 'Quản lý khai thác',
        url: null,
        isOpen: false,
        exact: false,
        child: [{
          icon: 'icon-drawer-out',
          name: 'Khai thác chuyến thư đi',
          url: '/khaithac/chuyenthudi',
          isOpen: false,
          exact: false,
          child: [],
        },
        {
          icon: 'icon-file-eye',
          name: 'Kiểm soát chuyến thư đi',
          url: '/khaithac/kiemsoatchuyenthudi',
          isOpen: false,
          exact: false,
          child: [],
        },
        {
          icon: 'icon-drawer-in',
          name: 'Khai thác chuyến thư đến',
          url: '/khaithac/chuyenthuden',
          isOpen: false,
          exact: false,
          child: [],
        }
          // 
        ],
      },
      {
        icon: 'icon-cart',
        name: 'Quản lý giao nhận',
        url: null,
        isOpen: false,
        exact: false,
        child: [{
          icon: 'icon-bag',
          name: 'Giao túi thư đi',
          url: '/giaonhan/giaotuigoi',
          isOpen: false,
          exact: false,
          child: [],
        },
        {
          icon: 'icon-envelop2',
          name: 'Nhận túi thư đến',
          url: '/giaonhan/nhantuigoi',
          isOpen: false,
          exact: false,
          child: [],
        }],
      },
      {
        icon: 'icon-cart',
        name: 'Quản lý vận chuyển',
        url: null,
        isOpen: false,
        exact: false,
        child: [{
          icon: 'icon-bag',
          name: 'Quản lý chuyến xe',
          url: '/vanchuyen/lenhdieuxe',
          isOpen: false,
          exact: false,
          child: [],
        }],
      },
      {
        icon: 'icon-cart',
        name: 'Quản lý phát',
        url: null,
        isOpen: false,
        exact: false,
        child: [{
          icon: 'icon-bag',
          name: 'Quản lý chuyến thư bưu tá',
          url: '/phatbuugui/thongtinphat',
          params: {
            type: 1
          },
          isOpen: false,
          exact: false,
          child: [],
        },
        {
          icon: 'icon-envelop2',
          name: 'Quản lý bưu gửi chuyển hoàn',
          url: '/phatbuugui/buuguichuyenhoan',
          isOpen: false,
          exact: false,
          child: [],
        },
        {
          icon: 'icon-link',
          name: 'Kiểm soát thông tin phát',
          url: '/phatbuugui/thongtinphat',
          params: {
            type: 2
          },
          isOpen: false,
          exact: false,
          child: [],
        },
        {
          icon: 'icon-link',
          name: 'Quản lý chứng từ chuyển trả',
          url: '/phatbuugui/chungtuchuyentra',
          isOpen: false,
          exact: false,
          child: [],
        }],
      },
      {
        icon: 'icon-cart',
        name: 'Quản lý khiếu nại',
        url: null,
        isOpen: false,
        exact: false,
        child: [{
          icon: 'icon-bag',
          name: 'Lập khiếu nại',
          url: '/khieunai/lapkhieunai',
          isOpen: false,
          exact: false,
          child: [],
        },
        {
          icon: 'icon-bag',
          name: 'Khiếu nại của khách hàng',
          url: '/khieunai/khachhangkhieunai',
          isOpen: false,
          exact: false,
          child: [],
        },
        {
          icon: 'icon-envelop2',
          name: 'Khiếu nại đến',
          url: '/khieunai/khieunaiden',
          isOpen: false,
          exact: false,
          child: [],
        },
        {
          icon: 'icon-bag',
          name: 'Quản lý sự cố',
          url: '/khieunai/phanhoi',
          isOpen: false,
          exact: false,
          child: [],
        }],
      },
      {
        icon: 'icon-cart',
        name: 'Quản lý báo cáo',
        url: null,
        isOpen: false,
        exact: false,
        child: [
          {
            icon: 'icon-link',
            name: 'KT13',
            url: '/report/KT13',
            isOpen: false,
            exact: false,
            child: [],
          },
          {
            icon: 'icon-stack-text',
            name: 'KT14',
            url: '/report/KT14',
            isOpen: false,
            exact: false,
            child: [],
          },
          {
            icon: 'icon-link',
            name: 'KPI-CP16',
            url: '/report/KPI_CP16',
            isOpen: false,
            exact: false,
            child: [],
          },
          {
            icon: 'icon-link',
            name: 'KPI-SANLUONG',
            url: '/report/KPI_SANLUONG',
            isOpen: false,
            exact: false,
            child: [],
          },
          {
            icon: 'icon-link',
            name: 'KPI-CP16',
            url: '/report/KPI_BaoCaoTuan',
            isOpen: false,
            exact: false,
            child: [],
          },
          {
            icon: 'icon-link',
            name: 'KPI-Tình hình cung cấp dịch vụ bưu chính KT1 theo tháng',
            url: '/report/KPI_BaoCaoThang',
            isOpen: false,
            exact: false,
            child: [],
          },
          {
            icon: 'icon-link',
            name: 'KPI-Tình hình cung cấp dịch vụ bưu chính KT1 theo tháng tổng hợp',
            url: '/report/KPI_BaoCaoThang_TongHop',
            isOpen: false,
            exact: false,
            child: [],
          },
          {
            icon: 'icon-link',
            name: 'KPI-Bảng kê chi tiết gửi',
            url: '/report/KPI_BangKeChiTietGui',
            isOpen: false,
            exact: false,
            child: [],
          },
          {
            icon: 'icon-link',
            name: 'KPI-KẾT QUẢ ĐỐI SOÁT SẢN LƯỢNG VÀ XÁC NHẬN CHẤT LƯỢNG DỊCH VỤ BCKT1 CỤC BĐTW',
            url: '/report/KPI_DoiSoat',
            isOpen: false,
            exact: false,
            child: [],
          },
          {
            icon: 'icon-link',
            name: 'KPI-BẢNG KÊ CHI TIẾT BƯU GỬI CHUYỂN PHÁT',
            url: '/report/KPI_BangKeChiTietGui',
            isOpen: false,
            exact: false,
            child: [],
          },
          {
            icon: 'icon-link',
            name: 'KPI-SẢN LƯỢNG VÀ XÁC NHẬN CHẤT LƯỢNG DỊCH VỤ BƯU CHÍNH KT1',
            url: '/report/KPI_SanLuong_XN_Thang',
            isOpen: false,
            exact: false,
            child: [],
          },
          {
            icon: 'icon-link',
            name: 'KPI-BẢNG ĐỐI SOÁT SẢN LƯỢNG - VÀ XÁC NHẬN CHẤT LƯỢNG DỊCH VỤ KHÁCH HÀNG',
            url: '/report/KPI_BangKeThang_KhachHang',
            isOpen: false,
            exact: false,
            child: [],
          },
          {
            icon: 'icon-link',
            name: 'KPI-BẢNG TỔNG HỢP PHÍ DỊCH VỤ BƯU CHÍNH KT1',
            url: '/report/KPI_TongHopChiPhi',
            isOpen: false,
            exact: false,
            child: [],
          },
          {
            icon: 'icon-link',
            name: 'Báo Cáo Chi Tiết Sản Lượng Chuyến Thư Chiều Đi/đến Theo Ca/ngày',
            url: '/report/PL0708',
            isOpen: false,
            exact: false,
            child: [],
          },
          {
            icon: 'icon-link',
            name: 'Báo Cáo Sản Lượng Tổng Hợp  Chuyến Thư Chiều Đi/đến Theo Tháng/năm',
            url: '/report/PL0708Month',
            isOpen: false,
            exact: false,
            child: [],
          },
          {
            icon: 'icon-link',
            name: 'Báo Cáo Sản Lượng Tổng Hợp Chuyến Thư Chiều Đi/đến Theo Tháng/năm, Bưu cục đóng',
            url: '/report/PL0708StartingCodeMonth',
            isOpen: false,
            exact: false,
            child: [],
          }
        ],
      },

      {
        icon: 'icon-coins',
        name: 'Quản lý cước phí',
        url: null,
        isOpen: false,
        exact: false,
        child: [{
          icon: 'icon-calculator2',
          name: 'Bảng Cước',
          url: '/cuocphi/bangcuoc',
          isOpen: false,
          exact: false,
          child: [],
        }],
      },
      {
        icon: 'icon-sync',
        name: 'Đối soát dữ liệu',
        url: null,
        isOpen: false,
        exact: false,
        child: [{
          icon: 'icon-file-empty',
          name: 'Bưu gửi',
          url: '/doisoatdulieu/buugui',
          isOpen: false,
          exact: false,
          child: [],
        },
        {
          icon: 'icon-truck',
          name: 'Chuyến thư',
          url: '/doisoatdulieu/chuyenthu',
          isOpen: false,
          exact: false,
          child: [],
        }],
      },
      {
        icon: 'icon-stack2',
        name: 'Danh mục',
        url: null,
        isOpen: false,
        exact: false,
        child: [
          {
            icon: 'icon-map5',
            name: 'Điểm phát',
            url: '/danhmuc/diem-phat',
            isOpen: false,
            exact: false,
            child: [],
          },
          {
            icon: 'icon-price-tags',
            name: 'Sản phẩm dịch vụ',
            url: '/danhmuc/san-pham-dich-vu',
            isOpen: false,
            exact: false,
            child: [],
          },
          {
            icon: 'icon-add',
            name: 'Cộng thêm',
            url: '/danhmuc/cong-them',
            isOpen: false,
            exact: false,
            child: [],
          },
          {
            icon: 'icon-collaboration',
            name: 'Ca',
            url: '/danhmuc/ca',
            isOpen: false,
            exact: false,
            child: [],
          },
          {
            icon: 'icon-store2',
            name: 'Đơn vị',
            url: '/danhmuc/donvi',
            isOpen: false,
            exact: false,
            child: [],
          },
          {
            icon: 'icon-hash',
            name: 'Mã bưu chính',
            url: '/danhmuc/mabuuchinh',
            isOpen: false,
            exact: false,
            child: [],
          },
          {
            icon: 'icon-vcard',
            name: 'Khách hàng, đối tác',
            url: '/danhmuc/khachhang',
            isOpen: false,
            exact: false,
            child: [],
          },
          {
            icon: 'icon-location4',
            name: 'Địa dư hành chính',
            url: '/danhmuc/diaduhanhchinh',
            isOpen: false,
            exact: false,
            child: [],
          },
          {
            icon: 'icon-envelop2',
            name: 'Đường thư',
            url: '/danhmuc/duongthu',
            isOpen: false,
            exact: false,
            child: [],
          },
          // {
          //   icon: '',
          //   name: 'SPDV',
          //   url: '/danhmuc/spdv',
          //   isOpen: false,
          //   exact: false,
          //   child: [],
          // },
          // {
          //   icon: '',
          //   name: 'Hướng đóng',
          //   url: '/danhmuc/huongdong',
          //   isOpen: false,
          //   exact: false,
          //   child: [],
          // },
          {
            icon: 'icon-split',
            name: 'Tuyến phát',
            url: '/danhmuc/tuyenphat',
            isOpen: false,
            exact: false,
            child: [],
          },
          // {
          //   icon: '',
          //   name: 'Tuyến phát - phạm vị phát',
          //   url: '/danhmuc/phamviphat',
          //   isOpen: false,
          //   exact: false,
          //   child: [],
          // },
          // {
          //   icon: 'icon-bag',
          //   name: 'Loại bưu gửi',
          //   url: '/danhmuc/loaibuugui',
          //   isOpen: false,
          //   exact: false,
          //   child: [],
          // },
          // {
          //   icon: '',
          //   name: 'Chỉ tiêu toàn trình',
          //   url: '/danhmuc/chitieutoantrinh',
          //   isOpen: false,
          //   exact: false,
          //   child: [],
          // },
          // {
          //   icon: '',
          //   name: 'Vùng sâu, vùng xa',
          //   url: '/danhmuc/vungsauvungxa',
          //   isOpen: false,
          //   exact: false,
          //   child: [],
          // },
          // {
          //   icon: '',
          //   name: 'Hải đảo',
          //   url: '/danhmuc/haidao',
          //   isOpen: false,
          //   exact: false,
          //   child: [],
          // },
          // {
          //   icon: '',
          //   name: 'Bảng cước dịch vụ',
          //   url: '/danhmuc/bangcuocdichvu',
          //   isOpen: false,
          //   exact: false,
          //   child: [],
          // },
          // {
          //   icon: '',
          //   name: 'Loại giao dịch điều chỉnh',
          //   url: '/danhmuc/loaigiaodichdieuchinh',
          //   isOpen: false,
          //   exact: false,
          //   child: [],
          // },
          {
            icon: 'icon-browser',
            name: 'Túi KT1',
            url: '/danhmuc/tuikt1',
            isOpen: false,
            exact: false,
            child: [],
          },
          {
            icon: 'icon-truck',
            name: 'PTVC',
            url: '/danhmuc/ptvc',
            isOpen: false,
            exact: false,
            child: [],
          },
          {
            icon: 'icon-grid4',
            name: 'Khu vực toàn trình',
            url: '/danhmuc/khu-vuc',
            isOpen: false,
            exact: false,
            child: [],
          },
          {
            icon: 'icon-alignment-unalign',
            name: 'chỉ tiêu toàn trình',
            url: '/danhmuc/toan-trinh',
            isOpen: false,
            exact: false,
            child: [],
          },
          {
            icon: 'icon-mobile3',
            name: 'Thiết bị',
            url: '/danhmuc/thiet-bi',
            isOpen: false,
            exact: false,
            child: [],
          },
          ,
          {
            icon: 'icon-printer',
            name: 'Cấu hình máy in',
            url: '/danhmuc/cauhinh-mayin',
            isOpen: false,
            exact: false,
            child: [],
          },
          {
            icon: 'icon-bookmark',
            name: 'Loại sự vụ',
            url: '/danhmuc/loaisuvu',
            isOpen: false,
            exact: false,
            child: [],
          }
        ]
      },
      {
        icon: 'icon-cog',
        name: 'Cấu hình',
        url: null,
        isOpen: false,
        exact: false,
        child: [
          {
            icon: 'icon-file-spreadsheet',
            name: 'Báo cáo',
            url: '/cauhinh/baocao',
            isOpen: false,
            exact: false,
            child: [],
          },
          {
            icon: 'icon-pie-chart5',
            name: 'Thiết lập biểu đồ',
            url: '/cauhinh/bieudo',
            isOpen: false,
            exact: false,
            child: [],
          },
        ],
      },
    ];
  }

  clearActiveMenu(source: any[]) {
    for (const item of source) {
      item.isOpen = false;
      if (item.child.length > 0) {
        this.clearActiveMenu(item.child);
      }
    }
  }

  private autoOpenMenuByUrl(source: any[], url: string, level: number = 0): boolean {
    let result = false;
    for (const item of source) {
      item.level = level;
      let queryParam = "";
      if (item.params) {
        for (const key in item.params) {
          const value = item.params[key];
          if (queryParam.indexOf('?') === -1) {
            queryParam += "?";
          } else {
            queryParam += "&";
          }
          queryParam += `${key}=${value}`;
        }
      }

      if (item.child.length > 0) {
        const rs = this.autoOpenMenuByUrl(item.child, url, level + 1);
        if (rs) {
          item.isOpen = true;
          result = rs;
        }
      } else if (`${item.url}${queryParam}` === url) {
        result = true;
      }
    }
    return result;
  }

  public openMenu(value): void {
    value.isOpen = !value.isOpen;
  }

  public resizeDocument(): void {
    if (window.screen.width <= 1366) {
      $('body').toggleClass('sidebar-xs').removeClass('sidebar-mobile-main');
    }
  }

  public hideMenuMobile() {
    $('body').removeClass('sidebar-mobile-main');
    this.isShowFullMenuMobile = false;
  }

  public showFullMenuMobile() {
    this.isShowFullMenuMobile = !this.isShowFullMenuMobile;
  }
}
