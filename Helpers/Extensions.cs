using Microsoft.AspNetCore.Http;

namespace customserver.Helpers
{
    public static class Extensions
    {
        //override response
        public static void  AddApplicationError(this HttpResponse response, string message)
        {
            response.Headers.Add("Application-Error", message);
            response.Headers.Add("Access-Control-Expose-Headers","Appication-Error");
            response.Headers.Add("Access-Control-Allow-Origin","*");
        }
    }
}