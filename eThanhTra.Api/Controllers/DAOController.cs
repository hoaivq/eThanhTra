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

        [HttpPost]
        public async Task<MsgResult<object>> SaveObject([FromBody] object Object)
        {
            string ObjectType = string.Empty;
            try
            {
                ObjectType = (Request == null) ? Object.GetType().Name : Request.GetHeader("ObjectType");
                using (eThanhTraEntities db = new eThanhTraEntities())
                {
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
                            output.TrangThai = 0;
                            db.DThanhTras.Add(output);
                        }
                        await db.SaveChangesAsync();
                        Object = output.Cast<DThanhTraDto>();
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
    }
}