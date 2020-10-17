using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.Authorization;
using xdcb.Common.DanhMuc.DonViBanHanhs;
using xdcb.Common.DanhMuc.FileCuaThuVienVanBanDtos;
using xdcb.Common.DanhMuc.FileCuaThuVienVanBans;
using xdcb.Common.DanhMuc.LinhVucVanBanDtos;
using xdcb.Common.DanhMuc.LinhVucVanBans;
using xdcb.Common.DanhMuc.LoaiVanBanDtos;
using xdcb.Common.DanhMuc.LoaiVanBans;
using xdcb.Common.DanhMuc.ThuVienVanBanDtos;
using xdcb.Common.Permissions;
using xdcb.FileService.DocumentStores;

namespace xdcb.Common.DanhMuc.ThuVienVanBans
{
    public class CreateModalModel : AbpPageModel
    {
        [BindProperty]
        public ThuVienVanBanViewModel ThuVienVanBan { get; set; }

        [BindProperty]
        //[Required(ErrorMessage = Messages.MSG_Requied)]
        [DisplayName(ViewTextConsts.ThuVienVanBan.TapTin)]
        public List<IFormFile> FileUploads { get; set; }

        public List<SelectListItem> SelectListLoaiVanBan { get; set; }

        public List<SelectListItem> SelectListLinhVucVanBan { get; set; }

        public List<SelectListItem> SelectListCapBanHanh { get; set; }

        public List<SelectListItem> SelectListDonViBanHanh { get; set; }

        private readonly IThuVienVanBanAppService _thuVienVanBanAppService;
        private readonly IAuthorizationService _authorization;
        private readonly ILinhVucVanBanAppService _linhVucVanBan;
        private readonly ILoaiVanBanAppService _loaiVanBan;
        private readonly IDonViBanHanhAppService _donViBanHanhAppService;
        private readonly IDocumentStoreAppService _documentStoreAppService;
        private readonly IFileCuaThuVienVanBanAppService _fileCuaThuVienVanBanAppService;

        public CreateModalModel(IThuVienVanBanAppService thuVienVanBanAppService,
            IAuthorizationService authorization,
            ILinhVucVanBanAppService linhVucVanBan, ILoaiVanBanAppService loaiVanBan,
            IDonViBanHanhAppService donViBanHanhAppService,
            IDocumentStoreAppService documentStoreAppService, IFileCuaThuVienVanBanAppService fileCuaThuVienVanBanAppService)
        {
            _thuVienVanBanAppService = thuVienVanBanAppService;
            _documentStoreAppService = documentStoreAppService;
            _authorization = authorization ?? throw new ArgumentNullException(nameof(authorization));
            _linhVucVanBan = linhVucVanBan;
            _loaiVanBan = loaiVanBan;
            _donViBanHanhAppService = donViBanHanhAppService;
            _fileCuaThuVienVanBanAppService = fileCuaThuVienVanBanAppService;
        }

        public async Task OnGetAsync()
        {
            var loaiVanBanDtos = (List<LoaiVanBanDto>)await _loaiVanBan.GetLoaiVanBanListAsync() ?? new List<LoaiVanBanDto>();
            SelectListLoaiVanBan = new List<SelectListItem>();
            foreach (var item in loaiVanBanDtos)
            {
                SelectListLoaiVanBan.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.TenLoaiVanBan.ToString() });
            }

