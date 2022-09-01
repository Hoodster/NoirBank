import { useSelector } from 'react-redux'

export const getCards = () => useSelector((state) => state.user.cards)