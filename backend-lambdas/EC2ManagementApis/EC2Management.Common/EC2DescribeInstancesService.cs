using Amazon.EC2;
using Amazon.EC2.Model;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace EC2Management.Common
{
    public class EC2DescribeInstancesService : IEC2DescribeInstancesService
    {
        private readonly AmazonEC2Client _client;

        public EC2DescribeInstancesService(AmazonEC2Client client)
        {
            _client = client;
        }

        public async Task<IEnumerable<string>> GetInstanceIdsAsync()
        {
            var getInstancesRequest = new DescribeInstancesRequest()
            {
                Filters =
                {
                    EC2InstancesFilter.EligibleForHandler
                }
            };

            DescribeInstancesResponse instances = await _client.DescribeInstancesAsync(getInstancesRequest);

            IEnumerable<string> instanceIds = instances.Reservations.SelectMany(x => x.Instances).Select(x => x.InstanceId);

            return instanceIds;
        }
    }
}
