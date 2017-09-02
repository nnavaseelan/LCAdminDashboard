
namespace CASecurity.Common
{
    public static class Enums
    {
        public enum APIResponseStatus
        {
            Success,
            Falied,
            NotFound,
            BadRequest,
            NoMatchingData,
            MandataryFieldsAreMissing,
            ServerError
        }
        public enum CallFrom
        {
            Bank,
            Client,
            SDK,
            None
        }
    }
}