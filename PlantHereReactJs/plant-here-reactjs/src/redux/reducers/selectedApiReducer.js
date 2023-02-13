import {SET_NODEJS,SET_DOTNET} from '../constants/selectedApiConstant'

const initialState ={
    isSelectedDotnetApi : true
}

const apiReducer = (state = initialState,action) =>{
    switch (action.type) {
        case SET_DOTNET: {
            return {
                ...state,
                isSelectedDotnetApi: action.payload
            }
        }
        case SET_NODEJS :{
            return {
                ...state,
                isSelectedDotnetApi:action.payload
            }
        }
        default:
            return state;
    };
}

export default apiReducer;