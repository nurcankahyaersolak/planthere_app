import { SET_AUTH, SET_USER } from '../constants/userConstant';

const initialState = {
    user: null,
    auth: false,
}

const userReducer = (state = initialState, action) => {
    switch (action.type) {
        case SET_USER: {
            return {
                ...state,
                user: action.payload
            }
        }
        case SET_AUTH :{
            return {
                ...state,
                auth:action.payload
            }
        }
        default:
            return state;
    };
}

export default userReducer;