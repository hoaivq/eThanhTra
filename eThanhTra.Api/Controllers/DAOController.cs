using Common;
using Common.Core;
using eThanhTra.Data;
using eThanhTra.Dto;
using eThanhTra.Network.System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using static Common.Core.Enums;

namespace eThanhTra.Api.Controllers
{
    public partial class DAOController : ApiController, IDAOApiNetwork
    {
        public SUserDto MyUser
        {
            get
            {
                if (Request == null)
                {
                    return new SUserDto
                    {
                        UserName = AppViewModel.MyUser.UserName,// Request.GetHeader("UserName"),
                        MaCQT = AppViewModel.MyUser.MaCQT,
                        UserType = AppViewModel.MyUser.UserType,
                    };
                }
                else
                {
                    return new SUserDto
                    {
                        UserName = Request.GetHeader("UserName"),
                        MaCQT = Request.GetHeader("MaCQT"),
                        UserType = Request.GetHeader("UserType").ToInt().Value,
                    };
                }
            }
        }


        [HttpPost]
        public async Task<MsgResult<DataTable>> GetTable([FromBody] CallSPDto callSPDto)
        {
            string JSON = string.Empty;
            try
            {
                JSON = JsonConvert.SerializeObject(callSPDto);
                using (DataTable dt = await MyApp.Dao.GetTableSPAsync(callSPDto.SPName, callSPDto.GetSqlParameter()))
                {
                    return new MsgResult<DataTable>(true, dt);
                }
            }
            catch (Exception ex)
            {
                return new MsgResult<DataTable>("GetTable", ex, JSON);
            }
            finally
            {
                MyApp.Log.GhiLog("GetTable", JSON);
            }
        }


        [HttpPost]
        public async Task<MsgResult<ObservableCollection<object>>> GetListObject([FromBody] CallSPDto callSPDto)
        {
            string JSON = string.Empty;
            try
            {
                JSON = JsonConvert.SerializeObject(callSPDto);
                using (DataTable dt = await MyApp.Dao.GetTableSPAsync(callSPDto.SPName, callSPDto.GetSqlParameter()))
                {
                    return new MsgResult<ObservableCollection<object>>(true, dt.ToListObject<object>());
                }
            }
            catch (Exception ex)
            {
                return new MsgResult<ObservableCollection<object>>("GetListObject", ex, JSON);
            }
            finally
            {
                MyApp.Log.GhiLog("GetListObject", JSON);
            }
        }

