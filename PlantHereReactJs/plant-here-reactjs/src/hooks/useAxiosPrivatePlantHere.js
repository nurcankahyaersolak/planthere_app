// React 
import { useEffect } from 'react';
import { useNavigate } from 'react-router-dom';

// Base Instance
import { axiosPrivateDotNet, axiosPrivateNodeJs } from '../api/axios'

// Token
import { getAccessToken } from '../services/localStorageService'
import useRefreshToken from './useRefreshToken';

// Navigate For Refresh Token
import useNavigateUser from './useNavigateUser';

// Notification
import { NOTIFICATION_STATUS } from '../models/enum/notificationStatus';

// Axios Instace NodeJS
export const useAxiosPrivateNodejs = (notificationRef = null) => {
    const refresh = useRefreshToken();
    const navigate = useNavigate();

    useEffect(() => {
        const requestIntercept = axiosPrivateNodeJs.interceptors.request.use(
            config => {
                if (!config.headers['Authorization']) {
                    config.headers['Authorization'] = `Bearer ${getAccessToken()}`;
                }
                return config
            }, (error) => {
                return Promise.reject(error)
            }
        );

        const responseIntercept = axiosPrivateNodeJs.interceptors.response.use(
            response => {
                if (response) {
                    successHandler(notificationRef, '.NodeJs')
                }
                return response
            },
            async (error) => {

                const prevRequest = error?.config;

                if (error?.response?.status === 401 && !prevRequest?.sent) {
                    prevRequest.sent = true;
                    const newAccessToken = await refresh();
                    prevRequest.headers['Authorization'] = `Bearer ${newAccessToken}`;
                    return axiosPrivateNodeJs(prevRequest);
                }
                else {
                    errorHandler(notificationRef, error, navigate)
                }

                return Promise.reject()
            }
        )

        return () => {
            axiosPrivateDotNet.interceptors.request.eject(requestIntercept)
            axiosPrivateDotNet.interceptors.response.eject(responseIntercept)
        }
    }, [refresh, notificationRef,navigate])

    return axiosPrivateNodeJs
}

// Axios Instance DotNet Plant Here
export const useAxiosPrivateDotNet = (notificationRef = null) => {
    const navigate = useNavigateUser()
    const refresh = useRefreshToken();

    useEffect(() => {
        const requestIntercept = axiosPrivateDotNet.interceptors.request.use(
            config => {
                if (!config.headers['Authorization']) {
                    config.headers['Authorization'] = `Bearer ${getAccessToken()}`;
                }
                return config
            }, (error) => {
                return Promise.reject(error)
            }
        );

        const responseIntercept = axiosPrivateDotNet.interceptors.response.use(
            response => {
                if (response) {
                    successHandler(notificationRef, '.NET')
                }
                return response
            },
            async (error) => {

                const prevRequest = error?.config;

                if (error?.response?.status === 401 && !prevRequest?.sent) {
                    prevRequest.sent = true;
                    const newAccessToken = await refresh();
                    prevRequest.headers['Authorization'] = `Bearer ${newAccessToken}`;
                    return axiosPrivateDotNet(prevRequest);
                }
                else {
                    errorHandler(notificationRef, error, navigate)
                }

                return Promise.reject()
            }
        )

        return () => {
            axiosPrivateDotNet.interceptors.request.eject(requestIntercept)
            axiosPrivateDotNet.interceptors.response.eject(responseIntercept)
        }
    }, [refresh, notificationRef,navigate])

    return axiosPrivateDotNet
}

// Return Selected Axios Instance
export const GetSelectedAxios = (isSelectedDotnetApi = true) => {
    if (isSelectedDotnetApi) {
        return useAxiosPrivateDotNet;
    }
    else {
        return useAxiosPrivateNodejs;
    }
}

// Error Handler
const errorHandler = (notificationRef, error, navigate) => {
    if (notificationRef?.current) {
        if (error?.response?.data?.Error?.Errors[0] === 'Refresh token not found') {
            authenticationHandler(notificationRef)
            navigate()
        }
        else if (error?.response?.data?.errors) {
            notificationRef.current.handleClick({ message: error.response?.data?.errors[0]?.message, status: NOTIFICATION_STATUS.WARNING })
        }
        else if (error?.message) {
            notificationRef.current.handleClick({ message: error.message, status: NOTIFICATION_STATUS.ERROR })
        }
    }
}

const successHandler = (notificationRef, api) => {
    if (notificationRef?.current) {
        notificationRef.current.handleClick({ message: `Successful (${api})`, status: NOTIFICATION_STATUS.SUCCESS })
    }
}

const authenticationHandler = (notificationRef) => {
    if (notificationRef?.current) {
        notificationRef.current.handleClick({ message: `Token has expired. You are redirected to login`, status: NOTIFICATION_STATUS.INFO })
    }
}
