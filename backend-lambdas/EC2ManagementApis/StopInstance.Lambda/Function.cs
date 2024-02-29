using Amazon.EC2.Model;
using Amazon.EC2;
using Amazon.Lambda.Core;
using EC2Management.Common;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace StopInstance.Lambda;

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
        context.Logger.LogInformation("[Stop Instance] - Iniciando lambda para inativar inst�ncias EC2 compat�veis");

        try
        {
            using var ec2Client = new AmazonEC2Client();
            IEC2DescribeInstancesService ec2DescribeInstancesService = new EC2DescribeInstancesService(ec2Client);

            var instanceIds = await ec2DescribeInstancesService.GetInstanceIdsAsync();

            if (!instanceIds.Any())
            {
                context.Logger.LogInformation("[Stop Instance] - N�o foram encontradas inst�ncias EC2 compat�veis");
                return;
            }

            var stopInstancesRequest = new StopInstancesRequest()
            {
                InstanceIds = instanceIds.ToList()
            };

            await ec2Client.StopInstancesAsync(stopInstancesRequest);

            context.Logger.LogInformation("[Stop Instance] - Finalizando execu��o da lambda");
        }
        catch (Exception)
        {
            context.Logger.LogError("[Stop Instance] - Lambda executou com falha");
        }
    }
}
