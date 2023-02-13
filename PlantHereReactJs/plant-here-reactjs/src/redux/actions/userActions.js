import { SET_AUTH, SET_USER } from '../../redux/constants/userConstant';
import { useAxiosPrivateAuthServer } from '../../hooks/useAxiosPrivateAuthServer';

export const SetUserStore = () => {

    const axiosPrivateAuthServer = useAxiosPrivateAuthServer()
    
    return async dispatch => {
        const data = await axiosPrivateAuthServer.get('/User')
        dispatch({
            type: SET_USER,
            payload: data
        });
    }
};

export const SetAuthStore = (value) => {
    return ({ type: SET_AUTH, payload: value })
}
