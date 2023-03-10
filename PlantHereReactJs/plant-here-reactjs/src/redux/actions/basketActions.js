import { FETCH_BASKET } from '../../redux/constants/basketConstant';

export const FetchBasket = (axiosInstance) => {
    return async dispatch => {
        const response = await axiosInstance.get('/baskets')
        dispatch({
            type: FETCH_BASKET,
            payload: response?.data?.data
        });
    }
};
