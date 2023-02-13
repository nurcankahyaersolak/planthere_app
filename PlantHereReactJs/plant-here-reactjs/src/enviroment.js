const dev = {
    DOTNET_AUTHSERVER_API_URL : "http://localhost:5002",
    DOTNET_PLANTHERE_API_URL : "http://localhost:5000",
    NODEJS_PLANTHERE_API_URL : "http://localhost:4000"
}

const prod = {
    DOTNET_AUTHSERVER_API_URL : "http://autserver_api:5002",
    DOTNET_PLANTHERE_API_URL : "http://planthere_dotnet_api:5000",
    NODEJS_PLANTHERE_API_URL : "http://localhost:4000"
}

const enviroment = process.env.NODE_ENV === 'development' ? dev : prod

export default enviroment
