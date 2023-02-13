// Axios
import axios from "axios";

//Env
import env from "../enviroment"

export default axios.create({
})

export const axiosPrivateDotNet = axios.create({
    baseURL: env.DOTNET_PLANTHERE_API_URL,
    headers: { 'Content-Type': "application/json" }
})

export const axiosPrivateAuthServer = axios.create({
    baseURL: env.DOTNET_AUTHSERVER_API_URL,
    headers: { 'Content-Type': "application/json" }
})

export const axiosPrivateNodeJs = axios.create({
    baseURL: env.NODEJS_PLANTHERE_API_URL,
    headers: { 'Content-Type': "application/json" }
})


