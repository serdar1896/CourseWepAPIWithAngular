using Newtonsoft.Json;
using System.Collections.Generic;

namespace GulaylarCase.Data.ViewModel
{
    public class ServiceResponse<T>
    {
        public ServiceResponse()
        {
            List = new List<T>();
        }
        public bool HasExceptionError { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ExceptionMessage { get; set; }

        public List<T> List { get; set; }

        [JsonProperty]
        public T Entity { get; set; }

        public int Count { get; set; }

        public bool IsValid => !HasExceptionError && string.IsNullOrEmpty(ExceptionMessage);

        public bool IsSuccessful { get; set; }
    }
}
