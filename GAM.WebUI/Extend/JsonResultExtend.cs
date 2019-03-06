using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GAM.WebUI.Extend
{
    public static class JsonResultExtend
    {
        public static OperateResult JsonObject(this Controller controller, bool success, string message, object other)
        {
            return new OperateResult(success, message, other);
        }
    }

    public class OperateResult : JsonResult
    {
        public bool Success { get; set; }

        public string Message { get; set; }

        public object Other { get; set; }

        public override void ExecuteResult(ActionContext context)
        {
            //base.ExecuteResult(context);
            if (context==null)
                throw new ArgumentNullException("context");

            var response = context.HttpContext.Response;
            response.ContentType = "application/json";

            this.Value = new { code = Success, massage = Message, other = Other };

            var result = JsonConvert.SerializeObject(Value);


        }
    }
}
