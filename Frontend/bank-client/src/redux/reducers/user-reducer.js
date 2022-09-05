import { createSlice } from '@reduxjs/toolkit'

const userInitialState = {
	cards: [],
	accounts: [],
	profile: undefined
}

export const userSlice = createSlice({
	name: 'user',
	initialState: userInitialState,
	reducers: {
		addProfile: (state, action) => {
			state.profile = action.payload
		},
		addCards: (state, action) => {
			state.cards = action.payload
		},
		addCard: (state, action) => {
			state.cards.push(action.payload)
		},
		addBankAccounts: (state, action) => {
			state.accounts = action.payload
		},
		addBankAccount: (state, action) => {
			state.accounts.push(action.payload)
		},
		reset: (state) => {
			state.cards = userInitialState.cards
			state.accounts = userInitialState.accounts
			state.profile = userInitialState.profile
		},
	}
})

export const { addProfile, addCards, addCard, addBankAccounts, addBankAccount, reset } = userSlice.actions
export default userSlice.reducer