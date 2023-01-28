# Pull the Base image for the ASP.NET COre App to run on it
FROM mcr.microsoft.com/dotnet/sdk:6.0 as builder
# Set the Work Directory inside the image where application files will be copied 
WORKDIR /src
# COPY the Project file to the Image
COPY ./ProductService.csproj .
# Restore all the references used in the Project file
RUN dotnet restore "ProductService.csproj"
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