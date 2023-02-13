import { combineReducers } from 'redux'
import userReducer from './userReducer'
import basketReducer from './basketReducer'
import apiReducer from './selectedApiReducer'

const rootReducer =  combineReducers({
    user : userReducer,
    basket : basketReducer,
    api : apiReducer
})

export default rootReducer


