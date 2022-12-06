package org.carlosgps.classes;

import org.apache.activemq.ActiveMQConnectionFactory;

import javax.jms.*;
import java.beans.ExceptionListener;

public class InstructionsConsumer implements Runnable, ExceptionListener {

        private String instructions = null;

        public void run() {
            try {

                // Create a ConnectionFactory
                ActiveMQConnectionFactory connectionFactory = new ActiveMQConnectionFactory("tcp://localhost:61616");

                // Create a Connection
                Connection connection = connectionFactory.createConnection();
                connection.start();

                connection.setExceptionListener(this::exceptionThrown);

                // Create a Session
                Session session = connection.createSession(false, Session.AUTO_ACKNOWLEDGE);

                // Create the destination (Topic or Queue)
                Destination destination = session.createQueue("instructions");

                // Create a MessageConsumer from the Session to the Topic or Queue
                MessageConsumer consumer = session.createConsumer(destination);

                // Wait for a message
                Message message = consumer.receive(1000);

                if (message instanceof TextMessage) {
                    TextMessage textMessage = (TextMessage) message;
                    instructions = textMessage.getText();

                } else {
                    instructions = message.toString();
                }

                consumer.close();
                session.close();
                connection.close();
            } catch (Exception e) {
                System.out.println("Caught: " + e);
                e.printStackTrace();
            }
        }

    public String getInstructions() {
        return instructions;
    }

    @Override
    public void exceptionThrown(Exception e) {
        System.out.println("JMS Exception occured.  Shutting down client.");
    }
}

