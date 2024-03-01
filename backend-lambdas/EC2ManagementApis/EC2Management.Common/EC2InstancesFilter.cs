using Amazon.EC2.Model;

namespace EC2Management.Common
{
    public class EC2InstancesFilter
    {
        public static Filter EligibleForHandler = new Filter()
        {
            Name = "tag:EligibleForHandler",
            Values = { "true" }
        };

        public static Filter StoppedInstance = new Filter()
        {
            Name = "instance-state-name",
            Values = { "stopped" }
        };

        public static Filter RunningInstance = new Filter()
        {
            Name = "instance-state-name",
            Values = { "running" }
        };
    }
}
