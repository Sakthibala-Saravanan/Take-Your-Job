using System.Net.Http;
using AspireSystems.Api.Base.Responses.Contracts;

namespace AspireSystems.Api.Base.Responses
{
    public class AspireSystemsApiMessage<TResponse> : HttpResponseMessage, IAspireSystemsApiMessage<TResponse>
    {
    }
}