            var linhVucVanBanDtos = (List<LinhVucVanBanDto>)await _linhVucVanBan.GetLinhVucVanBanListAsync() ?? new List<LinhVucVanBanDto>();
            SelectListLinhVucVanBan = new List<SelectListItem>() { new SelectListItem { Value = "null", Text = "---" } };
            foreach (var item in linhVucVanBanDtos)
            {
                SelectListLinhVucVanBan.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.TenLinhVuc.ToString() });
            }

            SelectListCapBanHanh = new List<SelectListItem>();
            var capBanHanhDtos = _thuVienVanBanAppService.GetCapBanHanhs();
            foreach (var item in capBanHanhDtos)
            {
                SelectListCapBanHanh.Add(new SelectListItem() { Value = item.Key.ToString(), Text = item.Value });
            }

            SelectListDonViBanHanh = new List<SelectListItem>();
            var donViBanHanhDtos = await _donViBanHanhAppService.GetDonViBanHanhsAsync();
            foreach (var item in donViBanHanhDtos)
            {
                SelectListDonViBanHanh.Add(new SelectListItem() { Value = item.Id.ToString(), Text = item.Ten });
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!await _authorization.IsGrantedAsync(xdcbCommonPermissions.ThuVienVanBanPermission.Create))
                throw new AbpAuthorizationException(Messages.MSG_NotPermission);
            var thuVienVanBanDto = ObjectMapper.Map<ThuVienVanBanViewModel, CreateUpdateThuVienVanBanDto>(ThuVienVanBan);
            var documentStores = await _documentStoreAppService.UploadMultiFilesAsync(FileUploads);
            var newThuVienVanBan = await _thuVienVanBanAppService.CreateAsync(thuVienVanBanDto);
            var listFiles = new List<CreateUpdateFileCuaThuVienVanBanDto>();
            foreach (var file in documentStores)
            {
                listFiles.Add(new CreateUpdateFileCuaThuVienVanBanDto
                {
                    FileId = file.Id,
                    ThuVienVanBanId = newThuVienVanBan.Id
                });
            }

            await _fileCuaThuVienVanBanAppService.InsertMultiAsync(listFiles);

            return NoContent();
        }

        public class ThuVienVanBanViewModel
        {
            [Required(ErrorMessage = Messages.MSG_Requied)]
            [BindProperty]
            [StringLength(50)]
            [DisplayName(ViewTextConsts.ThuVienVanBan.SoKyHieu)]
            [Placeholder(ViewTextConsts.ThuVienVanBanPlaceholder.SoKyHieu)]
            public string SoKyHieu { get; set; }

            [DisplayName(ViewTextConsts.ThuVienVanBan.LinhVucVanBan)]
            [SelectItems(nameof(SelectListLinhVucVanBan))]
            [Placeholder(ViewTextConsts.ThuVienVanBanPlaceholder.LinhVucVanBan)]
            public Guid? LinhVucVanBanId { get; set; }

            [Required(ErrorMessage = Messages.MSG_Requied)]
            [DisplayName(ViewTextConsts.ThuVienVanBan.LoaiVanBan)]
            [SelectItems(nameof(SelectListLoaiVanBan))]
            [Placeholder(ViewTextConsts.ThuVienVanBanPlaceholder.LoaiVanBan)]
            public Guid LoaiVanBanId { get; set; }

            [StringLength(500)]
            [DisplayName(ViewTextConsts.ThuVienVanBan.TrichYeu)]
            [TextArea(Rows = 4)]
            [Placeholder(ViewTextConsts.ThuVienVanBanPlaceholder.TrichYeu)]
            public string TrichYeu { get; set; }

            [DisplayName(ViewTextConsts.ThuVienVanBan.CapBanHanh)]
            [Placeholder(ViewTextConsts.ThuVienVanBanPlaceholder.CapBanHanh)]
            public CapBanHanh CapBanHanh { get; set; }

            [Required(ErrorMessage = Messages.MSG_Requied)]
            [DisplayName(ViewTextConsts.ThuVienVanBan.DonViBanHanh)]
            [SelectItems(nameof(SelectListDonViBanHanh))]
            [Placeholder(ViewTextConsts.ThuVienVanBanPlaceholder.DonViBanHanh)]
            public Guid DonViBanHanhId { get; set; }

            [Required(ErrorMessage = Messages.MSG_Requied)]
            [DisplayName(ViewTextConsts.ThuVienVanBan.NgayBanHanh)]
            [DataType(DataType.Date)]
            public DateTime NgayBanHanh { get; set; }
        }
    }
}