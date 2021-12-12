using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpyunAction.ResponseModels;

namespace UpyunAction
{
    public class UpyunApi
    {
        public string BaseApiUrl { get; set; } = "https://api.upyun.com";

        public string Token { get; set; }

        public async Task<TokenListItemResponseModel[]> TokenListAsync()
        {
            string apiUrl = $"{this.BaseApiUrl}/oauth/tokens";
            string[] headers = new string[] {
                "Content-Type: application/json", // 注意: 不加上这个会导致 400
                $"Authorization: Bearer {this.Token}",
            };
            string resJsonStr = string.Empty;
            try
            {
                resJsonStr = Utils.HttpUtil.HttpGet(url: apiUrl, headers: headers);
            }
            catch (Exception ex)
            {
                Utils.LogUtil.Exception(ex);

                return null;
            }

            if (resJsonStr.Contains("\"error_code\""))
            {
                ErrorResponseModel errorResponseModel = Utils.JsonUtil.JsonStr2Obj<ErrorResponseModel>(resJsonStr);
                Utils.LogUtil.Error(resJsonStr);

                return null;
            }
            TokenListItemResponseModel[] responseModel = Utils.JsonUtil.JsonStr2Obj<TokenListItemResponseModel[]>(resJsonStr);

            return await Task.FromResult(responseModel);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="name">string<= 20 token 备注名，长度 <=20 的字符串，不能和其他 token 重复</param>
        /// <param name="scope"></param>
        /// <param name="expiredAt">token 过期时间的秒级时间戳，当该参数不设置时，表示永不过期</param>
        /// <returns></returns>
        public async Task<CreateTokenResponseModel> CreateTokenAsync(string userName, string password, string name, string scope, long expiredAt = 0)
        {
            string apiUrl = $"{this.BaseApiUrl}/oauth/tokens";
            dynamic reqJsonObj = new
            {
                username = userName,
                password = password,
                // GUID（全局统一标识符）是指在一台机器上生成的数字，它保证对在同一时空中的所有机器都是唯一的。
                // GUID 的格式为“xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx”，其中每个 x 是 0-9 或 a-f 范围内的一个十六进制的数字。
                // 例如：337c7f2b-7a34-4f50-9141-bab9e6478cc8 即为有效的 GUID 值。
                code = System.Guid.NewGuid().ToString().Substring(0, 24), // 20-32位随机字符串，每次请求不能重复。只能包含数字、字母和中划线
                name = name,
                scope = scope,
            };
            if (expiredAt != 0)
            {
                reqJsonObj.expired_at = expiredAt;
            }
            string reqJsonStr = Utils.JsonUtil.Obj2JsonStr(reqJsonObj);
            string[] headers = new string[] {
                "Content-Type: application/json" // 注意: 不加上这个会导致 400
            };
            string resJsonStr = string.Empty;
            try
            {
                resJsonStr = Utils.HttpUtil.HttpPost(url: apiUrl, postDataStr: reqJsonStr, headers: headers);
            }
            catch (Exception ex)
            {
                Utils.LogUtil.Exception(ex);

                return null;
            }

            if (resJsonStr.Contains("\"error_code\""))
            {
                ErrorResponseModel errorResponseModel = Utils.JsonUtil.JsonStr2Obj<ErrorResponseModel>(resJsonStr);
                Utils.LogUtil.Error(resJsonStr);

                return null;
            }
            CreateTokenResponseModel responseModel = Utils.JsonUtil.JsonStr2Obj<CreateTokenResponseModel>(resJsonStr);

            return await Task.FromResult(responseModel);
        }

        public async Task<DeleteTokenResponseModel> DeleteTokenAsync(string name)
        {
            // TODO: 这里不知道 Default 是什么编码, 因此最好 name 全英文
            // 注意: 只需要对 name 编码即可 (即对 queryString 编码)，不要将 整个url编码
            name = System.Text.Encodings.Web.UrlEncoder.Default.Encode(name);
            string apiUrl = $"{this.BaseApiUrl}/oauth/tokens?name={name}";
            string[] headers = new string[] {
                "Content-Type: application/json", // 注意: 不加上这个会导致 400
                $"Authorization: Bearer {this.Token}",
            };
            string resJsonStr = string.Empty;
            try
            {
                resJsonStr = Utils.HttpUtil.HttpDelete(url: apiUrl, headers: headers);
            }
            catch (Exception ex)
            {
                Utils.LogUtil.Exception(ex);

                return null;
            }

            if (resJsonStr.Contains("\"error_code\""))
            {
                ErrorResponseModel errorResponseModel = Utils.JsonUtil.JsonStr2Obj<ErrorResponseModel>(resJsonStr);
                Utils.LogUtil.Error(resJsonStr);

                return null;
            }
            DeleteTokenResponseModel responseModel = Utils.JsonUtil.JsonStr2Obj<DeleteTokenResponseModel>(resJsonStr);

            return await Task.FromResult(responseModel);
        }

        public async Task<CacheBatchRefreshItemResponseModel[]> CacheBatchRefreshAsync(string urls)
        {
            string url = $"{BaseApiUrl}/buckets/purge/batch";
            string reqJsonStr = Utils.JsonUtil.Obj2JsonStr(new
            {
                noif = 1, // 强制刷新
                source_url = urls,
            });
            // Authorization: Bearer <Token>
            string[] headers = new string[] {
                $"Authorization: Bearer {this.Token}",
                "Content-Type: application/json" // 注意: 不加上这个会导致 400
            };
            string resJsonStr = string.Empty;
            try
            {
                resJsonStr = Utils.HttpUtil.HttpPost(url: url, postDataStr: reqJsonStr, headers: headers);
            }
            catch (Exception ex)
            {
                Utils.LogUtil.Exception(ex);

                return null;
            }

            if (resJsonStr.Contains("\"error_code\""))
            {
                ErrorResponseModel errorResponseModel = Utils.JsonUtil.JsonStr2Obj<ErrorResponseModel>(resJsonStr);
                Utils.LogUtil.Error(resJsonStr);

                return null;
            }
            CacheBatchRefreshItemResponseModel[] responseModel = Utils.JsonUtil.JsonStr2Obj<CacheBatchRefreshItemResponseModel[]>(resJsonStr);

            return await Task.FromResult(responseModel);
        }

        /// <summary>
        /// 缓存批量刷新
        /// </summary>
        public async Task<CacheBatchRefreshItemResponseModel[]> CacheBatchRefreshAsync(string[] urls)
        {
            string urlsStr = string.Join(@"\n", urls); // 多条使用换行符(\n)分割开

            return await CacheBatchRefreshAsync(urls);
        }






    }
}
