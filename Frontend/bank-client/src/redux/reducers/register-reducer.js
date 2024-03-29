import { createSlice } from '@reduxjs/toolkit'

const registerInitialState = {
	currentSlide: 0,
	form: {
		firstName: '',
		lastName: '',
		email: '',
		password: '',
		documentID: '',
		personalID: '',
		address: {
			street: '',
			building: '',
			apartment: '',
			postalCode: '',
			city: '',
			country: '',
		}
	}
}

export const registerSlice = createSlice({
	name: 'registration',
	initialState: registerInitialState,
	reducers: {
		nextSlide: (state) => {
			state.currentSlide++
		},
		previousSlide: (state) => {
			state.currentSlide--
		},
		setFormValue: (state, action) => {
			state.form = {
				...state.form,
				...action.payload
			}
		},
		setFormAddressValue: (state, action) => {
			state.form = {
				...state.form,
				address: {
					...state.form.address,
					...action.payload
				}
			}
		},
		reset: (state) => {
			// eslint-disable-next-line no-unused-vars
			state.currentSlide = registerInitialState.currentSlide
			state.form = registerInitialState.form
		}
	}
})

export const { nextSlide, previousSlide, reset, setFormValue, setFormAddressValue } = registerSlice.actions
export default registerSlice.reducer