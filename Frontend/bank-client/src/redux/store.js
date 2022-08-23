import { configureStore } from '@reduxjs/toolkit'
import modalReducer from './reducers/modal-reducer'
import registerReducer from './reducers/register-reducer'


export const store = configureStore({
	reducer: {
		registration: registerReducer,
		modal: modalReducer
	}
})