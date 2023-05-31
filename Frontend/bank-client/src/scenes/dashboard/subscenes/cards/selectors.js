import { useSelector } from 'react-redux'

export const getCards = () => useSelector((state) => state.user.cards)
export const getAccounts = () => useSelector((state) => state.user.accounts)