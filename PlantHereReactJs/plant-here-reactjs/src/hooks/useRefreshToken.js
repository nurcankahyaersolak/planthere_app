// local Storage
import { setToken, getRefreshToken } from '../services/localStorageService';


import env from "../enviroment";

import axios from "axios";

const useRefreshToken = () => {

    const refresh = async () => {
        
        const response = await axios.request({
            method: 'POST',
            url: `${env.DOTNET_AUTHSERVER_API_URL}/Auth/CreateTokenByRefreshToken`,
            data: {
                refreshToken:getRefreshToken()
            }
        });

        setToken(response?.data?.data)
        const { accessToken } = response?.data?.data
        return accessToken
    }
    
    return refresh
}

export default useRefreshToken;