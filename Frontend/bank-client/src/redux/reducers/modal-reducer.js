/* eslint-disable indent */
import { createSlice } from '@reduxjs/toolkit'

export const modalSlice = createSlice({
    name: 'modal',
    initialState: {
        isOpened: false,
        type: ''
    },
    reducers: {
        open: (state, payload) => {
            state.isOpened = true
            state.type = payload.payload
        },
        close: (state) => {
            state.isOpened = false
            state.type = ''
        }
    }
})

export const { open, close } = modalSlice.actions
export default modalSlice.reducer