using System.Text.Json;
using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace MyFunction {

    public class EchoMessage {
        public string message { get; set; } = "";
        public DateTime date  { get; set; }
    }

    public class Function
    {

        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public APIGatewayProxyResponse FunctionHandler(APIGatewayProxyRequest request, ILambdaContext context)
        {

            var input = JsonSerializer.Deserialize<EchoMessage>(request.Body);
            var output = new EchoMessage {
                message = input?.message?.ToUpper() ?? "",
                date = input?.date ?? DateTime.Now
            };
            return new APIGatewayProxyResponse {
                StatusCode = 200,
                Body = JsonSerializer.Serialize(output),
                Headers = new Dictionary<string, string> {
                    { "Content-Type", "application/json" },
                    { "Access-Control-Allow-Origin", "*" }
                }
            };
        }
    }
}
