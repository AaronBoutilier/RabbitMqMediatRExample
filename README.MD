
# RabbitMq MediatR Example

The rabbitmq service is currently configured to have 3 nodes, 1 master and 2 replicas.
 Before running this solution, you will need to start the rabbitmq containers.
  
To run RabbitMq, run the command `docker-compose up` inside the rabbitmq folder.

Make sure to go to the solution properties and go to the 'Common Properties' > 'Startup Project' menu and select 'Multiple startup projects' and set the following projects to 'Start'
 - Example.Api
 - Example.EmailingService
 - Example.LoggingService
 - Example.RealTimeService

Now for those same projects, go into each of their settings and go the the 'debug' tab. In here you'll need to add some 'Application arguments'. Add `--network host` to the application arguments, this will make the containers that visual studio creates use the host network, this is because by default they are isolated to their own network.

Now that you have your environment all setup, you can click the 'Start' button in visual studio. By default the api should open automatically and do a get on the 'lead' route. this is just for the sake of this example. it is where we fire off a command that fires off a domain event. the domain event is then picked up the other running services. you should be able to check their logs via the visual studio 'Containers' window.