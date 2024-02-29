using Amazon.EC2;
using Amazon.EC2.Model;
using Amazon.Lambda.Core;
using EC2Management.Common;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace StartInstance.Lambda;

public class Function
{
    
    /// <summary>
    /// A simple function that takes a string and does a ToUpper
    /// </summary>
    /// <param name="input"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public async Task FunctionHandler(ILambdaContext context)
    {
        context.Logger.LogInformation("[Start Instance] - Iniciando lambda para ativar instâncias EC2 compatíveis");

        try
        {
            using var ec2Client = new AmazonEC2Client();
            IEC2DescribeInstancesService ec2DescribeInstancesService = new EC2DescribeInstancesService(ec2Client);

            var instanceIds = await ec2DescribeInstancesService.GetInstanceIdsAsync();

            if (!instanceIds.Any()) 
            {
                context.Logger.LogInformation("[Start Instance] - Não foram encontradas instâncias EC2 compatíveis");
                return;
            }

            var startInstancesRequest = new StartInstancesRequest()
            {
                InstanceIds = instanceIds.ToList()
            };

            await ec2Client.StartInstancesAsync(startInstancesRequest);

            context.Logger.LogInformation("[Start Instance] - Finalizando execução da lambda");
        }
        catch (Exception)
        {
            context.Logger.LogError("[Start Instance] - Lambda executou com falha");
        }
    }
}
