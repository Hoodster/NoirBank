/* eslint-disable indent */
import { createSlice } from '@reduxjs/toolkit'

export const modalSlice = createSlice({
    name: 'modal',
    initialState: {
        isOpened: false,
        type: '',
        modalData: {}
    },
    reducers: {
        open: (state, action) => {
            state.isOpened = true
            state.type = action.payload.type
            state.modalData = action.payload.data
        },
        close: (state) => {
            state.isOpened = false
            state.type = ''
            state.modalData = {}
        },
        setModalData: (state, action) => {
            state.modalData = action.payload
        }
    }
})

export const { open, close, setModalData } = modalSlice.actions
export default modalSlice.reducer