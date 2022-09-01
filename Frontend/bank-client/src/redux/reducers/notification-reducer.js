import { createSlice } from '@reduxjs/toolkit'

const notificationInitialState = {
	isOpened: false,
	isSimple: false,
	type: 'info',
	message: 'default message'

}

export const notificationSlice = createSlice({
	name: 'notification',
	initialState: notificationInitialState,
	reducers: {
		openNotification: (state, action) => {
			const payload = action.payload
			state.isOpened = true
			state.type = payload.type || state.type
			state.isSimple = payload.isSimple || false
			state.message = payload.message
		},
		closeNotification: (state) => {
			state.isOpened = false
		},
	}
})

export const { openNotification, closeNotification } = notificationSlice.actions
export default notificationSlice.reducer