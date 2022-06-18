import { createSlice } from '@reduxjs/toolkit'

export const registerSlice = createSlice({
    name: 'register',
    initialState: {
        currentSlide: 1,
        numberOfSlides: 4,
    },
    reducers: {
        nextSlide: (state) => {
            state.currentSlide++        
        },
        prevSlide: (state) => {
            state.currentSlide--
        },
        reset: (state) => {
            state = this.initialState
        }
    }
})

export const { nextSlide, prevSlide, reset } = registerSlice.actions
export default registerSlice.reducer