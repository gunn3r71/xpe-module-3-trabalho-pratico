using Amazon.EC2.Model;

namespace EC2Management.Common
{
    public class EC2InstancesFilter
    {
        public static Filter EligibleForHandler = new Filter()
        {
            Name = "tag:EligibleForHandler"
        };
    }
}
