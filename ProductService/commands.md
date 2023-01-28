# Login on Docker
    docker login
        - THis will  ask for UserName and PAssword
# To pull Image from Docker
    docker pull [IMAGE-NAME]:[TAG]
    - e.g.
        - docker pull mcr.microsoft.com/dotnet/aspnet:7.0    
# To List All Images
    - docker images
# To delete image
    - docker rmi [IMAGE-ID]:[TAG] OR [IMAGE-NAME]:[TAG]
# To list all containers (Used aka running as well as stopped)
    - docker ps
# To list all containers those are running
    - docker ps -a

# Creating DOcker Image for the application
- Create a Dockerfile

```` html
# Pull the Base image for the ASP.NET COre App to run on it
FROM mcr.microsoft.com/dotnet/sdk:6.0 as builder
# Set the Work Directory inside the image where application files will be copied 
WORKDIR /src
# COPY the Project file to the Image
COPY ./ProductService.csproj .
# Restore all the references used in the Project file
RUN dotnet restore ProductService.csproj
# Copy all the executable references from the Application to the Image
COPY . .
# Inform the Image that the Base Runtime is read from the imported image
RUN dotnet build ProductService.csproj -c debug -o /src/out
# Point to Work Directrory from where the application will be accessible
FROM mcr.microsoft.com/dotnet/aspnet:6.0
# COPY the Path from where the execution will takes place indise the image
WORKDIR /app
COPY --from=builder /src/out .
# EXPOSE the PORT for the Application
EXPOSE 80
# Set the Entrypoint to the Application
ENTRYPOINT [ "dotnet","ProductService.dll" ]
````

- MAke sure that the .dockerignore file is added, tis file will contain all those paths which are not suppoed to be copied on image 
- Command to Build the Docker Image
    - go to the path where the dockerfile exist
    - docker build . -t [IMAGE-NAME]:[TAG]
        - The image name MUST be in lower case

# Running the Image
- We need Container to run the image
- docker run -p [LOCAL-MACHINE-PORT]:[PORT-EXPOSED-BY-IMAGE] --name=[CONTAINER-NAME] [IMAGE-NAME]:[TAG]
- e.g.
   - docker run -p 9009:80 --name=prdcontainer productsservice:v1 
- STarting te already available container
    - docker start [CONTAINER-NAME]
- Stop the COntainer
    - docker stop [COTAINER-NAME]
- Deleting the COntainer
    - MAke sure that the Container is Stopped
    - docker rm [CONTAINER-NAME]

# Publishing the image 
    - THis can be done using Repositories e.g. Docker Hub, Azure COntainer Registry (ACR), and Elastic COntainer Register (AWS ECR)
    - Login on the REgister
        - docker login
    - Tag the Image to the registery name
        - docker tag [IMAGE-NAME]:[TAG] [REGISTRY-NAME]/[IMAGE-NAME]:[TAG]
        - e.g.
            - docker tag productsservice:v1 mast007/productsservice:v1
    - Push this new tagged image
        - docker push [REGISTRY-NAME]/[IMAGE-NAME]:[TAG]
    - To pull the image
        - docker pull [REGISTRY-NAME]/[IMAGE-NAME]:[TAG]

        - docker pull mast007/productsservice:v1

        -  docker run -p 9009:80 --name=prdcontainer mast007/productsservice:v1 

# Pulling the SQL Server Image
- docker pull mcr.microsoft.com/mssql/server:2019-latest

# Connecting to this image by runin  it in DOcker
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=P@ssw0rd_" -p 1450:1433 -d mcr.microsoft.com/mssql/server:2019-latest
    - Since the 1433 is reserved port for SQL Server, if the SQL Server is already available on the machine, then map to the 1433 port exposed from Image to local machine by using other port e.g. 1450

# Using DOcker-Compose Cluster
- Navigate to the path where docker-compose.yml is present
- run the following command
    - docker-compose up
        - Build all images either by executing Dockerfile or pulling them from repository
        - Allocate Memory and Processor
        - Map with the port as mentioned in docker-compose file
        - Manage Dependencies across images
        - Establish Networking across images if required (depends_on) 
        - Finally Exposes images by hosting them inside the respective containers
             e.g. if images name for service is 'img', then its container name will be 'service_img'
   - To release all resources use the following command
    - docker-compose down          













