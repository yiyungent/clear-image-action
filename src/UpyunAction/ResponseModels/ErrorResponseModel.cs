using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpyunAction.ResponseModels
{
    public class ErrorResponseModel
    {
        public string type { get; set; }

        /// <summary>
        /// 错误代码 error_code 由两部分组成。 第1位为错误级别，1表示系统级别错误，2表示模块级别错误, 第2、3位表示模块代码，后两位表示具体的错误代码
        /// </summary>
        public string error_code { get; set; }
        public string request { get; set; }
        public string field { get; set; }
        public string message { get; set; }
    }
}
