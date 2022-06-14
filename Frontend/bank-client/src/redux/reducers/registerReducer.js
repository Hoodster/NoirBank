import { createSlice } from '@reduxjs/toolkit'

export const registerSlice = createSlice({
    name: 'register',
    initialState: {
        toUpdate: false,
        currentSlide: 1,
        numberOfSlides: 2,
        userData: {}
    },
    reducers: {
        nextSlide: (state) => {
            state.currentSlide++
            state.toUpdate = true           
        },
        prevSlide: (state) => {
            state.currentSlide--
            state.toUpdate = true
        },
        update: (state, action) => {
            state.toUpdate = false
            action.payload.userData.forEach(chunk => {
                state.userData[chunk.name] = chunk.value
            })
        }
    }
})

export const { nextSlide, prevSlide, update } = registerSlice.actions
export default registerSlice.reducer