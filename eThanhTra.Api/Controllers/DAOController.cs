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



        [HttpPost]
        public async Task<MsgResult<ObservableCollection<DFileDto>>> GetListFile([FromBody] CallSPDto callSPDto)
        {
            string JSON = string.Empty;
            try
            {
                JSON = JsonConvert.SerializeObject(callSPDto);
                using (DataTable dt = await MyApp.Dao.GetTableSPAsync(callSPDto.SPName, callSPDto.GetSqlParameter()))
                {
                    return new MsgResult<ObservableCollection<DFileDto>>(true, dt.ToListObject<DFileDto>());
                }
            }
            catch (Exception ex)
            {
                return new MsgResult<ObservableCollection<DFileDto>>("GetListFile", ex, JSON);
            }
            finally
            {
                MyApp.Log.GhiLog("GetListFile", JSON);
            }
        }


        [HttpPost]
        public async Task<MsgResult<ObservableCollection<DFileDto>>> SaveFile([FromBody] ObservableCollection<DFileDto> ListFile)
        {
            try
            {
                using (SqlConnection myConn = new SqlConnection(MyApp.Setting.DBConnStr))
                {

                    foreach (DFileDto dto in ListFile)
                    {
                        if (dto.FileMode == (int)EFileMode.Delete)
                        {
                            if (dto.Id.HasValue)
                            {
                                MyApp.Dao.ExecSQL("DELETE FROM DFileData WHERE IdFile = @Id; DELETE FROM DFile WHERE Id = @Id", new SqlParameter[] {
                                    new SqlParameter("Id", dto.Id.Value)
                                });
                            }
                            ListFile.Remove(dto);
                        }
                        else if (dto.FileMode == (int)EFileMode.Add)
                        {

                            long IdFile = MyApp.Dao.ExecSQLGetId("INSERT INTO DFile(IdCha, TableName, FileName, FileType, FileSize, CreatedDate) VALUES(@IdCha, @TableName, @FileName, @FileType, @FileSize, GETDATE())", new SqlParameter[]
                             {
                                    new SqlParameter("IdCha",       dto.IdCha),
                                    new SqlParameter("TableName",   dto.TableName),
                                    new SqlParameter("FileName",    dto.FileName),
                                    new SqlParameter("FileType",    dto.FileType),
                                    new SqlParameter("FileSize",    dto.FileSize),
                             }, myConn);

                            MyApp.Dao.ExecSQL("INSERT INTO DFileData(IdFile, FileData) VALUES(@IdFile, @FileData)", new SqlParameter[]
                                {
                                new SqlParameter("IdFile", IdFile),
                                new SqlParameter("FileData", SqlDbType.VarBinary){ Value = Convert.FromBase64String( dto.FileData) },
                                }
                                , myConn);

                            dto.Id = IdFile;
                            dto.CreatedDate = DateTime.Now;
                            dto.FileMode = (int)EFileMode.View;
                            dto.FileData = null;
                        }
                    }
                    await Task.CompletedTask;
                    return new MsgResult<ObservableCollection<DFileDto>>(true, ListFile);
                }
            }
            catch (Exception ex)
            {
                return new MsgResult<ObservableCollection<DFileDto>>("SaveFile", ex);
            }
        }



        [HttpPost]
        public async Task<MsgResult<int>> DeleteFile([FromBody] long Id)
        {
            try
            {
                int ketQua = await MyApp.Dao.ExecSQLAsync("DELETE FROM DFileData WHERE IdFile = @Id; DELETE FROM DFile WHERE Id = @Id", new SqlParameter[] { new SqlParameter("Id", Id) });
                return new MsgResult<int>(true, ketQua);
            }
            catch (Exception ex)
            {
                return new MsgResult<int>("DeleteFile", ex);
            }
        }


        [HttpPost]
        public async Task<MsgResult<string>> ViewFile([FromBody] long Id)
        {
            try
            {
                using (DataTable dt = await MyApp.Dao.GetTableAsync("SELECT * FROM DFileData WHERE IdFile = @Id", new SqlParameter[] { new SqlParameter("Id", Id) }))
                {
                    if (dt.Rows.Count == 0)
                    {
                        return new MsgResult<string>(false, string.Empty);
                    }

                    return new MsgResult<string>(true, Convert.ToBase64String((byte[])dt.Rows[0]["FileData"]));
                }
            }
            catch (Exception ex)
            {
                return new MsgResult<string>("ViewFile", ex);
            }
        }
    }
}