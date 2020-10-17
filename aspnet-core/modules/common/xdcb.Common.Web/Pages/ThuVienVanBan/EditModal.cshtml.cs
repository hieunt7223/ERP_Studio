using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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
using xdcb.FileService.DocumentStoreDtos;
using xdcb.FileService.DocumentStores;

namespace xdcb.Common.DanhMuc.ThuVienVanBans
{
    public class EditModalModel : AbpPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public ThuVienVanBanViewModel ThuVienVanBan { get; set; }

        [BindProperty]
        public List<IFormFile> FileUploads { get; set; }

        [BindProperty]
        public List<DocumentStoreDto> DocumentStores { get; set; }

        [BindProperty]
        public string FileDel { get; set; }

        public List<SelectListItem> SelectListLoaiVanBan { get; set; }

        public List<SelectListItem> SelectListLinhVucVanBan { get; set; }

        public List<SelectListItem> SelectListCapBanHanh { get; set; }

        public List<SelectListItem> SelectListDonViBanHanh { get; set; }

        private readonly IThuVienVanBanAppService _thuVienVanBanAppService;
        private readonly IFileCuaThuVienVanBanAppService _fileCuaThuVienVanBanAppService;
        private readonly IAuthorizationService _authorization;
        private readonly ILinhVucVanBanAppService _linhVucVanBan;
        private readonly ILoaiVanBanAppService _loaiVanBan;
        private readonly IDonViBanHanhAppService _donViBanHanhAppService;
        private readonly IDocumentStoreAppService _documentStoreAppService;

        public EditModalModel(IThuVienVanBanAppService thuVienVanBanAppService,
            IAuthorizationService authorization, IFileCuaThuVienVanBanAppService fileCuaThuVienVanBanAppService,
            ILinhVucVanBanAppService linhVucVanBan, ILoaiVanBanAppService loaiVanBan,
            IDonViBanHanhAppService donViBanHanhAppService,
            IDocumentStoreAppService documentStoreAppService)
        {
            _thuVienVanBanAppService = thuVienVanBanAppService;

            _authorization = authorization ?? throw new ArgumentNullException(nameof(authorization));
            _linhVucVanBan = linhVucVanBan;
            _loaiVanBan = loaiVanBan;
            _fileCuaThuVienVanBanAppService = fileCuaThuVienVanBanAppService;
            _donViBanHanhAppService = donViBanHanhAppService;
            DocumentStores = new List<DocumentStoreDto>();
            _documentStoreAppService = documentStoreAppService;
        }

        public async Task OnGetAsync()
        {
            var thuVienVanBanDto = await _thuVienVanBanAppService.GetAsync(Id);
            ThuVienVanBan = ObjectMapper.Map<ThuVienVanBanDto, ThuVienVanBanViewModel>(thuVienVanBanDto);
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

            // lấy thông tin file của thư viên văn bản
            var idFiles = _fileCuaThuVienVanBanAppService.GetFileIdListAsync(Id).Result.ToList();
            foreach (var idFile in idFiles)
            {
                DocumentStores.Add(await _documentStoreAppService.GetAsync(idFile));
            }

            SelectListCapBanHanh = new List<SelectListItem>();
            var capBanHanhs = _thuVienVanBanAppService.GetCapBanHanhs();
            foreach (var item in capBanHanhs)
            {
                SelectListCapBanHanh.Add(new SelectListItem() { Value = item.Key.ToString(), Text = item.Value });
            }

            var donViBanHanhDtos = await _donViBanHanhAppService.GetDonViBanHanhsAsync();
            SelectListDonViBanHanh = new List<SelectListItem>();
            foreach (var item in donViBanHanhDtos)
            {
                SelectListDonViBanHanh.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Ten });
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!await _authorization.IsGrantedAsync(xdcbCommonPermissions.ThuVienVanBanPermission.Update))
                throw new AbpAuthorizationException(Messages.MSG_NotPermission);

            var thuVienVanBanDto = ObjectMapper.Map<ThuVienVanBanViewModel, CreateUpdateThuVienVanBanDto>(ThuVienVanBan);
            await _thuVienVanBanAppService.UpdateAsync(Id, thuVienVanBanDto);

            var listFileDel = FileDel.Replace("//", "").Trim().Split("/");
            foreach (var item in listFileDel)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    await _fileCuaThuVienVanBanAppService.DeleteByFileIdAsync(Guid.Parse(item));
                }
            }

            if (FileUploads != null && FileUploads.Any())
            {
                var documentStores = await _documentStoreAppService.UploadMultiFilesAsync(FileUploads);
                var listFiles = new List<CreateUpdateFileCuaThuVienVanBanDto>();
                foreach (var file in documentStores)
                {
                    listFiles.Add(new CreateUpdateFileCuaThuVienVanBanDto
                    {
                        FileId = file.Id,
                        ThuVienVanBanId = Id
                    });
                }

                await _fileCuaThuVienVanBanAppService.InsertMultiAsync(listFiles);
            }
            return NoContent();
        }

        public class ThuVienVanBanViewModel
        {
            [Required(ErrorMessage = Messages.MSG_Requied)]
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