Docker command to start RabbitMQ bus
docker run -d --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:management
