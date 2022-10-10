import { configureStore } from '@reduxjs/toolkit'
import modalReducer from './reducers/modal-reducer'
import notificationReducer from './reducers/notification-reducer'
import registerReducer from './reducers/register-reducer'
import settingsReducer from './reducers/settings-reducer'
import userReducer from './reducers/user-reducer'


export const store = configureStore({
	reducer: {
		settings: settingsReducer,
		registration: registerReducer,
		modal: modalReducer,
		notification: notificationReducer,
		user: userReducer
	}
})