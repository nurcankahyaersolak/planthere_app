import {SET_NODEJS,SET_DOTNET} from '../constants/selectedApiConstant'

export const SetDotnet = () => {
    return ({ type: SET_DOTNET, payload: true })
}

export const SetNodejs = () => {
    return ({ type: SET_NODEJS, payload: false })
}

export const SetSelectedApi = (value) =>{
    if(value){
        return SetDotnet()
    }
    else{
        return SetNodejs()
    }
} 