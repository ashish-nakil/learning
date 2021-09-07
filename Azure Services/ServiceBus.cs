using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;

namespace Azure_Services
{
    public static class ServiceBus
    {
        private static string queueConnectionString = "Endpoint=sb://ashishn.servicebus.windows.net/;SharedAccessKeyName=t1policy;SharedAccessKey=lLOKStomF7Hv6N+ThWSl/VWirUpiXdfEGO2/ui3OBpU=";
        private static string queueName = "q1";
        private static string topic1 = "t1";

        public static void Call()
        {
            IQueueClient queueClient = new QueueClient(queueConnectionString, queueName);
            ITopicClient topicClient = new TopicClient(queueConnectionString, topic1);
            topicClient.SendAsync(new Message(Encoding.UTF8.GetBytes("Hello Azure Galaxy")));
            queueName = "q1";
        }

        public static async Task SendQueueMessage()
        {
            IQueueClient queueClient = new QueueClient(queueConnectionString, queueName);
            await queueClient.SendAsync(new Message(Encoding.UTF8.GetBytes("Hello Azure Galaxy")));
        }

        public static void CallQueue()
        {
            IQueueClient queueClient = new QueueClient(queueConnectionString, queueName);
            queueClient.SendAsync(new Message(Encoding.UTF8.GetBytes("Hello Azure Galaxy1")));
        }
    }
}