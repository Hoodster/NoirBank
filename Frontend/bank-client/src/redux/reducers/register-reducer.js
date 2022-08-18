import { createSlice } from '@reduxjs/toolkit'

export const registerSlice = createSlice({
	name: 'register',
	initialState: {
		currentSlide: 0,
		data: {
			firstName: null,
			lastName: null,
			address: null,
			idNumber: null,
			idCardNumber: null,
		}
	},
	reducers: {
		nextSlide: (state, payload) => {
			state.currentSlide++,
			state.data = {
				...state.data,
				payload
			}     
		},
		prevSlide: (state) => {
			state.currentSlide--
		},
		reset: (state) => {
			// eslint-disable-next-line no-unused-vars
			state = this.initialState
		}
	}
})

export const { nextSlide, prevSlide, reset } = registerSlice.actions
export default registerSlice.reducer