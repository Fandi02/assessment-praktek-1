using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Todos.Management.Application.Common.Models
{
    public class Result
    {
        public Result()
        {
            IsSuccess = true;
            StatusCode = (int)HttpStatusCode.OK;
            Message = HttpStatusCode.OK.ToString();
            InnerMessage = null;
            Path = null;
            Payload = null;
        }

        /// <summary>
        /// Flag to user response API success or not
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// HttpStatusCode and OtherStatusCode
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// Message api
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Inner message to user if error exception. Default value is null
        /// </summary>
        public string InnerMessage { get; set; }


        /// <summary>
        /// Error code of a response. Default null. Example value : #E01x001 (E Define as Error, 01 define as API, 001 ~ n what you defined)
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// Path
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Data payload response
        /// </summary>
        public object Payload { get; set; }
    }
}
