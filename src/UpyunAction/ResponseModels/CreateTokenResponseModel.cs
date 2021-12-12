using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpyunAction.ResponseModels
{
    public class CreateTokenResponseModel
    {
        public string name { get; set; }
        public string access_token { get; set; }
        public string scope { get; set; }
        public string[] services { get; set; }
        public long created_at { get; set; }
        public long expired_at { get; set; }
    }
}
