import { createSlice } from '@reduxjs/toolkit'

export const registerSlice = createSlice({
	name: 'register',
	initialState: {
		currentSlide: 1,
		numberOfSlides: 5,
	},
	reducers: {
		nextSlide: (state) => {
			state.currentSlide++        
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