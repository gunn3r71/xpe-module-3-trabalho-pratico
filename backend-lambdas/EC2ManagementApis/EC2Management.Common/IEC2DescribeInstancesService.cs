using Amazon.EC2.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EC2Management.Common
{
    public interface IEC2DescribeInstancesService
    {
        Task<IEnumerable<string>> GetInstanceIdsAsync(params Filter[] filters);
    }
}
