using System;
using Apache.NMS;
using Apache.NMS.ActiveMQ;
using System.Collections.Generic;
using OSMElement;

namespace RoutingServer
{
    internal class ActiveMQ
    {
        public static void SendToQueue(List<Instruction> instructions)
        {
            // Create a Connection Factory.
            Uri connecturi = new Uri("activemq:tcp://localhost:61616");
            ConnectionFactory connectionFactory = new ConnectionFactory(connecturi);

            // Create a single Connection from the Connection Factory.
            IConnection connection = connectionFactory.CreateConnection();
            connection.Start();

            // Create a session from the Connection.
            ISession session = connection.CreateSession();

            // Use the session to target a queue.
            IDestination destination = session.GetQueue("instructions");

            // Clear queue
            session.DeleteDestination(destination);

            // Create a Producer targetting the selected queue.
            IMessageProducer producer = session.CreateProducer(destination);

            // You may configure everything to your needs, for instance:
            producer.DeliveryMode = MsgDeliveryMode.NonPersistent;

            // Finally, to send messages:
            ITextMessage message;
            foreach (Instruction instruction in instructions) {
                message = session.CreateTextMessage(instruction.text + " dans " + instruction.distance + "m");
                producer.Send(message);
            }

            // Don't forget to close your session and connection when finished.
            session.Close();
            connection.Close();
        }
    }
}
