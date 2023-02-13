// React 
import { useEffect } from 'react';

// Base Instance
import { axiosPrivateAuthServer } from '../api/axios'

// Token
import { getAccessToken } from '../services/localStorageService'

//Notification
import { NOTIFICATION_STATUS } from '../models/enum/notificationStatus';


export const useAxiosPrivateAuthServerWithNotification = (notificationRef) => {
    useEffect(() => {
        const requestIntercept = axiosPrivateAuthServer.interceptors.request.use(
            config => {
                return config
            }, (error) => {
                return Promise.reject(error)
            }
        );
        const responseIntercept = axiosPrivateAuthServer.interceptors.response.use(
            response => {
                notificationRef.current.handleClick({ message: "Authentication Process Successful ", status: NOTIFICATION_STATUS.SUCCESS })
                return response.data.data
            },
            async (error) => {
                if (error?.response?.data?.Error) {
                    notificationRef.current.handleClick({ message: error.response?.data?.Error?.Errors[0], status: NOTIFICATION_STATUS.WARNING })
                }
                else {
                    notificationRef.current.handleClick({ message: error.message, status: NOTIFICATION_STATUS.ERROR })
                }
                return Promise.reject(error)
            }
        )

        return () => {
            axiosPrivateAuthServer.interceptors.request.eject(requestIntercept)
            axiosPrivateAuthServer.interceptors.response.eject(responseIntercept)
        }
    })

    return axiosPrivateAuthServer
}

export const useAxiosPrivateAuthServer = () => {
    axiosPrivateAuthServer.interceptors.request.use(
        config => {
            if (!config.headers['Authorization']) {
                config.headers['Authorization'] = `Bearer ${getAccessToken()}`;
            }
            return config
        }, (error) => {
            return Promise.reject(error)
        }
    );

    axiosPrivateAuthServer.interceptors.response.use(
        response => {
            return response
        },
        async (error) => {
            return Promise.reject(error)
        }
    )

    return axiosPrivateAuthServer
}

