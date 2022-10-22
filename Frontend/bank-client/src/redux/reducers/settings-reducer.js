/* eslint-disable indent */
import { createSlice } from '@reduxjs/toolkit'

export const settingsSlice = createSlice({
    name: 'settings',
    initialState: {
        theme: localStorage.getItem('theme') || 'system'
    },
    reducers: {
        setApplicationTheme: (state, action) => {
            localStorage.setItem('theme', action.payload)
            state.theme = action.payload
        },
    }
})

export const { setApplicationTheme } = settingsSlice.actions
export default settingsSlice.reducer