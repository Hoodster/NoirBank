import {configureStore} from '@reduxjs/toolkit'
import { combineReducers } from 'redux'
import registerReducer from './reducers/registerReducer'

const reducersRoot = combineReducers(registerReducer)

export const store = configureStore(reducersRoot)