        //Hàm lưu các đối tượng lên Database dựa vào ObjectType
        [HttpPost]
        public async Task<MsgResult<object>> SaveObject([FromBody] object Object)
        {
            string ObjectType = string.Empty;
            try
            {
                //lấy giá trị ObjectType từ loại của Object hoặc từ header của HttpRequest
                ObjectType = (Request == null) ? Object.GetType().Name : Request.GetHeader("ObjectType");
                using (eThanhTraEntities db = new eThanhTraEntities())
                {
                    //nếu kiểu dữ liệu là DThanhTraDto 
                    if (ObjectType.Equals("DThanhTraDto"))
                    {
                        DThanhTraDto input = (Request == null) ? Object as DThanhTraDto : JsonConvert.DeserializeObject<DThanhTraDto>(Object.ToString());
                        DThanhTra output = input.Cast<DThanhTra>();
                        if (input.Id.HasValue())
                        {
                            output = db.DThanhTras.FirstOrDefault(c => c.Id == output.Id);
                            output.GetDataFrom<DThanhTra, DThanhTraDto>(input);
                        }
                        else
                        {
                            db.DThanhTras.Add(output);
                        }

                        await db.SaveChangesAsync();
                        DThanhTraThanhVien dThanhTraThanhVien = db.DThanhTraThanhViens.FirstOrDefault(c => c.IdThanhTra == output.Id && c.VaiTro == (int)EVaiTro.TruongDoan);
                        if (dThanhTraThanhVien == null)
                        {
                            dThanhTraThanhVien = new DThanhTraThanhVien();
                            dThanhTraThanhVien.IdThanhTra = output.Id;
                            dThanhTraThanhVien.UserName = output.UserNameTDTT;
                            dThanhTraThanhVien.VaiTro = (int)EVaiTro.TruongDoan;
                            dThanhTraThanhVien.IsEnable = true;
                            db.DThanhTraThanhViens.Add(dThanhTraThanhVien);
                        }
                        else
                        {
                            dThanhTraThanhVien.UserName = output.UserNameTDTT;
                        }
                        await db.SaveChangesAsync();

                        Object = output.Cast<DThanhTraDto>();
                    }
                    //Nếu kiểu dữ kiểu là SUserDto
                    if (ObjectType.Equals("SUserDto"))
                    {

                        SUserDto input = (Request == null) ? Object as SUserDto : JsonConvert.DeserializeObject<SUserDto>(Object.ToString());
                        SUser output = input.Cast<SUser>();

                        //output = db.SUsers.FirstOrDefault(c => c.UserName == output.UserName);
                        output.GetDataFrom<SUser, SUserDto>(input);

                        //output.TrangThai = 0;
                        db.SUsers.Add(output);

                        await db.SaveChangesAsync();
                        Object = output.Cast<SUserDto>();
                    }
                    else if (ObjectType.Equals("DThanhTraThanhVienDto"))
                    {
                        DThanhTraThanhVienDto input = (Request == null) ? Object as DThanhTraThanhVienDto : JsonConvert.DeserializeObject<DThanhTraThanhVienDto>(Object.ToString());
                        DThanhTraThanhVien output = input.Cast<DThanhTraThanhVien>();
                        if (input.Id.HasValue())
                        {
                            output = db.DThanhTraThanhViens.FirstOrDefault(c => c.Id == output.Id);
                            output.GetDataFrom<DThanhTraThanhVien, DThanhTraThanhVienDto>(input);
                        }
                        else
                        {
                            db.DThanhTraThanhViens.Add(output);
                        }
                        await db.SaveChangesAsync();
                        Object = output.Cast<DThanhTraThanhVienDto>();
                    }
                    else if (ObjectType.Equals("DThanhTraCongViecDto"))
                    {
                        DThanhTraCongViecDto input = (Request == null) ? Object as DThanhTraCongViecDto : JsonConvert.DeserializeObject<DThanhTraCongViecDto>(Object.ToString());
                        DThanhTraCongViec output = input.Cast<DThanhTraCongViec>();
                        if (input.Id.HasValue())
                        {
                            output = db.DThanhTraCongViecs.FirstOrDefault(c => c.Id == output.Id);
                            output.GetDataFrom<DThanhTraCongViec, DThanhTraCongViecDto>(input);
                        }
                        else
                        {
                            db.DThanhTraCongViecs.Add(output);
                        }
                        await db.SaveChangesAsync();
                        Object = output.Cast<DThanhTraCongViecDto>();
                    }
                    else if (ObjectType.Equals("DThanhTraThanhVienCongViecDto"))
                    {
                        DThanhTraThanhVienCongViecDto input = (Request == null) ? Object as DThanhTraThanhVienCongViecDto : JsonConvert.DeserializeObject<DThanhTraThanhVienCongViecDto>(Object.ToString());
                        DThanhTraThanhVienCongViec output = db.DThanhTraThanhVienCongViecs.FirstOrDefault(c => c.IdThanhTra == input.IdThanhTra && c.IdThanhVien == input.IdThanhVien && c.IdCongViec == input.IdCongViec);

                        if (output == null)
                        {
                            output = input.Cast<DThanhTraThanhVienCongViec>();
                            db.DThanhTraThanhVienCongViecs.Add(output);
                        }
                        else
                        {
                            output.GetDataFrom<DThanhTraThanhVienCongViec, DThanhTraThanhVienCongViecDto>(input);
                        }

                        await db.SaveChangesAsync();
                        Object = output.Cast<DThanhTraThanhVienCongViecDto>();
                    }
                    else if (ObjectType.Equals("DThanhTraThanhVienCongViecChiTietDto"))
                    {
                        DThanhTraThanhVienCongViecChiTietDto input = (Request == null) ? Object as DThanhTraThanhVienCongViecChiTietDto : JsonConvert.DeserializeObject<DThanhTraThanhVienCongViecChiTietDto>(Object.ToString());
                        DThanhTraThanhVienCongViecChiTiet output = input.Cast<DThanhTraThanhVienCongViecChiTiet>();
                        if (input.Id.HasValue())
                        {
                            output = db.DThanhTraThanhVienCongViecChiTiets.FirstOrDefault(c => c.Id == output.Id);
                            output.GetDataFrom<DThanhTraThanhVienCongViecChiTiet, DThanhTraThanhVienCongViecChiTietDto>(input);
                        }
                        else
                        {
                            output.NgayNhap = DateTime.Now;
                            db.DThanhTraThanhVienCongViecChiTiets.Add(output);
                        }
                        await db.SaveChangesAsync();
                        Object = output.Cast<DThanhTraThanhVienCongViecChiTietDto>();
                    }

                    else if (ObjectType.Equals("DGiaHanTTDto"))
                    {
                        DGiaHanTTDto input = (Request == null) ? Object as DGiaHanTTDto : JsonConvert.DeserializeObject<DGiaHanTTDto>(Object.ToString());
                        DGiaHanTT output = input.Cast<DGiaHanTT>();
                        output.GetDataFrom<DGiaHanTT, DGiaHanTTDto>(input);
                        db.DGiaHanTTs.Add(output);
                        await db.SaveChangesAsync();
                        Object = output.Cast<DGiaHanTTDto>();
                    }



                    return new MsgResult<object>(true, Object);
                }
            }
            catch (Exception ex)
            {
                StringBuilder sbErr = new StringBuilder();
                if (ex is DbEntityValidationException)
                {
                    DbEntityValidationException validationException = (DbEntityValidationException)ex;
                    foreach (DbEntityValidationResult validationResult in validationException.EntityValidationErrors)
                    {
                        foreach (DbValidationError validationError in validationResult.ValidationErrors)
                        {
                            sbErr.AppendLine(validationError.ErrorMessage);
                        }
                    }
                }

                MsgResult<object> rs = new MsgResult<object>("SaveObject", ex, ObjectType) { Value = Object };
                rs.Value = Object;
                if (sbErr.Length > 0)
                {
                    rs.Message = rs.Message + Environment.NewLine + sbErr.ToString();
                }
                return rs;
            }
        }


        [HttpPost]
        public async Task<MsgResult<object>> DeleteObject([FromBody] DeleteDto deleteDto)
        {
            try
            {
                await MyApp.Dao.ExecSQLAsync("DELETE FROM " + deleteDto.TableName + " WHERE Id = @Id", new SqlParameter[] { new SqlParameter("Id", deleteDto.Id) });
                return new MsgResult<object>(true, null);
            }
            catch (Exception ex)
            {
                return new MsgResult<object>("DeleteObject", ex);
            }
        }
    }
}