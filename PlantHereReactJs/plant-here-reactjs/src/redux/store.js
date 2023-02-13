//Reduxt
import storage from 'redux-persist/lib/storage';
import thunk from "redux-thunk";
import { persistStore, persistReducer } from 'redux-persist';
import { configureStore } from '@reduxjs/toolkit'

//Reducer
import  rootReducer  from './reducers/rootReducer'; 

const persistConfig  = {    
   storage,     
   key: "root"
};

const persistedReducer = persistReducer(persistConfig, rootReducer);

export const store = configureStore({reducer: persistedReducer,  middleware: [thunk]});

export const persistor = persistStore(store);  
