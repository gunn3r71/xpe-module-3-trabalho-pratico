using Amazon.EC2;
using Amazon.EC2.Model;
using Amazon.Lambda.Core;
using EC2Management.Common;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace ChangeInstanceType.Lambda;

public class Function
{

    /// <summary>
    /// A simple function that takes a string and does a ToUpper
    /// </summary>
    /// <param name="input"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public async Task FunctionHandler(string instanceType, ILambdaContext context)
    {
        context.Logger.LogInformation("[Change Instance Type] - Iniciando lambda para alterar tipo de instâncias EC2 compatíveis");

        try
        {
            using var ec2Client = new AmazonEC2Client();
            IEC2DescribeInstancesService ec2DescribeInstancesService = new EC2DescribeInstancesService(ec2Client);

            var instanceIds = await ec2DescribeInstancesService.GetInstanceIdsAsync();

            if (!instanceIds.Any())
            {
                context.Logger.LogInformation("[Change Instance Type] - Não foram encontradas instâncias EC2 compatíveis");
                return;
            }

            List<Task> tasks = new(instanceIds.Count());

            foreach (var instanceId in instanceIds) 
            {
                var modifyInstanceTypeRequest = new ModifyInstanceAttributeRequest()
                {
                    InstanceId = instanceId,
                    InstanceType = instanceType
                };

                tasks.Add(ec2Client.ModifyInstanceAttributeAsync(modifyInstanceTypeRequest));
            }

            await Task.WhenAll(tasks);

            context.Logger.LogInformation("[Change Instance Type] - Finalizando execução da lambda");
        }
        catch (Exception)
        {
            context.Logger.LogError("[Change Instance Type] - Lambda executou com falha");
        }
    }
}
