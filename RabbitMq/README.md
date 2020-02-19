# Requirements
1. Have docker installed

### How do I get it working?
`docker-compose up -d` in this directory (with the compose file and config and definitions files)

### How do I get it to stop?
`docker-compose down` in this directory (with the compose file)

### How do I know if it's running?
 go to http://localhost:15672/#/ and you should see three nodes

 login credentials
    username: guest
    password: guest

 OR

 `docker ps -a` and see if you have any rabbitmq containers running.