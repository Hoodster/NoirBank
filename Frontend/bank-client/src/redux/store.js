import {configureStore} from '@reduxjs/toolkit'
import registerReducer from './reducers/register-reducer'


export const store = configureStore({
	reducer: {
		register: registerReducer
	}
})