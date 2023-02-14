using Common.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Common.Class
{
    public class AppCommon
    {
        public string PathCombine(params string[] Paths)
        {
            if (Paths.Length <= 0) { return string.Empty; }
            string firstPath = Paths[0];

            string filePath = string.Empty;
            bool isFirstPath = true;
            foreach (string nextPath in Paths)
            {
                if (isFirstPath) { isFirstPath = false; continue; }
                filePath = Path.Combine(filePath, nextPath);
            }

            return firstPath.TrimEnd(new char[] { '\\' }) + @"\" + filePath.TrimStart(new char[] { '\\' });
        }

        public string GetExcelColumnName(int columnNumber)
        {
            string columnName = "";

            while (columnNumber > 0)
            {
                int modulo = (columnNumber - 1) % 26;
                columnName = Convert.ToChar('A' + modulo) + columnName;
                columnNumber = (columnNumber - modulo) / 26;
            }

            return columnName;
        }

        public string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }

        public string Encrypt(string clearText, string EnKey = "")
        {
            if (string.IsNullOrEmpty(EnKey)) { EnKey = MyApp.Setting.EncryptionKey; }
            byte[] clearBytes = Encoding.UTF8.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EnKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }
        public string Decrypt(string cipherText, string EnKey = "")
        {
            if (string.IsNullOrEmpty(EnKey)) { EnKey = MyApp.Setting.EncryptionKey; }
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EnKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.UTF8.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }


        public string GetWebApi(dynamic requestBody, params string[] MethodURL)
        {
            HttpWebRequest tRequest = null;
            string json = string.Empty;
            string sResponseFromServer = string.Empty;
            try
            {
                StringBuilder sbParam = new StringBuilder();

                if (requestBody != null)
                {
                    Dictionary<string, object> param = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(requestBody));
                    if (param.Count > 0)
                    {
                        sbParam.Append("?");
                        sbParam.Append(string.Join("&", param.Select(c => c.Key + "=" + c.Value)));
                    }
                }

                tRequest = (HttpWebRequest)WebRequest.Create(MyApp.Setting.APIUrl + string.Join("/", MethodURL) + sbParam.ToString());
                ServicePointManager.Expect100Continue = true;

                tRequest.Method = "GET";
                tRequest.AllowAutoRedirect = false;
                tRequest.Timeout = MyApp.Setting.TimeOut;
                using (WebResponse tResponse = tRequest.GetResponse())
                {
                    using (Stream dataStreamResponse = tResponse.GetResponseStream())
                    {
                        using (StreamReader tReader = new StreamReader(dataStreamResponse))
                        {
                            sResponseFromServer = tReader.ReadToEnd();
                            return sResponseFromServer;
                            //return JsonConvert.DeserializeObject<MsgResult>(sResponseFromServer);
                            //return JObject.Parse(sResponseFromServer);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MyApp.Log.GhiLog("GetWebApi", ex, tRequest.RequestUri.AbsoluteUri, json);
                throw ex;
            }
        }

        public async Task<T> GetWebApiAsync<T>(dynamic requestBody, params string[] MethodURL)
        {
            HttpWebRequest tRequest = null;
            string json = string.Empty;
            string sResponseFromServer = string.Empty;
            try
            {
                StringBuilder sbParam = new StringBuilder();

                if (requestBody != null)
                {
                    Dictionary<string, object> param = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(requestBody));
                    if (param.Count > 0)
                    {
                        sbParam.Append("?");
                        sbParam.Append(string.Join("&", param.Select(c => c.Key + "=" + c.Value)));
                    }
                }

                tRequest = (HttpWebRequest)WebRequest.Create(MyApp.Setting.APIUrl + string.Join("/", MethodURL) + sbParam.ToString());
                ServicePointManager.Expect100Continue = true;

                tRequest.Method = "GET";
                tRequest.AllowAutoRedirect = false;
                tRequest.Timeout = MyApp.Setting.TimeOut;

                if (AppViewModel.MyUser != null)
                {
                    tRequest.Headers.Add("UserName", AppViewModel.MyUser.UserName);
                    tRequest.Headers.Add("MaCQT", AppViewModel.MyUser.MaCQT);
                    tRequest.Headers.Add("UserType", AppViewModel.MyUser.UserType.ToString());
                }

                using (WebResponse tResponse = await tRequest.GetResponseAsync())
                {
                    using (Stream dataStreamResponse = tResponse.GetResponseStream())
                    {
                        using (StreamReader tReader = new StreamReader(dataStreamResponse))
                        {
                            sResponseFromServer = await tReader.ReadToEndAsync();
                            //return sResponseFromServer;
                            return JsonConvert.DeserializeObject<T>(sResponseFromServer);
                            //return JObject.Parse(sResponseFromServer);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MyApp.Log.GhiLog("GetWebApiAsync", ex, tRequest.RequestUri.AbsoluteUri, json);
                throw ex;
            }
        }

        public string PostWebApi(dynamic requestBody, params string[] MethodURL)
        {
            HttpWebRequest tRequest = null;
            string json = string.Empty;
            try
            {
                tRequest = (HttpWebRequest)WebRequest.Create(MyApp.Setting.APIUrl + string.Join("/", MethodURL));
                ServicePointManager.Expect100Continue = true;

                tRequest.AllowAutoRedirect = false;
                tRequest.Method = "post";
                tRequest.ContentType = "application/json";

                json = JsonConvert.SerializeObject(requestBody);
                byte[] byteArray = Encoding.UTF8.GetBytes(json);
                tRequest.ContentLength = byteArray.Length;
                tRequest.Timeout = MyApp.Setting.TimeOut;

                using (Stream dataStream = tRequest.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    using (WebResponse tResponse = tRequest.GetResponse())
                    {
                        using (Stream dataStreamResponse = tResponse.GetResponseStream())
                        {
                            using (StreamReader tReader = new StreamReader(dataStreamResponse))
                            {
                                string sResponseFromServer = tReader.ReadToEnd();
                                return sResponseFromServer;
                                //return JsonConvert.DeserializeObject<MsgResult>(sResponseFromServer);
                                //return JObject.Parse(sResponseFromServer);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MyApp.Log.GhiLog("PostWebApi", ex, tRequest.RequestUri.AbsoluteUri, json);
                throw ex;
            }
        }
        public async Task<T> PostWebApiAsync<T>(dynamic requestBody, params string[] MethodURL)
        {
            HttpWebRequest tRequest = null;
            string json = string.Empty;
            try
            {
                tRequest = (HttpWebRequest)WebRequest.Create(MyApp.Setting.APIUrl + string.Join("/", MethodURL));
                ServicePointManager.Expect100Continue = true;

                tRequest.AllowAutoRedirect = false;
                tRequest.Method = "post";
                tRequest.ContentType = "application/json";

                if (AppViewModel.MyUser != null)
                {
                    tRequest.Headers.Add("UserName", AppViewModel.MyUser.UserName);
                    tRequest.Headers.Add("MaCQT", AppViewModel.MyUser.MaCQT);
                    tRequest.Headers.Add("UserType", AppViewModel.MyUser.UserType.ToString());
                }

                json = JsonConvert.SerializeObject(requestBody);
                byte[] byteArray = Encoding.UTF8.GetBytes(json);
                tRequest.ContentLength = byteArray.Length;
                tRequest.Timeout = MyApp.Setting.TimeOut;

                using (Stream dataStream = tRequest.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    using (WebResponse tResponse = await tRequest.GetResponseAsync())
                    {
                        using (Stream dataStreamResponse = tResponse.GetResponseStream())
                        {
                            using (StreamReader tReader = new StreamReader(dataStreamResponse))
                            {
                                string sResponseFromServer = await tReader.ReadToEndAsync();
                                //return sResponseFromServer;
                                return JsonConvert.DeserializeObject<T>(sResponseFromServer);
                                //return JObject.Parse(sResponseFromServer);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MyApp.Log.GhiLog("PostWebApiAsync", ex, tRequest.RequestUri.AbsoluteUri, json);
                throw ex;
            }
        }

        public T GetObjectController<T, TOnline, TOffline>() where TOffline : T, new() where TOnline : T, new()
        {
            if (MyApp.Setting.IsOnline) { return new TOnline(); }
            else { return new TOffline(); }
        }

    }
}
