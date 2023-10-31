import thunk from 'redux-thunk';

import { configureStore } from '@reduxjs/toolkit';
import { combineReducers } from 'redux';

import services from './slices/ServiceSlice';
import products from './slices/ProductSlice';
import news from './slices/NewsSlice';
import auth from './slices/AuthSlice';
import appointments from './slices/AppointmentsSlice';

const reducers = combineReducers({
    auth,  
    services,
    products,
    news, 
    appointments,
});

const store = configureStore({
  reducer: reducers,
  devTools: process.env.NODE_ENV !== 'production',
  middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware({
      serializableCheck: false,
    }).concat(thunk),
});

export default store;
